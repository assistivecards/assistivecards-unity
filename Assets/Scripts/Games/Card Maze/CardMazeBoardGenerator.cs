using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardMazeBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] SpriteRenderer cardTexture;
    [SerializeField] GameObject cardParent;
    [SerializeField] GameObject maze;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] Texture2D randomImage;
    [SerializeField] Sprite randomSprite;
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> uniqueCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] TMP_Text throwText;
    [SerializeField] GameObject loadingPanel;


    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
    }

    private void OnEnable()
    {
        if (isBackAfterSignOut)
        {
            gameAPI.PlayMusic();
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

        TranslateMazeText();
        await PopulateRandomTextures();
        PlaceSprites();
        DisableLoadingPanel();
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

    }

    public void ScaleImagesUp()
    {
        LeanTween.scale(cardParent, Vector3.one * 12, 0.2f);
        LeanTween.scale(throwText.gameObject, Vector3.one, 0.2f);
        LeanTween.scale(maze, Vector3.one, 0.2f);

    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(cardParent, Vector3.zero, 0.2f);
        LeanTween.scale(throwText.gameObject, Vector3.zero, 0.2f);
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
        gameAPI.Speak(uniqueCards[0].title);
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
            // Debug.Log("Log before checkifcardexists " + cardToAdd.slug);
            CheckIfCardExists(cardToAdd);
        }

    }

    public void ClearUniqueCards()
    {
        uniqueCards.Clear();
    }

    public async Task PopulateRandomTextures()
    {

        var texture = await gameAPI.GetCardImage(packSlug, uniqueCards[0].slug);
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

    private void DisableLoadingPanel()
    {
        loadingPanel.SetActive(false);
    }

    public void TranslateMazeText()
    {
        throwText.text = gameAPI.Translate(throwText.gameObject.name, gameAPI.ToSentenceCase(uniqueCards[0].title).Replace("-", " "), selectedLangCode);
    }

}
