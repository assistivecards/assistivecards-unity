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


    [Header ("Classes")]
    [SerializeField] private UIControllerWordHunt uıController;
    [SerializeField] private DetectTouchWordHunt detectTouch;

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
    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Game Elements")]
    public List<GameObject> gridChilds = new List<GameObject>();
    public List<GameObject> exampleCards = new List<GameObject>();
    public List<GameObject> exampleCardPositions = new List<GameObject>();
    [SerializeField] private GameObject collectText;
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject exampleCard0;
    [SerializeField] private GameObject exampleCard1;
    [SerializeField] private GameObject exampleCard2;
    [SerializeField] private GameObject exampleCard3;
    [SerializeField] private GameObject exampleCard4;
    [SerializeField] private GameObject exampleCard5;
    [SerializeField] private GameObject exampleCard6;

    [Header ("Colors")]
    public Color[] colors;

    [Header ("Game Lists")]
    public List<GameObject> currentWordLetterObjects = new List<GameObject>();
    public List<GameObject> tempLetterPositions = new List<GameObject>();
    public List<string> selectedWords = new List<string>();
    private List<string> selectedWordsEn = new List<string>();
    public List<string> accurateWords = new List<string>();
    private List<string> accurateWordsEn = new List<string>();
    public List<string> longWords = new List<string>();
    private List<string> longWordsEn = new List<string>();
    public List<string> shortWords = new List<string>();
    private List<string> shortWordsEn = new List<string>();
    public List<string> usedWords = new List<string>();
    private List<string> usedWordsEn = new List<string>();
    public List<string> currentWordLetters = new List<string>();
    public List<int> usedRandomOrderCards = new List<int>();
    public List<int> longWordAccurateIndexes = new List<int>();

    [Header ("Game Values")]
    public int horizontalValue;
    public string currentWord;
    public bool elementsEmpty = true;
    public bool isPointerUp;
    public bool finished;
    public int selectedWordCount;
    public int randomOrder;
    public int cardNameLenght;
    public int iterationCountHorizontal;
    public int iterationCountVertical;
    public int score;
    public int function;
    private bool firstElementFilled = false;
    private string cardName;

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
                letterString = letterString.ToLower();
                if(!localAlphabet.Contains(letterString) && letterString != " ")
                {
                    localAlphabet.Add(letterString);
                }
            }
        }
    }

    private void CreateExampleCardsPositionList()
    {
        exampleCardPositions.Add(exampleCard0);
        exampleCardPositions.Add(exampleCard1);
        exampleCardPositions.Add(exampleCard2);
        exampleCardPositions.Add(exampleCard3);
        exampleCardPositions.Add(exampleCard4);
        exampleCardPositions.Add(exampleCard5);
        exampleCardPositions.Add(exampleCard6);
    }

    private async void CreateSelectedLongShortWords()
    {
        int shortWordElement = Random.Range(0, shortWords.Count());
        if(shortWords.Count() > 0)
        {
            if(!selectedWords.Contains(shortWords[shortWordElement]))
            {
                selectedWords.Insert(0, shortWords[shortWordElement]);
                selectedWordsEn.Insert(0, shortWordsEn[shortWordElement]);
            }
            shortWordElement = Random.Range(0, shortWords.Count());
            if(!selectedWords.Contains(shortWords[shortWordElement]))
            {
                selectedWords.Insert(0, shortWords[shortWordElement]);
                selectedWordsEn.Insert(0, shortWordsEn[shortWordElement]);
            }
        }
            
    }

    private async void CreateSelectedWords()
    {
        int random = Random.Range(0, accurateWords.Count);
        
        if(!selectedWords.Contains(accurateWords[random].ToLower()) && accurateWords[random].Length <= 7)
        {
            selectedWords.Add(accurateWords[random].ToLower());
            selectedWordsEn.Add(accurateWordsEn[random].ToLower());
        }
        else if(selectedWords.Contains(accurateWords[random].ToLower()))
        {
            CreateSelectedWords();
        }
    }

    private void CreateWordList()
    {
        for(int i = 0; i < cardLocalNames.Count; i++)
        {
            if(!cardLocalNames[i].Contains(" ") && cardLocalNames[i].Length >= 2)
            {
                accurateWordsEn.Add(cardNames[i]);
                accurateWords.Add(cardLocalNames[i]);
            }
        }

        longWordAccurateIndexes.Add(0);
        longWordAccurateIndexes.Add(8);
        //longWordAccurateIndexes.Add(16);
        longWordAccurateIndexes.Add(24);
        longWordAccurateIndexes.Add(32);
    }

    public async void GeneratedBoardAsync()
    {
        uıController.LoadingScreenActivation();
        finished = false;
        packSlug = packSelectionPanel.selectedPackElement.name;
        await CacheLetterCards();
        await CacheCards(packSlug);
        CreateExampleCardsPositionList();
        CreateAlphabet();
        CheckRandom();
        GetGridList();
        CreateWordList();
        for(int x = 0; x < accurateWords.Count(); x++)
        {
            if(accurateWords[x].Length == 8)
            {
                longWords.Add(accurateWords[x].ToLower());
                longWordsEn.Add(accurateWordsEn[x].ToLower());
            }
            if(accurateWords[x].Length <= 3)
            {
                shortWords.Add(accurateWords[x].ToLower());
                shortWordsEn.Add(accurateWordsEn[x].ToLower());
            }
        }
        for(int j = 0; j < selectedWordCount; j++)
        {
            CreateSelectedWords();
        }
        CreateSelectedLongShortWords();
        if(longWords.Count() > 0)
        {
            CreateLongWordHorizontal(Random.Range(0, longWords.Count()), longWordAccurateIndexes[Random.Range(0, longWordAccurateIndexes.Count())]);
        }
        for(int i = 0; i < selectedWords.Count(); i++)
        {
            if(selectedWords[i].Length >= 5)
            {
                CreateWordHorizontal(i);
            }
            else if(selectedWords[i].Length < 5)
            {
                int random = Random.Range(0, 3);
                switch(random)
                {
                case 0:
                    CreateWordVertical(i, Random.Range(0, 18));
                    break;
                case 1:
                    CreateWordVertical(i, Random.Range(0, 18));
                    break;
                case 2:
                    CreateWordVertical(i, Random.Range(0, 18));
                    break;
                }
            }
        }
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
                    card.GetComponent<CardElementWordHunt>().cardLetter = cardName;
                    card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                    //card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                    card.transform.GetChild(1).gameObject.SetActive(false);
                    cards.Add(card);
                }
                else
                {
                    card.transform.SetParent(grid.transform);
                    card.transform.name = cardName;
                    card.transform.GetChild(0).gameObject.SetActive(false);
                    card.transform.GetChild(1).gameObject.SetActive(true);
                    card.GetComponent<CardElementWordHunt>().cardLetter = cardName;
                    card.transform.GetChild(1).GetComponent<Text>().text = cardName.ToUpper();
                    //card.transform.GetChild(1).GetComponent<Text>().color = colors[Random.Range(0, colors.Length)];
                    cards.Add(card);
                }
                card.GetComponent<CardElementWordHunt>().filled = true;
            }
        }

        for(int i= 0; i < usedWords.Count(); i++)
        {
            if(exampleCardPositions[i] != null)
            {
                GameObject card = Instantiate(cardPrefab, exampleCardPositions[i].transform.position, Quaternion.identity);
                card.transform.SetParent(exampleCardPositions[i].transform);
                var cardTexture = await gameAPI.GetCardImage(packSlug, usedWordsEn[i], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.localScale = Vector3.one * (Random.Range(0.45f, 0.55f));
                card.transform.localPosition = Vector3.zero;
                card.name = usedWords[i];
                exampleCards.Add(card);
                card.GetComponent<ExampleCardWordHunt>().cardName = selectedWords[i];
                LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-40, 40)), 0f);
            }
        }
        UpdateScoreText();
        collectText.SetActive(true);
        Invoke("GameUIActivate", 0.5f);
    }

    private void GetGridList()
    {
        foreach(Transform child in grid.transform)
        {
            gridChilds.Add(child.gameObject);
        }
    }

    private void CreateLongWordHorizontal(int wordIndex, int startIndex)
    {
        tempLetterPositions.Clear();
        elementsEmpty = true;
        string selectedWordName =( "" + longWords[wordIndex]).ToLower();
        for(int j = 0; j < selectedWordName.Length; j++)
        {
            var card = gridChilds[startIndex + j];
            tempLetterPositions.Add(card);
        }
        if(elementsEmpty == true)
        {
            usedWordsEn.Add(longWordsEn[wordIndex]);
            usedWords.Add(longWords[wordIndex]);
            for(int i = 0; i < selectedWordName.Length; i++)
            {
                string cardLetter = "" + selectedWordName[i];
                FillCard(cardLetter, tempLetterPositions[i]);
            }
        }
    }

    private void CreateWordHorizontal(int wordIndex)
    {
        tempLetterPositions.Clear();
        elementsEmpty = true;
        string selectedWordName =( "" + selectedWords[wordIndex]).ToLower();
        int startIndex = 0;
        int column = Random.Range(0, 6);
        int row = Random.Range(0, 5);
        if((column + selectedWordName.Length) > 7)
        {
            column = 7 - (selectedWordName.Length);
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
            if(gridChilds[startIndex + j] != null)
            {
                var card = gridChilds[startIndex + j];
                tempLetterPositions.Add(card);
            }
        }
        CheckFilledElementOnBoard();
        if(elementsEmpty == true)
        {
            usedWordsEn.Add(selectedWordsEn[wordIndex]);
            usedWords.Add(selectedWords[wordIndex]);
            for(int i = 0; i < selectedWordName.Length; i++)
            {
                string cardLetter = "" + selectedWordName[i];
                FillCard(cardLetter, tempLetterPositions[i]);
            }
            iterationCountHorizontal = 0;
        }
    }


    private void CreateWordVertical(int wordIndex, int startIndex)
    {
        tempLetterPositions.Clear();
        elementsEmpty = true;
        string selectedWordName =( "" + selectedWords[wordIndex]).ToLower();
        int column;
        int row;
        if(startIndex + ((selectedWordName.Length) * 8) > 40)
        {
            startIndex = 39 - ((selectedWordName.Length) * 8);
        }
        for(int j = 0; j < selectedWordName.Length; j++)
        {
            var card = gridChilds[startIndex + (j * 8)];
            tempLetterPositions.Add(card);
        }
        CheckFilledElementOnBoard();
        if(elementsEmpty == true)
        {
            usedWordsEn.Add(selectedWordsEn[wordIndex]);
            usedWords.Add(selectedWords[wordIndex]);
            for(int i = 0; i < selectedWordName.Length; i++)
            {
                string cardLetter = "" + selectedWordName[i];
                FillCard(cardLetter, tempLetterPositions[i]);
            }
            iterationCountVertical = 0;
        }
        else if(elementsEmpty == false && iterationCountVertical < 10)
        {
            if(startIndex < 32)
            {
                iterationCountVertical++;
                CreateWordVertical(wordIndex, startIndex + 1);
            }
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
            card.GetComponent<CardElementWordHunt>().cardLetter = cardLetter;
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            //card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            card.transform.GetChild(1).gameObject.SetActive(false);
            cards.Add(card);
        }
        else
        {
            card.transform.SetParent(grid.transform);
            card.transform.name = cardLetter;
            card.transform.GetChild(0).gameObject.SetActive(false);
            card.transform.GetChild(1).gameObject.SetActive(true);
            card.GetComponent<CardElementWordHunt>().cardLetter = cardLetter;
            card.transform.GetChild(1).GetComponent<Text>().text = cardLetter.ToUpper();
            //card.transform.GetChild(1).GetComponent<Text>().color = colors[Random.Range(0, colors.Length)];
            cards.Add(card);
        }
        card.GetComponent<CardElementWordHunt>().filled = true;
    }

    private void CheckFilledElementOnBoard()
    {
        foreach(var position in tempLetterPositions)
        {
            if(position != null)
            {
                if(position.GetComponent<CardElementWordHunt>() != null)
                {
                    if(position.GetComponent<CardElementWordHunt>().filled == true)
                    {
                        elementsEmpty = false;
                    }
                }
            }
        }
    }

    private void UpdateScoreText()
    {
        collectText.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = score + " / " + usedWords.Count().ToString();
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

    public void CheckWord()
    {
        foreach(var letter in currentWordLetters)
        {
            currentWord += letter;
        }

        if(!usedWords.Contains(currentWord))
        {
            foreach(var letterObject in currentWordLetterObjects)
            {
                letterObject.GetComponent<Image>().color = Color.white;
                letterObject.GetComponent<CardElementWordHunt>().oneTime = true;
            }
        }
        else
        {
            gameAPI.PlayConfettiParticle(detectTouch.touchDetectionObject.transform.position);
        }
        ExampleCardDestroyAnimation();
        Invoke("CheckLevelEnding", 1.25f);
        Invoke("ResetWord", 1f);
    }

    private void ExampleCardDestroyAnimation()
    {
        foreach(var card in exampleCards)
        {
            if(card.name == currentWord)
            {
                score++;
                UpdateScoreText();
                card.GetComponent<ExampleCardWordHunt>().ScaleUp();
            }
        }
    }

    public void ResetWord()
    {
        currentWordLetterObjects.Clear();
        currentWordLetters.Clear();
        currentWord = "";
    }

    public void CheckLevelEnding()
    {
        if(score == usedWords.Count())
        {
            ClearBoard();
            uıController.LevelChangeScreenActivate();
        }
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

    private void PlaySuccess()
    {
        gameAPI.PlaySFX("Success");
    }

    public void ClearBoard()
    {
        foreach(var card in exampleCards)
        {
            Destroy(card);
        }
        foreach(var child in gridChilds)
        {
            child.GetComponent<CardElementWordHunt>().filled = false;
            child.GetComponent<CardElementWordHunt>().oneTime = true;
            child.GetComponent<Image>().color = Color.white;
        }
        exampleCards.Clear();
        cards.Clear();
        cardsList.Clear();
        gridChilds.Clear();
        exampleCardPositions.Clear();
        selectedWords.Clear();
        selectedWordsEn.Clear();
        usedWords.Clear();
        usedWordsEn.Clear();
        score = 0;
        iterationCountVertical = 0;
        iterationCountHorizontal = 0;
        accurateWords.Clear();
        accurateWordsEn.Clear();
        usedRandomOrderCards.Clear();
        tempLetterPositions.Clear();
        currentWordLetters.Clear();
        localAlphabet.Clear();
        letterCardNames.Clear();
        letterCardsList.Clear();
        cardLocalNames.Clear();
        cardNames.Clear();
        randomValueList.Clear();
        usedRandomOrderCards.Clear();
        longWords.Clear();
        longWordsEn.Clear();
        shortWords.Clear();
        shortWordsEn.Clear();
        longWordAccurateIndexes.Clear();
        firstElementFilled = false;
    }
}
