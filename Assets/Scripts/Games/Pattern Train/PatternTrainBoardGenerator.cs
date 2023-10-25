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

    private GameObject questionMarkSlot;
    public string trueCardName;
    public int randomPosition;
    public int questionMarkSlotIndex ;
    public int round;
    public int patternCardCount;

    [Header ("Game Values")]
    public int cardCount;
    public int maxLevelCount;
    public int levelCount;
    public int prefetchedCardsCount;

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

    private void CreateQuestionMarkSlot()
    {
        questionMarkSlotIndex = Random.Range(1, patternPositions.Count - 1);
    }

    public async void GeneratedBoardAsync()
    {
        if(uıController.canGenerate)
        {
            uıController.LoadingScreenActivation();
            CreatePositionsList();
            CreateQuestionMarkSlot();
            patternCardCount = Random.Range(2, 4);
            for(int j = 0; j < patternPositions.Count; j++)
            {
                if(j != questionMarkSlotIndex)
                {
                    FillSlot(j, (j % patternCardCount) + levelCount);
                }
                else if(j == questionMarkSlotIndex)
                {
                    questionMarkSlot = Instantiate(cardPrefab, patternPositions[j].transform.position, Quaternion.identity);
                    questionMarkSlot.transform.SetParent( patternPositions[j].transform);
                    questionMarkSlot.transform.GetChild(0).gameObject.SetActive(false);
                    questionMarkSlot.transform.GetChild(1).gameObject.SetActive(true);
                    trueCardName = prefetchedCardNames[(j % patternCardCount) + levelCount].ToLower();
                    questionMarkSlot.GetComponent<BoxCollider2D>().enabled = true;
                }

            }
            for(int j = 0; j < draggablePositions.Count; j++)
            {
                randomPosition = Random.Range(0, draggablePositions.Count);
                GameObject card = Instantiate(cardPrefab, draggablePositions[j].transform.position, Quaternion.identity);
                card.transform.SetParent( draggablePositions[j].transform);

                var cardTexture = prefetchedCardTextures[j + levelCount];
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;
                card.transform.tag = "Untagged";
                card.transform.name = prefetchedCardNames[j + levelCount].ToLower();
                card.GetComponent<PatternTrainCardController>().draggable = true;
                card.GetComponent<PatternTrainCardController>().cardName = prefetchedCardNames[j + levelCount];
                card.GetComponent<PatternTrainCardController>().trueCardName = trueCardName;
                card.GetComponent<PatternTrainCardController>().cardLocalName = prefetchedCardNames[j + levelCount];
                card.GetComponent<BoxCollider2D>().enabled = true;
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                if(prefetchedCardNames[j + levelCount].ToLower() == trueCardName)
                {
                    tutorial.GetComponent<PatternTrainTutorial>().trueCard = card.transform;
                }
                cards.Add(card);
            }
            Invoke("GameUIActivate", 0.1f);
        }
    }

    private async void FillSlot(int _positionIndex, int _cardIndex)
    {
        GameObject card = Instantiate(cardPrefab, patternPositions[_positionIndex].transform.position, Quaternion.identity);
        card.transform.SetParent( patternPositions[_positionIndex].transform);
        var cardTexture = prefetchedCardTextures[_cardIndex];
        cardTexture.wrapMode = TextureWrapMode.Clamp;
        cardTexture.filterMode = FilterMode.Bilinear;

        card.transform.name = prefetchedCardNames[_cardIndex];
        card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
        card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
        LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-15, 15)), 0f);
        cards.Add(card);
        round++;
    }

    public void GameUIActivate()
    {
        uıController.GameUIActivate();
    }

    public void LevelEnd()
    {
        ClearBoard();
        uıController.LevelEndCheck();
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
        Destroy(questionMarkSlot);
        randomValueList.Clear();
        patternPositions.Clear();
        draggablePositions.Clear();
        trueCardName = null;
        levelCount++;
        round = 0;
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
            Debug.Log(cardNames[randomValueList[i]]);
        }
        Invoke("GeneratedBoardAsync", 2f);
    }
}
