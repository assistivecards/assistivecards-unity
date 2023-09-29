using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardGeneration : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private GameObject tutorial;
    [SerializeField] Image[] cardImagesInScene;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    List<AssistiveCardsSDK.AssistiveCardsSDK.Card> prefetchedRandomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    List<Texture2D> randomImages = new List<Texture2D>();
    List<Texture2D> prefetchedRandomImages = new List<Texture2D>();
    List<Sprite> randomSprites = new List<Sprite>();
    public string selectedLangCode;
    [SerializeField] string correctCardSlug;
    [SerializeField] TMP_Text circleText;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] DrawManager drawManager;
    private CircleUIController UIController;
    [SerializeField] GameObject loadingPanel;
    public int correctCardImageIndex;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<CircleUIController>();
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
        TranslateCircleText();
        await PopulateRandomTextures();
        AssignTags();
        PlaceSprites();
        DisableLoadingPanel();
        ScaleImagesUp();
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.15f);
        Invoke("EnableDrawManager", 0.15f);
        tutorial.GetComponent<Tutorial>().tutorialPosition = cardImagesInScene[correctCardImageIndex].transform;
        UIController.TutorialSetActive(tutorial);
        await PrefetchNextLevelsTexturesAsync();

    }

    private void PopulateRandomCards()
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

    private async Task PopulateRandomTextures()
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

    private void TranslateCircleText()
    {
        circleText.text = gameAPI.Translate(circleText.gameObject.name, gameAPI.ToSentenceCase(UIController.correctMatches == 0 ? randomCards[0].title : prefetchedRandomCards[0].title).Replace("-", " "), selectedLangCode);
    }

    private void AssignTags()
    {
        correctCardImageIndex = Random.Range(0, cardImagesInScene.Length);

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            if (i != correctCardImageIndex)
            {
                cardImagesInScene[i].tag = "WrongCard";
            }
            else
            {
                cardImagesInScene[correctCardImageIndex].tag = "CorrectCard";
            }
        }
    }

    private void PlaceSprites()
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

    }

    public void ClearBoard()
    {
        circleText.text = "";
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].sprite = null;
        }

    }

    public void ScaleImagesUp()
    {
        LeanTween.scale(circleText.gameObject, Vector3.one, 0.15f);
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            LeanTween.scale(cardImagesInScene[i].gameObject, Vector3.one, 0.15f);
        }
    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(circleText.gameObject, Vector3.zero, 0.15f);
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            LeanTween.scale(cardImagesInScene[i].gameObject, Vector3.zero, 0.15f);
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

    public void EnableDrawManager()
    {
        drawManager.gameObject.SetActive(true);
    }

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
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
