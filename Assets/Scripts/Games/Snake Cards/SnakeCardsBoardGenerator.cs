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

    [Header ("Game Elements")]
    [SerializeField] private GameObject snake;
    [SerializeField] private TMP_Text eatCardsText;
    [SerializeField] private GameObject cardPosition1;
    [SerializeField] private GameObject cardPosition2;
    [SerializeField] private GameObject cardPosition3;
    [SerializeField] private GameObject cardPosition4;
    [SerializeField] private GameObject cardPosition5;
    [SerializeField] private GameObject cardPosition6;
    [SerializeField] private GameObject cardPosition7;
    [SerializeField] private GameObject cardPosition8;
    [SerializeField] private GameObject cardPosition9;
    public List<GameObject> cardPositions = new List<GameObject>();

    [Header ("In Game Values")]
    public bool gameStarted;
    public string targetCard;
    public int eatenCardCount;
    public int reloadCount;

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
        cardPositions.Add(cardPosition2);
        cardPositions.Add(cardPosition3);
        cardPositions.Add(cardPosition5);
        cardPositions.Add(cardPosition6);
        cardPositions.Add(cardPosition7);
        cardPositions.Add(cardPosition8);
        cardPositions.Add(cardPosition9);
        cardPositions.Add(cardPosition1);
        cardPositions.Add(cardPosition4);
    }

    private void RandomizePositions()
    {
        foreach(GameObject position in cardPositions)
        {
            if(position.transform.childCount <= 0)
            {
                LeanTween.moveLocal(position, new Vector3(Random.Range(position.transform.localPosition.x - 30, position.transform.localPosition.x +30),
                Random.Range(position.transform.localPosition.y - 20, position.transform.localPosition.y + 20), 0), 0);
            }
        }
    }

    public async void GeneratedBoardAsync()
    {
        if(uıController.canGenerate)
        {
            await CacheCards();
            CreatePositionsList();
            RandomizePositions();
            for(int j = 0; j < 5; j++)
            {
                CheckRandom();
                if(cardPositions[j].transform.childCount <= 0)
                {
                    GameObject card = Instantiate(cardPrefab, cardPositions[j].transform.position, Quaternion.identity);
                    card.transform.SetParent(cardPositions[j].transform);

                    var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[j]], 512);
                    cardTexture.wrapMode = TextureWrapMode.Clamp;
                    cardTexture.filterMode = FilterMode.Bilinear;

                    card.transform.name = cardNames[randomValueList[j]];
                    card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                    card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                    card.GetComponent<SnakeCardsCardController>().cardName = cardNames[randomValueList[j]];
                    card.GetComponent<SnakeCardsCardController>().cardLocalName = cardLocalNames[randomValueList[j]];
                    LeanTween.scale(card, Vector3.one * 0.75f, 0);
                    LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-30, 30)), 0f);
                    card.gameObject.tag = "Card";
                    cards.Add(card);
                }
            }
            CheckRandom();
            for(int i = 5; i < 9; i++)
            {
                if(cardPositions[i].transform.childCount <= 0)
                {
                    GameObject card = Instantiate(cardPrefab, cardPositions[i].transform.position, Quaternion.identity);
                    card.transform.SetParent(cardPositions[i].transform);

                    var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[5]], 512);
                    cardTexture.wrapMode = TextureWrapMode.Clamp;
                    cardTexture.filterMode = FilterMode.Bilinear;

                    card.transform.name = cardLocalNames[randomValueList[5]];
                    card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                    card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                    card.GetComponent<SnakeCardsCardController>().cardName = cardNames[randomValueList[5]];
                    card.GetComponent<SnakeCardsCardController>().cardLocalName = cardLocalNames[randomValueList[5]];
                    LeanTween.scale(card, Vector3.one * 0.75f, 0);
                    LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-30, 30)), 0f);
                    card.gameObject.tag = "Card";
                    cards.Add(card);
                }
            }
            targetCard = cardNames[randomValueList[5]];
            eatCardsText.text = gameAPI.Translate(eatCardsText.gameObject.name, gameAPI.ToSentenceCase(targetCard).Replace("-", " "), selectedLangCode);
            reloadCount++;
            Invoke("GameUIActivate", 0.1f);
        }
    }

    public void CardEaten()
    {
        eatenCardCount++;
        if(eatenCardCount >= 4  && reloadCount < 3)
        {
            ClearForRefill();
            GeneratedBoardAsync();
        }
        else if(eatenCardCount >= 4  && reloadCount == 3)
        {
            uıController.LevelChangeScreenActivate();
        }   
    }

    public void GameUIActivate()
    {
        uıController.GameUIActivate();
        if(reloadCount == 1)
        {
            LeanTween.moveLocal(snake, new Vector3(-400, 0, 0), 0);
            snake.GetComponentInChildren<TrailRenderer>().time = 1.5f;
        }
        gameStarted = true;
    }

    public void LevelEnd()
    {
        ClearBoard();
        uıController.LevelChangeScreenActivate();
    }

    public void ClearForRefill()
    {
        cardNames.Clear();
        cardsList.Clear();
        cardLocalNames.Clear();
        cards.Clear();
        randomValueList.Clear();
        cardPositions.Clear();
        eatenCardCount = 0;
    }

    public void ClearBoard()
    {
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cardNames.Clear();
        cardsList.Clear();
        cardLocalNames.Clear();
        cards.Clear();
        randomValueList.Clear();
        cardPositions.Clear();
        eatenCardCount = 0;
        reloadCount = 0;
    }
}
