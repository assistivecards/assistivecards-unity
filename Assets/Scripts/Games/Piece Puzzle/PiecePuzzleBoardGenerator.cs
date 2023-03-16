using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PiecePuzzleBoardGenerator : MonoBehaviour
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
    [SerializeField] Image hintImage;
    [SerializeField] GameObject[] puzzlePieceParents;
    [SerializeField] GameObject[] puzzlePieceSlots;
    [SerializeField] List<Image> puzzlePieceImages = new List<Image>();
    [SerializeField] List<Sprite> puzzlePiecesRef = new List<Sprite>();
    [SerializeField] List<Sprite> puzzlePieces = new List<Sprite>();
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> uniqueCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private PuzzleProgressChecker puzzleProgressChecker;
    private PiecePuzzleUIController UIController;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        puzzleProgressChecker = GameObject.Find("GamePanel").GetComponent<PuzzleProgressChecker>();
        UIController = gameObject.GetComponent<PiecePuzzleUIController>();
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

        if (puzzlePieces.Count == 0)
        {
            for (int i = 0; i < puzzlePiecesRef.Count; i++)
            {
                puzzlePieces.Add(puzzlePiecesRef[i]);
            }
        }

        randomImage = await gameAPI.GetCardImage(packSlug, uniqueCards[puzzleProgressChecker.puzzlesCompleted].slug);
        randomImage.wrapMode = TextureWrapMode.Clamp;
        randomImage.filterMode = FilterMode.Bilinear;

        for (int i = 0; i < puzzlePieceParents.Length; i++)
        {
            if (puzzlePieceParents[i].GetComponent<Image>().sprite == null)
            {
                var randomIndex = Random.Range(0, puzzlePieces.Count);
                var sprite = puzzlePieces[randomIndex];
                puzzlePieces.RemoveAt(randomIndex);
                puzzlePieceParents[i].GetComponent<Image>().sprite = sprite;
                puzzlePieceParents[i].SetActive(true);
                puzzlePieceParents[i].GetComponent<PiecePuzzleDraggablePiece>().enabled = true;
            }
        }

        ScaleImagesUp();
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.15f);
    }

    public void ClearBoard()
    {
        cardToAdd = null;
        randomImage = null;
        puzzlePieces.Clear();
        for (int i = 0; i < puzzlePieceParents.Length; i++)
        {
            puzzlePieceParents[i].GetComponent<Image>().sprite = null;
            puzzlePieceParents[i].GetComponent<PiecePuzzleMatchDetection>().correctMatch = false;
            puzzlePieceParents[i].transform.GetChild(0).GetComponent<PiecePuzzleAnchorPointDetection>().isMatched = false;
        }
    }

    public void ScaleImagesUp()
    {
        for (int i = 0; i < puzzlePieceSlots.Length; i++)
        {
            puzzlePieceParents[i].transform.SetParent(puzzlePieceSlots[i].transform);
            puzzlePieceParents[i].transform.position = puzzlePieceSlots[i].transform.position;
            puzzlePieceParents[i].transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(randomImage, new Rect(0.0f, 0.0f, randomImage.width, randomImage.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
        hintImage.sprite = Sprite.Create(randomImage, new Rect(0.0f, 0.0f, randomImage.width, randomImage.height), new Vector2(0.5f, 0.5f), 100.0f);

        LeanTween.scale(hintImage.gameObject, Vector3.one, 0.15f);

        for (int i = 0; i < puzzlePieceParents.Length; i++)
        {
            LeanTween.scale(puzzlePieceParents[i], Vector3.one, 0.15f);
        }
    }

    public void ScaleImagesDown()
    {
        for (int i = 0; i < puzzlePieceParents.Length; i++)
        {
            if (puzzlePieceParents[i].transform.parent.name != "HintImage")
            {
                LeanTween.scale(puzzlePieceParents[i], Vector3.zero, .15f);
            }

        }
        LeanTween.scale(hintImage.gameObject, Vector3.zero, .15f);
    }

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
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
}
