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

    [Header ("Cache Cards")]
    public string selectedLangCode;
    public List<string> cardLocalNames = new List<string>();
    public List<GameObject> cards = new List<GameObject>();
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    private string packSlug;


    [Header ("Game Objects & UI")]
    public GameObject moveCard;
    [SerializeField] private GameObject parentalObject;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject bucketBack;
    [SerializeField] private GameObject bucketFront;
    [SerializeField] private GameObject targetCardImage;
    [SerializeField] private GameObject end;
    [SerializeField] private TMP_Text collectText;
    [SerializeField] private TMP_Text collectedCountText;
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    [SerializeField] private UIControllerBucket uıControllerBucket;

    
    [Header ("Random")]
    private List<int> randomValues = new List<int>();
    private int preRandom;
    private int random;


    [Header ("Reset")]
    private List<GameObject> collectedDrops = new List<GameObject>();
    private List<GameObject> cardsInGrid = new List<GameObject>();
    private List<GameObject> endCards = new List<GameObject>();


    [Header ("Check ")]
    public bool isBoardCreated;
    public int matchCount;
    public bool isLevelEnd;
    public string collectableCard;
    public string collectableCardLocale;
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

        if(preRandom == random)
        {
            random =  random - 1;
            collectableCard = cardNames[random + 2];
            collectableCardLocale = cardLocalNames[random + 2];
        }
        else if(preRandom != random)
        {
            collectableCard = cardNames[random + 2];
            collectableCardLocale = cardLocalNames[random + 2];
        }
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
        targetCardImage.GetComponent<RawImage>().texture = await gameAPI.GetCardImage(_packSlug, collectableCard, 512);
        uıControllerBucket.CloseTransitionScreen();
        uıControllerBucket.InGame();
        bucketBack.transform.localPosition = new Vector3(-13, -230, 0);
        bucketBack.SetActive(true);
        bucketFront.SetActive(true);
        Invoke("SelectMoveCard", 1.25f);
        collectText.text = gameAPI.Translate(collectText.gameObject.name, gameAPI.ToSentenceCase(collectableCardLocale).Replace("-", " "), selectedLangCode);
        LeanTween.scale(collectText.gameObject, Vector3.one, 0.2f);
        SetCount();
        LeanTween.scale(collectedCountText.gameObject, Vector3.one, 0.2f);
    }

    public void SelectMoveCard()
    {
        if(droppedCardCount < 30)
        {
            var random = Random.Range(0, cards.Count);

            if(cards.Count > 0)
                moveCard = cards[random];

            isBoardCreated = true;
            droppedCardCount ++;
        }
        else if(droppedCardCount == 30)
        {
            isBoardCreated = true;
            droppedCardCount ++;
            LeanTween.scale(collectText.gameObject, Vector3.zero, 0.15f).setOnComplete(ResetText);
            LeanTween.scale(collectedCountText.gameObject, Vector3.zero, 0.15f).setOnComplete(ResetText);
            Invoke("ResetLevel", 0.25f);
            gameAPI.AddExp(gameAPI.sessionExp);
            gameAPI.PlaySFX("Finished");
        }
        else if(droppedCardCount > 30)
        {
            Invoke("ResetLevel", 0.25f);
            gameAPI.PlaySFX("Finished");
        }
    }

    public void GenerateDropable()
    {
        if(uıControllerBucket.canGenerate)
        {
            GeneratedDropableAsync(packSelectionPanel.selectedPackElement.name);
        }
    }

    public void ResetLevel()
    {
        preRandom = random;
        CloseCollectText();
        cards.Clear();
        bucketBack.SetActive(false);
        bucketFront.SetActive(false);
        uıControllerBucket.LevelChangeActive();
        isBoardCreated = false;
        cardsList.Clear();
        matchCount = 0;
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
        preRandom = random;
        CloseCollectText();
        cards.Clear();
        bucketBack.SetActive(false);
        bucketFront.SetActive(false);
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

    public void CloseCollectText()
    {
        LeanTween.scale(collectedCountText.gameObject, Vector3.zero, 0);
        LeanTween.scale(collectText.gameObject, Vector3.zero, 0).setOnComplete(ResetText);
    }

    private void ResetText()
    {
        collectText.text = "";
    }

    private void GetBucketChildList()
    {
        for(int i = 2; i < bucketBack.transform.childCount; i++)
        {
            collectedDrops.Add(bucketBack.transform.GetChild(i).gameObject);
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
        if(collectedCountText.transform.localScale.x > 0.5f)
        {
            LeanTween.scale(collectedCountText.gameObject, Vector3.one * 1.75f ,0.5f).setOnComplete(ScaleDownCollectText);
        }
    }

    private void ScaleDownCollectText()
    {
        LeanTween.scale(collectedCountText.gameObject, Vector3.one ,0.5f);
    }
}
