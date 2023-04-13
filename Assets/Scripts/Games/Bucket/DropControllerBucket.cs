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
    [SerializeField] private GameObject end;
    [SerializeField] private TMP_Text collectText;
    [SerializeField] private TMP_Text collectedCountText;


    [SerializeField] private PackSelectionPanel packSelectionPanel;
    [SerializeField] private UIControllerBucket uıControllerBucket;
    public List<GameObject> cards = new List<GameObject>();

    private List<int> randomValues = new List<int>();
    private List<int> usedRandomValues = new List<int>();
    private List<GameObject> collectedDrops = new List<GameObject>();
    private List<GameObject> cardsInGrid = new List<GameObject>();
    private List<GameObject> endCards = new List<GameObject>();
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
        SetCount();
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
        collectableCard = cardNames[random + 2];
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
        bucket.transform.localPosition = new Vector3(-13, -230, 0);
        bucket.SetActive(true);
        Invoke("SelectMoveCard", 1.25f);
        collectText.text = gameAPI.Translate(collectText.gameObject.name, gameAPI.ToSentenceCase(collectableCard).Replace("-", " "), selectedLangCode);
        LeanTween.scale(collectText.gameObject, Vector3.one, 0.2f);
        LeanTween.scale(collectedCountText.gameObject, Vector3.one, 0.2f);
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
        else if(droppedCardCount == 30)
        {
            isBoardCreated = true;
            droppedCardCount ++;
        }
        else if(droppedCardCount > 30)
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
        LeanTween.scale(collectText.gameObject, Vector3.zero, 0.15f).setOnComplete(ResetText);
        LeanTween.scale(collectedCountText.gameObject, Vector3.zero, 0.15f).setOnComplete(ResetText);
        cards.Clear();
        bucket.SetActive(false);
        uıControllerBucket.LevelChangeActive();
        isBoardCreated = false;
        cardsList.Clear();
        matchCount = 0;
        SetCount();
        droppedCardCount = 0;
        cardNames.Clear();
        randomValues.Clear();
        cardLocalNames.Clear();

        GetGridChildList();
        GetBucketChildList();
        GetEndChildList();

        foreach(var drop in collectedDrops)
        {
            Destroy(drop);
        }
        foreach(var child in cardsInGrid)
        {
            Destroy(child);
        }
        foreach(var end in endCards)
        {
            Destroy(end);
        }
    }

    public void ResetLevelBackButtonClick()
    {
        LeanTween.scale(collectText.gameObject, Vector3.zero, 0.15f).setOnComplete(ResetText);
        LeanTween.scale(collectedCountText.gameObject, Vector3.zero, 0.15f).setOnComplete(ResetText);
        cards.Clear();
        bucket.SetActive(false);
        uıControllerBucket.PackSelectionActive();
        isBoardCreated = false;
        cardsList.Clear();
        matchCount = 0;
        SetCount();
        droppedCardCount = 0;
        cardNames.Clear();
        randomValues.Clear();
        cardLocalNames.Clear();
        GetGridChildList();
        GetBucketChildList();
        GetEndChildList();

        foreach(var drop in collectedDrops)
        {
            Destroy(drop);
        }
        foreach(var child in cardsInGrid)
        {
            Destroy(child);
        }
        foreach(var end in endCards)
        {
            Destroy(end);
        }
    }

    private void ResetText()
    {
        collectText.text = "";
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

    private void GetEndChildList()
    {
        for(int i = 0; i < end.transform.childCount; i++)
        {
            endCards.Add(end.transform.GetChild(i).gameObject);
        }
    }

    public void SetCount()
    {
        collectedCountText.text = matchCount.ToString();
    }
}
