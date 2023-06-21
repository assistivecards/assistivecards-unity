using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SizePuzzleBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] Image[] cardTextures;
    [SerializeField] GameObject[] cardParents;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] Texture2D randomImage;
    [SerializeField] Sprite randomSprite;
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> uniqueCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] TMP_Text chooseText;
    [SerializeField] GameObject loadingPanel;
    private List<float> randomScalers = new List<float>();
    [SerializeField] List<string> sizes = new List<string>();
    public string selectedSize;
    SizePuzzleUIController UIController;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<SizePuzzleUIController>();
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

        SetRandomScalers();
        TranslateChooseText();
        await PopulateRandomTextures();
        PlaceSprites();
        DisableLoadingPanel();
        ScaleImagesUp();
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.15f);
    }

    private void SetRandomScalers()
    {
        randomScalers.Add(.8f);
        randomScalers.Add(1);
        randomScalers.Add(1.2f);
    }

    public void ClearBoard()
    {
        randomImage = null;
        randomSprite = null;

        for (int i = 0; i < cardTextures.Length; i++)
        {
            cardTextures[i].sprite = null;
        }

    }

    public void ScaleImagesUp()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            cardParents[i].GetComponent<SizePuzzleMatchDetection>().isClicked = false;
            LeanTween.alpha(cardParents[i].GetComponent<RectTransform>(), 1, .001f);
            var randomScalerIndex = Random.Range(0, randomScalers.Count);
            LeanTween.scale(cardParents[i], Vector3.one * randomScalers[randomScalerIndex], 0.2f);
            randomScalers.RemoveAt(randomScalerIndex);
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
        if (!uniqueCards.Contains(cardToAdd))
        {
            uniqueCards.Add(cardToAdd);
        }
        else
        {
            cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
        }
    }

    public void ReadCard()
    {
        gameAPI.Speak(uniqueCards[UIController.correctMatches - 1].title);
    }

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
    }

    public void PopulateUniqueCards()
    {

        for (int i = 0; i < 5; i++)
        {
            var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
        }

    }

    public void ClearUniqueCards()
    {
        uniqueCards.Clear();
    }

    public async Task PopulateRandomTextures()
    {

        var texture = await gameAPI.GetCardImage(packSlug, uniqueCards[UIController.correctMatches].slug);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Bilinear;
        randomImage = texture;
        randomSprite = Sprite.Create(randomImage, new Rect(0.0f, 0.0f, randomImage.width, randomImage.height), new Vector2(0.5f, 0.5f), 100.0f);

    }

    public void PlaceSprites()
    {
        for (int i = 0; i < cardTextures.Length; i++)
        {
            if (cardTextures[i].sprite == null)
            {

                var sprite = randomSprite;
                cardTextures[i].sprite = sprite;
            }
        }
    }

    private void DisableLoadingPanel()
    {
        loadingPanel.SetActive(false);
    }

    public void TranslateChooseText()
    {
        selectedSize = sizes[Random.Range(0, sizes.Count)];

        if (selectedSize == "small")
        {
            chooseText.name = "choose_text_small";
        }
        else if (selectedSize == "medium")
        {
            chooseText.name = "choose_text_medium";
        }
        else if (selectedSize == "large")
        {
            chooseText.name = "choose_text_large";
        }

        chooseText.text = gameAPI.Translate(chooseText.gameObject.name, gameAPI.ToSentenceCase(uniqueCards[UIController.correctMatches].title).Replace("-", " "), selectedLangCode);
    }

}
