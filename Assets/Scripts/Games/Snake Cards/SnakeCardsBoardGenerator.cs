using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SnakeCardsBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;
    [Header ("Classes")]
    [SerializeField] private SnakeCardsUIController uıController;
    [SerializeField] private SnakeCardSnakeController snakeController;
    [Header ("Cache Cards")]
    public string selectedLangCode;
    public List<string> cardLocalNames = new List<string>();
    public List<GameObject> cards = new List<GameObject>();
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    [SerializeField] private PackSelectionPanel packSelectionPanel;

    [Header ("Letter Cards")]
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLetterCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> letterList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    public List<string> letterCardsNames = new List<string>();

    [Header ("Random")]
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Pattern Positions")]
    [SerializeField] private GameObject cardPosition1;
    [SerializeField] private GameObject cardPosition2;
    [SerializeField] private GameObject cardPosition3;
    [SerializeField] private GameObject cardPosition4;
    [SerializeField] private GameObject cardPosition5;
    [SerializeField] private GameObject cardPosition6;
    [SerializeField] private GameObject cardPosition7;
    [SerializeField] private GameObject cardPosition8;
    public List<GameObject> cardPositions = new List<GameObject>();

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

    private void CreatePositionsList()
    {
        cardPositions.Add(cardPosition1);
        cardPositions.Add(cardPosition2);
        cardPositions.Add(cardPosition3);
        cardPositions.Add(cardPosition4);
        cardPositions.Add(cardPosition5);
        cardPositions.Add(cardPosition6);
        cardPositions.Add(cardPosition7);
    }

    public async void GeneratedBoardAsync()
    {
        if(uıController.canGenerate)
        {
            await CacheCards();
            CreatePositionsList();
            for(int j = 0; j < cardPositions.Count; j++)
            {
                CheckRandom();
                GameObject card = Instantiate(cardPrefab, cardPositions[j].transform.position, Quaternion.identity);
                card.transform.SetParent(cardPositions[j].transform);

                var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[j]], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = cardLocalNames[randomValueList[j]];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                LeanTween.scale(card, Vector3.one * 0.75f, 0);
                LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-15, 15)), 0f);
                cards.Add(card);
            }
            snakeController.GenerateSnake();
            Invoke("GameUIActivate", 0.1f);
        }
    }

    public void GameUIActivate()
    {
        uıController.GameUIActivate();
    }

    public void LevelEnd()
    {
        ClearBoard();
        uıController.LevelChangeScreenActivate();
    }

    public void ClearBoard()
    {
        cardLocalNames.Clear();
        cardNames.Clear();
        cardsList.Clear();
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();

        letterList.Clear();
        letterCardsNames.Clear();

        randomValueList.Clear();

        cardPositions.Clear();
    }
}
