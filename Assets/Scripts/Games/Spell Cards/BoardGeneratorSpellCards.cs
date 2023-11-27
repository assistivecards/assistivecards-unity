using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardGeneratorSpellCards : MonoBehaviour
{
    GameAPI gameAPI;

    [SerializeField] private UIControllerSpellCards uıController;

    [Header ("Cache Cards")]
    public string selectedLangCode;
    public List<GameObject> cards = new List<GameObject>();
    public AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    public List<string> cardNames = new List<string>();
    public List<string> cardLocalNames = new List<string>();
    public List<Texture2D> prefetchedCardTextures = new List<Texture2D>();
    public List<string> prefetchedCardNames = new List<string>();
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    public string packSlug;

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
    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private GameObject dashedSquare;
    [SerializeField] private GameObject tutorial;

    [Header ("Colors")]
    public Color[] colors;

    [Header ("Game Elements")]
    public List<int> selectedWordRandomValues = new List<int>();
    private GameObject selectedCard;
    [SerializeField] private GameObject dashedSquarePosition;
    [SerializeField] private GameObject letterPosition;
    [SerializeField] private GameObject cardPosition;
    private List<GameObject> dashedSquares = new List<GameObject>(); 
    private List<GameObject> letterCards = new List<GameObject>(); 

    [Header ("Game Values")]
    private int matchCount;
    public string selectedWord;
    public int cardCount;
    public int maxLevelCount;
    public int levelCount;
    public int prefetchedCardsCount;
    private string cardName;
    public string firstLetter;
    private GameObject tempCard;
    private int random;
    public int cardNameLenght;

    
    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
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

    public async void PrefetchCardTextures()
    {
        if(uıController.canGenerate)
        {
            packSlug = packSelectionPanel.selectedPackElement.name;
            randomValueList.Clear();
            prefetchedCardTextures.Clear();
            prefetchedCardNames.Clear();
            levelCount = 0;
            await CacheCards(packSlug);
            if(cardNames.Count >= (cardCount * maxLevelCount))
            {
                prefetchedCardsCount = (cardCount * maxLevelCount);
            }
            else
            {
                prefetchedCardsCount = cardNames.Count;
            }
            for(int i = 0; i < prefetchedCardsCount; i++)
            {
                CheckRandom();
            }
            PrefetchNextLevelsTexturesAsync();
        }
    }


    private void CheckRandom()
    {
        tempRandomValue = Random.Range(0, cardNames.Count);

        if(randomValueList.IndexOf(tempRandomValue) < 0)
        {
            randomValue = tempRandomValue;
            randomValueList.Add(randomValue);
        }
        else
        {
            CheckRandom();
        }
    }

    private void CreateRandomForSelectedWord()
    {
        tempRandomValue = Random.Range(0, selectedWord.Length);

        if(selectedWordRandomValues.IndexOf(tempRandomValue) < 0)
        {

            if(tempRandomValue == 0 && selectedWordRandomValues.Count() <= 0)
            {
                CreateRandomForSelectedWord();
            }
            else
            {
                randomValue = tempRandomValue;
                selectedWordRandomValues.Add(randomValue);
            }
        }
        else
        {
            CreateRandomForSelectedWord();
        }
    }

    public async void GeneratedBoardAsync()
    {
        selectedCard = Instantiate(cardPrefab, cardPosition.transform.position, Quaternion.identity);
        selectedCard.transform.SetParent(cardPosition.transform);
        var cardTexture = prefetchedCardTextures[levelCount];
        selectedCard.transform.name = prefetchedCardNames[levelCount];
        selectedCard.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
        selectedCard.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
        LeanTween.scale(selectedCard.gameObject, Vector3.one * 0.5f, 0.1f);
        selectedWord = selectedCard.name;
        CreateLetterObjects();
        CreateDashedSquares();
        uıController.Invoke("GameUIActivate", 0.5f);
    }

    private void CreateLetterObjects()
    {
        for(int i = 0; i < selectedWord.Length; i++)
        {
            CreateRandomForSelectedWord();
            string letter = "" + selectedWord[selectedWordRandomValues[i]];
            GameObject letterCard = Instantiate(letterPrefab, letterPosition.transform.position, Quaternion.identity);
            letterCard.transform.SetParent(letterPosition.transform);
            letterCard.transform.name = letter.ToUpper();
            letterCard.transform.GetChild(0).GetComponent<Text>().text = letter.ToUpper();
            letterCard.transform.GetChild(0).GetComponent<Text>().color = colors[Random.Range(0, colors.Length)];
            letterCard.GetComponent<CardControllerSpellCards>().cardLetter = letter.ToUpper();
            LeanTween.scale(letterCard.gameObject, Vector3.one, 0.1f);
            letterCards.Add(letterCard);
        }
    }

    private void CreateDashedSquares()
    {
        for(int i = 0; i < selectedWord.Length; i++)
        {
            string letter = "" + selectedWord[i];
            GameObject letterCardSlot = Instantiate(dashedSquare, dashedSquarePosition.transform.position, Quaternion.identity);
            letterCardSlot.transform.SetParent(dashedSquarePosition.transform);
            letterCardSlot.GetComponent<CorrectLetterHolderSpellCards>().correctLetterForSlot = letter.ToUpper();
            LeanTween.scale(letterCardSlot.gameObject, Vector3.one, 0.1f);
            dashedSquares.Add(letterCardSlot);
        }
    }

    public void CheckLevelEnd()
    {
        foreach (var correctLetterHolder in dashedSquares)
        {
            if(correctLetterHolder.GetComponent<CorrectLetterHolderSpellCards>().isEmpty == false)
            {
                matchCount++;
            }
            else
            {
                matchCount = 0;
            }
        }
            Debug.Log("LEVEL COUNT: " + levelCount);
        if(matchCount == dashedSquares.Count())
        {
            Debug.Log("LEVEL END");
            if(levelCount == maxLevelCount)
            {
                ClearLevel();
                uıController.GameUIDeactivate();
                uıController.LevelChangeScreenActivate();
            }
            else if(levelCount < maxLevelCount)
            {
                CreateNewLevel();
            }
        }
    }

    private void CreateNewLevel()
    {
        levelCount++;
        ClearBoard();
        GeneratedBoardAsync();
    }


    public void ClearBoard()
    {
        foreach (var correctLetterHolder in dashedSquares)
        {
            Destroy(correctLetterHolder);
        }
        selectedWordRandomValues.Clear();
        dashedSquares.Clear();
        foreach (var letterCard in letterCards)
        {
            Destroy(letterCard);
        }
        letterCards.Clear();
        Destroy(selectedCard);
        cardLocalNames.Clear();
        cards.Clear();
        cardNames.Clear();
        randomValueList.Clear();
    }

    public void ClearLevel()
    {
        levelCount = 0;
        ClearBoard();
    }

    private async Task PrefetchNextLevelsTexturesAsync()
    {
        for(int i = 0; i < prefetchedCardsCount; i++)
        {
            prefetchedCardNames.Add(cardLocalNames[randomValueList[i]]);
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[randomValueList[i]], 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear; 
            prefetchedCardTextures.Add(cardTexture);
        }
        Invoke("GeneratedBoardAsync", 2f);
        uıController.Invoke("SetTutorialActive", 2.1f);
    }
}
