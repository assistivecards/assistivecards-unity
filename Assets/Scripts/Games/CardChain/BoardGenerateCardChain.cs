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
    [SerializeField] private GameObject tutorial;
    [SerializeField] private UIControllerCardChain uıController;
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cardDefinitions;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cardTextures;
    [SerializeField] private PackSelectionPanel packSelectionPanel;

    private int tempRandomValue;
    private int randomValue;

    public List<string> cardNames = new List<string>();
    public List<string> cardDefinitionsLocale = new List<string>();
    public List<GameObject> cards  = new List<GameObject>();
    public List<GameObject> cardPositions  = new List<GameObject>();
    public GameObject centerPosition;

    public List<int> randomValueList = new List<int>();
    public List<int> usedPositionList = new List<int>();

    [SerializeField] private GameObject boardGenerator;
    [SerializeField] private GameObject doubleCard;
    public int cardCount;
    public string packSlug;
    public bool isBoardCreated = false;
    public int matchCount;


    private void OnEnable()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        gameAPI.PlayMusic();
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
        for(int i = 0; i < boardGenerator.transform.childCount; i++)
        {
            cardPositions.Add(boardGenerator.transform.GetChild(i).gameObject);
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
            cards[j].transform.parent = boardGenerator.transform;

            var cardName = cardNames[randomValueList[j]];
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardName, 512);
            var localName = cardDefinitionsLocale[randomValueList[j]];

            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;
            cards[j].transform.GetChild(0).GetComponentInChildren<RawImage>().texture = cardTexture;
            cards[j].transform.GetChild(0).gameObject.name = cardName;
            cards[j].GetComponent<CardChainCardController>().leftCardLocalName = localName;
            cards[j].GetComponent<CardChainCardController>().boardGenerateCardChain = this;
            cards[j].GetComponent<CardChainCardController>().uıController = uıController;

            var cardName1 = cardNames[randomValueList[j + 1]];
            var cardTexture1 = await gameAPI.GetCardImage(packSlug, cardName1, 512);
            var localName1 = cardDefinitionsLocale[randomValueList[j + 1]];

            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;
            cards[j].transform.GetChild(1).GetComponentInChildren<RawImage>().texture = cardTexture1;
            cards[j].transform.GetChild(1).gameObject.name = cardName1;
            cards[j].GetComponent<CardChainCardController>().rightCardLocalName = localName1;
            cards[j].transform.tag = "Card";
            LeanTween.scale(cards[j], Vector3.one * 0.5f, 0.5f);
            CreateRandomPosition(cards[j]);
        }
        tutorial.GetComponent<TutorialCardChain>().point1 = cards[0].transform;
        tutorial.GetComponent<TutorialCardChain>().point1 = cards[1].transform;
        Invoke("BoardCreatedBool", 0.5f);
    }

    private void CreateRandomPosition(GameObject _card)
    {
        var randomPos = Random.Range(0,cardPositions.Count);

        if(!usedPositionList.Contains(randomPos))
        {
            usedPositionList.Add(randomPos);
            LeanTween.move(_card, cardPositions[randomPos].transform.position, 0);
        }
        else if(usedPositionList.Contains(randomPos))
        {
            CreateRandomPosition(_card);
        }
    }

    private void BoardCreatedBool()
    {
        uıController.loadingScreen.SetActive(false);
        isBoardCreated = true;
        uıController.cardPosition = cardPositions[0];
        uıController.cardPosition1 = cardPositions[1];
        uıController.TutorialActive();
        uıController.gameUI.SetActive(true);
    }

    public async void CreateBoard()
    {
        uıController.loadingScreen.SetActive(true);
        uıController.InGameBar();
        await CacheCards(packSelectionPanel.selectedPackElement.name);
    }

    public void ResetBoard()
    {
        isBoardCreated = false;
        foreach(var card in cards)
        {
            if(card != null)
                LeanTween.scale(card.gameObject, Vector3.zero, 0.2f).setOnComplete(DestroyCard);
        }
        cardNames.Clear();
        randomValueList.Clear();
        cardDefinitionsLocale.Clear();
        cards.Clear();
        matchCount = 0;
        usedPositionList.Clear();
    }

    public void ClearBoard()
    {
        isBoardCreated = false;
        foreach(var card in cards)
        {
            Destroy(card);
        }
        cardNames.Clear();
        randomValueList.Clear();
        cardDefinitionsLocale.Clear();
        cards.Clear();
        matchCount = 0;
        usedPositionList.Clear();
    }

    private void DestroyCard()
    {
        GameObject _card = GameObject.Find("DoubleCard(Clone)");
        Destroy(_card);
    }
}
