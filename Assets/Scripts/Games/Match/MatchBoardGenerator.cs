using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class MatchBoardGenerator : MonoBehaviour
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
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;

    [Header ("Positions")]
    [SerializeField] private GameObject cardPosition1;
    [SerializeField] private GameObject cardPosition2;
    [SerializeField] private GameObject cardPosition3;
    [SerializeField] private GameObject cardPosition4;
    [SerializeField] private GameObject cardPosition5;
    [SerializeField] private GameObject cardPosition6;

    [Header ("Lists")]
    public List<GameObject> cardPositions = new List<GameObject>();
    public List<int> cardPositionRandoms = new List<int>(); 
    private int randomCardPosition;

    public string firstColumnCards;
    public string secondColumnCards;
    public int matchCount;


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
    }

    public async void GeneratedBoardAsync()
    {
        //if(uıController.canGenerate)
            GetPositionList();
            await CacheCards();

            for(int i = 0; i < cardPositions.Count / 2; i++)
            {
                CheckRandom();

                GameObject card = Instantiate(cardPrefab, cardPositions[i].transform.position, Quaternion.identity);
                card.transform.SetParent(cardPositions[i].transform);

                var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[i]], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = cardNames[randomValueList[i]];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                cards.Add(card);
                card.GetComponent<MatchCardElement>().moveable = false;
                card.GetComponent<MatchCardElement>().cardName = cardLocalNames[randomValueList[i]];
                LeanTween.scale(card.gameObject, Vector3.one * 0.5f, 0f);
            }

            for(int i = 0; i < cardPositions.Count / 2; i++)
            {
                CreateRandomCardPos();

                GameObject card = Instantiate(cardPrefab, cardPositions[cardPositionRandoms[i]].transform.position, Quaternion.identity);
                card.transform.SetParent(cardPositions[cardPositionRandoms[i]].transform);

                var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[i]], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = cardNames[randomValueList[i]];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                cards.Add(card);
                card.GetComponent<MatchCardElement>().moveable = true;
                card.GetComponent<MatchCardElement>().cardName = cardLocalNames[randomValueList[i]];
                LeanTween.scale(card.gameObject, Vector3.one * 0.5f, 0f);
            }

            for(int i = 0; i < cards.Count; i++)
            {
                if(i < 3)
                {
                    firstColumnCards = firstColumnCards + " - " + cardPositions[i].transform.GetChild(0).name;
                }
                else if(i >= 3)
                {
                    secondColumnCards = secondColumnCards + " - " + cardPositions[i].transform.GetChild(0).name;
                }
            }
            //uıController.GameUIActivate();
            CheckColumnStrings();
    }

    private void CheckColumnStrings()
    {
        if(firstColumnCards == secondColumnCards)
        {
            Debug.Log("CheckColumnStrings");
            ChangePositions();
        }
    }

    private void ChangePositions()
    {
        cardPositions[0].transform.GetChild(0).transform.position = cardPositions[1].transform.position;
        cardPositions[1].transform.GetChild(0).transform.position = cardPositions[0].transform.position;
    }

    private void CreateRandomCardPos()
    {
        randomCardPosition = Random.Range(3, 6);

        if(!cardPositionRandoms.Contains(randomCardPosition))
        {
            cardPositionRandoms.Add(randomCardPosition);
        }
        else
        {
            CreateRandomCardPos();
        }
    }

    private void ClearBoard()
    {
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
        firstColumnCards = null;
        secondColumnCards = null;
    }

    public void CheckMatches()
    {
        foreach(GameObject card in cards)
        {
            if(card.GetComponent<MatchCardElement>().match == true)
            {
                matchCount++;
            }
        }

        if(matchCount != 6)
        {
            matchCount = 0;
        }
        else if(matchCount == 6)
        {
            // call level end function
        }
    }
}
