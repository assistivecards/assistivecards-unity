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
    [SerializeField] Image cardTexture;
    [SerializeField] GameObject cardParent;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] Texture2D randomImage;
    [SerializeField] Sprite randomSprite;
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> uniqueCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] TMP_Text pressText;
    public int pressCount;
    [SerializeField] PressCardsMatchDetection matchDetector;
    private PressCardsUIController UIController;

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
        TranslatePressCardText();
        await PopulateRandomTextures();
        PlaceSprites();
        ScaleImagesUp();
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.15f);
    }

    public void ClearBoard()
    {
        var rb = cardParent.GetComponent<Rigidbody2D>();
        randomImage = null;
        randomSprite = null;
        cardTexture.sprite = null;
        cardParent.GetComponent<PressCardsCounterSpawner>().counter = 0;

    }

    public void ScaleImagesUp()
    {
        LeanTween.scale(cardParent, Vector3.one, 0.2f);
        LeanTween.scale(pressText.gameObject, Vector3.one, 0.2f);
        cardParent.GetComponent<PressCardsCounterSpawner>().enabled = true;

    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(cardParent, Vector3.zero, 0.2f);
        LeanTween.scale(pressText.gameObject, Vector3.zero, 0.2f);
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

    public void TranslatePressCardText()
    {
        pressText.text = gameAPI.Translate(pressText.gameObject.name, gameAPI.ToSentenceCase(uniqueCards[matchDetector.correctMatches].title).Replace("-", " "), selectedLangCode);
        pressText.text = pressText.text.Replace("$2", pressCount.ToString());
    }

    public async Task PopulateRandomTextures()
    {

        var texture = await gameAPI.GetCardImage(packSlug, uniqueCards[matchDetector.correctMatches].slug);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Bilinear;
        randomImage = texture;
        randomSprite = Sprite.Create(randomImage, new Rect(0.0f, 0.0f, randomImage.width, randomImage.height), new Vector2(0.5f, 0.5f), 100.0f);

    }

    public void PlaceSprites()
    {

        if (cardTexture.sprite == null)
        {
            var sprite = randomSprite;
            cardTexture.sprite = sprite;
        }
    }

    public void RandomizePressCount()
    {
        pressCount = Random.Range(1, 9);
    }

}
