using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardGeneratorComplete : MonoBehaviour
{
    GameAPI gameAPI;

    [Header ("Classes")]
    [SerializeField] private UIControllerComplete uıController;
    [SerializeField] private TutorialComplete tutorialComplete;

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

    AssistiveCardsSDK.AssistiveCardsSDK.Cards cardDefinitions;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cardTextures;
    [SerializeField] private GameObject cardPool;
    public List<GameObject> actualCards  = new List<GameObject>();

    private int tempRandomValue;
    private int randomValue;
    public List<int> randomValueList = new List<int>();
    public List<int> usedRandomValues = new List<int>();

    [Header ("Game Objects")]
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject gridBackground;
    [SerializeField] private GameObject actualCardPrefab;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private Transform card1Position;
    [SerializeField] private Transform card2Position;

    [Header ("Game Values")]
    public int cardCount;
    public int maxLevelCount;
    public int levelCount;
    public int prefetchedCardsCount;
    public bool isBoardCreated = false;
    public bool levelEnded;
    public int matchCount;
    [SerializeField] private Color dark;
    private bool oneTime;


    private void OnEnable()
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

    public async Task GeneratedBoardAsync()
    {
        uıController.GameUIActivate();
        for(int j = 0; j < cardCount; j++)
        {
            var cardName = prefetchedCardNames[j];
            var cardTexture = prefetchedCardTextures[j];

            cards.Add(Instantiate(cardPrefab, Vector3.zero, Quaternion.identity));
            cards[j].transform.parent = grid.transform;
            LeanTween.scale(cards[j], Vector3.one * 1.18f, 0);

            cards[j].transform.name = "Card" + j;

            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            cards[j].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            cards[j].transform.GetChild(0).GetComponent<RawImage>().color = dark;
            cards[j].GetComponent<CardElementComplete>().cardType = cardName;

            actualCards.Add(Instantiate(actualCardPrefab, Vector3.zero, Quaternion.identity));
            actualCards[j].transform.parent = cardPool.transform;
            actualCards[j].transform.name = "ActualCard" + j;
            actualCards[j].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            actualCards[j].GetComponent<CardElementComplete>().cardType = cardName;
            actualCards[j].GetComponent<CardElementComplete>().moveable = true;
            actualCards[j].GetComponent<CardElementComplete>().localName = prefetchedCardNames[j];
            actualCards[j].SetActive(false);
        }
        Invoke("FillCardSlot", 0.5f);
        LeanTween.scale(gridBackground, Vector3.one, 0.25f);
        isBoardCreated = true;
        oneTime = true;
    }

    public void CheckChilds()
    {
        card1Position.GetComponent<CardSpawnerComplete>().CheckChild();
        card2Position.GetComponent<CardSpawnerComplete>().CheckChild();
    }

    public void FillCardSlot()
    {
        if(usedRandomValues.Count < cardCount && !levelEnded)
        {
            if(card1Position.GetComponent<CardSpawnerComplete>().hasChild == false)
            {
                var random = UnityEngine.Random.Range(0, 12);
                while(usedRandomValues.Contains(random))
                {
                    random = UnityEngine.Random.Range(0, 12);
                }
                usedRandomValues.Add(random);
                var actualCard = actualCards[random];

                if(actualCard == null)
                {
                    random = Random.Range(0, 12);

                    actualCard.SetActive(true);
                    actualCard.transform.position = card1Position.position;
                    LeanTween.scale(actualCard, Vector3.one * 5, 0.8f);
                    actualCard.transform.SetParent(card1Position);
                }
                else if(actualCard != null)
                {
                    actualCard.SetActive(true);
                    actualCard.transform.position = card1Position.position;
                    actualCard.GetComponent<CardElementComplete>().startPosition = card1Position.position;
                    LeanTween.scale(actualCard, Vector3.one * 5, 0.8f);
                    actualCard.transform.SetParent(card1Position);
                }

            }
            if(card2Position.GetComponent<CardSpawnerComplete>().hasChild == false)
            {
                var random = UnityEngine.Random.Range(0, cardCount);
                while(usedRandomValues.Contains(random))
                {
                    random = UnityEngine.Random.Range(0, cardCount);
                }
                usedRandomValues.Add(random);
                var actualCard = actualCards[random];

                if(actualCard == null)
                {
                    random = UnityEngine.Random.Range(0, cardCount);

                    actualCard.SetActive(true);
                    actualCard.transform.position = card2Position.position;
                    LeanTween.scale(actualCard, Vector3.one * 5, 0.8f);
                    actualCard.transform.SetParent(card2Position);
                }
                else if(actualCard != null)
                {
                    actualCard.SetActive(true);
                    actualCard.transform.position = card2Position.position;
                    actualCard.GetComponent<CardElementComplete>().startPosition = card2Position.position;
                    LeanTween.scale(actualCard, Vector3.one * 5, 0.8f);
                    actualCard.transform.SetParent(card2Position);
                }
            }
        }
    }

    public void ResetLevel()
    {
        foreach (var card in cards)
        {
            Destroy(card);
        }
        foreach (var card in actualCards)
        {
            Destroy(card);
        }
        cardNames.Clear();
        randomValueList.Clear();
        usedRandomValues.Clear();
        cards.Clear();
        actualCards.Clear();
        matchCount = 0;
    }

    public void  EndLevel()
    {
        if(matchCount >= cardCount)
        {
            gameAPI.PlaySFX("Finished");
            LeanTween.scale(gridBackground, Vector3.zero, 0.25f);
            ResetLevel();
            uıController.Invoke("LevelChangeScreenActivate", 0.5f);
        }
    }

    public void BoardCreatedFalse()
    {
        isBoardCreated = false;
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
