using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SnakeCardsBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;
    [Header ("Classes")]
    [SerializeField] private SnakeCardsUIController uıController;
    
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

    [Header ("Random")]
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Game Elements")]
    [SerializeField] private GameObject snake;
    [SerializeField] private TMP_Text eatCardsText;
    [SerializeField] private GameObject cardPosition1;
    [SerializeField] private GameObject cardPosition2;
    [SerializeField] private GameObject cardPosition3;
    [SerializeField] private GameObject cardPosition4;
    [SerializeField] private GameObject cardPosition5;
    [SerializeField] private GameObject cardPosition6;
    [SerializeField] private GameObject cardPosition7;
    [SerializeField] private GameObject cardPosition8;
    [SerializeField] private GameObject cardPosition9;
    [SerializeField] private GameObject cardPosition10;
    [SerializeField] private GameObject cardPosition11;
    [SerializeField] private GameObject cardPosition12;
    [SerializeField] private GameObject cardPosition13;
    [SerializeField] private GameObject levelEndCardPosition;
    [SerializeField] private GameObject levelEndCard;
    [SerializeField] private GameObject selectedCardImage;
    [SerializeField] private TMP_Text score;
    [SerializeField] private GameObject collect;
    public List<GameObject> cardPositions = new List<GameObject>();
    public List<GameObject> targetCards = new List<GameObject>();

    [Header ("Game Values")]
    private int targetCardRandomValue;
    public string targetCardLocal;
    public string targetCard;
    public bool gameStarted;
    public int eatenCardCount;
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
        cardPositions.Add(cardPosition2);
        cardPositions.Add(cardPosition10);
        cardPositions.Add(cardPosition11);
        cardPositions.Add(cardPosition12);
        cardPositions.Add(cardPosition3);
        cardPositions.Add(cardPosition5);
        cardPositions.Add(cardPosition6);
        cardPositions.Add(cardPosition7);
        cardPositions.Add(cardPosition8);
        cardPositions.Add(cardPosition9);
        cardPositions.Add(cardPosition1);
        cardPositions.Add(cardPosition4);
        cardPositions.Add(cardPosition13);
    }

    private void RandomizePositions()
    {
        foreach(GameObject position in cardPositions)
        {
            if(position.transform.childCount <= 0)
            {
                LeanTween.moveLocal(position, new Vector3(Random.Range(position.transform.localPosition.x - 30, position.transform.localPosition.x +30),
                Random.Range(position.transform.localPosition.y - 20, position.transform.localPosition.y + 20), 0), 0);
            }
        }
    }

    public async void GeneratedBoardAsync()
    {
        CreatePositionsList();
        RandomizePositions();
        targetCardRandomValue = Random.Range(0, 9);
        if(levelEndCard != null)
        {
            LeanTween.scale(levelEndCard, Vector3.zero, 0.2f);
        }
        for(int j = 0; j < 8; j++)
        {
            if(cardPositions[j].transform.childCount <= 0 && j != targetCardRandomValue)
            {
                GameObject card = Instantiate(cardPrefab, cardPositions[j].transform.position, Quaternion.identity);
                card.transform.SetParent(cardPositions[j].transform);

                var cardTexture = prefetchedCardTextures[j];
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = prefetchedCardNames[j];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                card.GetComponent<SnakeCardsCardController>().cardName = prefetchedCardNames[j];
                card.GetComponent<SnakeCardsCardController>().cardLocalName = prefetchedCardNames[j];
                LeanTween.scale(card, Vector3.one * 0.75f, 0);
                LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-30, 30)), 0f);
                card.gameObject.tag = "Card";
                cards.Add(card);
            }
        }
        for(int i = 8; i < 13; i++)
        {
            if(cardPositions[i].transform.childCount <= 0)
            {
                GameObject card = Instantiate(cardPrefab, cardPositions[i].transform.position, Quaternion.identity);
                card.transform.SetParent(cardPositions[i].transform);

                var cardTexture = prefetchedCardTextures[targetCardRandomValue];
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = prefetchedCardNames[targetCardRandomValue];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                card.GetComponent<SnakeCardsCardController>().cardName = prefetchedCardNames[targetCardRandomValue];
                card.GetComponent<SnakeCardsCardController>().cardLocalName = prefetchedCardNames[targetCardRandomValue];
                LeanTween.scale(card, Vector3.one * 0.75f, 0);
                LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-30, 30)), 0f);
                card.gameObject.tag = "Card";
                targetCards.Add(card);
                cards.Add(card);
            }
        }
        levelEndCard = Instantiate(cardPrefab, levelEndCardPosition.transform.position, Quaternion.identity);
        levelEndCard.transform.SetParent(levelEndCardPosition.transform);
        var targetCardCardTexture = prefetchedCardTextures[targetCardRandomValue];
        targetCardCardTexture.wrapMode = TextureWrapMode.Clamp;
        targetCardCardTexture.filterMode = FilterMode.Bilinear;
        levelEndCard.transform.GetChild(0).GetComponent<RawImage>().texture = targetCardCardTexture;
        levelEndCard.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
        LeanTween.scale(levelEndCard, Vector3.zero, 0);
        selectedCardImage.GetComponent<RawImage>().texture = prefetchedCardTextures[targetCardRandomValue];
        targetCard = prefetchedCardNames[targetCardRandomValue];
        targetCardLocal = prefetchedCardNames[targetCardRandomValue];
        collect.SetActive(true);
        Invoke("GameUIActivate", 0.5f);
    }

    public void CardEaten()
    {
        eatenCardCount++;
        score.text = eatenCardCount.ToString() + " / 5";
        if(eatenCardCount >= targetCards.Count  && levelCount < maxLevelCount)
        {
            eatenCardCount = 0;
            levelCount++;
            Invoke("ClearForRefill", 0.75f);
        }
        else if(eatenCardCount >= 5  && levelCount == maxLevelCount)
        {
            eatenCardCount = 0;
            levelCount = 0;
            uıController.Invoke("LevelChangeScreenActivate", 0.75f);
        }
    }

    public void ScaleUpLevelEndCard()
    {
        gameAPI.Speak(targetCardLocal);
        Debug.Log(targetCardLocal);
        LeanTween.scale(levelEndCard, Vector3.one, 0.5f);
        Invoke("GeneratedBoardAsync", 1f);
    }

    public void GameUIActivate()
    {
        LeanTween.moveLocal(snake, new Vector3(-400, 0, 0), 0);
        snake.GetComponentInChildren<TrailRenderer>().time = 1.5f;
        uıController.GameUIActivate();
        snake.SetActive(true);
        gameStarted = true;
    }

    public void LevelEnd()
    {
        ClearBoard();
        uıController.LevelChangeScreenActivate();
    }

    private void ResetSnake()
    {
        snake.SetActive(false);
        snake.GetComponentInChildren<TrailRenderer>().time = 1.5f;
    }

    public void ClearForRefill()
    {
        gameStarted = false;
        cardNames.Clear();
        cardsList.Clear();
        cardLocalNames.Clear();
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
        randomValueList.Clear();
        cardPositions.Clear();
        targetCards.Clear();
        collect.SetActive(false);
        score.text = eatenCardCount.ToString() + " / 5";
        ResetSnake();
        ScaleUpLevelEndCard();
    }

    public void ClearBoard()
    {
        gameStarted = false;
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cardNames.Clear();
        cardsList.Clear();
        cardLocalNames.Clear();
        cards.Clear();
        randomValueList.Clear();
        cardPositions.Clear();
        targetCards.Clear();
        collect.SetActive(false);
        score.text = eatenCardCount.ToString() + " / 5";
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
