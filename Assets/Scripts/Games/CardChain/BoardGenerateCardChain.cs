using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardGenerateCardChain : MonoBehaviour
{
    GameAPI gameAPI;
    public string selectedLangCode;

    AssistiveCardsSDK.AssistiveCardsSDK.Cards cardDefinitions;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cardTextures;
    [SerializeField] private PackSelectionPanel packSelectionPanel;

    private int tempRandomValue;
    private int randomValue;

    private List<string> cardNames = new List<string>();
    private List<string> cardDefinitionsLocale = new List<string>();
    public List<GameObject> cards  = new List<GameObject>();
    public List<GameObject> cardPositions  = new List<GameObject>();

    public List<int> randomValueList = new List<int>();
    public List<int> usedRandomValues = new List<int>();

    [SerializeField] private GameObject cardPrefab;
    public int cardCount;
    public string packSlug;
    public bool isBoardCreated = false;


    private void OnEnable()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start() 
    {
        GetChildList();
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();
        cardDefinitions = await gameAPI.GetCards(selectedLangCode, _packSlug);
        cardTextures = await gameAPI.GetCards("en", _packSlug);
        await GenerateRandomBoardAsync(_packSlug);
        packSlug = _packSlug;
    }

    private void GetChildList()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            cardPositions.Add(transform.GetChild(i).gameObject);
        }
    }

    private void CheckRandom()
    {
        tempRandomValue = Random.Range(0, cardTextures.cards.Length);

        if(randomValueList.IndexOf(tempRandomValue) < 0)
        {
            randomValue = tempRandomValue;
            randomValueList.Add(randomValue);
        }
        else
        {
            CheckRandom();
        }
    }

    public async Task GenerateRandomBoardAsync(string packSlug)
    {
        for(int x = 0; x < 6; x++)
        {
            CheckRandom();
        }

        for(int i = 0; i < cardTextures.cards.Length; i++)
        {
            cardNames.Add(cardTextures.cards[i].title.ToLower().Replace(" ", "-"));
            cardDefinitionsLocale.Add(cardDefinitions.cards[i].title);
        }

        for(int j = 0; j < cardCount; j++)
        {
            cards.Add(Instantiate(cardPrefab, Vector3.zero, Quaternion.identity));
            cards[j].transform.parent = this.transform;
            cards[j].transform.name = "Card" + j;
            var randomElement = randomValueList[Random.Range(0, randomValueList.Count)];
            var cardName = cardNames[randomElement];
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardName, 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;
            cards[j].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

            var randomElement2 = randomValueList[Random.Range(0, randomValueList.Count)];
            var cardName2 = cardNames[randomValueList[Random.Range(0, randomValueList.Count)]];
            while(cardName2 == cardName)
            {
                cardName2 = cardNames[randomValueList[Random.Range(0, randomValueList.Count)]];
            }
            var cardTexture2 = await gameAPI.GetCardImage(packSlug, cardName2, 512);
            cardTexture2.wrapMode = TextureWrapMode.Clamp;
            cardTexture2.filterMode = FilterMode.Bilinear;
            cards[j].transform.GetChild(1).GetComponent<RawImage>().texture = cardTexture2;

            cards[j].transform.position = cardPositions[j].transform.position;
            LeanTween.scale(cards[j], Vector3.one * 0.5f, 0);
        }
        Invoke("FillCardSlot", 0.5f);
        isBoardCreated = true;
    }

    public async void CreateBoard()
    {
        await CacheCards(packSelectionPanel.selectedPackElement.name);
    }
}
