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

    //[SerializeField] private uıController;
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
    [SerializeField] private Transform patternPositionsParent;
    private List<GameObject> patternPositions = new List<GameObject>();

    [Header ("Draggable Positions")]
    [SerializeField] private Transform draggablePositionsParent;
    private List<GameObject> draggablePositions = new List<GameObject>();

    private int round;
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
        foreach(Transform child in patternPositionsParent)
        {
            patternPositions.Add(child.gameObject);
        }
        foreach(Transform child in draggablePositionsParent)
        {
            draggablePositions.Add(child.gameObject);
        }
    }

    public async void GeneratedBoardAsync()
    {
        //if(uıController.canGenerate)
        //{
            await CacheCards();
            CreatePositionsList();
            for(int j = 0; j < patternPositions.Count; j++)
            {
                if(round == 0){
                    CheckRandom();
                    GameObject card = Instantiate(cardPrefab, patternPositions[j].transform.position, Quaternion.identity);
                    card.transform.SetParent( patternPositions[j].transform);

                    var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[0]], 512);
                    cardTexture.wrapMode = TextureWrapMode.Clamp;
                    cardTexture.filterMode = FilterMode.Bilinear;

                    card.transform.name = cardLocalNames[randomValueList[0]];
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

                    card.transform.name = cardLocalNames[randomValueList[1]];
                    card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                    card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                    LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-15, 15)), 0f);
                    cards.Add(card);
                    round ++;
                }else if(round == 2){
                    CheckRandom();
                    GameObject card = Instantiate(cardPrefab, patternPositions[j].transform.position, Quaternion.identity);
                    card.transform.SetParent( patternPositions[j].transform);

                    var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[2]], 512);
                    cardTexture.wrapMode = TextureWrapMode.Clamp;
                    cardTexture.filterMode = FilterMode.Bilinear;

                    card.transform.name = cardLocalNames[randomValueList[2]];
                    card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                    card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                    LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-15, 15)), 0f);
                    cards.Add(card);
                    round = 0;
                }
            }

            for(int j = 0; j < draggablePositions.Count; j++)
            {
                CheckRandom();
                GameObject card = Instantiate(cardPrefab, draggablePositions[j].transform.position, Quaternion.identity);
                card.transform.SetParent( draggablePositions[j].transform);

                var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[j]], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = cardLocalNames[randomValueList[j]];
                card.GetComponent<PatternTrainCardController>().draggable = true;
                card.GetComponent<BoxCollider2D>().enabled = true;
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                cards.Add(card);
            }
        //}
        Invoke("GameUIActivate", 0.3f);
    }

    public void GameUIActivate()
    {
        //uıController.GameUIActivate();
    }

    public void ClearBoard()
    {
        cardLocalNames.Clear();
        cards.Clear();
        cardNames.Clear();

        letterList.Clear();
        letterCardsNames.Clear();

        randomValueList.Clear();
    }
}
