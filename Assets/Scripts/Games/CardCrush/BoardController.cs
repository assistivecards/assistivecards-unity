using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardController : MonoBehaviour
{
    GameAPI gameAPI;
    private GameObject cardElement;
    public string selectedLangCode;

    [SerializeField] private CardTileInformation cardTileInformation;
    [SerializeField] private GameObject tempcardElement;
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    [SerializeField] public List<GameObject> cards = new List<GameObject>();
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    [SerializeField] private GridGenerator gridGenerator;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cardTextures;
    private List<Sprite> cardSprites = new List<Sprite>();

    public int cardTypeCount;

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

    private async Task GenerateBoardAsync(string _packSlug)
    {
        await CacheCards(_packSlug);
        CreateRandomValue();
        packSlug = _packSlug;

        for(int i = 0; i < gridGenerator.gridWidth * gridGenerator.gridHeight; i ++)
        {
            int cardImageRandom = randomValues[Random.Range(0,cardTypeCount)];
            cards.Add(Instantiate(tempcardElement, gridGenerator.gridTiles[i].transform.position, Quaternion.identity));
            cards[i].transform.parent = this.transform;
            cards[i].transform.localScale = Vector3.one * 0.5f;

            cards[i].GetComponent<CardTileInformation>().xValue = gridGenerator.gridTiles[i].GetComponent<Tile>().x;
            cards[i].GetComponent<CardTileInformation>().yValue = gridGenerator.gridTiles[i].GetComponent<Tile>().y;
            cards[i].GetComponent<CardTileInformation>().listNum = i;


            var cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[cardImageRandom], 512);
            cards[i].transform.name = cardNames[cardImageRandom];
            cards[i].transform.GetChild(0).name = cardNames[cardImageRandom];
            cards[i].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            cards[i].GetComponent<CardTileInformation>().type = cardNames[cardImageRandom];
            
            int maxIterations = 0;
            while(FindVerticalMatchesAtBeginning(i) && maxIterations < 50)
            {
                cardImageRandom = randomValues[Random.Range(0,cardTypeCount)];
                cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[cardImageRandom], 512);
                cards[i].transform.name = cardNames[cardImageRandom];
                cards[i].transform.GetChild(0).name = cardNames[cardImageRandom];
                cards[i].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                cards[i].GetComponent<CardTileInformation>().type = cardNames[cardImageRandom];
                maxIterations ++;
            }
            maxIterations = 0;
            while(FindHorizontalMatchesAtBeginning(i) && maxIterations < 50)
            {
                cardImageRandom = randomValues[Random.Range(0,cardTypeCount)];
                cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[cardImageRandom], 512);
                cards[i].transform.name = cardNames[cardImageRandom];
                cards[i].transform.GetChild(0).name = cardNames[cardImageRandom];
                cards[i].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                cards[i].GetComponent<CardTileInformation>().type = cardNames[cardImageRandom];
                maxIterations ++;
            }
            maxIterations = 0;
        }

        foreach(var card in cards)
        {
            card.GetComponent<CardTileInformation>().DetectNeightbours();
        }
    }

    private bool FindVerticalMatchesAtBeginning(int cardNum)
    {
        if(cardNum >= 1)
        {
            if(cards[cardNum].GetComponent<CardTileInformation>().type == cards[cardNum-1].GetComponent<CardTileInformation>().type)
            {
                return true;
            }
            return false;
        }
        return false;
    }

    private bool FindHorizontalMatchesAtBeginning(int cardNum)
    {
        if(cardNum > gridGenerator.gridHeight)
        {
            if(cards[cardNum].GetComponent<CardTileInformation>().type == cards[cardNum - gridGenerator.gridHeight].GetComponent<CardTileInformation>().type)
            {
                return true;
            }
            return false;
        }
        return false;
    }

    private async void GenerateBoard(string _packSlug)
    {
        await GenerateBoardAsync(_packSlug);
    }

    public void GenerateBoardWithSelectedPack()
    {
        GenerateBoard(packSelectionPanel.selectedPackElement.name);
    }

    public async void BoardRefiller(GameObject _emptyCard)
    {
        int cardImageRandom = randomValues[Random.Range(0,cardTypeCount)];
        var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[cardImageRandom], 512);
        _emptyCard.transform.name = cardNames[cardImageRandom];        
        _emptyCard.transform.GetChild(0).name = cardNames[cardImageRandom];
        _emptyCard.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
        _emptyCard.GetComponent<CardTileInformation>().type = cardNames[cardImageRandom];
        _emptyCard.GetComponent<CardTileInformation>().isMatched = false;
    }
}
