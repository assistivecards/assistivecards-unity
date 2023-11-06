using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardGeneratorWordHunt : MonoBehaviour
{
    GameAPI gameAPI;

    [SerializeField] private UIControllerWordHunt uıController;

    [Header ("Cache Cards")]
    public string selectedLangCode;
    public List<GameObject> cards = new List<GameObject>();
    public AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    public List<string> cardNames = new List<string>();
    public List<string> cardLocalNames = new List<string>();
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    public string packSlug;

    [Header ("Cache Letter Cards")]
    public AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLetterCards;
    public List<string> letterCardNames = new List<string>();
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> letterCardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    public List<string> localAlphabet = new List<string>();


    [Header ("Random")]
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Game UI")]
    [SerializeField] private GameObject grid;
    public List<GameObject> gridChilds = new List<GameObject>();

    [Header ("Colors")]
    public Color[] colors;

    [Header ("Game Values")]
    public int horizontalValue;
    public List<string> selectedWords = new List<string>();
    public List<string> accurateWords = new List<string>();
    public List<GameObject> tempLetterPositions = new List<GameObject>();
    public bool elementsEmpty = true;
    private string cardName;
    public int selectedWordCount;
    public int randomOrder;
    public List<int> usedRandomOrderCards = new List<int>();
    public int cardNameLenght;
    public int matchedCardCount;
    public bool isPointerUp;
    public bool finished;
    int startIndex;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        gameAPI.PlayMusic();
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();

        cachedCards = await gameAPI.GetCards("en", _packSlug);
        cachedLocalCards = await gameAPI.GetCards(selectedLangCode, _packSlug);

        cardsList = cachedCards.cards.ToList();

        for(int i = 0; i < cachedCards.cards.Length; i++)
        {
            cardNames.Add(cachedCards.cards[i].title.ToLower().Replace(" ", "-"));
            cardLocalNames.Add(cachedLocalCards.cards[i].title);
        }
    }

    public async Task CacheLetterCards()
    {
        cachedLetterCards = await gameAPI.GetCards("en", "letters");
        letterCardsList = cachedLetterCards.cards.ToList();

        for(int i = 0; i < cachedLetterCards.cards.Length; i++)
        {
            letterCardNames.Add(cachedLetterCards.cards[i].title.ToLower().Replace(" ", "-"));
        }
    }

    private void CheckRandom()
    {
        tempRandomValue = Random.Range(0, localAlphabet.Count);
        randomValue = tempRandomValue;
        randomValueList.Add(randomValue);
    }

    private void CreateAlphabet()
    {
        foreach(string cardName in cardLocalNames)
        {
            foreach(var letter in cardName)
            {
                string letterString = "" + letter;
                letterString = letterString.ToUpper();
                if(!localAlphabet.Contains(letterString) && letterString != " ")
                {
                    localAlphabet.Add(letterString);
                }
            }
        }
    }

    public async void GeneratedBoardAsync()
    {
        uıController.LoadingScreenActivation();
        finished = false;
        packSlug = packSelectionPanel.selectedPackElement.name;
        await CacheLetterCards();
        await CacheCards(packSlug);
        CreateAlphabet();
        CheckRandom();
        GetGridList();
        CreateWordList();
        for(int j = 0; j < selectedWordCount; j++)
        {
            CreateSelectedWords();
        }
        CreateWordVertical(0);
        CreateWordHorizontal(1);
        CreateWordHorizontal(2);
        for(int i = 0; i < 40; i++)
        {
            CheckRandom();
            var cardName = localAlphabet[randomValueList[i]];
            var card = gridChilds[i];
            if(card.GetComponent<CardElementWordHunt>().filled == false)
            {
                if(cardNames.Contains(localAlphabet[randomValueList[i]]))
                {
                    var cardTexture = await gameAPI.GetCardImage("letters", cardName, 512);
                    cardTexture.wrapMode = TextureWrapMode.Clamp;
                    cardTexture.filterMode = FilterMode.Bilinear;
                    card.transform.name = cardName;
                    card.transform.GetChild(0).gameObject.SetActive(true);
                    card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                    card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                    card.transform.GetChild(1).gameObject.SetActive(false);
                    cards.Add(card);
                }
                else
                {
                    card.transform.SetParent(grid.transform);
                    card.transform.name = cardName;
                    card.transform.GetChild(0).gameObject.SetActive(false);
                    card.transform.GetChild(1).gameObject.SetActive(true);
                    card.transform.GetChild(1).GetComponent<Text>().text = cardName;
                    card.transform.GetChild(1).GetComponent<Text>().color = colors[Random.Range(0, colors.Length)];
                    cards.Add(card);
                }
                card.GetComponent<CardElementWordHunt>().filled = true;
            }
        }
        Invoke("GameUIActivate", 0.5f);
    }

    private void CreateSelectedWords()
    {
        int random = Random.Range(0, accurateWords.Count);
        if(!selectedWords.Contains(accurateWords[random]))
        {
            selectedWords.Add(accurateWords[random]);
        }
        else
        {
            CreateSelectedWords();
        }
    }

    private void CreateWordList()
    {
        foreach(var cardName in cardLocalNames)
        {
            if(cardName.Length <= 5 && !cardName.Contains(" ") && cardName.Length >= 2)
            {
                accurateWords.Add(cardName);
            }
        }
    }

    private void GetGridList()
    {
        foreach(Transform child in grid.transform)
        {
            gridChilds.Add(child.gameObject);
        }
    }

    private void CreateWordHorizontal(int wordIndex)
    {
        tempLetterPositions.Clear();
        elementsEmpty = true;
        string selectedWordName =( "" + selectedWords[wordIndex]).ToUpper();
        int column = Random.Range(0, 5);
        int row = Random.Range(0, 7);
        if((column + selectedWordName.Length) > 7)
        {
            column = 7 - selectedWordName.Length;
            Debug.Log("Column Changed To: " + (7 - selectedWordName.Length));
        }
        foreach(var card in gridChilds)
        {
            if((card.GetComponent<CardElementWordHunt>().column == column)  && card.GetComponent<CardElementWordHunt>().row == row)
            {
                startIndex = card.GetComponent<CardElementWordHunt>().index;
            }
        }
        for(int j = 0; j < selectedWordName.Length; j++)
        {
            var card = gridChilds[startIndex + j];
            tempLetterPositions.Add(card);
        }
        CheckFilledElementOnBoard();
        if(elementsEmpty == true)
        {
            for(int i = 0; i < selectedWordName.Length; i++)
            {
                string cardLetter = "" + selectedWordName[i];
                FillCard(cardLetter, tempLetterPositions[i]);
            }
        }
        else
        {
            CreateWordHorizontal(wordIndex);
            Debug.Log("Horizontal recall: " +  selectedWords[wordIndex].ToUpper());
        }
    }


    private void CreateWordVertical(int wordIndex)
    {
        tempLetterPositions.Clear();
        elementsEmpty = true;
        string selectedWordName =( "" + selectedWords[wordIndex]).ToUpper();
        int column = Random.Range(0, 5);
        int row = Random.Range(0, 7);
        if((column + selectedWordName.Length) > 5)
        {
            row = 5 - selectedWordName.Length;
            Debug.Log("Row Changed To: " + (7 - selectedWordName.Length));
        }
        for(int j = 0; j < selectedWordName.Length; j++)
        {
            var card = gridChilds[startIndex + (j * 8)];
            tempLetterPositions.Add(card);
        }
        CheckFilledElementOnBoard();
        if(elementsEmpty == true)
        {
            for(int i = 0; i < selectedWordName.Length; i++)
            {
                string cardLetter = "" + selectedWordName[i];
                FillCard(cardLetter, tempLetterPositions[i]);
            }
        }
        else if(elementsEmpty == false)
        {
            CreateWordVertical(wordIndex);
            Debug.Log("Vertical recall for: " +  selectedWords[wordIndex].ToUpper());
        }
    }

    private async void FillCard(string cardLetter, GameObject card)
    {
        if(cardNames.Contains(cardLetter))
        {
            var cardTexture = await gameAPI.GetCardImage("letters", cardLetter, 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;
            card.transform.SetParent(grid.transform);
            card.transform.name = cardLetter;
            card.transform.GetChild(0).gameObject.SetActive(true);
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            card.transform.GetChild(1).gameObject.SetActive(false);
            cards.Add(card);
        }
        else
        {
            card.transform.SetParent(grid.transform);
            card.transform.name = cardName;
            card.transform.GetChild(0).gameObject.SetActive(false);
            card.transform.GetChild(1).gameObject.SetActive(true);
            card.transform.GetChild(1).GetComponent<Text>().text = cardLetter;
            card.transform.GetChild(1).GetComponent<Text>().color = colors[Random.Range(0, colors.Length)];
            cards.Add(card);
        }
        card.GetComponent<CardElementWordHunt>().filled = true;
    }

    private void CheckFilledElementOnBoard()
    {
        foreach(var position in tempLetterPositions)
        {
            if(position.GetComponent<CardElementWordHunt>().filled == true)
            {
                elementsEmpty = false;
            }
        }
    }

    public void GameUIActivate()
    {
        foreach(var card in cards)
        {
            LeanTween.scale(card, Vector3.one * 0.9f, 0.3f);
        }
        uıController.GameUIActivate();
    }

    private void CreateNewLevel()
    {
        ClearBoard();
        GeneratedBoardAsync();
    }

    private void GameUIScaleDown()
    {
        foreach(var card in cards)
        {
            LeanTween.scale(card, Vector3.zero, 0.3f);
        }
        uıController.Invoke("GameUIDeactivate", 0.3f);
        Invoke("ClearBoard", 0.3f);
    }

    public void CheckLevelEnding()
    {
    }

    private void LevelEndAnimation() // match animation
    {
        foreach(var card in cards)
        {
            LeanTween.scale(card, Vector3.zero, 0.5f);
        }
        Invoke("ClearBoard", 0.5f);
    }

    private void PlaySuccess()
    {
        gameAPI.PlaySFX("Success");
    }

    public void ClearBoard()
    {
        matchedCardCount = 0;
        cardLocalNames.Clear();
        cardNames.Clear();
        randomValueList.Clear();
        usedRandomOrderCards.Clear();
        selectedWords.Clear();
        uıController.LevelChangeScreenActivate();
    }

    public void BackButtonClear()
    {
        matchedCardCount = 0;
        cardLocalNames.Clear();
        cardNames.Clear();
        randomValueList.Clear();
        usedRandomOrderCards.Clear();
        selectedWords.Clear();
        uıController.PackSelectionPanelActive();
    }
}
