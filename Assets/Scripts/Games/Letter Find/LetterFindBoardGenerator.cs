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
    public List<string> wordletters = new List<string>();
    public List<string> guessCardLetters = new List<string>();

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
    public GameObject cardNameHorizontalParent;
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
    public int secondWordCharIndex;

    
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

    private void CreateTargetCard()
    {
        targetCardName = cardLocalNames[Random.Range(0, cardLocalNames.Count)].ToUpper();
        if(targetCardName.Contains("-".ToUpper()) || targetCardName.Length > 10)
        {
            CreateTargetCard();
        }
        else if(targetCardName.Length < 4)
        {
            CreateTargetCard();
        }
        else
        {
            emptyLetterIndex = Random.Range(1, targetCardName.Length);
        }

    }

    public async void GeneratedBoardAsync()
    {
        if(uıController.canGenerate)
        {
            await CacheCards();
            await CreateLetters();
            CheckRandom();
            CreateCardList();
            CreateTargetCard();
            if(targetCardName != null)
            {
                foreach(char c in targetCardName)
                {
                    GameObject letter = Instantiate(letterPrefab, cardNameHorizontalParent.transform.position, Quaternion.identity);
                    letter.transform.SetParent(cardNameHorizontalParent.transform);
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
                    wordletters.Add(letter.GetComponentInChildren<Text>().text);
                    LeanTween.scale(letter, Vector3.one, 0);
                }
                foreach(var letter in letterCardsNames)
                {
                    CheckRandomForLetters();
                    if(letter.ToUpper() == emptyLetter)
                    {
                        Transform cardPosition = cardPositions[Random.Range(0, cardPositions.Count)].transform;
                        card = Instantiate(cardPrefab, cardPosition.position, Quaternion.identity);
                        card.transform.SetParent(cardPosition);
                        var letterCardTexture = await gameAPI.GetCardImage("letters", letter, 512);
                        letterCardTexture.wrapMode = TextureWrapMode.Clamp;
                        letterCardTexture.filterMode = FilterMode.Bilinear;
                        card.GetComponent<LetterFindCardController>().cardLetter = letter.ToUpper();
                        card.GetComponent<LetterFindCardController>().targetWord = targetCardName;
                        tutorialScript.trueLetterCard = card;
                        LeanTween.scale(card, Vector3.one * 0.45f, 0);
                        card.transform.GetChild(0).GetComponent<RawImage>().texture = letterCardTexture;
                        card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                        cards.Add(card);
                    }
                }
                for(int i = 0; i < cardPositions.Count; i++)
                {
                    if(cardPositions[i].transform.childCount == 0)
                    {
                        if(letterCardsNames.Contains(emptyLetter.ToLower()))
                        {
                            if(letterCardsNames[randomLetterValueList[i]].ToUpper() != emptyLetter)
                            {
                                int randomLetter = randomLetterValueList[i]; 
                                if(guessCardLetters.Contains(letterCardsNames[randomLetter]))
                                {
                                    randomLetter = 0;
                                }
                                card = Instantiate(cardPrefab, cardPositions[i].transform.position, Quaternion.identity);
                                card.transform.SetParent(cardPositions[i].transform);
                                card.transform.GetChild(0).gameObject.SetActive(true);
                                card.transform.GetChild(1).gameObject.SetActive(false);

                                var letterCardTexture = await gameAPI.GetCardImage("letters", letterCardsNames[randomLetter], 512);
                                letterCardTexture.wrapMode = TextureWrapMode.Clamp;
                                letterCardTexture.filterMode = FilterMode.Bilinear;
                                card.transform.GetChild(0).GetComponent<RawImage>().texture = letterCardTexture;
                                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);

                                card.GetComponent<LetterFindCardController>().cardLetter = letterCardsNames[randomLetter].ToUpper();
                                card.GetComponent<LetterFindCardController>().targetWord = targetCardName;
                                LeanTween.scale(card, Vector3.one * 0.45f, 0);
                                guessCardLetters.Add(card.GetComponent<LetterFindCardController>().cardLetter);
                                cards.Add(card);
                            }
                            else if(letterCardsNames[randomLetterValueList[i]].ToUpper() == emptyLetter)
                            {
                                int randomLetter = randomLetterValueList[i + 1]; 
                                if(guessCardLetters.Contains(letterCardsNames[randomLetter]))
                                {
                                    randomLetter = 0;
                                }
                                card = Instantiate(cardPrefab, cardPositions[i].transform.position, Quaternion.identity);
                                card.transform.SetParent(cardPositions[i].transform);
                                card.transform.GetChild(0).gameObject.SetActive(true);
                                card.transform.GetChild(1).gameObject.SetActive(false);

                                var letterCardTexture = await gameAPI.GetCardImage("letters", letterCardsNames[randomLetter], 512);
                                letterCardTexture.wrapMode = TextureWrapMode.Clamp;
                                letterCardTexture.filterMode = FilterMode.Bilinear;
                                card.transform.GetChild(0).GetComponent<RawImage>().texture = letterCardTexture;
                                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                                card.GetComponent<LetterFindCardController>().cardLetter = letterCardsNames[randomLetter].ToUpper();
                                card.GetComponent<LetterFindCardController>().targetWord = targetCardName;
                                LeanTween.scale(card, Vector3.one * 0.45f, 0);
                                guessCardLetters.Add(card.GetComponent<LetterFindCardController>().cardLetter);
                                cards.Add(card);
                            }
                        }
                    }
                }
                if(!letterCardsNames.Contains(emptyLetter.ToLower()))
                {
                    int correctCardRandom = Random.Range(0, cardPositions.Count);
                    //diffrent alphabet
                    card = Instantiate(cardPrefab, cardPositions[correctCardRandom].transform.position, Quaternion.identity);
                    card.transform.SetParent(cardPositions[correctCardRandom].transform);
                    card.transform.GetChild(1).gameObject.SetActive(true);
                    card.transform.GetChild(0).gameObject.SetActive(false);
                    tutorialScript.trueLetterCard = card;
                    card.GetComponentInChildren<TMP_Text>().text = emptyLetter;
                    card.GetComponent<LetterFindCardController>().cardLetter = emptyLetter;
                    card.GetComponent<LetterFindCardController>().targetWord = targetCardName;
                    card.GetComponentInChildren<TMP_Text>().color = colors[Random.Range(0, colors.Length)];
                    LeanTween.scale(card, Vector3.one * 0.45f, 0);
                    cards.Add(card);

                    for(int j = 0; j < cardPositions.Count; j++)
                    {
                        if(cardPositions[j].transform.childCount == 0)
                        {
                            int randomLetter = Random.Range(1, wordletters.Count); 
                            if(wordletters[randomLetter] == emptyLetter || guessCardLetters.Contains(wordletters[randomLetter]))
                            {
                                randomLetter = 0;
                            }
                            card = Instantiate(cardPrefab, cardPositions[j].transform.position, Quaternion.identity);
                            card.transform.SetParent(cardPositions[j].transform);
                            card.transform.GetChild(1).gameObject.SetActive(true);
                            card.transform.GetChild(0).gameObject.SetActive(false);
                            card.GetComponentInChildren<TMP_Text>().text = wordletters[randomLetter];
                            card.GetComponent<LetterFindCardController>().cardLetter = wordletters[randomLetter];
                            card.GetComponent<LetterFindCardController>().targetWord = targetCardName;
                            card.GetComponentInChildren<TMP_Text>().color = colors[Random.Range(0, colors.Length)];
                            LeanTween.scale(card, Vector3.one * 0.45f, 0);
                            guessCardLetters.Add(card.GetComponent<LetterFindCardController>().cardLetter);
                            cards.Add(card);
                            if(card.GetComponent<LetterFindCardController>().cardLetter == "")
                            {
                                int randomDummyLetter = Random.Range(0, letterCardsNames.Count); 
                                card.GetComponentInChildren<TMP_Text>().text = letterCardsNames[randomDummyLetter];
                                card.GetComponent<LetterFindCardController>().cardLetter = letterCardsNames[randomDummyLetter];
                            }
                        }
                    }
                }
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
        guessCardLetters.Clear();
        letters.Clear();
        letterList.Clear();
        letterCardsNames.Clear();
        wordletters.Clear();
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
