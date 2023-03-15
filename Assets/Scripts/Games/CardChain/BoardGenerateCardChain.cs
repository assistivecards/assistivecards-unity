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

    public List<string> cardNames = new List<string>();
    public List<string> cardDefinitionsLocale = new List<string>();
    public List<GameObject> cards  = new List<GameObject>();
    public List<GameObject> cardPositions  = new List<GameObject>();

    public List<int> randomValueList = new List<int>();
    public List<int> usedRandomValues = new List<int>();

    [SerializeField] private GameObject cardParent;
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

    private void SuffleList()
    {
        for(int i = 0; i < cardNames.Count; i++)
        {   
            var random = Random.Range(0, cardNames.Count);
            cardNames[i] = cardNames[random];
            cardDefinitionsLocale[i] = cardDefinitionsLocale[random];
        }
    }

    public async Task GenerateRandomBoardAsync(string packSlug)
    {
        for(int x = 0; x < 12; x++)
        {
            CheckRandom();
        }

        for(int i = 0; i < cardTextures.cards.Length; i++)
        {
            cardNames.Add(cardTextures.cards[i].title.ToLower().Replace(" ", "-"));
            cardDefinitionsLocale.Add(cardDefinitions.cards[i].title);
        }
        SuffleList();
        for(int j = 0; j < cardCount; j++)
        {
            cards.Add(Instantiate(cardParent, Vector3.zero, Quaternion.identity));
            cards[j].transform.parent = this.transform;


            var card1 = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);
            card1.transform.SetParent(cards[j].transform);

            var cardName = cardNames[j];
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardName, 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;
            card1.GetComponentInChildren<RawImage>().texture = cardTexture;
            //cards[j].GetComponent<CardControllerCardChain>().firstCardLocalName = cardDefinitionsLocale[j];
            card1.gameObject.name = cardDefinitionsLocale[j];

            var card2 = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);
            card2.transform.SetParent(cards[j].transform);

            var cardName2 = cardNames[j + 1];
            var cardTexture2 = await gameAPI.GetCardImage(packSlug, cardName2, 512);
            cardTexture2.wrapMode = TextureWrapMode.Clamp;
            cardTexture2.filterMode = FilterMode.Bilinear;
            card2.GetComponentInChildren<RawImage>().texture = cardTexture2;
            //cards[j].GetComponent<CardControllerCardChain>().secondCardLocalName = cardDefinitionsLocale[j + 1];
            card2.gameObject.name = cardDefinitionsLocale[j + 1];

            cards[j].transform.position = cardPositions[j].transform.position;
            //cards[j].transform.rotation = Quaternion.Euler(0, 0, Random.Range(11, -11));
            LeanTween.scale(cards[j], Vector3.one * 0.5f, 0.5f);

            cards[j].GetComponent<ChainController>().GetChildList();
        }
        isBoardCreated = true;
    }

    public async void CreateBoard()
    {
        await CacheCards(packSelectionPanel.selectedPackElement.name);
    }
}
