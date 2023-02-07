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
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    [SerializeField] private CardCrushGrid cardCrushGrid;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();

    public int cardTypeCount;
    public bool isBoardCreated = false;

    private int tempRandomValue;
    private List<int> randomValues = new List<int>();
    private string packSlug;
    public List<GameObject> matchedCards = new List<GameObject>();
    public List<string> matchedCardName = new List<string>();

    public bool isOnRefill = false;
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
        isOnGame = true;
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
        }

        foreach(var cell in cardCrushGrid.allCells)
        {
            cell.GetComponent<CardCrushCell>().DetectNeighbourCells();
            cell.GetComponent<CardCrushCell>().DetectNeighboursAround();
        }
        isBoardCreated = true;
    }

    public async void RefillBoard()
    {
        gameAPI.PlaySFX("SmallSuccess");
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
                //Debug.Log("Refill is done");
            }
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
        }
    }
}