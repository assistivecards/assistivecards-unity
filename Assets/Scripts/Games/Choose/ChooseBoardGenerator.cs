using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] Image[] cardTextures;
    public GameObject[] cardParents;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    List<AssistiveCardsSDK.AssistiveCardsSDK.Card> prefetchedRandomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    List<Texture2D> randomImages = new List<Texture2D>();
    List<Texture2D> prefetchedRandomImages = new List<Texture2D>();
    List<Sprite> randomSprites = new List<Sprite>();
    public string selectedLangCode;
    public string correctCardSlug;
    [SerializeField] TMP_Text chooseText;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] GameObject loadingPanel;
    ChooseUIController UIController;
    [SerializeField] GameObject tutorial;
    public int correctCardImageIndex;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<ChooseUIController>();
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
        TranslateChooseCardText();
        await PopulateRandomTextures();
        AssignTags();
        PlaceSprites();
        DisableLoadingPanel();
        ScaleImagesUp();
        Invoke("SetTutorialPosition", .3f);
        backButton.SetActive(true);
        UIController.Invoke("TutorialSetActive", .3f);
        Invoke("EnableBackButton", 0.15f);
        await PrefetchNextLevelsTexturesAsync();
    }

    public void ClearBoard()
    {
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();

        for (int i = 0; i < cardTextures.Length; i++)
        {
            cardTextures[i].sprite = null;
        }

    }

    public void ScaleImagesUp()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            cardParents[i].GetComponent<ChooseMatchDetection>().isClicked = false;
            LeanTween.alpha(cardParents[i].GetComponent<RectTransform>(), 1, .001f);
            LeanTween.scale(cardParents[i], Vector3.one, 0.2f);
        }

        LeanTween.scale(chooseText.gameObject, Vector3.one, 0.2f);

    }

    public void ScaleImagesDown()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            LeanTween.scale(cardParents[i], Vector3.zero, 0.2f);
        }

        LeanTween.scale(chooseText.gameObject, Vector3.zero, 0.2f);
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

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
    }

    public void PopulateRandomCards()
    {
        if (UIController.correctMatches == 0)
        {
            for (int i = 0; i < cardParents.Length; i++)
            {
                var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
                CheckIfCardExists(cardToAdd);
            }

            correctCardSlug = randomCards[0].slug;
        }

    }

    public async Task PopulateRandomTextures()
    {
        if (UIController.correctMatches == 0)
        {
            for (int i = 0; i < cardTextures.Length; i++)
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

    private void AssignTags()
    {
        correctCardImageIndex = Random.Range(0, cardTextures.Length);

        for (int i = 0; i < cardTextures.Length; i++)
        {
            if (i != correctCardImageIndex)
            {
                cardTextures[i].transform.parent.tag = "WrongCard";
            }
            else
            {
                cardTextures[correctCardImageIndex].transform.parent.tag = "CorrectCard";
            }
        }
    }

    public void PlaceSprites()
    {
        if (UIController.correctMatches != 0)
        {
            for (int i = 0; i < cardTextures.Length; i++)
            {
                randomSprites.Add(Sprite.Create(prefetchedRandomImages[i], new Rect(0.0f, 0.0f, prefetchedRandomImages[i].width, prefetchedRandomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
                randomSprites[i].name = prefetchedRandomImages[i].name;
            }
        }

        cardTextures[correctCardImageIndex].sprite = randomSprites[0];

        for (int i = 0; i < cardTextures.Length; i++)
        {
            if (cardTextures[i].sprite == null)
            {
                var randomIndex = Random.Range(1, randomSprites.Count);
                var sprite = randomSprites[randomIndex];
                randomSprites.RemoveAt(randomIndex);
                cardTextures[i].sprite = sprite;
            }
        }
    }

    private void DisableLoadingPanel()
    {
        loadingPanel.SetActive(false);
    }

    public void TranslateChooseCardText()
    {
        chooseText.text = gameAPI.Translate(chooseText.gameObject.name, gameAPI.ToTitleCase(UIController.correctMatches == 0 ? randomCards[0].title : prefetchedRandomCards[0].title).Replace("-", " "), selectedLangCode);
    }

    public void ReadCard()
    {
        gameAPI.Speak(cardTextures[correctCardImageIndex].sprite.name);
    }

    private void SetTutorialPosition()
    {

        for (int i = 0; i < cardParents.Length; i++)
        {
            if (cardParents[i].transform.GetChild(0).GetComponent<Image>().sprite.texture == randomImages[0])
            {
                tutorial.GetComponent<Tutorial>().tutorialPosition = cardParents[i].transform;
            }
        }

    }

    private async Task PrefetchNextLevelsTexturesAsync()
    {
        prefetchedRandomCards.Clear();
        prefetchedRandomImages.Clear();

        for (int i = 0; i < cardParents.Length; i++)
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
