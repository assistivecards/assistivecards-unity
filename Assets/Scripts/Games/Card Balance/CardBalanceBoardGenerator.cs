using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardBalanceBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;

    [SerializeField] private CardBalanceUIController uıController;
    [Header ("Cache Cards")]
    public string selectedLangCode;
    public List<string> cardLocalNames = new List<string>();
    public List<GameObject> cards = new List<GameObject>();
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    [SerializeField] private PackSelectionPanel packSelectionPanel;

    [Header ("Random")]
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Game UI")]
    public GameObject referencePosition1;
    public GameObject referencePosition2;
    public GameObject referencePosition3;
    private List<GameObject> referencePositions = new List<GameObject>();

    public GameObject cardPosition1;
    public GameObject cardPosition2;
    public GameObject cardPosition3;
    private List<GameObject> cardPositions = new List<GameObject>();

    public int levelCount;
    private string cardName;
    private int random;
    public int cardNameLenght;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards()
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();

        cachedCards = await gameAPI.GetCards("en", packSelectionPanel.selectedPackElement.name);
        cachedLocalCards = await gameAPI.GetCards(selectedLangCode, packSelectionPanel.selectedPackElement.name);

        cardsList = cachedCards.cards.ToList();

        for(int i = 0; i < cachedCards.cards.Length; i++)
        {
            cardNames.Add(cachedCards.cards[i].title.ToLower().Replace(" ", "-"));
            cardLocalNames.Add(cachedLocalCards.cards[i].title);
        }
    }

    private void CheckRandom()
    {
        tempRandomValue = Random.Range(0, cardsList.Count);

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

    private void CreateCardPositionList()
    {
        referencePositions.Add(referencePosition1);
        referencePositions.Add(referencePosition2);
        referencePositions.Add(referencePosition3);

        cardPositions.Add(cardPosition1);
        cardPositions.Add(cardPosition2);
        cardPositions.Add(cardPosition3);
    }

    public async void GeneratedBoardAsync()
    {
        if(uıController.canGenerate)
        {
            await CacheCards();

            for(int i = 0; i < 3; i++)
            {
                CheckRandom();
                CreateCardPositionList();
                GameObject card = Instantiate(cardPrefab, referencePositions[i].transform.position, Quaternion.identity);

                var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[i]], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.SetParent(referencePositions[i].transform);
                card.transform.name = cardLocalNames[randomValueList[i]];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                cards.Add(card);


                GameObject cloneCard = Instantiate(cardPrefab, cardPositions[i].transform.position, Quaternion.identity);

                var cloneCardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[i]], 512);
                cloneCardTexture.wrapMode = TextureWrapMode.Clamp;
                cloneCardTexture.filterMode = FilterMode.Bilinear;

                cloneCard.transform.SetParent(cardPositions[i].transform);
                cloneCard.transform.name = cardLocalNames[randomValueList[i]];
                cloneCard.transform.GetChild(0).GetComponent<RawImage>().texture = cloneCardTexture;
                cloneCard.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                cloneCard.GetComponent<CardBalanceDraggable>().draggable = true;
                cloneCard.GetComponent<CardBalanceDraggable>().ActiavateGravityEffect();
                cloneCard.gameObject.tag = "Card";
                cards.Add(cloneCard);
            }
        }
        GameUIActivate();
    }

    public void GameUIActivate()
    {
        uıController.GameUIActivate();
        //tutorial.GetComponent<AlphabetChooseTutorial>().SetPosition(cards[random].transform);
    }

    private void CreateNewLevel()
    {
        ClearBoard();
        GeneratedBoardAsync();
    }

    public void ClearBoard()
    {
        cardLocalNames.Clear();
        cards.Clear();
        cardNames.Clear();
        randomValueList.Clear();
    }
}
