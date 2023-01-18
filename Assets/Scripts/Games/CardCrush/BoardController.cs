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

    [SerializeField] private GameObject tempcardElement;
    [SerializeField] private List<GameObject> cards = new List<GameObject>();
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cardTextures;
    private List<Sprite> cardSprites = new List<Sprite>();

    public int cardCount;
    public int cardTypeCount;

    private int tempRandomValue;
    private List<int> randomValues = new List<int>();

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start() {
        GenerateBoard("animals");
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

        for(int i = 0; i < cardCount; i ++)
        {
            cards.Add(Instantiate(tempcardElement, Vector3.zero, Quaternion.identity));
            cards[i].transform.parent = this.transform;
            cards[i].transform.localScale = Vector3.one * 1.5f;
            //Debug.Log(cardsList[randomValues[Random.Range(0,3)]].title);
            var cardTexture = await gameAPI.GetCardImage("animals", cardNames[randomValues[Random.Range(0,cardTypeCount)]], 512);
            cards[i].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
        }
    }

    private async void GenerateBoard(string _packSlug)
    {
        GenerateBoardAsync(_packSlug);
    }
}
