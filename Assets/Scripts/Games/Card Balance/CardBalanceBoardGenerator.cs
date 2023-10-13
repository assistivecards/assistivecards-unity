using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardBalanceBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;

    [SerializeField] private CardBalanceUIController uıController;
    [Header ("Cache Cards")]
    public string selectedLangCode;
    public List<GameObject> cards = new List<GameObject>();
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    private List<string> cardNames = new List<string>();
    private List<string> cardLocalNames = new List<string>();
    public List<Texture2D> prefetchedCardTextures = new List<Texture2D>();
    public List<string> prefetchedCardNames = new List<string>();
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    public string packSlug;

    [Header ("Random")]
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;
    public List<Texture2D> usedCardTextures = new List<Texture2D>();

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Game UI")]
    public GameObject referencePosition1;
    public GameObject referencePosition2;
    public GameObject referencePosition3;
    private List<GameObject> referencePositions = new List<GameObject>();
    [SerializeField] private GameObject floors; 

    public GameObject cardPosition1;
    public GameObject cardPosition2;
    public GameObject cardPosition3;
    public List<GameObject> cardPositions = new List<GameObject>();
    public List<GameObject> cloneCards = new List<GameObject>();
    public List<Texture2D> cloneCardsTextures = new List<Texture2D>();

    [Header ("Game Values")]
    public int cardCount;
    public int maxLevelCount;
    public int levelCount;
    private string cardName;
    public int usedRandom;
    public int randomOrder;
    public List<int> usedRandomOrderCards = new List<int>();
    public int cardNameLenght;
    public int matchedCardCount;
    public bool isPointerUp;
    private int order;
    public bool oneTime = true;

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
            for(int i = 0; i < (maxLevelCount * cardCount); i++)
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

    private void CreateCardPositionList()
    {
        referencePositions.Add(referencePosition1);
        referencePositions.Add(referencePosition2);
        referencePositions.Add(referencePosition3);

        cardPositions.Add(cardPosition1);
        cardPositions.Add(cardPosition2);
        cardPositions.Add(cardPosition3);
    }

    public async void GeneratedBoardAsync()
    {
        if(uıController.canGenerate)
        {
            Debug.Log("GeneratedBoardAsync");
            oneTime = true;
            CreateCardPositionList();
            for(int i = 0; i < 3; i++)
            {
                GameObject card = Instantiate(cardPrefab, referencePositions[i].transform.position, Quaternion.identity);

                var cardTexture =  prefetchedCardTextures[i + (levelCount * cardCount)];
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;
                cloneCardsTextures.Add(cardTexture);
                card.transform.SetParent(referencePositions[i].transform);
                card.transform.name = prefetchedCardNames[i + (levelCount * cardCount)];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                card.GetComponent<CardBalanceDraggable>().draggable = false;
                cards.Add(card);

                card.transform.localScale = new Vector3(0.45f, 0.45f, 0f);
                card.transform.localPosition = Vector3.zero;
            }
            CreateRandomOrderedCards();
            floors.SetActive(true);
            GameUIActivate();
        }
    }

    private async void CreateRandomOrderedCards()
    {
        if(!usedRandomOrderCards.Contains(randomOrder) || cardPositions[randomOrder].transform.childCount == 0)
        {
            CreateRandomOrderNum();
            GameObject cloneCard = Instantiate(cardPrefab, cardPositions[randomOrder].transform.position, Quaternion.identity);

            var cloneCardTexture = cloneCardsTextures[randomOrder];
            cloneCardTexture.wrapMode = TextureWrapMode.Clamp;
            cloneCardTexture.filterMode = FilterMode.Bilinear;
            usedCardTextures.Add(cloneCardsTextures[randomOrder]);
            cloneCard.transform.SetParent(cardPositions[randomOrder].transform);
            cloneCard.transform.name = cardNames[randomValueList[randomOrder]];
            cloneCard.transform.GetChild(0).GetComponent<RawImage>().texture = cloneCardTexture;
            cloneCard.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            cloneCard.GetComponent<CardBalanceDraggable>().draggable = true;
            cloneCard.GetComponent<CardBalanceDraggable>().ActivateGravityEffect();
            cloneCard.GetComponent<CardBalanceDetectFloor>().cardLocalName = cardNames[randomValueList[randomOrder]];
            cloneCard.GetComponent<BoxCollider2D>().enabled = true;
            cloneCard.gameObject.tag = "Card";
            cards.Add(cloneCard);
            cloneCards.Add(cloneCard);
            int index = randomOrder;
            if(index == 0)
            {
                cloneCard.GetComponent<CardBalanceDetectFloor>().requiredFloor = "Floor3";
            }
            else if(index == 1)
            {
                cloneCard.GetComponent<CardBalanceDetectFloor>().requiredFloor = "Floor2";
            }
            else if(index == 2)
            {
                cloneCard.GetComponent<CardBalanceDetectFloor>().requiredFloor = "Floor1";
            }
            usedRandom = randomOrder;
            cloneCard.transform.localScale = new Vector3(0.45f, 0.45f, 0f);
            LeanTween.moveLocal(cloneCard, Vector3.zero, 0.75f);
        }
        foreach(var position in cardPositions)
        {
            if(position.transform.childCount <= 0)
            {
                GameObject cloneCard = Instantiate(cardPrefab, position.transform.position, Quaternion.identity);
                var cloneCardTexture = cloneCardsTextures[0];
                for(int j = 0; j < cardCount; j++)
                {
                    if(!usedCardTextures.Contains(cloneCardsTextures[j]))
                    {
                        cloneCardTexture = cloneCardsTextures[j];
                        order = j;
                    }
                }
                usedCardTextures.Add(cloneCardTexture);
                cloneCardTexture.wrapMode = TextureWrapMode.Clamp;
                cloneCardTexture.filterMode = FilterMode.Bilinear;
                cloneCard.transform.SetParent(position.transform);
                cloneCard.transform.name = cardNames[randomValueList[order]];
                cloneCard.transform.GetChild(0).GetComponent<RawImage>().texture = cloneCardTexture;
                cloneCard.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                cloneCard.GetComponent<CardBalanceDraggable>().draggable = true;
                cloneCard.GetComponent<CardBalanceDraggable>().ActivateGravityEffect();
                cloneCard.GetComponent<CardBalanceDetectFloor>().cardLocalName = cardNames[randomValueList[order]];
                cloneCard.GetComponent<BoxCollider2D>().enabled = true;
                cloneCard.gameObject.tag = "Card";
                cards.Add(cloneCard);
                cloneCards.Add(cloneCard);
                int index = order;
                if(index == 0)
                {
                    cloneCard.GetComponent<CardBalanceDetectFloor>().requiredFloor = "Floor3";
                }
                else if(index == 1)
                {
                    cloneCard.GetComponent<CardBalanceDetectFloor>().requiredFloor = "Floor2";
                }
                else if(index == 2)
                {
                    cloneCard.GetComponent<CardBalanceDetectFloor>().requiredFloor = "Floor1";
                }
                usedRandomOrderCards.Add(randomOrder);
                usedRandom = randomOrder;
                cloneCard.transform.localScale = new Vector3(0.45f, 0.45f, 0f);
                LeanTween.moveLocal(cloneCard, Vector3.zero, 0.75f);
            }
        }
    }

    private void CreateRandomOrderNum()
    {
        randomOrder = Random.Range(0,  3);
        usedRandomOrderCards.Add(randomOrder);
    }

    public void DetectMatches()
    {
        foreach (var card in cloneCards)
        {
            if(card.GetComponent<CardBalanceDetectFloor>().matched)
            {
                matchedCardCount++;
            }
        }

        if(matchedCardCount >= cardCount)
        {
            if(oneTime)
            {
                uıController.GameUIDeactivate();
                ClearLevel();
                oneTime = false;
            }
        }
        else
        {
            matchedCardCount = 0;
        }
    }

    public void GameUIActivate()
    {
        foreach(var card in cards)
        {
            LeanTween.scale(card, Vector3.one * 0.45f, 0.3f);
        }
        uıController.GameUIActivate();
    }

    public void ClearLevel()
    {
        Debug.Log("ClearLevel");
        matchedCardCount = 0;
        randomOrder = 0;
        cloneCardsTextures.Clear();
        foreach(var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
        cardLocalNames.Clear();
        cloneCards.Clear();
        usedRandomOrderCards.Clear();
        usedCardTextures.Clear();
        floors.SetActive(false);
        levelCount++;
        if(levelCount == maxLevelCount)
        {
            uıController.LevelChangeScreenActivate();
            gameAPI.PlaySFX("Finished");
        }
        else if(levelCount < maxLevelCount)
        {
            Invoke("GeneratedBoardAsync", 0.5f);
        }
    }

        private async Task PrefetchNextLevelsTexturesAsync()
    {
        for(int i = 0; i < (maxLevelCount * cardCount) ; i++)
        {
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[randomValueList[i]], 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear; 
            prefetchedCardNames.Add(cardLocalNames[randomValueList[i]]);
            prefetchedCardTextures.Add(cardTexture);
        }
        Invoke("GeneratedBoardAsync", 0.5f);
    }
}
