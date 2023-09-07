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
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Card cardToAdd;
    [SerializeField] Texture2D randomImage;
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    private SplitPuzzleUIController UIController;
    [SerializeField] GameObject hintImageParent;
    [SerializeField] List<Image> hintImagePieces = new List<Image>();
    [SerializeField] GameObject[] puzzlePieceParents;
    [SerializeField] GameObject[] puzzlePieceSlots;
    [SerializeField] List<Image> puzzlePieceImages = new List<Image>();
    [SerializeField] GameObject puzzleSlotsDarkParent;
    [SerializeField] GameObject puzzleSlotsLightParent;
    private List<Sprite> puzzlePieces = new List<Sprite>();
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> uniqueCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private PuzzleProgressChecker puzzleProgressChecker;
    [SerializeField] GameObject loadingPanel;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<SplitPuzzleUIController>();
        puzzleProgressChecker = gameObject.GetComponent<PuzzleProgressChecker>();
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

        // for (int i = 0; i < 5; i++)
        // {
        //     cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
        //     Debug.Log("Log before checkifcardexists " + cardToAdd.slug);
        //     CheckIfCardExists(cardToAdd);
        // }

        // cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
        // Debug.Log("Log before checkifcardexists " + cardToAdd.slug);
        // await CheckIfCardExists(cardToAdd);
        // randomCard = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];

        randomImage = await gameAPI.GetCardImage(packSlug, uniqueCards[puzzleProgressChecker.puzzlesCompleted].slug);
        randomImage.wrapMode = TextureWrapMode.Clamp;
        randomImage.filterMode = FilterMode.Bilinear;
        Divide(randomImage);

        DisableLoadingPanel();
        ScaleImagesUp();
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.15f);
        UIController.TutorialSetActive();
    }

    public void ClearBoard()
    {
        cardToAdd = null;
        randomImage = null;
        puzzlePieces.Clear();
        for (int i = 0; i < puzzlePieceImages.Count; i++)
        {
            puzzlePieceImages[i].sprite = null;
        }
    }

    public void ScaleImagesUp()
    {
        for (int i = 0; i < puzzlePieceSlots.Length; i++)
        {
            puzzlePieceParents[i].transform.SetParent(puzzlePieceSlots[i].transform);
            puzzlePieceParents[i].transform.position = puzzlePieceSlots[i].transform.position;
            puzzlePieceParents[i].GetComponent<DraggablePiece>().enabled = true;
            puzzlePieceParents[i].GetComponent<Rigidbody2D>().isKinematic = false;
            puzzlePieceParents[i].GetComponent<BoxCollider2D>().size = new Vector2(150f, 150f);
            puzzlePieceParents[i].GetComponent<BoxCollider2D>().isTrigger = false;
        }
        puzzleSlotsLightParent.transform.SetAsLastSibling();
        LeanTween.alpha(puzzleSlotsLightParent.GetComponent<RectTransform>(), .2f, .15f);
        LeanTween.alpha(puzzleSlotsDarkParent.GetComponent<RectTransform>(), .7f, .15f);
        LeanTween.scale(hintImageParent, Vector3.one, 0.15f);
        LeanTween.scale(puzzleSlotsDarkParent, Vector3.one, 0.15f);
        LeanTween.scale(puzzleSlotsLightParent, Vector3.one, 0.15f);


        for (int i = 0; i < puzzlePieceParents.Length; i++)
        {
            LeanTween.scale(puzzlePieceParents[i], Vector3.one, 0.15f);
            puzzlePieceParents[i].GetComponent<SplitPuzzleMatchDetection>().isMatched = false;
        }
    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(puzzleSlotsDarkParent, Vector3.zero, .15f);
        LeanTween.scale(puzzleSlotsLightParent, Vector3.zero, .15f);
        for (int i = 0; i < puzzlePieceParents.Length; i++)
        {
            if (puzzlePieceParents[i].transform.parent.name != "HintImage")
            {
                LeanTween.scale(puzzlePieceParents[i], Vector3.zero, .15f);
            }

        }
        LeanTween.scale(hintImageParent, Vector3.zero, .15f);
    }

    public void ReadCard()
    {
        gameAPI.Speak(uniqueCards[puzzleProgressChecker.puzzlesCompleted - 1].title);
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

    public void CheckIfCardExists(AssistiveCardsSDK.AssistiveCardsSDK.Card cardToAdd)
    {
        if (!uniqueCards.Contains(cardToAdd))
        {
            uniqueCards.Add(cardToAdd);
            // Debug.Log(cardToAdd.slug + " uniqueCards'a eklendi!!");
        }
        else
        {
            cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
            // Debug.Log(cardToAdd.slug + " uniqueCards'a eklenmedi!!");
        }
    }

    public void ClearUniqueCards()
    {
        uniqueCards.Clear();
    }

    public void PopulateUniqueCards()
    {
        for (int i = 0; i < 5; i++)
        {
            cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            // Debug.Log("Log before checkifcardexists " + cardToAdd.slug);
            CheckIfCardExists(cardToAdd);
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
