using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardShootingBoardGenerator : MonoBehaviour
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

    [Header ("Card Fishing Classes")]
    [SerializeField] private CardShootingUIController uıController;
    [SerializeField] private CardShootingBallController ballController;

    [Header ("Game UI")]
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject selectedCardImage;
    [SerializeField] private GameObject cardPrefab;
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
    [SerializeField] private GameObject levelEndCard;
    public Texture2D selectedCardTexture;
    public GameObject selectedObjectAtEnd;
    public int score;

    [Header ("Random")]
    private List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Game Values")]
    public int cardCount;
    public int maxLevelCount;
    public int levelCount;
    public int prefetchedCardsCount;
    private List<GameObject> cardPositions = new List<GameObject>();
    public GameObject selectedCardObject;
    public string selectedCard;
    public string selectedCardLocal;
    public string formerSelected;


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

    private void GetPositionList()
    {
        cardPositions.Add(cardPosition1);
        cardPositions.Add(cardPosition2);
        cardPositions.Add(cardPosition3);
        cardPositions.Add(cardPosition4);
        cardPositions.Add(cardPosition5);
        cardPositions.Add(cardPosition6);
        cardPositions.Add(cardPosition7);
        cardPositions.Add(cardPosition8);
        cardPositions.Add(cardPosition9);
        cardPositions.Add(cardPosition10);
    }

    public async void GeneratedBoardAsync()
    {
        if(uıController.canGenerate)
        {
            GetPositionList();
            for(int i = 0; i < cardPositions.Count / 2; i++)
            {
                int parentIndex = Random.Range(0, cardPositions.Count / 2);

                if(cardPositions[parentIndex].transform.childCount > 0)
                {
                    for(int j = 0; j < cardPositions.Count / 2; j++)
                    {
                        if(cardPositions[j].transform.childCount == 0)
                        {
                            parentIndex = j;
                        }
                    }
                }
                GameObject card = Instantiate(cardPrefab, cardPositions[parentIndex].transform.position, Quaternion.identity);
                LeanTween.rotateZ(card, Random.Range(-30f, 30), 0);

                card.transform.SetParent(cardPositions[parentIndex].transform);

                var cardTexture = prefetchedCardTextures[i + (levelCount * (cardCount / 2))];
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = prefetchedCardNames[i + (levelCount * (cardCount / 2))];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.GetComponent<CardShootingCardName>().cardName = prefetchedCardNames[i + (levelCount * (cardCount / 2))];
                cards.Add(card);
                LeanTween.scale(card.gameObject, Vector3.one * 0.3f, 0f);
            }

            for(int j = 0; j < cardPositions.Count / 2; j++)
            {
                GameObject card = Instantiate(cardPrefab, cardPositions[j + 5].transform.position, Quaternion.identity);
                LeanTween.rotateZ(card, Random.Range(-25f, 25), 0);
                card.transform.SetParent(cardPositions[j + 5].transform);
                var cardTexture = prefetchedCardTextures[j + (levelCount * (cardCount / 2))];
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = prefetchedCardNames[j + (levelCount * (cardCount / 2))];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.GetComponent<CardShootingCardName>().cardName = prefetchedCardNames[j + (levelCount * cardCount / 2)];
                cards.Add(card);
                LeanTween.scale(card.gameObject, Vector3.one * 0.3f, 0f);
            }

            selectedCardObject = cards[Random.Range(0, cards.Count)];
            selectedCard = selectedCardObject.name;
            selectedCardLocal = selectedCardObject.GetComponent<CardShootingCardName>().cardName;
            if(selectedCard == formerSelected)
            {
                selectedCardObject = cards[Random.Range(0, cards.Count)];
                selectedCard = selectedCardObject.name;
                selectedCardLocal = selectedCardObject.GetComponent<CardShootingCardName>().cardName;
            }
            if(selectedObjectAtEnd != null)
            {
                selectedObjectAtEnd.GetComponent<CardShootingCardName>().ScaleDown();
            }
            selectedObjectAtEnd = Instantiate(selectedCardObject, levelEndCard.transform.position, Quaternion.identity);
            selectedObjectAtEnd.transform.GetChild(1).GetComponent<TMP_Text>().text = selectedCardObject.GetComponent<CardShootingCardName>().cardName;
            selectedObjectAtEnd.transform.GetChild(1).gameObject.SetActive(true);
            selectedObjectAtEnd.transform.GetChild(0).transform.localPosition = new Vector3(0, 26, 0);
            selectedCardTexture = (Texture2D)selectedObjectAtEnd.transform.GetChild(0).GetComponent<RawImage>().texture;
            selectedCardImage.GetComponent<RawImage>().texture = selectedCardTexture;
            LeanTween.scale(selectedObjectAtEnd, Vector3.zero, 0);
            LeanTween.rotateZ(selectedObjectAtEnd, 0, 0);
            selectedObjectAtEnd.transform.SetParent(levelEndCard.transform);
            uıController.Invoke("GameUIActivate", 0.5f);
            
        }
    }

    public void LevelEndCardScale()
    {
        LeanTween.scale(selectedObjectAtEnd, Vector3.one, 1f);
        gameAPI.Speak(selectedCardLocal);
        Debug.Log(selectedCardLocal);
        Invoke("LevelEndCardDownScale", 1.5f);

        if(levelCount < maxLevelCount)
        {
            Invoke("GeneratedBoardAsync", 1.5f);
        }
        else
        {
            selectedObjectAtEnd.GetComponent<CardShootingCardName>().Invoke("ScaleDown", 1f);
        }
    }

    public void IncreaseScore(int _score)
    {
        score = score + _score;
        scoreText.GetComponent<TMP_Text>().text = score.ToString() + " / 2";
    }

    public void ClearBoard()
    {
        formerSelected = selectedCard;
        ballController.hitCount = 0;
        cardNames.Clear();
        cardsList.Clear();
        cardLocalNames.Clear();
        cardPositions.Clear();
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
        randomValueList.Clear();
        score = 0;
        IncreaseScore(0);
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
        uıController.Invoke("SetTutorialActive", 2.1f);
    }
}
