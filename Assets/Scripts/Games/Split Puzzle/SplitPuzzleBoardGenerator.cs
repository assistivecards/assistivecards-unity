using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SplitPuzzleBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Card randomCard;
    [SerializeField] Texture2D randomImage;
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    private CircleUIController UIController;
    [SerializeField] GameObject hintImageParent;
    [SerializeField] List<Image> hintImagePieces = new List<Image>();
    [SerializeField] GameObject[] puzzlePieceSlots;
    [SerializeField] List<Image> puzzlePieceImages = new List<Image>();
    [SerializeField] GameObject puzzleSlotsDarkParent;
    [SerializeField] GameObject puzzleSlotsLightParent;
    private List<Sprite> puzzlePieces = new List<Sprite>();

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
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


        randomCard = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];

        randomImage = await gameAPI.GetCardImage(packSlug, randomCard.slug);
        randomImage.wrapMode = TextureWrapMode.Clamp;
        randomImage.filterMode = FilterMode.Bilinear;
        Divide(randomImage);


        ScaleImagesUp();
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.15f);
    }

    public void ClearBoard()
    {
        randomCard = null;
        randomImage = null;
    }

    public void ScaleImagesUp()
    {
        LeanTween.scale(hintImageParent, Vector3.one, 0.15f);
        LeanTween.scale(puzzleSlotsDarkParent, Vector3.one, 0.15f);
        LeanTween.scale(puzzleSlotsLightParent, Vector3.one, 0.15f);


        for (int i = 0; i < puzzlePieceSlots.Length; i++)
        {
            LeanTween.scale(puzzlePieceSlots[i], Vector3.one, 0.15f);
        }
    }

    public void ScaleImagesDown()
    {

    }

    public void ReadCard()
    {
        gameAPI.Speak(randomCard.title);
    }

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
    }

    public void Divide(Texture2D texture)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Sprite newSprite = Sprite.Create(texture, new Rect(i * 128, j * 128, 128, 128), new Vector2(0.5f, 0.5f));
                puzzlePieces.Add(newSprite);
            }
        }

        for (int i = 0; i < hintImagePieces.Count; i++)
        {
            hintImagePieces[i].sprite = puzzlePieces[i];
        }

        for (int i = 0; i < puzzlePieceImages.Count; i++)
        {
            if (puzzlePieceImages[i].sprite == null)
            {
                var randomIndex = Random.Range(0, puzzlePieces.Count);
                var sprite = puzzlePieces[randomIndex];
                puzzlePieces.RemoveAt(randomIndex);
                puzzlePieceImages[i].sprite = sprite;
            }
        }
    }
}
