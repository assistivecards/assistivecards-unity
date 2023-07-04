using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CountGenerateBoard : MonoBehaviour
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


    [Header ("Random")]
    private List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

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


    private List<GameObject> cardPositions = new List<GameObject>();


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
        //if(uıController.canGenerate)
        GetPositionList();
        await CacheCards();

        int countNum = Random.Range(1, 8);
        for(int i = 0; i < cardPositions.Count - countNum; i++)
        {
            CheckRandom();
            int parentIndex = Random.Range(0, cardPositions.Count);

            if(cardPositions[parentIndex].transform.childCount > 0)
            {
                for(int j = 0; j < cardPositions.Count; j++)
                {
                    if(cardPositions[j].transform.childCount == 0)
                    {
                        parentIndex = j;
                    }
                }
            }
            GameObject card = Instantiate(cardPrefab, cardPositions[parentIndex].transform.position, Quaternion.identity);

            card.transform.SetParent(cardPositions[parentIndex].transform);

            var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[i]], 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            card.transform.name = cardNames[randomValueList[i]];
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            cards.Add(card);
            LeanTween.scale(card.gameObject, Vector3.one * 0.3f, 0f);
        }

        for(int i = 0; i < countNum; i++)
        {
            int parentIndex = Random.Range(0, cardPositions.Count);

            if(cardPositions[parentIndex].transform.childCount > 0)
            {
                for(int j = 0; j < cardPositions.Count; j++)
                {
                    if(cardPositions[j].transform.childCount == 0)
                    {
                        parentIndex = j;
                    }
                }
            }
            GameObject card = Instantiate(cardPrefab, cardPositions[parentIndex].transform.position, Quaternion.identity);

            card.transform.SetParent(cardPositions[parentIndex].transform);

            var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[0]], 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            card.transform.name = cardNames[randomValueList[i]];
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            cards.Add(card);
            LeanTween.scale(card.gameObject, Vector3.one * 0.3f, 0f);
        }
    }
}
