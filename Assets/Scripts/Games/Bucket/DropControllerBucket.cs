using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DropControllerBucket : MonoBehaviour
{   
    GameAPI gameAPI;
    public string selectedLangCode;
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    public List<string> cardLocalNames = new List<string>();
    private string packSlug;

    [SerializeField] private GameObject parentalObject;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject bucket;
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    [SerializeField] private UIControllerBucket uıControllerBucket;
    public List<GameObject> cards = new List<GameObject>();

    private List<int> randomValues = new List<int>();
    private List<int> usedRandomValues = new List<int>();
    private List<GameObject> collectedDrops = new List<GameObject>();
    private List<GameObject> cardsInGrid = new List<GameObject>();
    private int random;

    public GameObject moveCard;
    public bool isBoardCreated;
    public int matchCount;
    public bool isLevelEnd;

    public string collectableCard;
    public int droppedCardCount;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();

        cachedCards = await gameAPI.GetCards("en", _packSlug);
        cachedLocalCards = await gameAPI.GetCards(selectedLangCode, _packSlug);
        packSlug = _packSlug;

        cardsList = cachedCards.cards.ToList();

        for(int i = 0; i < cachedCards.cards.Length; i++)
        {
            cardNames.Add(cachedCards.cards[i].title.ToLower().Replace(" ", "-"));
            cardLocalNames.Add(cachedLocalCards.cards[i].title);
        }
    }

    private void CreateIntValues()
    {
        random = Random.Range(0, cardNames.Count - 6);
        collectableCard = cardNames[random];
        Debug.Log("random :" + random);
        Debug.Log("card list :" + cardNames.Count);
        Debug.Log(collectableCard);
    }

    private async void GeneratedDropableAsync(string _packSlug)
    {
        await CacheCards(_packSlug);
        CreateIntValues();
        for(int j = 0; j < 6; j++)
        {
            int randomCard = random + j;
            for(int i=0; i < 5; i++)
            {
                GameObject card = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);

                var cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[randomCard], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = cardNames[randomCard];
                card.transform.SetParent(parentalObject.transform);
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.GetComponent<CardControllerBucket>().cardLocalName = cardLocalNames[randomCard];
                cards.Add(card);
            }
        }
        uıControllerBucket.CloseTransitionScreen();
        uıControllerBucket.InGame();
        bucket.SetActive(true);
        Invoke("SelectMoveCard", 1.25f);
    }

    public void SelectMoveCard()
    {
        if(droppedCardCount < 30)
        {
            var random = Random.Range(0, cards.Count);
            moveCard = cards[random];
            isBoardCreated = true;
            droppedCardCount ++;
        }
        else if(droppedCardCount >= 30)
        {
            Invoke("ResetLevel", 0.25f);
            gameAPI.PlaySFX("Finished");
        }
    }

    public void GenerateDropable()
    {
        GeneratedDropableAsync(packSelectionPanel.selectedPackElement.name);
    }

    public void ResetLevel()
    {
        cards.Clear();
        bucket.SetActive(false);
        uıControllerBucket.LevelChangeActive();
        isBoardCreated = false;
        cardsList.Clear();
        matchCount = 0;
        droppedCardCount = 0;
        cardNames.Clear();
        randomValues.Clear();
        cardLocalNames.Clear();

        GetBucketChildList();

        foreach(var drop in collectedDrops)
        {
            Destroy(drop);
        }
    }

    public void ResetLevelBackButtonClick()
    {
        cards.Clear();
        bucket.SetActive(false);
        uıControllerBucket.PackSelectionActive();
        isBoardCreated = false;
        cardsList.Clear();
        matchCount = 0;
        droppedCardCount = 0;
        cardNames.Clear();
        randomValues.Clear();
        cardLocalNames.Clear();
        GetGridChildList();
        GetBucketChildList();

        foreach(var drop in collectedDrops)
        {
            Destroy(drop);
        }
        foreach(var child in cardsInGrid)
        {
            Destroy(child);
        }
    }

    private void GetBucketChildList()
    {
        for(int i = 0; i < bucket.transform.childCount; i++)
        {
            collectedDrops.Add(bucket.transform.GetChild(i).gameObject);
        }
    }

    private void GetGridChildList()
    {
        for(int i = 0; i < parentalObject.transform.childCount; i++)
        {
            cardsInGrid.Add(parentalObject.transform.GetChild(i).gameObject);
        }
    }
}
