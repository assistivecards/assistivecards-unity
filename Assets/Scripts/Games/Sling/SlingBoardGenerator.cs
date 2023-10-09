using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SlingBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] SpriteRenderer cardTexture;
    [SerializeField] GameObject cardParent;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] Texture2D randomImage;
    [SerializeField] Texture2D prefetchedRandomImage;
    [SerializeField] Sprite randomSprite;
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] Transform box;
    [SerializeField] Transform cardSlot;
    private SlingUIController UIController;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> uniqueCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    SlingProgressChecker progressChecker;
    [SerializeField] TMP_Text throwText;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] GameObject separator;


    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<SlingUIController>();
        progressChecker = gameObject.GetComponent<SlingProgressChecker>();
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

            for (int i = 0; i < uniqueCards.Count; i++)
            {
                uniqueCards[i] = cachedCards.cards.Where(card => card.slug == uniqueCards[i].slug).ToList()[0];
            }

            didLanguageChange = false;
        }

        // PopulateRandomCards();
        TranslateThrowCardText();
        await PopulateRandomTextures();
        PlaceSprites();
        DisableLoadingPanel();
        ScaleImagesUp();
        UIController.TutorialSetActive();
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.15f);
        await PrefetchNextLevelsTexturesAsync();
    }

    public void ClearBoard()
    {
        var rb = cardParent.GetComponent<Rigidbody2D>();
        randomImage = null;
        randomSprite = null;

        cardTexture.sprite = null;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.freezeRotation = true;
        cardParent.transform.rotation = Quaternion.Euler(0, 0, 0);
        cardParent.transform.position = cardSlot.position;
        rb.freezeRotation = false;
        cardParent.GetComponent<SwipeManager>().canThrow = true;
        cardParent.GetComponent<SwipeManager>().isValid = false;
        cardParent.GetComponent<SwipeManager>().enabled = false;

        for (int i = 0; i < box.childCount - 1; i++)
        {
            LeanTween.color(box.GetChild(i).gameObject, Color.white, .2f);
        }

    }

    public void ScaleImagesUp()
    {
        LeanTween.alpha(cardParent, 1, .001f);
        LeanTween.scale(cardParent, Vector3.one * 12, 0.2f);
        LeanTween.scale(throwText.gameObject, Vector3.one, 0.2f);
        LeanTween.scale(box.gameObject, Vector3.one, 0.2f);
        LeanTween.scale(separator, Vector3.one, 0.2f);
        cardParent.GetComponent<SwipeManager>().enabled = true;

    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(cardParent, Vector3.zero, 0.2f);
        LeanTween.scale(throwText.gameObject, Vector3.zero, 0.2f);
    }

    public void ScaleBoxDown()
    {
        LeanTween.scale(box.gameObject, Vector3.zero, 0.2f);
        LeanTween.scale(separator, Vector3.zero, 0.2f);
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
        gameAPI.Speak(uniqueCards[progressChecker.correctMatches - 1].title);
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

    public void TranslateThrowCardText()
    {
        throwText.text = gameAPI.Translate(throwText.gameObject.name, gameAPI.ToSentenceCase(uniqueCards[progressChecker.correctMatches].title).Replace("-", " "), selectedLangCode);
    }

    public async Task PopulateRandomTextures()
    {
        if (progressChecker.correctMatches == 0)
        {
            var texture = await gameAPI.GetCardImage(packSlug, uniqueCards[progressChecker.correctMatches].slug);
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Bilinear;
            texture.name = uniqueCards[progressChecker.correctMatches].title;
            randomImage = texture;
            randomSprite = Sprite.Create(randomImage, new Rect(0.0f, 0.0f, randomImage.width, randomImage.height), new Vector2(0.5f, 0.5f), 100.0f);
            randomSprite.name = randomImage.name;
        }

    }

    public void PlaceSprites()
    {
        if (progressChecker.correctMatches != 0)
        {

            randomSprite = Sprite.Create(prefetchedRandomImage, new Rect(0.0f, 0.0f, prefetchedRandomImage.width, prefetchedRandomImage.height), new Vector2(0.5f, 0.5f), 100.0f);
            randomSprite.name = prefetchedRandomImage.name;

        }

        if (cardTexture.sprite == null)
        {

            var sprite = randomSprite;
            cardTexture.sprite = sprite;
        }
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
        prefetchedRandomImage = null;

        var texture = await gameAPI.GetCardImage(packSlug, uniqueCards[progressChecker.correctMatches + 1].slug);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Bilinear;
        texture.name = uniqueCards[progressChecker.correctMatches + 1].title;
        prefetchedRandomImage = texture;

    }

}
