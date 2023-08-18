using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LetterFindBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;

    [Header ("Classes")]
    [SerializeField] private LetterFindUIController uıController;
    [SerializeField] private LetterFindTutorial tutorialScript;

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
    private List<GameObject> letters = new List<GameObject>();

    [Header ("Random")]
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Random Letters")]
    public List<int> randomLetterValueList = new List<int>();
    private int tempRandomLetterValue;
    private int randomLetterValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Game Elements")]
    public GameObject card;
    public string targetCardName;
    public GameObject tempCardPosition;
    public GameObject selectedCard;
    public GameObject cardPosition1;
    public GameObject cardPosition2;
    public GameObject cardPosition3;
    public List<GameObject> cardPositions = new List<GameObject>();

    [Header ("Colors")]
    public Color[] colors;

    public int emptyLetterIndex;
    public string emptyLetter;
    public bool emptySlotCreated = false;

    
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

    public async Task CreateLetters()
    {
        cachedLetterCards = await gameAPI.GetCards("en", "letters");
        letterList = cachedLetterCards.cards.ToList();

        for(int i = 0; i < cachedLetterCards.cards.Length; i++)
        {
            letterCardsNames.Add(cachedLetterCards.cards[i].title.ToLower().Replace(" ", "-"));
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

    private void CheckRandomForLetters()
    {
        tempRandomLetterValue = Random.Range(0, letterList.Count);

        if(!randomLetterValueList.Contains(tempRandomLetterValue))
        {
            randomLetterValue = tempRandomLetterValue;
            randomLetterValueList.Add(randomLetterValue);
        }
        else
        {
            CheckRandomForLetters();
        }
    }

    private void CreateCardList()
    {
        cardPositions.Add(cardPosition1);
        cardPositions.Add(cardPosition2);
        cardPositions.Add(cardPosition3);
    }

    public async void GeneratedBoardAsync()
    {
        if(uıController.canGenerate)
        {
            await CacheCards();
            await CreateLetters();
            CreateCardList();
            CheckRandom();
            targetCardName = cardNames[Random.Range(0, cardNames.Count)].ToUpper();
            emptyLetterIndex = Random.Range(0, targetCardName.Length);
            foreach(char c in targetCardName)
            {
                GameObject letter = Instantiate(letterPrefab, tempCardPosition.transform.position, Quaternion.identity);
                letter.transform.SetParent(tempCardPosition.transform);
                letters.Add(letter);
                if(!emptySlotCreated)
                {
                    if(targetCardName[emptyLetterIndex] != c)
                    {
                        letter.GetComponentInChildren<Text>().text = "" + c;
                    }
                    else if(targetCardName[emptyLetterIndex] == c)
                    {
                        emptySlotCreated = true;
                        letter.GetComponent<BoxCollider2D>().enabled = true;
                        letter.transform.tag = "EmptyLetter";
                        tutorialScript.emptyLetter = letter;
                        emptyLetter = "" + c;
                    }
                }
                else
                {
                    letter.GetComponentInChildren<Text>().text = "" + c;
                }
                letter.transform.GetChild(0).GetComponent<Text>().color = colors[Random.Range(0, colors.Length)];
                letter.GetComponent<LetterFindLetterController>().letter = "" + c;;
            }
            for(int i = 0; i < cardPositions.Count; i++)
            {
                card = Instantiate(cardPrefab, cardPositions[i].transform.position, Quaternion.identity);
                card.transform.SetParent(cardPositions[i].transform);
                var letterCardTexture = await gameAPI.GetCardImage("letters", letterCardsNames[i], 512);
                letterCardTexture.wrapMode = TextureWrapMode.Clamp;
                letterCardTexture.filterMode = FilterMode.Bilinear;
                card.GetComponent<LetterFindCardController>().cardLetter = letterCardsNames[i].ToUpper();
                card.GetComponent<LetterFindCardController>().targetWord = targetCardName;
                if(letterCardsNames[i].ToUpper() == emptyLetter)
                {
                    tutorialScript.trueLetterCard = card;
                }
                LeanTween.scale(card, Vector3.one * 0.45f, 0);
                card.transform.GetChild(0).GetComponent<RawImage>().texture = letterCardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                cards.Add(card);
            }
        }
        Invoke("GameUIActivate", 0.25f);
    }

    public void GameUIActivate()
    {
        uıController.GameUIActivate();
    }

    public void ClearBoard()
    {
        foreach(var letter in letters)
        {
            Destroy(letter);
        }
        foreach(var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
        letters.Clear();
        letterList.Clear();
        letterCardsNames.Clear();
        randomValueList.Clear();
        randomLetterValueList.Clear();
        targetCardName = null;
        cardLocalNames.Clear();
        cardNames.Clear();
        cardPositions.Clear();
        Destroy(card);
        emptySlotCreated = false;
    }
}
