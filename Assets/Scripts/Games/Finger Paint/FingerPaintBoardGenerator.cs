using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class FingerPaintBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] Image[] cardImagesInScene;
    [SerializeField] private GameObject tutorial;
    [SerializeField] GameObject[] imageParents;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    List<AssistiveCardsSDK.AssistiveCardsSDK.Card> prefetchedRandomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    List<Texture2D> randomImages = new List<Texture2D>();
    List<Texture2D> prefetchedRandomImages = new List<Texture2D>();
    List<Sprite> randomSprites = new List<Sprite>();
    public string selectedLangCode;
    [SerializeField] string correctCardSlug;
    [SerializeField] TMP_Text paintText;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    private FingerPaintUIController UIController;
    [SerializeField] GameObject loadingPanel;
    public int correctCardImageIndex;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = GameObject.Find("GamePanel").GetComponent<FingerPaintUIController>();
    }

    private void OnEnable()
    {
        if (isBackAfterSignOut)
        {
            gameAPI.PlayMusic();
            UIController.OnBackButtonClick();
            isBackAfterSignOut = false;
        }
    }

    public async Task CacheCards(string packName)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();
        cachedCards = await gameAPI.GetCards(selectedLangCode, packName);
    }


    public async Task GenerateRandomBoardAsync()
    {
        if (didLanguageChange)
        {
            await CacheCards(packSlug);
            didLanguageChange = false;
        }

        PopulateRandomCards();
        TranslateFindCardText();
        await PopulateRandomTextures();
        AssignTags();
        PlaceSprites();
        DisableLoadingPanel();
        ScaleImagesUp();
        UIController.TutorialSetActive();
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.30f);
        await PrefetchNextLevelsTexturesAsync();
    }

    public void ClearBoard()
    {
        paintText.text = "";
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].sprite = null;
            cardImagesInScene[i].GetComponent<PaintManager>().isFullyColorized = false;
        }

    }

    public void ScaleImagesUp()
    {
        LeanTween.scale(paintText.gameObject, Vector3.one, 0.30f);
        for (int i = 0; i < imageParents.Length; i++)
        {
            cardImagesInScene[i].GetComponent<PaintImage>().enabled = true;
            LeanTween.alpha(imageParents[i].transform.GetChild(0).GetComponent<RectTransform>(), 1f, .01f);
            imageParents[i].transform.GetChild(0).GetComponent<PaintImage>().ResetMask();
            LeanTween.scale(imageParents[i].gameObject, Vector3.one, 0.30f);
        }
    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(paintText.gameObject, Vector3.zero, 0.25f);
        for (int i = 0; i < imageParents.Length; i++)
        {
            LeanTween.scale(imageParents[i].gameObject, Vector3.zero, 0.25f);
        }
    }

    public void CheckIfCardExists(AssistiveCardsSDK.AssistiveCardsSDK.Card cardToAdd)
    {
        if (!randomCards.Contains(cardToAdd) && cardToAdd.slug != correctCardSlug)
        {
            randomCards.Add(cardToAdd);
        }
        else
        {
            cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
        }
    }

    public void CheckIfCardExistsPrefetch(AssistiveCardsSDK.AssistiveCardsSDK.Card prefetchedCardToAdd)
    {
        if (!prefetchedRandomCards.Contains(prefetchedCardToAdd) && prefetchedCardToAdd.slug != correctCardSlug)
        {
            prefetchedRandomCards.Add(prefetchedCardToAdd);
        }
        else
        {
            prefetchedCardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExistsPrefetch(prefetchedCardToAdd);
        }
    }

    public void ReadCard()
    {
        gameAPI.Speak(cardImagesInScene[correctCardImageIndex].sprite.name);
    }

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
    }

    public void PopulateRandomCards()
    {
        if (UIController.correctMatches == 0)
        {
            for (int i = 0; i < cardImagesInScene.Length; i++)
            {
                var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
                CheckIfCardExists(cardToAdd);
            }

            correctCardSlug = randomCards[0].slug;
        }
    }

    public void TranslateFindCardText()
    {
        paintText.text = gameAPI.Translate(paintText.gameObject.name, gameAPI.ToSentenceCase(UIController.correctMatches == 0 ? gameAPI.ToTitleCase(randomCards[0].title) : gameAPI.ToTitleCase(prefetchedRandomCards[0].title)).Replace("-", " "), selectedLangCode);
    }

    public async Task PopulateRandomTextures()
    {
        if (UIController.correctMatches == 0)
        {
            for (int i = 0; i < cardImagesInScene.Length; i++)
            {
                var texture = await gameAPI.GetCardImage(packSlug, randomCards[i].slug);
                texture.wrapMode = TextureWrapMode.Clamp;
                texture.filterMode = FilterMode.Bilinear;
                texture.name = randomCards[i].title;
                randomImages.Add(texture);
                randomSprites.Add(Sprite.Create(randomImages[i], new Rect(0.0f, 0.0f, randomImages[i].width, randomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
                randomSprites[i].name = randomImages[i].name;
            }
        }
    }

    public void AssignTags()
    {
        correctCardImageIndex = Random.Range(0, cardImagesInScene.Length);

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            if (i != correctCardImageIndex)
            {
                cardImagesInScene[i].tag = "WrongCard";
                cardImagesInScene[i].transform.GetChild(0).tag = "WrongCard";
            }
            else
            {
                cardImagesInScene[correctCardImageIndex].tag = "CorrectCard";
                cardImagesInScene[correctCardImageIndex].transform.GetChild(0).tag = "CorrectCard";
                tutorial.GetComponent<Tutorial>().tutorialPosition = cardImagesInScene[correctCardImageIndex].transform.parent;
            }
        }
    }

    public void PlaceSprites()
    {
        if (UIController.correctMatches != 0)
        {
            for (int i = 0; i < cardImagesInScene.Length; i++)
            {
                randomSprites.Add(Sprite.Create(prefetchedRandomImages[i], new Rect(0.0f, 0.0f, prefetchedRandomImages[i].width, prefetchedRandomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
                randomSprites[i].name = prefetchedRandomImages[i].name;
            }
        }

        cardImagesInScene[correctCardImageIndex].sprite = randomSprites[0];

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].gameObject.SetActive(true);
            if (cardImagesInScene[i].sprite == null)
            {
                var randomIndex = Random.Range(1, randomSprites.Count);
                var sprite = randomSprites[randomIndex];
                randomSprites.RemoveAt(randomIndex);
                cardImagesInScene[i].sprite = sprite;
            }
        }

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].transform.GetChild(0).GetComponent<Image>().sprite = ConvertToGrayscale(cardImagesInScene[i].sprite);
        }

    }

    public Sprite ConvertToGrayscale(Sprite textureToConvert)
    {
        Sprite oldTexture = textureToConvert;
        Texture2D newTexture = new Texture2D(oldTexture.texture.width, oldTexture.texture.height);

        for (int i = 0; i < newTexture.width; i++)
        {
            for (int j = 0; j < newTexture.height; j++)
            {
                Color oldColor = oldTexture.texture.GetPixel(i, j);
                float avg = ((oldColor.r + oldColor.g + oldColor.b) / 3);
                Color color = new Color(avg, avg, avg, oldColor.a);
                newTexture.SetPixel(i, j, color);
            }
        }

        newTexture.Apply();
        newTexture.wrapMode = TextureWrapMode.Clamp;
        newTexture.filterMode = FilterMode.Bilinear;
        Sprite sprite = Sprite.Create(newTexture, new Rect(0.0f, 0.0f, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f), 100f); ;
        return sprite;
    }

    private void DisableLoadingPanel()
    {
        // if (loadingPanel.activeInHierarchy)
        // {
        loadingPanel.SetActive(false);
        // }
    }

    private async Task PrefetchNextLevelsTexturesAsync()
    {
        prefetchedRandomCards.Clear();
        prefetchedRandomImages.Clear();

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            var prefetchedCardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExistsPrefetch(prefetchedCardToAdd);

            var texture = await gameAPI.GetCardImage(packSlug, prefetchedRandomCards[i].slug);
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Bilinear;
            texture.name = prefetchedRandomCards[i].title;
            prefetchedRandomImages.Add(texture);

        }

        correctCardSlug = prefetchedRandomCards[0].slug;

    }

}
