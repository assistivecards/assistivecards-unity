using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardBlastFillGrid : MonoBehaviour
{
    GameAPI gameAPI;
    public string selectedLangCode;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private SoundController soundController;
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    [SerializeField] private CardCrushGrid cardCrushGrid;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private GameObject scoreObj;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private CardBlastUIController UIController;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();

    public bool canMatch = true;

    public int cardTypeCount;
    public bool isBoardCreated = false;

    private int tempRandomValue;
    private List<int> randomValues = new List<int>();
    private string packSlug;
    public List<GameObject> matchedCards = new List<GameObject>();
    public List<string> matchedCardName = new List<string>();

    public bool isOnRefill = false;
    public int scoreInt = 0;
    public bool isOnGame = false;
    private RectTransform rect;

    public List<CardCrushCell> topCells = new List<CardCrushCell>();
    public List<CardCrushCell> bottomCells = new List<CardCrushCell>();
    private Vector3 startPosition;
    public List<GameObject> moveableCards = new List<GameObject>();
    public List<GameObject> matcheableCards = new List<GameObject>();
    private bool oneTime = false;

    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    public List<string> cardLocalNames = new List<string>();

    bool sfxOneTime = true;
    bool onBottomReset = true;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        rect = GetComponent<RectTransform>();
        startPosition = transform.position;
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();

        cachedCards = await gameAPI.GetCards("en", _packSlug);
        cachedLocalCards = await gameAPI.GetCards(selectedLangCode, _packSlug);
        packSlug = _packSlug;

        cardsList = cachedCards.cards.ToList();

        for(int i = 0; i < cachedCards.cards.Length; i++)
        {
            cardNames.Add(cachedCards.cards[i].title.ToLower().Replace(" ", "-"));
            cardLocalNames.Add(cachedLocalCards.cards[i].title);
        }
    }

    private void CreateRandomValue()
    {
        for(int i = 0; i <= cardTypeCount; i++)
        {
            tempRandomValue = Random.Range(0, cardsList.Count);

            if(!randomValues.Contains(tempRandomValue))
            {
                randomValues.Add(tempRandomValue);
            }
            else if(randomValues.Contains(tempRandomValue))
            {
                tempRandomValue = Random.Range(0, cardsList.Count);

                if(!randomValues.Contains(tempRandomValue))
                {
                    randomValues.Add(tempRandomValue);
                }
                else
                {
                    CreateRandomValue();
                }
            }

        }
    }

    public void GeneratStylized()
    {
        GenerateBoard(packSelectionPanel.selectedPackElement.name);
        GetTopCells();
        GetBottomCells();
        canMatch = true;
        loadingScreen.SetActive(true);
    }

    private async void  GenerateBoard(string _packSlug)
    {
        isOnGame = true;
        await CacheCards(_packSlug);
        CreateRandomValue();
        for(int i = 0; i < cardCrushGrid.allCells.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab, cardCrushGrid.allCells[i].transform.position, Quaternion.identity);
            
            int cardImageRandom = randomValues[Random.Range(0, cardTypeCount)];
            var cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[cardImageRandom], 512);

            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            card.transform.name = cardNames[cardImageRandom];
            card.transform.SetParent(cardCrushGrid.allCells[i].transform);
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

            cardCrushGrid.allCells[i].card = card;

            card.GetComponent<CardBlastElement>().x = cardCrushGrid.allCells[i].x;
            card.GetComponent<CardBlastElement>().y = cardCrushGrid.allCells[i].y;
            card.GetComponent<CardBlastElement>().type = cardNames[cardImageRandom];
            card.GetComponent<CardBlastElement>().localName = cardLocalNames[cardImageRandom];
            card.transform.localPosition = Vector3.zero;
            LeanTween.scale(card, Vector3.one, 0.5f);
        }

        foreach(var cell in cardCrushGrid.allCells)
        {
            cell.GetComponent<CardCrushCell>().DetectNeighbourCells();
            cell.GetComponent<CardCrushCell>().DetectNeighboursAround();
        }
        LeanTween.scale(this.gameObject, new Vector2(0.75f, 0.75f), 0.1f);
        SetLeft(rect, -127);
        UIController.Invoke("TutorialSetActive", 2f);
        loadingScreen.SetActive(false);
        isBoardCreated = true;

        Invoke("SetCardPositions", 0.25f);
    }

    private void FixedUpdate() 
    {
        matcheableCards.RemoveAll(item => item == null);
        if(matcheableCards.Count == 0 && cardTypeCount > 3 && isBoardCreated)
        {
            ResetBottomCells();
        }
        if(scoreInt < 0)
        {
            scoreInt = 0;
        }
        scoreObj.GetComponent<TMP_Text>().text = scoreInt.ToString() + "/100";
        if(scoreInt >= 100)
        {
            Invoke("SetIsOnGameFalse", 0.75f);
        }
    }

    private void SetIsOnGameFalse()
    {
        isOnGame = false;
    }

    public async void RefillBoardsTop()
    {
        foreach(var cell in cardCrushGrid.allCells)
        {
            if(cell.isEmpty == true && cell.y == 3 && isBoardCreated)
            {
                cell.isEmpty = false;
                GameObject card = Instantiate(cardPrefab, cell.transform.position, Quaternion.identity);
                
                int cardImageRandom = randomValues[Random.Range(0, cardTypeCount)];
                var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[cardImageRandom], 512);
                
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;
                
                if(card != null)
                {
                    card.transform.name = cardNames[cardImageRandom];
                    card.transform.SetParent(cell.transform);
                    card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

                    cell.card = card;
                    card.GetComponent<CardBlastElement>().x = cell.x;
                    card.GetComponent<CardBlastElement>().y = cell.y;
                    card.GetComponent<CardBlastElement>().type = cardNames[cardImageRandom];
                    card.GetComponent<CardBlastElement>().localName = cardLocalNames[cardImageRandom];
                    LeanTween.scale(card, Vector3.one, 0.5f);
                }
            }
        }

        foreach(var cell in cardCrushGrid.allCells)
        {
            if(cell.card != null)
                cell.card.GetComponent<CardBlastElement>().canMatch.Clear();
        }

        Invoke("OnRefillBool", 0.5f);
    }

    public async void RefillBoard()
    {
        foreach(var cell in cardCrushGrid.allCells)
        {
            if(cell.isEmpty == true)
            {
                cell.isEmpty = false;
                GameObject card = Instantiate(cardPrefab, cell.transform.position, Quaternion.identity);
                
                int cardImageRandom = randomValues[Random.Range(0, cardTypeCount)];
                var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[cardImageRandom], 512);
                
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;
                
                if(card != null)
                {
                    card.transform.name = cardNames[cardImageRandom];
                    card.transform.SetParent(cell.transform);
                    card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

                    cell.card = card;
                    card.GetComponent<CardBlastElement>().x = cell.x;
                    card.GetComponent<CardBlastElement>().y = cell.y;
                    card.GetComponent<CardBlastElement>().type = cardNames[cardImageRandom];
                    card.GetComponent<CardBlastElement>().localName = cardLocalNames[cardImageRandom];
                    LeanTween.scale(card, Vector3.one, 0.5f);
                }
            }
        }

        foreach(var cell in cardCrushGrid.allCells)
        {
            if(cell.card != null)
                cell.card.GetComponent<CardBlastElement>().canMatch.Clear();
        }

        Invoke("OnRefillBool", 0.5f);
    }

    private void OnRefillBool()
    {
        isOnRefill = false;
    }

    public void SetBoardDifficulty(int _cardTypeCount)
    {
        cardTypeCount = _cardTypeCount;
    }

    private void GetTopCells()
    {
        foreach(var cell in cardCrushGrid.allCells)
        {
            if(cell.y > 2)
            {
                topCells.Add(cell);
            }
        }   
    }

    private void GetBottomCells()
    {
        foreach(var cell in cardCrushGrid.allCells)
        {
            if(cell.y == 0)
            {
                bottomCells.Add(cell);
            }
        }   
    }

    public void ResetGrid()
    {
        foreach(var cell in cardCrushGrid.allCells)
        {
            Destroy(cell.card.gameObject);
            cell.neighbours.Clear();
            cell.horizontalNeighboursLeft.Clear();
            cell.horizontalNeighboursRight.Clear();
            cell.verticalNeightboursBottom.Clear();
            cell.verticalNeightboursTop.Clear();
            matcheableCards.Clear();

            cardNames.Clear();
            randomValues.Clear();
            matchedCards.Clear();
        }
    }

    private void SetCardPositions()
    {
        foreach(var cell in cardCrushGrid.allCells)
        {
            if(cell.card != null)
            {
                cell.card.transform.localPosition = Vector3.zero;
            }
        }
    }

    public void ResetPosition()
    {
        SetLeft(rect, 10000);
    }

    public static void SetLeft(RectTransform _rect, float left)
    {
        _rect.offsetMin = new Vector2(left, _rect.offsetMin.y);
    }

    public static void SetBottom(RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }

    private void ResetBottomCells()
    {
        if(onBottomReset && isBoardCreated)
        {
            onBottomReset = false;
            foreach(var cell in bottomCells)
            {
                if(cell.card != null)
                {
                    if(cell.card.GetComponent<CardBlastElement>() != null)
                    {
                        cell.card.GetComponent<CardBlastElement>().DestroyCard();
                    }
                }
            }
            matcheableCards.Clear();
            Invoke("SetResetBottomTrue", 1f);
        }
    }

    private void SetResetBottomTrue()
    {
        onBottomReset = true;
    }

    private async void ResetScene()
    {
        if(!canMatch && !oneTime && cardTypeCount > 3)
        {
            canMatch = true;
            ResetPosition();
            ResetGrid();
            GeneratStylized();
            oneTime = true;
            Invoke("OneTimeFalse", 2f);
        }
    }

    private void OneTimeFalse()
    {
        oneTime = false;
    }
}

