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
    private Vector3 startPosition;
    
    

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
        packSlug = _packSlug;

        cardsList = cachedCards.cards.ToList();

        for(int i = 0; i < cachedCards.cards.Length; i++)
        {
            cardNames.Add(cachedCards.cards[i].title.ToLower().Replace(" ", "-"));
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
    }

    private async void  GenerateBoard(string _packSlug)
    {
        isOnGame = true;
        await CacheCards(_packSlug);
        CreateRandomValue();
        loadingScreen.SetActive(true);
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
        }

        foreach(var cell in cardCrushGrid.allCells)
        {
            cell.GetComponent<CardCrushCell>().DetectNeighbourCells();
            cell.GetComponent<CardCrushCell>().DetectNeighboursAround();
        }
        LeanTween.scale(this.gameObject, new Vector2(0.75f, 0.75f), 0.1f);
        SetLeft(rect, -124);
        loadingScreen.SetActive(false);
        isBoardCreated = true;
    }

    private void FixedUpdate() 
    {
        if(scoreInt < 0)
        {
            scoreInt = 0;
        }
        scoreObj.GetComponent<TMP_Text>().text = scoreInt.ToString() + "/100";

        if(isBoardCreated)
        {
            foreach(var cell in cardCrushGrid.allCells)
            {
                if(cell.isEmpty)
                {
                    //SpawnNewCard();
                    RefillBoard();
                }
            }
        }
        if(!canMatch)
        {
            Invoke("ResetScene", 0.75f);
        }
        if(scoreInt >= 100)
        {
            isOnGame = false;
        }
    }

    public async void RefillBoard()
    {
        scoreInt += 1;
        gameAPI.PlaySFX("SmallSuccess");
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
                }

            }
        }
        Invoke("OnRefillBool", 0.5f);

    }

    private void CheckPossibleMatch()
    {
        if(isOnGame)
        {
            canMatch = false;
        }
    }

    private void OnRefillBool()
    {
        isOnRefill = false;
        CheckPossibleMatch();
    }

    public void SetBoardDifficulty(int _cardTypeCount)
    {
        cardTypeCount = _cardTypeCount;
    }

    public async void RefillCell(CardCrushCell cell)
    {
        cell.isEmpty = false;
        cell.GetComponent<CardCrushCell>().isEmpty=false;
        GameObject card = Instantiate(cardPrefab, cell.transform.position, Quaternion.identity);
        
        int cardImageRandom = randomValues[Random.Range(0,cardTypeCount)];
        var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[cardImageRandom], 512);

        card.transform.name = cardNames[cardImageRandom];
        card.transform.SetParent(cell.transform);
        card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

        cell.card = card;

        card.GetComponent<CardBlastElement>().x = cell.x;
        card.GetComponent<CardBlastElement>().y = cell.y;
    }

    private async void SpawnNewCard()
    {
        scoreInt += 1;
        foreach(var cell in topCells)
        {
            cell.isEmpty = false;
            cell.GetComponent<CardCrushCell>().isEmpty=false;
            GameObject card = Instantiate(cardPrefab, cell.transform.position, Quaternion.identity);
            
            int cardImageRandom = randomValues[Random.Range(0,cardTypeCount)];
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[cardImageRandom], 512);

            card.transform.name = cardNames[cardImageRandom];
            card.transform.SetParent(cell.transform);
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

            cell.card = card;

            card.GetComponent<CardBlastElement>().x = cell.x;
            card.GetComponent<CardBlastElement>().y = cell.y;
        }
        
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

            cardNames.Clear();
            randomValues.Clear();
            matchedCards.Clear();
        }
    }

    public void ResetPosition()
    {
        SetLeft(rect, 1000000);
    }

    public static void SetLeft(RectTransform _rect, float left)
    {
        _rect.offsetMin = new Vector2(left, _rect.offsetMin.y);
    }

    public static void SetBottom(RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }

    private void ResetScene()
    {
        //canMatch = true;
    }
}
