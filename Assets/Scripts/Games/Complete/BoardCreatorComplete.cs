using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardCreatorComplete : MonoBehaviour
{
    GameAPI gameAPI;
    public string selectedLangCode;

    AssistiveCardsSDK.AssistiveCardsSDK.Cards cardDefinitions;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cardTextures;
    private List<string> cardNames = new List<string>();
    private List<string> cardDefinitionsLocale = new List<string>();

    private int tempRandomValue;
    private int randomValue;
    public List<int> randomValueList = new List<int>();


    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject actualCardPrefab;
    public List<GameObject> cards  = new List<GameObject>();
    [SerializeField] private Transform card1Position;
    [SerializeField] private Transform card2Position;
    public int cardCount;
    public string packSlug;
    public bool isBoardCreated = false;


    private void OnEnable()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();
        cardDefinitions = await gameAPI.GetCards(selectedLangCode, _packSlug);
        cardTextures = await gameAPI.GetCards("en", _packSlug);

        await GenerateRandomBoardAsync(_packSlug);
        packSlug = _packSlug;
    }

    private void CheckRandom()
    {
        tempRandomValue = Random.Range(0, cardTextures.cards.Length);

        if(randomValueList.IndexOf(tempRandomValue) < 0)
        {
            randomValue = tempRandomValue;
            randomValueList.Add(randomValue);
            Debug.Log(randomValue);
        }
        else
        {
            CheckRandom();
        }
    }

    public async Task GenerateRandomBoardAsync(string packSlug)
    {
        for(int x = 0; x < cardCount; x++)
        {
            CheckRandom();
        }

        for(int i = 0; i< cardTextures.cards.Length; i++)
        {
            cardNames.Add(cardTextures.cards[i].title.ToLower().Replace(" ", "-"));
            cardDefinitionsLocale.Add(cardDefinitions.cards[i].title);
        }

        for(int j = 0; j < cardCount; j++)
        {
            var cardName = cardNames[randomValueList[j]];
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardName, 512);

            cards.Add(Instantiate(cardPrefab, Vector3.zero, Quaternion.identity));
            cards[j].transform.parent = this.transform;

            cards[j].transform.name = "Card" + j;

            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            cards[j].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            cards[j].transform.GetChild(0).GetComponent<RawImage>().color = Color.black;
            cards[j].GetComponent<CardElementComplete>().cardType = cardName;
        }
        GenerateCardFirst(packSlug, 3);
        GenerateCardSecond(packSlug, 4);

        isBoardCreated = true;
    }

    public async void GenerateCardFirst(string packSlug, int random)
    {
        Debug.Log("generate");
        var cardName = cardNames[randomValueList[random]];
        var cardTexture = await gameAPI.GetCardImage(packSlug, cardName, 512);

        for(int i = 0; i< cardTextures.cards.Length; i++)
        {
            cardNames.Add(cardTextures.cards[i].title.ToLower().Replace(" ", "-"));
            cardDefinitionsLocale.Add(cardDefinitions.cards[i].title);
        }

        var card = Instantiate(actualCardPrefab, card1Position.position, Quaternion.identity);

        cards.Add(card);
        card.transform.parent = card1Position;
        card.transform.name = "Card" + random;
        card.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);

        cardTexture.wrapMode = TextureWrapMode.Clamp;
        cardTexture.filterMode = FilterMode.Bilinear;

        card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
        card.transform.GetChild(0).transform.localScale = Vector3.one;
        card.GetComponent<CardElementComplete>().cardType = cardName;
        card.GetComponent<CardElementComplete>().moveable = true;
    } 

    public async void GenerateCardSecond(string packSlug, int random)
    {
        var cardName = cardNames[randomValueList[random]];
        var cardTexture = await gameAPI.GetCardImage(packSlug, cardName, 512);

        for(int i = 0; i< cardTextures.cards.Length; i++)
        {
            cardNames.Add(cardTextures.cards[i].title.ToLower().Replace(" ", "-"));
            cardDefinitionsLocale.Add(cardDefinitions.cards[i].title);
        }

        var card = Instantiate(actualCardPrefab, card2Position.position, Quaternion.identity);

        cards.Add(card);
        card.transform.parent = card2Position;
        card.transform.name = "Card" + random;
        card.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);

        cardTexture.wrapMode = TextureWrapMode.Clamp;
        cardTexture.filterMode = FilterMode.Bilinear;

        card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
        card.transform.GetChild(0).transform.localScale = Vector3.one;
        card.GetComponent<CardElementComplete>().cardType = cardName;
        card.GetComponent<CardElementComplete>().moveable = true;
    } 
}
