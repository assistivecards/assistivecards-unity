using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using PathCreation;

public class BoardGeneratorFollowPath : MonoBehaviour
{
    GameAPI gameAPI;

    [SerializeField] private UIControllerFollowPath uıController;

    [Header ("Cache Cards")]
    public string selectedLangCode;
    public List<GameObject> cards = new List<GameObject>();
    public AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    public List<string> cardNames = new List<string>();
    public List<string> cardLocalNames = new List<string>();
    public List<Texture2D> prefetchedCardTextures = new List<Texture2D>();
    public List<string> prefetchedCardNames = new List<string>();
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    public string packSlug;

    [Header ("Random")]
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Game UI")]
    public List<Texture> cardTextures = new List<Texture>();
    private GameObject stablePosition;
    private GameObject cardPosition1;
    private GameObject cardPosition2;
    private GameObject cardPosition3;
    private List<GameObject> cardPositions = new List<GameObject>();
    [SerializeField] private GameObject path;
    [SerializeField] private GameObject alternativePath1;
    [SerializeField] private GameObject alternativePath2;
    [SerializeField] private GameObject alternativePath3;
    [SerializeField] private GameObject alternativePath4;
    [SerializeField] private GameObject alternativePath5;
    [SerializeField] private GameObject alternativePath6;
    private GameObject correctPath;
    private GameObject generalPath;
    private GameObject correctCard;
    private GameObject correctCardPosition;

