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
    [SerializeField] private CardCrushGrid cardCrushGrid;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();

    public int cardTypeCount;
    public bool isBoardCreated = false;

    private int tempRandomValue;
    private List<int> randomValues = new List<int>();
    private string packSlug;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();

        cachedCards = await gameAPI.GetCards("en", _packSlug);

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
            else
            {
                CreateRandomValue();
            }

        }
    }
    private void Start() {
        GenerateBoard("animals");
    }

    private async void  GenerateBoard(string _packSlug)
    {
        await CacheCards(_packSlug);
        CreateRandomValue();
        packSlug = _packSlug;

        for(int i = 0; i < cardCrushGrid.allCells.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab, cardCrushGrid.allCells[i].transform.position, Quaternion.identity);
            
            int cardImageRandom = randomValues[Random.Range(0,cardTypeCount)];
            var cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[cardImageRandom], 512);

            card.transform.name = cardNames[cardImageRandom];
            card.transform.parent = cardCrushGrid.allCells[i].transform;
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

            cardCrushGrid.allCells[i].card = card;

            card.GetComponent<CardElement>().x = cardCrushGrid.allCells[i].x;
            card.GetComponent<CardElement>().y = cardCrushGrid.allCells[i].y;
            card.GetComponent<CardElement>().type = cardNames[cardImageRandom];

            int maxIterations = 0;
            while(FindVerticalMatchesAtBeginning(i) && maxIterations < 50)
            {   
                cardImageRandom = randomValues[Random.Range(0,cardTypeCount)];
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
            while(FindHorizontalMatchesAtBeginning(i) && maxIterations < 50)
            {   
                cardImageRandom = randomValues[Random.Range(0,cardTypeCount)];
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
        isBoardCreated = true;
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

    void FixedUpdate()
    {
        if(isBoardCreated)
            RefillBoard();
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

                card.transform.name = cardNames[cardImageRandom];
                card.transform.parent = cell.transform;
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

                cell.card = card;

                card.GetComponent<CardElement>().x = cell.x;
                card.GetComponent<CardElement>().y = cell.y;
                card.GetComponent<CardElement>().type = cardNames[cardImageRandom];
            }
            else
            {
                
            }
        }
    }
}
