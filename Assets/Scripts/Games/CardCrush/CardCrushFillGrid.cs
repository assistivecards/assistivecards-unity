using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardCrushFillGrid : MonoBehaviour
{
    GameAPI gameAPI;
    public string selectedLangCode;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    [SerializeField] private CardCrushGrid cardCrushGrid;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private GameObject scoreObj;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();

    public int cardTypeCount;
    public bool isBoardCreated = false;

    private int tempRandomValue;
    private List<int> randomValues = new List<int>();
    private string packSlug;
    public List<GameObject> matchedCards = new List<GameObject>();

    public bool isOnRefill = false;
    public int scoreInt = 0;
    public bool isOnGame = false;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
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
    }

    private async void  GenerateBoard(string _packSlug)
    {
        await CacheCards(_packSlug);
        CreateRandomValue();

        for(int i = 0; i < cardCrushGrid.allCells.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab, cardCrushGrid.allCells[i].transform.position, Quaternion.identity);
            
            int cardImageRandom = randomValues[Random.Range(0, cardTypeCount)];
            var cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[cardImageRandom], 512);

            card.transform.name = cardNames[cardImageRandom];
            card.transform.SetParent(cardCrushGrid.allCells[i].transform);
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

            cardCrushGrid.allCells[i].card = card;

            card.GetComponent<CardElement>().x = cardCrushGrid.allCells[i].x;
            card.GetComponent<CardElement>().y = cardCrushGrid.allCells[i].y;
            card.GetComponent<CardElement>().type = cardNames[cardImageRandom];

            int maxIterations = 0;
            while(FindVerticalMatchesAtBeginning(i) && maxIterations < 100)
            {   
                cardImageRandom = randomValues[Random.Range(0, cardTypeCount)];
                cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[cardImageRandom], 512);

                card.transform.name = cardNames[cardImageRandom];
                card.transform.parent = cardCrushGrid.allCells[i].transform;
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

                cardCrushGrid.allCells[i].card = card;

                card.GetComponent<CardElement>().x = cardCrushGrid.allCells[i].x;
                card.GetComponent<CardElement>().y = cardCrushGrid.allCells[i].y;
                card.GetComponent<CardElement>().type = cardNames[cardImageRandom];
                maxIterations ++;
            }

            maxIterations = 0;
            while(FindHorizontalMatchesAtBeginning(i) && maxIterations < 100)
            {   
                cardImageRandom = randomValues[Random.Range(0, cardTypeCount)];
                cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[cardImageRandom], 512);

                card.transform.name = cardNames[cardImageRandom];
                card.transform.parent = cardCrushGrid.allCells[i].transform;
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

                cardCrushGrid.allCells[i].card = card;

                card.GetComponent<CardElement>().x = cardCrushGrid.allCells[i].x;
                card.GetComponent<CardElement>().y = cardCrushGrid.allCells[i].y;
                card.GetComponent<CardElement>().type = cardNames[cardImageRandom];
                maxIterations ++;
            }

            maxIterations = 0;

        }

        foreach(var cell in cardCrushGrid.allCells)
        {
            cell.GetComponent<CardCrushCell>().DetectNeighbourCells();
            cell.GetComponent<CardCrushCell>().DetectNeighboursAround();
        }
        isBoardCreated = true;
        isOnGame = true;
    }
    private bool FindVerticalMatchesAtBeginning(int i)
    {
        if(i > 1)
        {
            if(cardCrushGrid.allCells[i].card.GetComponent<CardElement>().type == cardCrushGrid.allCells[i - 1].card.GetComponent<CardElement>().type)
            {
                return true;
            }
            return false;
        }
        return false;
    }

    private bool FindHorizontalMatchesAtBeginning(int i)
    {
        if(i > cardCrushGrid.height)
        {
            if(cardCrushGrid.allCells[i].card.GetComponent<CardElement>().type == cardCrushGrid.allCells[i - cardCrushGrid.height].card.GetComponent<CardElement>().type)
            {
                return true;
            }
            return false;
        }
        return false;
    }

    public async void RefillBoard()
    {
        scoreInt += 1;
        foreach(var cell in cardCrushGrid.allCells)
        {
            if(cell.isEmpty == true)
            {
                cell.isEmpty = false;
                GameObject card = Instantiate(cardPrefab, cell.transform.position, Quaternion.identity);
                
                int cardImageRandom = randomValues[Random.Range(0, cardTypeCount)];
                var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[cardImageRandom], 512);

                card.transform.name = cardNames[cardImageRandom];
                card.transform.SetParent(cell.transform);
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

                cell.card = card;

                card.GetComponent<CardElement>().x = cell.x;
                card.GetComponent<CardElement>().y = cell.y;
                card.GetComponent<CardElement>().type = cardNames[cardImageRandom];
                Debug.Log("Refill is done");
            }
        }
        Invoke("OnRefillBool", 1f);

    }

    private void OnRefillBool()
    {
        isOnRefill = false;
    }

    private void FixedUpdate() 
    {
        if(scoreInt < 0)
        {
            scoreInt = 0;
        }
        scoreObj.GetComponent<TMP_Text>().text = scoreInt.ToString() + "/100";
        
        if(isBoardCreated && scoreInt < 100)
        {
            foreach(var cell in cardCrushGrid.allCells)
            {
                if(cell.isEmpty)
                {
                    RefillBoard();
                }
            }
        }
        if(scoreInt >= 100)
        {
            isOnGame = false;
        }
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

        card.GetComponent<CardElement>().x = cell.x;
        card.GetComponent<CardElement>().y = cell.y;
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
            scoreInt = 0;
        }
    }
}