    [Header ("Game Values")]
    public List<GameObject> generalPathElements = new List<GameObject>();
    public List<GameObject> correctPathElements = new List<GameObject>();
    public List<GameObject> selectedPathElements = new List<GameObject>();
    public List<GameObject> alternativePaths = new List<GameObject>();
    public List<int> usedRandomOrderCards = new List<int>();
    public int cardCount;
    public int maxLevelCount;
    public int levelCount;
    public int prefetchedCardsCount;
    private string cardName;
    public int randomOrder;
    public int cardNameLenght;
    public int matchedCardCount;
    public bool isPointerUp;
    public bool finished;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        gameAPI.PlayMusic();
    }

     public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();

        cachedCards = await gameAPI.GetCards("en", _packSlug);
        cachedLocalCards = await gameAPI.GetCards(selectedLangCode, _packSlug);

        cardsList = cachedCards.cards.ToList();

        for(int i = 0; i < cachedCards.cards.Length; i++)
        {
            cardNames.Add(cachedCards.cards[i].title.ToLower().Replace(" ", "-"));
            cardLocalNames.Add(cachedLocalCards.cards[i].title);
        }
    }

    public async void PrefetchCardTextures()
    {
        if(uıController.canGenerate)
        {
            packSlug = packSelectionPanel.selectedPackElement.name;
            randomValueList.Clear();
            prefetchedCardTextures.Clear();
            prefetchedCardNames.Clear();
            levelCount = 0;
            await CacheCards(packSlug);
            if(cardNames.Count >= (cardCount * maxLevelCount))
            {
                prefetchedCardsCount = (cardCount * maxLevelCount);
            }
            else
            {
                prefetchedCardsCount = cardNames.Count;
            }
            for(int i = 0; i < prefetchedCardsCount; i++)
            {
                CheckRandom();
            }
            PrefetchNextLevelsTexturesAsync();
        }
    }

    private void CheckRandom()
    {
        tempRandomValue = Random.Range(0, cardsList.Count);

        if(!randomValueList.Contains(tempRandomValue))
        {
            randomValue = tempRandomValue;
            randomValueList.Add(randomValue);
        }
        else
        {
            CheckRandom();
        }
    }

    private void CreateCardPositionList()
    {
        int index = 0;
        alternativePaths.Add(alternativePath1);
        alternativePaths.Add(alternativePath2);
        alternativePaths.Add(alternativePath3);
        alternativePaths.Add(alternativePath4);
        alternativePaths.Add(alternativePath5);
        alternativePaths.Add(alternativePath6);

        path = alternativePaths[Random.Range(0, alternativePaths.Count)];
        path.SetActive(true);

        generalPath = path.transform.GetChild(0).gameObject;
        foreach(Transform child in generalPath.transform)
        {
            generalPathElements.Add(child.gameObject);
            child.gameObject.GetComponent<PathPartControllerFollowPath>().isGeneralPathElement = true;
        }

        correctPath = path.transform.GetChild(1).gameObject;
        foreach(Transform child in correctPath.transform)
        {
            correctPathElements.Add(child.gameObject);
            child.gameObject.GetComponent<PathPartControllerFollowPath>().isCorrectPathElement = true;
        }
        stablePosition = path.GetComponent<PathControllerFollowPath>().stablePosition;
        correctCardPosition = path.GetComponent<PathControllerFollowPath>().correctCardPosition;
        cardPosition1 = path.GetComponent<PathControllerFollowPath>().wrongCardPosition1;
        cardPosition2 = path.GetComponent<PathControllerFollowPath>().wrongCardPosition2;

        cardPositions.Add(stablePosition);
        cardPositions.Add(cardPosition1);
        cardPositions.Add(cardPosition2);
    }

    public async void GeneratedBoardAsync()
    {
        finished = false;
        if(uıController.canGenerate)
        {
            CreateCardPositionList();
            for(int i = 0; i < 3; i++)
            {
                GameObject card = Instantiate(cardPrefab, cardPositions[i].transform.position, Quaternion.identity);
                var cardTexture = prefetchedCardTextures[i + (levelCount * cardCount)];
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;
                cardTextures.Add(cardTexture);
                card.transform.SetParent(cardPositions[i].transform);
                card.transform.name = prefetchedCardNames[i + (levelCount * cardCount)];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.GetComponent<CardControllerFollowPath>().isCorrect = false;
                cards.Add(card);
                card.transform.localScale = new Vector3(0.45f, 0.45f, 0f);
                card.transform.localPosition = Vector3.zero;
            }

            correctCard = Instantiate(cardPrefab, correctCardPosition.transform.position, Quaternion.identity);
            var correctCardTexture = prefetchedCardTextures[(levelCount * cardCount)];
            correctCardTexture.wrapMode = TextureWrapMode.Clamp;
            correctCardTexture.filterMode = FilterMode.Bilinear;
            cardTextures.Add(correctCardTexture);
            correctCard.transform.SetParent(correctCardPosition.transform);
            correctCard.transform.name = prefetchedCardNames[(levelCount * cardCount)];
            correctCard.transform.GetChild(0).GetComponent<RawImage>().texture = correctCardTexture;
            correctCard.GetComponent<CardControllerFollowPath>().isCorrect = true;
            cards.Add(correctCard);
            correctCard.transform.localScale = new Vector3(0.45f, 0.45f, 0f);
            correctCard.transform.localPosition = Vector3.zero;
        }
        GameUIActivate();
    }

    public void GameUIActivate()
    {
        foreach(var card in cards)
        {
            LeanTween.scale(card, Vector3.one * 0.45f, 0.3f);
        }
        uıController.GameUIActivate();
    }

    private void CreateNewLevel()
    {
        ClearBoard();
        GeneratedBoardAsync();
    }

    private void GameUIScaleDown()
    {
        foreach(var card in cards)
        {
            LeanTween.scale(card, Vector3.zero, 0.3f);
        }
        uıController.Invoke("GameUIDeactivate", 0.3f);
        Invoke("ClearBoard", 0.3f);
    }

    public void CheckPath()
    {
        bool correctPathSelected = true;
        foreach(var element in correctPathElements)
        {
            if(!selectedPathElements.Contains(element))
            {
                correctPathSelected = false;
            }
        }

        if(!correctPathSelected)
        {
            foreach(var element in selectedPathElements)
            {
                element.GetComponent<PathPartControllerFollowPath>().ResetColor();
                element.GetComponent<PathPartControllerFollowPath>().selected = false;
            }
            selectedPathElements.Clear();
        }
        else
        {
            correctCard.GetComponent<CardControllerFollowPath>().isAllCorrectSelected = true;
            levelCount++;
        }

    }

    public void CheckLevelEnding()
    {

    }

    private void LevelEndAnimation()
    {
        foreach(var card in cards)
        {
            LeanTween.scale(card, Vector3.zero, 0.5f);
        }
        Invoke("ClearBoard", 0.5f);
    }

    private void PlaySuccess()
    {
        gameAPI.PlaySFX("Success");
    }

    public void ClearBoard()
    {
        matchedCardCount = 0;
        foreach(var card in cards)
        {
            Destroy(card);
        }
        cardLocalNames.Clear();
        cards.Clear();
        cardNames.Clear();
        randomValueList.Clear();
        usedRandomOrderCards.Clear();
        cardTextures.Clear();
        cardPositions.Clear();
        levelCount++;
        if(levelCount >= maxLevelCount)
        {
            uıController.LevelChangeScreenActivate();
            levelCount = 0;
        }
        else
        {
            uıController.GameUIDeactivate();
            uıController.LoadingScreenActivation();
            GeneratedBoardAsync();
        }
    }

    public void BackButtonClear()
    {
        matchedCardCount = 0;
        foreach(var card in cards)
        {
            Destroy(card);
        }
        cardLocalNames.Clear();
        cards.Clear();
        cardNames.Clear();
        randomValueList.Clear();
        usedRandomOrderCards.Clear();
        cardTextures.Clear();
        cardPositions.Clear();
        uıController.PackSelectionPanelActive();
    }

    private async Task PrefetchNextLevelsTexturesAsync()
    {
        for(int i = 0; i < prefetchedCardsCount; i++)
        {
            prefetchedCardNames.Add(cardLocalNames[randomValueList[i]]);
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[randomValueList[i]], 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;
            prefetchedCardTextures.Add(cardTexture);
            Debug.Log(cardNames[randomValueList[i]]);
        }
        Invoke("GeneratedBoardAsync", 2f);
        uıController.Invoke("SetTutorialActive", 2.1f);
    }
}
