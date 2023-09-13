using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PatternTrainBoardGenerator : MonoBehaviour 
{
    GameAPI gameAPI;

    [SerializeField] private PatternTrainUIController uıController;
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
    [SerializeField] private GameObject patternPosition1;
    [SerializeField] private GameObject patternPosition2;
    [SerializeField] private GameObject patternPosition3;
    [SerializeField] private GameObject patternPosition4;
    [SerializeField] private GameObject patternPosition5;
    [SerializeField] private GameObject patternPosition6;
    [SerializeField] private GameObject patternPosition7;
    [SerializeField] private GameObject patternPosition8;
    public List<GameObject> patternPositions = new List<GameObject>();

    [Header ("Draggable Positions")]
    [SerializeField] private GameObject draggablePosition1;
    [SerializeField] private GameObject draggablePosition2;
    [SerializeField] private GameObject draggablePosition3;
    public List<GameObject> draggablePositions = new List<GameObject>();

    [SerializeField] private GameObject questionMarkSlot;
    public string trueCardName;
    public int randomPosition;
    public int round;

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

    private void RandomizePosition()
    {
        randomPosition = Random.Range(0, draggablePositions.Count);
        if(draggablePositions[randomPosition].transform.childCount != 0)
        {
            RandomizePosition();
        }
    }

    private void CreatePositionsList()
    {
        patternPositions.Add(patternPosition1);
        patternPositions.Add(patternPosition2);
        patternPositions.Add(patternPosition3);
        patternPositions.Add(patternPosition4);
        patternPositions.Add(patternPosition5);
        patternPositions.Add(patternPosition6);
        patternPositions.Add(patternPosition7);
        patternPositions.Add(patternPosition8);

        draggablePositions.Add(draggablePosition1);
        draggablePositions.Add(draggablePosition2);
        draggablePositions.Add(draggablePosition3);

    }

    public async void GeneratedBoardAsync()
    {
        if(uıController.canGenerate)
        {
            uıController.LoadingScreenActivation();
            await CacheCards();
            CreatePositionsList();
            for(int j = 0; j < patternPositions.Count; j++)
            {
                CheckRandom();
                if(round == 0){
                    CheckRandom();
                    GameObject card = Instantiate(cardPrefab, patternPositions[j].transform.position, Quaternion.identity);
                    card.transform.SetParent( patternPositions[j].transform);

                    var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[0]], 512);
                    cardTexture.wrapMode = TextureWrapMode.Clamp;
                    cardTexture.filterMode = FilterMode.Bilinear;

                    card.transform.name = cardLocalNames[randomValueList[0]].ToLower();
                    card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                    card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                    LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-15, 15)), 0f);
                    cards.Add(card);
                    round ++;
                }
                else if(round == 1)
                {
                    CheckRandom();
                    GameObject card = Instantiate(cardPrefab, patternPositions[j].transform.position, Quaternion.identity);
                    card.transform.SetParent( patternPositions[j].transform);

                    var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[1]], 512);
                    cardTexture.wrapMode = TextureWrapMode.Clamp;
                    cardTexture.filterMode = FilterMode.Bilinear;

                    card.transform.name = cardLocalNames[randomValueList[1]].ToLower();
                    card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                    card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                    LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-15, 15)), 0f);
                    cards.Add(card);
                    round ++;
                }
                else if(round == 2)
                {
                    CheckRandom();
                    GameObject card = Instantiate(cardPrefab, patternPositions[j].transform.position, Quaternion.identity);
                    card.transform.SetParent( patternPositions[j].transform);

                    var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[2]], 512);
                    cardTexture.wrapMode = TextureWrapMode.Clamp;
                    cardTexture.filterMode = FilterMode.Bilinear;

                    card.transform.name = cardLocalNames[randomValueList[2]].ToLower();;
                    card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                    card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                    LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-15, 15)), 0f);
                    cards.Add(card);
                    round = 0;
                }
            }
            GetTrueCard();
            for(int j = 0; j < draggablePositions.Count; j++)
            {
                CheckRandom();
                RandomizePosition();
                GameObject card = Instantiate(cardPrefab, draggablePositions[randomPosition].transform.position, Quaternion.identity);
                card.transform.SetParent( draggablePositions[randomPosition].transform);

                var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[j]], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = cardLocalNames[randomValueList[j]].ToLower();;
                card.GetComponent<PatternTrainCardController>().draggable = true;
                card.GetComponent<PatternTrainCardController>().cardName = cardNames[randomValueList[j]];
                card.GetComponent<PatternTrainCardController>().trueCardName = trueCardName;
                card.GetComponent<PatternTrainCardController>().cardLocalName = cardLocalNames[randomValueList[j]];
                card.GetComponent<BoxCollider2D>().enabled = true;
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                if(cardLocalNames[randomValueList[j]].ToLower() == trueCardName)
                {
                    tutorial.GetComponent<PatternTrainTutorial>().trueCard = card.transform;
                }
                cards.Add(card);
            }
            questionMarkSlot.SetActive(true);
            Invoke("GameUIActivate", 0.1f);
        }
    }

    public void GameUIActivate()
    {
        uıController.GameUIActivate();
    }

    private void GetTrueCard()
    {
        trueCardName = cardLocalNames[randomValueList[1]].ToLower();
    }

    public void LevelEnd()
    {
        ClearBoard();
        uıController.LevelEndCheck();
    }

    public void ClearBoard()
    {
        questionMarkSlot.SetActive(false);
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

        patternPositions.Clear();
        draggablePositions.Clear();
        trueCardName = null;
        round = 0;
    }
}
