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
    [SerializeField] private GameObject cardPosition10;
    [SerializeField] private GameObject cardPosition11;
    [SerializeField] private GameObject cardPosition12;
    [SerializeField] private GameObject levelEndCardPosition;
    [SerializeField] private GameObject levelEndCard;
    public List<GameObject> cardPositions = new List<GameObject>();
    public List<GameObject> targetCards = new List<GameObject>();

    [Header ("In Game Values")]
    private int targetCardRandomValue;
    public string targetCardLocal;
    public string targetCard;
    public bool gameStarted;
    public int eatenCardCount;
    public int reloadCount;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        gameAPI.PlayMusic();
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
        cardPositions.Add(cardPosition10);
        cardPositions.Add(cardPosition11);
        cardPositions.Add(cardPosition12);
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
            CheckRandom();

            if(levelEndCard != null)
            {
                LeanTween.scale(levelEndCard, Vector3.zero, 0.2f);
            }
            for(int j = 0; j < 8; j++)
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
            targetCardRandomValue = 9;
            for(int i = 8; i < 12; i++)
            {
                if(cardPositions[i].transform.childCount <= 0)
                {
                    GameObject card = Instantiate(cardPrefab, cardPositions[i].transform.position, Quaternion.identity);
                    card.transform.SetParent(cardPositions[i].transform);

                    var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[targetCardRandomValue]], 512);
                    cardTexture.wrapMode = TextureWrapMode.Clamp;
                    cardTexture.filterMode = FilterMode.Bilinear;

                    card.transform.name = cardNames[randomValueList[targetCardRandomValue]];
                    card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                    card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                    card.GetComponent<SnakeCardsCardController>().cardName = cardNames[randomValueList[targetCardRandomValue]];
                    card.GetComponent<SnakeCardsCardController>().cardLocalName = cardLocalNames[randomValueList[targetCardRandomValue]];
                    LeanTween.scale(card, Vector3.one * 0.75f, 0);
                    LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-30, 30)), 0f);
                    card.gameObject.tag = "Card";
                    targetCards.Add(card);
                    cards.Add(card);
                }
            }

            levelEndCard = Instantiate(cardPrefab, levelEndCardPosition.transform.position, Quaternion.identity);
            levelEndCard.transform.SetParent(levelEndCardPosition.transform);

            var targetCardCardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[targetCardRandomValue]], 512);
            targetCardCardTexture.wrapMode = TextureWrapMode.Clamp;
            targetCardCardTexture.filterMode = FilterMode.Bilinear;

            levelEndCard.transform.GetChild(0).GetComponent<RawImage>().texture = targetCardCardTexture;
            levelEndCard.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            LeanTween.scale(levelEndCard, Vector3.zero, 0);

            targetCard = cardNames[randomValueList[targetCardRandomValue]];
            targetCardLocal = cardLocalNames[randomValueList[targetCardRandomValue]];
            eatCardsText.text = gameAPI.Translate(eatCardsText.gameObject.name, gameAPI.ToSentenceCase(targetCardLocal).Replace("-", " "), selectedLangCode);
            reloadCount++;
            Invoke("GameUIActivate", 0.1f);
        }
    }

    public void CardEaten()
    {
        eatenCardCount++;
        if(eatenCardCount >= targetCards.Count  && reloadCount < 3)
        {
            ClearForRefill();
            ScaleUpLevelEndCard();
        }
        else if(eatenCardCount >= 4  && reloadCount == 3)
        {
            uıController.LevelChangeScreenActivate();
        }   
    }

    public void ScaleUpLevelEndCard()
    {
        gameAPI.Speak(targetCardLocal);
        Debug.Log(targetCardLocal);
        LeanTween.scale(levelEndCard, Vector3.one, 0.5f).setOnComplete(GeneratedBoardAsync);
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
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
        randomValueList.Clear();
        cardPositions.Clear();
        targetCards.Clear();
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
        targetCards.Clear();
        reloadCount = 0;
    }
}
