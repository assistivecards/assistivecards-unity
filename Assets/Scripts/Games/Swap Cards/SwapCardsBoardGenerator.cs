using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SwapCardsBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;

    [SerializeField] private SwapCardsUIController uıController;

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
    public GameObject cardPosition4;
    public GameObject cardPosition5;
    public GameObject cardPosition6;
    public List<GameObject> cardPositions = new List<GameObject>();
    public List<GameObject> cloneCards = new List<GameObject>();
    public List<Texture> cardTextures = new List<Texture>();
    public List<Transform> cardPosition1Positions = new List<Transform>();
    public List<Transform> cardPosition2Positions = new List<Transform>();
    public List<Transform> cardPosition3Positions = new List<Transform>();

    public string childNameSection1;
    public string childNameSection2;
    public string childNameSection3;

    public int match;
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
        cardPositions.Add(cardPosition4);
        cardPositions.Add(cardPosition5);
        cardPositions.Add(cardPosition6);

        cardPosition1Positions.Add(referencePosition1.transform);
        cardPosition1Positions.Add(referencePosition2.transform);
        cardPosition1Positions.Add(referencePosition3.transform);

        cardPosition2Positions.Add(cardPosition1.transform);
        cardPosition2Positions.Add(cardPosition2.transform);
        cardPosition2Positions.Add(cardPosition3.transform);

        cardPosition3Positions.Add(cardPosition4.transform);
        cardPosition3Positions.Add(cardPosition5.transform);
        cardPosition3Positions.Add(cardPosition5.transform);
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
                cardTextures.Add(cardTexture);
                card.transform.SetParent(referencePositions[i].transform);
                card.transform.name = cardLocalNames[randomValueList[i]];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                card.transform.GetChild(1).GetComponent<TMP_Text>().text = cardLocalNames[randomValueList[i]];
                card.GetComponent<SwapCardsCardController>().cardType = cardLocalNames[randomValueList[i]];
                card.GetComponent<SwapCardsCardController>().parentName = card.transform.parent.transform.tag;
                cards.Add(card);
                card.transform.localScale = new Vector3(0.45f, 0.45f, 0f);
                card.transform.localPosition = Vector3.zero;
            }
            CreateRandomOrderedCards(0);
            CreateRandomOrderedCards(1);
            CreateRandomOrderedCards(2);
            usedRandomOrderCards.Clear();
            CreateRandomOrderedCards(3);
            CreateRandomOrderedCards(4);
            CreateRandomOrderedCards(5);
        }
        GameUIActivate();
    }

    private void CreateRandomOrderedCards(int randomOrder)
    {
        int order = Random.Range(0 , 3);
        if(usedRandomOrderCards.Contains(order))
        {
            CreateRandomOrderedCards(randomOrder);
        }
        else if(!usedRandomOrderCards.Contains(order))
        {
            GameObject cloneCard = Instantiate(cardPrefab, cardPositions[randomOrder].transform.position, Quaternion.identity);

            cloneCard.transform.SetParent(cardPositions[randomOrder].transform);
            cloneCard.transform.name = cardLocalNames[randomValueList[order]];
            cloneCard.transform.GetChild(0).GetComponent<RawImage>().texture = cardTextures[order];
            cloneCard.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            cloneCard.transform.GetChild(1).GetComponent<TMP_Text>().text = cardLocalNames[randomValueList[order]];
            cloneCard.GetComponent<SwapCardsCardController>().cardType = cardLocalNames[randomValueList[order]];
            cloneCard.GetComponent<SwapCardsCardController>().parentName = cloneCard.transform.parent.transform.tag;
            cloneCard.GetComponent<BoxCollider2D>().enabled = true;
            cloneCard.gameObject.tag = "Card";
            cards.Add(cloneCard);
            cloneCards.Add(cloneCard);
            int index = cloneCards.IndexOf(cloneCard);
            usedRandomOrderCards.Add(order);
            cloneCard.transform.localScale = new Vector3(0.45f, 0.45f, 0f);
            cloneCard.transform.localPosition = Vector3.zero;
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

    public void CheckCardChilds()
    {
        childNameSection1 = cardPosition1Positions[0].transform.GetChild(0).transform.GetComponent<SwapCardsCardController>().cardType;
        childNameSection2 = cardPosition2Positions[0].transform.GetChild(0).transform.GetComponent<SwapCardsCardController>().cardType;
        childNameSection3 = cardPosition3Positions[0].transform.GetChild(0).transform.GetComponent<SwapCardsCardController>().cardType;

        foreach(Transform child in cardPosition1Positions)
        {
            if(child.transform.GetChild(0).GetComponent<SwapCardsCardController>().parentName == "CardPositions1")
            {
                Debug.Log("child 1 " + child.transform.GetChild(0).name);
                match++;
            }
        }

        foreach(Transform child in cardPosition2Positions)
        {
            if(child.transform.GetChild(0).GetComponent<SwapCardsCardController>().parentName == "CardPositions2")
            {
                Debug.Log("child 2 " + child.transform.GetChild(0).name);
                match++;
            }
        }

        foreach(Transform child in cardPosition3Positions)
        {
            if(child.transform.GetChild(0).GetComponent<SwapCardsCardController>().parentName == "CardPositions3")
            {
                Debug.Log("child 3 " + child.transform.GetChild(0).name);
                match++;
            }
        }

    }

    public void CheckLevelEnding()
    {
        if(match >= 27)
        {
            ClearLevel();
            Debug.Log("Level Ended");
        }
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
        cardPosition1Positions.Clear();
        cardPosition2Positions.Clear();
        cardPosition3Positions.Clear();
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
        cardPosition1Positions.Clear();
        cardPosition2Positions.Clear();
        cardPosition3Positions.Clear();
        cards.Clear();
        cardLocalNames.Clear();
        cloneCards.Clear();
        cardNames.Clear();
        randomValueList.Clear();
        usedRandomOrderCards.Clear();
    }
}
