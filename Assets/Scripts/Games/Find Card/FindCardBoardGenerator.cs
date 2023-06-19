using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class FindCardBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomImages = new List<Texture2D>();
    [SerializeField] List<Sprite> randomSprites = new List<Sprite>();
    [SerializeField] List<Sprite> tempSprites = new List<Sprite>();
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] TMP_Text findText;
    [SerializeField] string correctCardSlug;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] Image[] cardImagesInScene;
    public GameObject[] cardParents;
    public float visibilityTime;
    private FindCardMatchDetection matchDetector;
    private FindCardUIController UIController;
    public int cardsNeeded;
    [SerializeField] GameObject targetCard;
    [SerializeField] GameObject cardsParent;
    [SerializeField] GameObject tutorial;
    private Transform tutorialPosition;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        matchDetector = gameObject.GetComponent<FindCardMatchDetection>();
        UIController = gameObject.GetComponent<FindCardUIController>();
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
        TranslateFindCardsText();
        await PopulateRandomTextures();
        PopulateTempSprites();
        PlaceSprites();
        AssignTags();
        DisableLoadingPanel();
        ScaleImagesUp();
        Invoke("FlipCardsBack", visibilityTime);
        backButton.SetActive(true);
        UIController.Invoke("TutorialSetActive", visibilityTime + 0.75f);
        Invoke("EnableBackButton", 0.2f);
    }

    public void ClearBoard()
    {
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();
        tempSprites.Clear();
        matchDetector.flippedCards.Clear();
        cardsNeeded = 0;

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].sprite = null;
        }

    }

    public void ScaleImagesUp()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            LeanTween.alpha(cardParents[i].GetComponent<RectTransform>(), 1, .001f);
            cardParents[i].GetComponent<FindCardFlipCard>().enabled = true;
            cardParents[i].transform.rotation = Quaternion.Euler(0, -180, 0);
            LeanTween.scale(cardParents[i], Vector3.one, 0.2f);
        }

        LeanTween.scale(findText.gameObject, Vector3.one, 0.2f);
        LeanTween.scale(targetCard, Vector3.one, 0.2f);

    }

    public void ScaleImagesDown()
    {

        for (int i = 0; i < cardParents.Length; i++)
        {
            LeanTween.scale(cardParents[i], Vector3.zero, 0.25f);
        }

        LeanTween.scale(findText.gameObject, Vector3.zero, 0.25f);
        LeanTween.scale(targetCard, Vector3.zero, 0.25f);
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

    public void TranslateFindCardsText()
    {
        findText.text = gameAPI.Translate(findText.gameObject.name, gameAPI.ToTitleCase(randomCards[0].title).Replace("-", " "), selectedLangCode);
    }

    public async Task PopulateRandomTextures()
    {
        for (int i = 0; i < randomCards.Count; i++)
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

    private void PopulateTempSprites()
    {

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                tempSprites.Add(randomSprites[i]);
            }
        }

        for (int i = 10; i < cardImagesInScene.Length; i++)
        {
            var randomSpriteToAdd = randomSprites[Random.Range(0, randomSprites.Count)];
            tempSprites.Add(randomSpriteToAdd);
        }

    }

    public void PlaceSprites()
    {

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {

            if (cardImagesInScene[i].sprite == null)
            {
                var randomIndex = Random.Range(0, tempSprites.Count);
                var sprite = tempSprites[randomIndex];
                tempSprites.RemoveAt(randomIndex);
                cardImagesInScene[i].sprite = sprite;
            }
        }

        targetCard.transform.GetChild(0).GetComponent<Image>().sprite = randomSprites[0];
    }

    public void PopulateRandomCards()
    {
        for (int i = 0; i < 5; i++)
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

    private void FlipCardsBack()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            cardParents[i].GetComponent<FindCardFlipCard>().FlipBack();
        }

        gameAPI.PlaySFX("FlipCardBack");
    }

    private void AssignTags()
    {
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            if (cardImagesInScene[i].GetComponent<Image>().sprite != randomSprites[0])
            {
                cardImagesInScene[i].transform.parent.parent.tag = "WrongCard";
            }
            else
            {
                cardImagesInScene[i].transform.parent.parent.tag = "CorrectCard";
            }
        }

        var cards = cardsParent.GetComponentsInChildren<FindCardFlipCard>(true);

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].tag == "CorrectCard")
            {
                cardsNeeded++;
                tutorialPosition = cards[i].transform;
            }
        }

        tutorial.GetComponent<Tutorial>().tutorialPosition = tutorialPosition;

        // cardsNeeded = GameObject.FindGameObjectsWithTag("CorrectCard").Length - 1;
    }

    public void ReadCard()
    {
        gameAPI.Speak(randomCards[0].title);
    }

}
