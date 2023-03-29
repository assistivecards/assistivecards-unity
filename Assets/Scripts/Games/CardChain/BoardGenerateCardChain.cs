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

    [SerializeField] private GameObject doubleCard;
    public int cardCount;
    public string packSlug;
    public bool isBoardCreated = false;

    public int matchCount;


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

        if(!randomValueList.Contains(tempRandomValue))
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
        for(int x = 0; x < 12; x++)
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
            cards.Add(Instantiate(doubleCard, Vector3.zero, Quaternion.identity));
            cards[j].transform.parent = this.transform;

            var cardName = cardNames[randomValueList[j]];
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardName, 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;
            cards[j].transform.GetChild(0).GetComponentInChildren<RawImage>().texture = cardTexture;
            cards[j].transform.GetChild(0).gameObject.name = cardDefinitionsLocale[j];

            var cardName1 = cardNames[randomValueList[j + 1]];
            var cardTexture1 = await gameAPI.GetCardImage(packSlug, cardName1, 512);

            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;
            cards[j].transform.GetChild(1).GetComponentInChildren<RawImage>().texture = cardTexture1;
            cards[j].transform.GetChild(1).gameObject.name = cardDefinitionsLocale[j + 1];
            LeanTween.scale(cards[j], Vector3.one * 0.5f, 0.5f);
            LeanTween.move(cards[j], cardPositions[j].transform.position, 0);
            cards[j].GetComponent<CardControllerCardChain>().GetChildNames();
            cards[j].GetComponent<CardControllerCardChain>().boardGenerateCardChain = this;
        }
        Invoke("BoardCreatedBool", 1f);
    }

    private void BoardCreatedBool()
    {
        isBoardCreated = true;
    }

    public async void CreateBoard()
    {
        await CacheCards(packSelectionPanel.selectedPackElement.name);
    }
}
