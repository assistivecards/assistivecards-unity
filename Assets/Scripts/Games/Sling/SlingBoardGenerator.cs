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
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomImages = new List<Texture2D>();
    [SerializeField] List<Sprite> randomSprites = new List<Sprite>();
    public string selectedLangCode;
    [SerializeField] string correctCardSlug;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] GameObject box;


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

        PopulateRandomCards();
        await PopulateRandomTextures();
        PlaceSprites();
        ScaleImagesUp();
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.15f);
    }

    public void ClearBoard()
    {
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();

        cardTexture.sprite = null;

    }

    public void ScaleImagesUp()
    {

        LeanTween.scale(cardParent, Vector3.one * 10, 0.2f);
        LeanTween.scale(box, Vector3.one, 0.2f);

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

    public void PopulateRandomCards()
    {

        var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
        CheckIfCardExists(cardToAdd);

    }


    public async Task PopulateRandomTextures()
    {

        var texture = await gameAPI.GetCardImage(packSlug, randomCards[0].slug);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Bilinear;
        randomImages.Add(texture);
        randomSprites.Add(Sprite.Create(randomImages[0], new Rect(0.0f, 0.0f, randomImages[0].width, randomImages[0].height), new Vector2(0.5f, 0.5f), 100.0f));

    }

    public void PlaceSprites()
    {

        if (cardTexture.sprite == null)
        {

            var sprite = randomSprites[0];
            cardTexture.sprite = sprite;
        }
    }

}
