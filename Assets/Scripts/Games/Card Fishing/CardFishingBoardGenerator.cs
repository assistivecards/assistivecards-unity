using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardFishingBoardGenerator : MonoBehaviour
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
    [SerializeField] private PackSelectionPanel packSelectionPanel;

    [Header ("Card Fishing Classes")]
    [SerializeField] private CardFishingUIController UIController;
    [SerializeField] private CardFishingCatchMechanic catchMechanics;

    [Header ("Game UI")]
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
    [SerializeField] private TMP_Text collectText;

    [Header ("Random")]
    private List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    private List<GameObject> cardPositions = new List<GameObject>();
    public string selectedCard;
    public string selectedCardLocal;


    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
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
        GetPositionList();
        await CacheCards();
        for(int i = 0; i < cardPositions.Count / 2; i++)
        {
            CheckRandom();
            GameObject card = Instantiate(cardPrefab, cardPositions[i].transform.position, Quaternion.identity);
            LeanTween.rotateZ(card, Random.Range(-25f, 25), 0);
            card.transform.SetParent(cardPositions[i].transform);
            var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[i]], 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            card.transform.name = cardNames[randomValueList[i]];
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            card.GetComponent<CardFishingCardName>().cardName = cardLocalNames[randomValueList[i]];
            cards.Add(card);
        }

        for(int j = 0; j < cardPositions.Count / 2; j++)
        {
            CheckRandom();
            GameObject card = Instantiate(cardPrefab, cardPositions[j + 5].transform.position, Quaternion.identity);
            LeanTween.rotateZ(card, Random.Range(-25f, 25), 0);
            card.transform.SetParent(cardPositions[j + 5].transform);
            var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[j]], 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            card.transform.name = cardNames[randomValueList[j]];
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            card.GetComponent<CardFishingCardName>().cardName = cardLocalNames[randomValueList[j]];
            cards.Add(card);
        }
        int random = Random.Range(0, cards.Count);
        selectedCard = cards[random].name;
        selectedCardLocal = cards[random].GetComponent<CardFishingCardName>().cardName;

        collectText.text = gameAPI.Translate(collectText.gameObject.name, gameAPI.ToSentenceCase(selectedCardLocal).Replace("-", " "), selectedLangCode);
        LeanTween.scale(collectText.gameObject, Vector3.one, 0.2f);
        collectText.gameObject.SetActive(true);
        UIController.GameUIActivate();
    }

    public void ClearBoard()
    {
        cardNames.Clear();
        cardsList.Clear();
        cardLocalNames.Clear();
        cardPositions.Clear();
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
        catchMechanics.catctedCard = false;
        catchMechanics.score = 0;
        catchMechanics.cachedCardCount = 0;
        randomValueList.Clear();
        collectText.gameObject.SetActive(false);
    }
}
