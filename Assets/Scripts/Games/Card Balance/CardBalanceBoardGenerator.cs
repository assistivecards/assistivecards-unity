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
    public List<string> cardLocalNames = new List<string>();
    public List<GameObject> cards = new List<GameObject>();
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    [SerializeField] private PackSelectionPanel packSelectionPanel;

    [Header ("Random")]
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Game UI")]
    public GameObject referencePosition1;
    public GameObject referencePosition2;
    public GameObject referencePosition3;
    private List<GameObject> referencePositions = new List<GameObject>();

    public GameObject cardPosition1;
    public GameObject cardPosition2;
    public GameObject cardPosition3;
    public List<GameObject> cardPositions = new List<GameObject>();
    public List<GameObject> cloneCards = new List<GameObject>();

    private string cardName;
    public int randomOrder;
    public List<int> usedRandomOrderCards = new List<int>();
    public int cardNameLenght;
    public int matchedCardCount;
    public bool isPointerUp;
    private bool finished;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        gameAPI.PlayMusic();
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
        finished = false;
        if(uıController.canGenerate)
        {
            await CacheCards();
            CreateCardPositionList();
            for(int i = 0; i < 3; i++)
            {
                CheckRandom();
                GameObject card = Instantiate(cardPrefab, referencePositions[i].transform.position, Quaternion.identity);

                var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[i]], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.SetParent(referencePositions[i].transform);
                card.transform.name = cardLocalNames[randomValueList[i]];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                card.GetComponent<CardBalanceDraggable>().draggable = false;
                cards.Add(card);

                CreateRandomOrderedCards(i);
                card.transform.localScale = new Vector3(0.45f, 0.45f, 0f);
                card.transform.localPosition = Vector3.zero;
            }
        }
        GameUIActivate();
    }

    private async void CreateRandomOrderedCards(int order)
    {
        randomOrder = Random.Range(0, 3);
        if(!usedRandomOrderCards.Contains(randomOrder) || cardPositions[randomOrder].transform.childCount <= 0)
        {
            GameObject cloneCard = Instantiate(cardPrefab, cardPositions[randomOrder].transform.position, Quaternion.identity);

            var cloneCardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[order]], 512);
            cloneCardTexture.wrapMode = TextureWrapMode.Clamp;
            cloneCardTexture.filterMode = FilterMode.Bilinear;

            cloneCard.transform.SetParent(cardPositions[randomOrder].transform);
            cloneCard.transform.name = cardLocalNames[randomValueList[order]];
            cloneCard.transform.GetChild(0).GetComponent<RawImage>().texture = cloneCardTexture;
            cloneCard.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            cloneCard.GetComponent<CardBalanceDraggable>().draggable = true;
            cloneCard.GetComponent<CardBalanceDraggable>().ActivateGravityEffect();
            cloneCard.GetComponent<CardBalanceDetectFloor>().cardLocalName = cardLocalNames[randomValueList[order]];
            cloneCard.GetComponent<BoxCollider2D>().enabled = true;
            cloneCard.gameObject.tag = "Card";
            cards.Add(cloneCard);
            cloneCards.Add(cloneCard);
            int index = cloneCards.IndexOf(cloneCard);
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
            cloneCard.transform.localScale = new Vector3(0.45f, 0.45f, 0f);
            cloneCard.transform.localPosition = Vector3.zero;
        }
        else if(usedRandomOrderCards.Contains(randomOrder) || cardPositions[randomOrder].transform.childCount > 0)
        {
            CreateRandomOrderedCards(order);
        }
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

        if(matchedCardCount >= 3)
        {
            Invoke("GameUIScaleDown", 0.5f);
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

    public void ClearBoard()
    {
        matchedCardCount = 0;
        foreach(var card in cards)
        {
            Destroy(card);
        }
        cardLocalNames.Clear();
        cards.Clear();
        cloneCards.Clear();
        cardNames.Clear();
        randomValueList.Clear();
        usedRandomOrderCards.Clear();
        if(!finished)
        {
            uıController.LevelChangeScreenActivate();
            gameAPI.PlaySFX("Finished");
            finished = true;
        }
    }

    public void ClearLevel()
    {
        matchedCardCount = 0;
        randomOrder = 0;
        foreach(var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
        cardLocalNames.Clear();
        cloneCards.Clear();
        cardNames.Clear();
        randomValueList.Clear();
        usedRandomOrderCards.Clear();
    }
}
