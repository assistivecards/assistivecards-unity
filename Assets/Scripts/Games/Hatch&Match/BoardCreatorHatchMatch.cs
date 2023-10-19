using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardCreatorHatchMatch : MonoBehaviour
{
    GameAPI gameAPI;

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

    [Header ("Game Objects")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject actualCardPrefab;
    [SerializeField] private Transform card1Position;
    [SerializeField] private Transform card2Position;
    [SerializeField] private Transform card3Position;
    [SerializeField] private Transform cardPosition;
    [SerializeField] private GameObject egg;
    [SerializeField] private PackSelectionScreenUIController packageSelectManager;
    [SerializeField] private HatchMatchUIController uıController;

    [Header ("Random")]
    private List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;
    public List<GameObject> guessCards = new List<GameObject>();
    public bool levelEnd;
    public bool boardCreated = false;
    public GameObject card;
    public GameObject[] clones;
    public string previousCard;
    public string actualCardType;

    [Header ("Game Values")]
    public int cardCount;
    public int maxLevelCount;
    public int levelCount;
    public int prefetchedCardsCount;

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

    public async void PrefetchCardTextures()
    {
        if(uıController.canGenerate)
        {
            packSlug = packSelectionPanel.selectedPackElement.name;
            randomValueList.Clear();
            prefetchedCardTextures.Clear();
            prefetchedCardNames.Clear();
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

    private async void  GenerateCard(string _packSlug, Transform _cardPosition, int _randomValue)
    {
        egg.GetComponent<EggController>().ResetEgg();
        var cardTexture = prefetchedCardTextures[_randomValue];
        
        GameObject card1 = Instantiate(cardPrefab, _cardPosition.position, Quaternion.identity);

        cardTexture.wrapMode = TextureWrapMode.Clamp;
        cardTexture.filterMode = FilterMode.Bilinear;

        card1.transform.name = prefetchedCardNames[_randomValue];
        card1.transform.SetParent(this.transform);
        card1.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

        guessCards.Add(card1);
        cards.Add(card1);
    }

    private async void  GenerateActualCard(string _packSlug, Transform _cardPosition, int _randomValue)
    {
        var cardTexture = prefetchedCardTextures[_randomValue];
        
        GameObject card1 = Instantiate(actualCardPrefab, _cardPosition.position, Quaternion.identity);

        cardTexture.wrapMode = TextureWrapMode.Clamp;
        cardTexture.filterMode = FilterMode.Bilinear;

        card1.transform.name = prefetchedCardNames[_randomValue];
        card1.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
        card = card1;
        card1.transform.SetParent(this.transform);
        card1.GetComponent<CardElementHatchMatch>().cardName = prefetchedCardNames[_randomValue];
        cards.Add(card1);

        actualCardType = prefetchedCardNames[_randomValue];
    }

    public async void GeneratStylized()
    {
        if(packageSelectManager.canGenerate)
        {
            GenerateCard(packSelectionPanel.selectedPackElement.name, card1Position, 1);
            GenerateCard(packSelectionPanel.selectedPackElement.name, card2Position, 2);
            GenerateCard(packSelectionPanel.selectedPackElement.name, card3Position, 3);
            egg.SetActive(true);
            LeanTween.scale(egg, Vector3.one * 1.25f, 1f);
            Invoke("GenerateStylizedCard", 0.5f);
            uıController.GameUIActivate();
            Invoke("ScaleUpCards", 1f);
        }
    }

    private void GenerateStylizedCard()
    {
        if(uıController.canGenerate)
        {
            GenerateActualCard(packSelectionPanel.selectedPackElement.name, cardPosition, Random.Range(1,4));

            if(actualCardType != previousCard)
            {
                previousCard = actualCardType;
                boardCreated = true;
            }
            else if(actualCardType == previousCard)
            {
                GenerateActualCard(packSelectionPanel.selectedPackElement.name, cardPosition, Random.Range(1,4));
                boardCreated = true;
                previousCard = actualCardType;
            }
        }
    }

    private void ScaleUpCards()
    {
        foreach(var card in guessCards)
        {
            card.transform.localScale = Vector3.one * 0.5f;
        }
    }

    public void NewLevel() 
    {
        ReloadBoard();
        levelEnd = false;
    }

    private void ReloadBoard()
    {
        LevelEndAnimationStart();
        cards.Clear();
        guessCards.Clear();
        egg.GetComponent<EggController>().clickCount = 0;
        boardCreated = false;
        Invoke("GeneratStylized", 1f);     
        levelCount++;
        Invoke(nameof(ClearLevel), 0.25f);
    }

    public void ResetBoard()
    {
        LevelEndAnimationStart();
        cards.Clear();
        guessCards.Clear();
        egg.GetComponent<EggController>().clickCount = 0;
        LeanTween.scale(egg, Vector3.zero, 0.1f);
        boardCreated = false;    
        Invoke(nameof(ClearLevel), 0.25f);
    }

    public void ActivateLevelChange()
    {
        uıController.LevelChangeScreenActivate();
        gameAPI.AddExp(gameAPI.sessionExp);
    }


    public void ResetLevelCount()
    {
        levelCount = 0;
        cardsList.Clear();
        cardNames.Clear();
        tempRandomValue = 0;
        cards.Clear();
        guessCards.Clear();
    }

    private void ClearLevel()
    {
        clones = GameObject.FindGameObjectsWithTag("cardBlast");

        foreach(var clone in clones)
        {
            Destroy(clone);
        }

        foreach (var card in cards)
        {
            Destroy(card);
        }
    }

    private void LevelEndAnimationStart()
    {
        foreach (var card in cards)
        {
            LeanTween.scale(card, Vector3.zero, 0.25f);
        }
        uıController.LoadingScreenActivation();
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
