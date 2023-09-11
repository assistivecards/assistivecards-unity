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
    public List<string> cardLocalNames = new List<string>();
    public List<GameObject> cards = new List<GameObject>();
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    [SerializeField] private PackSelectionPanel packSelectionPanel;

    [Header ("Card Fishing Classes")]
    [SerializeField] private CardShootingUIController uıController;
    [SerializeField] private CardShootingBallController ballController;

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
    [SerializeField] private GameObject levelEndCard;
    [SerializeField] private TMP_Text collectText;
    public GameObject selectedObjectAtEnd;

    [Header ("Random")]
    private List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;


    private List<GameObject> cardPositions = new List<GameObject>();
    public GameObject selectedCardObject;
    public string selectedCard;
    public string selectedCardLocal;
    public string formerSelected;


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
        if(uıController.canGenerate)
        {
            GetPositionList();
            await CacheCards();
            for(int i = 0; i < cardPositions.Count / 2; i++)
            {
                CheckRandom();
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

                var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[i]], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = cardNames[randomValueList[i]];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.GetComponent<CardShootingCardName>().cardName = cardLocalNames[randomValueList[i]];
                cards.Add(card);
                LeanTween.scale(card.gameObject, Vector3.one * 0.3f, 0f);
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
                card.GetComponent<CardShootingCardName>().cardName = cardLocalNames[randomValueList[j]];
                cards.Add(card);
                LeanTween.scale(card.gameObject, Vector3.one * 0.3f, 0f);
            }


            if(selectedObjectAtEnd != null)
            {
                selectedObjectAtEnd.GetComponent<CardShootingCardName>().ScaleDown();
            }

            selectedCardObject = cards[Random.Range(0, cards.Count)];
            selectedCard = selectedCardObject.name;
            selectedCardLocal = selectedCardObject.GetComponent<CardShootingCardName>().cardName;

            if(selectedCard == formerSelected)
            {
                selectedCard = cards[Random.Range(0, cards.Count)].name;
            }
            selectedObjectAtEnd = Instantiate(selectedCardObject, levelEndCard.transform.position, Quaternion.identity);
            selectedObjectAtEnd.transform.GetChild(1).GetComponent<TMP_Text>().text = selectedCardObject.GetComponent<CardShootingCardName>().cardName;
            selectedObjectAtEnd.transform.GetChild(1).gameObject.SetActive(true);
            selectedObjectAtEnd.transform.GetChild(0).transform.localPosition = new Vector3(0, 26, 0);
            LeanTween.scale(selectedObjectAtEnd, Vector3.zero, 0);
            LeanTween.rotateZ(selectedObjectAtEnd, 0, 0);
            selectedObjectAtEnd.transform.SetParent(levelEndCard.transform);


            collectText.text = gameAPI.Translate(collectText.gameObject.name, gameAPI.ToSentenceCase(selectedCard).Replace("-", " "), selectedLangCode);
            LeanTween.scale(collectText.gameObject, Vector3.one, 0.2f);
            collectText.gameObject.SetActive(true);

            uıController.Invoke("GameUIActivate", 0.5f);
            
        }
    }

    public void LevelEndCardScale()
    {
        LeanTween.scale(selectedObjectAtEnd, Vector3.one, 1f);
        gameAPI.Speak(selectedCardLocal);
        Debug.Log(selectedCardLocal);
        Invoke("LevelEndCardDownScale", 1.5f);

        if(ballController.levelCount < 3)
        {
            GeneratedBoardAsync();
        }
        else
        {
            selectedObjectAtEnd.GetComponent<CardShootingCardName>().Invoke("ScaleDown", 1f);
        }
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
        collectText.gameObject.SetActive(false);
    }
}
