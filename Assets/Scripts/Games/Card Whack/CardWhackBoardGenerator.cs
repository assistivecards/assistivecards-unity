using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardWhackBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomImages = new List<Texture2D>();
    public List<Sprite> randomSprites = new List<Sprite>();
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] TMP_Text whackText;
    [SerializeField] string correctCardSlug;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] GameObject[] slots;
    public int numOfCards = 5;
    [SerializeField] GameObject cardToWhack;
    [SerializeField] GameObject scoreParent;
    [SerializeField] GameObject cardSpawner;
    private CardWhackScoreManager scoreManager;
    private CardWhackUIController UIController;
    [MinTo(10)] public Vector2 spawnTime;
    [SerializeField] GameObject tutorial;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<CardWhackScoreManager>();
        UIController = gameObject.GetComponent<CardWhackUIController>();
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
        TranslateWhackCardText();
        await PopulateRandomTextures();
        DisableLoadingPanel();
        ScaleImagesUp();
        backButton.SetActive(true);
        tutorial.GetComponent<Tutorial>().tutorialPosition = slots[4].transform;
        UIController.Invoke("TutorialSetActive", spawnTime.x);
        Invoke("EnableBackButton", 0.2f);
        cardSpawner.GetComponent<CardWhackCardSpawner>().InvokeRepeating("SpawnCard", 1, Random.Range(spawnTime.x, spawnTime.y));
    }

    public void ClearBoard()
    {
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();
        scoreManager.score = 0;
        scoreManager.isLevelComplete = false;

    }

    public void ScaleImagesUp()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            LeanTween.scale(slots[i], Vector3.one, 0.2f);
        }

        LeanTween.scale(whackText.gameObject, Vector3.one, 0.2f);
        LeanTween.scale(scoreParent, Vector3.one, 0.2f);
        cardToWhack.transform.GetChild(0).GetComponent<Image>().sprite = randomSprites[0];
        LeanTween.scale(cardToWhack, Vector3.one, 0.2f);

    }

    public void ScaleImagesDown()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            LeanTween.scale(slots[i], Vector3.zero, 0.2f);
        }

        LeanTween.scale(whackText.gameObject, Vector3.zero, 0.2f);
        LeanTween.scale(scoreParent, Vector3.zero, 0.2f);
        LeanTween.scale(cardToWhack, Vector3.zero, 0.2f);
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

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
    }

    public async Task PopulateRandomTextures()
    {
        for (int i = 0; i < numOfCards; i++)
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

    public void PopulateRandomCards()
    {
        for (int i = 0; i < numOfCards; i++)
        {
            var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
        }

        correctCardSlug = randomCards[0].slug;
    }

    private void DisableLoadingPanel()
    {
        loadingPanel.SetActive(false);
    }

    public void TranslateWhackCardText()
    {
        whackText.text = gameAPI.Translate(whackText.gameObject.name, gameAPI.ToTitleCase(randomCards[0].title).Replace("-", " "), selectedLangCode);
    }

}
