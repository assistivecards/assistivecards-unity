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
    [SerializeField] public List<GameObject> cards = new List<GameObject>();
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();

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
            card.transform.parent = this.transform;
            card.transform.GetChild(0).name = cardNames[cardImageRandom];
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
        }
    }
}
