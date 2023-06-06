using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PressCardsBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomImages = new List<Texture2D>();
    [SerializeField] List<Sprite> randomSprites = new List<Sprite>();
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    // [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> uniqueCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] TMP_Text pressText;
    public int pressCount;
    [SerializeField] PressCardsMatchDetection matchDetector;
    private PressCardsUIController UIController;
    [SerializeField] string correctCardSlug;
    [SerializeField] Image[] cardImagesInScene;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] private GameObject tutorial;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<PressCardsUIController>();
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

        RandomizePressCount();
        PopulateRandomCards();
        TranslatePressCardText();
        await PopulateRandomTextures();
        AssignTags();
        PlaceSprites();
        DisableLoadingPanel();
        ScaleImagesUp();
        backButton.SetActive(true);
        UIController.TutorialSetActive();
        Invoke("EnableBackButton", 0.15f);
    }

    public void ClearBoard()
    {
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].sprite = null;
        }

        // cardParent.GetComponent<PressCardsCounterSpawner>().counter = 0;
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].transform.parent.GetComponent<PressCardsCounterSpawner>().counter = 0;
            LeanTween.alpha(cardImagesInScene[i].GetComponent<RectTransform>(), 1, 0.0001f);
            LeanTween.alpha(cardImagesInScene[i].transform.parent.GetComponent<RectTransform>(), 1, 0.0001f);
        }

    }

    public void ScaleImagesUp()
    {
        // LeanTween.scale(cardParent, Vector3.one, 0.2f);
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            LeanTween.scale(cardImagesInScene[i].transform.parent.gameObject, Vector3.one, 0.2f);
            cardImagesInScene[i].transform.parent.GetComponent<PressCardsCounterSpawner>().enabled = true;
        }

        LeanTween.scale(pressText.gameObject, Vector3.one, 0.2f);
        // cardParent.GetComponent<PressCardsCounterSpawner>().enabled = true;


    }

    public void ScaleImagesDown()
    {
        // LeanTween.scale(cardParent, Vector3.zero, 0.2f);
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            LeanTween.scale(cardImagesInScene[i].transform.parent.gameObject, Vector3.zero, 0.2f);
        }
        LeanTween.scale(pressText.gameObject, Vector3.zero, 0.2f);
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

    // public void PopulateUniqueCards()
    // {

    //     for (int i = 0; i < 5; i++)
    //     {
    //         var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
    //         CheckIfCardExists(cardToAdd);
    //     }

    // }

    // public void ClearUniqueCards()
    // {
    //     uniqueCards.Clear();
    // }

    public void TranslatePressCardText()
    {
        pressText.text = gameAPI.Translate(pressText.gameObject.name, gameAPI.ToSentenceCase(randomCards[0].title).Replace("-", " "), selectedLangCode);

        pressText.text = pressText.text.Replace("$2", pressCount.ToString());

        if (pressCount == 1 && pressText.text.Contains("times"))
        {
            pressText.text = pressText.text.Replace("times", "time");
        }
    }

    public async Task PopulateRandomTextures()
    {
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            var texture = await gameAPI.GetCardImage(packSlug, randomCards[i].slug);
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Bilinear;
            randomImages.Add(texture);
            randomSprites.Add(Sprite.Create(randomImages[i], new Rect(0.0f, 0.0f, randomImages[i].width, randomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
        }
    }

    public void PlaceSprites()
    {
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {

            if (cardImagesInScene[i].sprite == null)
            {
                var randomIndex = Random.Range(1, randomSprites.Count);
                var sprite = randomSprites[randomIndex];
                randomSprites.RemoveAt(randomIndex);
                cardImagesInScene[i].sprite = sprite;
            }
        }
    }

    public void RandomizePressCount()
    {
        pressCount = Random.Range(1, 9);
    }

    public void ReadCard()
    {
        gameAPI.Speak(randomCards[0].title);
    }

    public void PopulateRandomCards()
    {
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
        }

        correctCardSlug = randomCards[0].slug;
    }

    public void AssignTags()
    {
        var correctCardImageIndex = Random.Range(0, cardImagesInScene.Length);
        cardImagesInScene[correctCardImageIndex].sprite = randomSprites[0];

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            if (i != correctCardImageIndex)
            {
                cardImagesInScene[i].tag = "WrongCard";
                cardImagesInScene[i].transform.parent.tag = "WrongCard";
            }
            else
            {
                cardImagesInScene[correctCardImageIndex].tag = "CorrectCard";
                cardImagesInScene[correctCardImageIndex].transform.parent.tag = "CorrectCard";
                tutorial.GetComponent<Tutorial>().tutorialPosition = cardImagesInScene[correctCardImageIndex].transform;
            }
        }
    }

    private void DisableLoadingPanel()
    {
        // if (loadingPanel.activeInHierarchy)
        // {
        loadingPanel.SetActive(false);
        // }
    }

}
