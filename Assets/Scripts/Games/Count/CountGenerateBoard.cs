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

    [Header ("Classes")]
    [SerializeField] private CountUIController uıController;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject buttonPrefab;

    [Header ("Positions")]
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

    [SerializeField] private GameObject buttonPosition1;
    [SerializeField] private GameObject buttonPosition2;
    [SerializeField] private GameObject buttonPosition3;

    [Header ("Game UI")]
    [SerializeField] private TMP_Text countText;



    [Header ("Buttons")]
    [SerializeField] private Sprite image2;
    [SerializeField] private Sprite image3;
    [SerializeField] private Sprite image4;
    [SerializeField] private Sprite image5;
    [SerializeField] private Sprite image6;
    [SerializeField] private Sprite image7;
    [SerializeField] private Sprite image8;
    [SerializeField] private Sprite image9;
    [SerializeField] private Sprite image10;

    [Header ("Lists")]
    public List<GameObject> cardPositions = new List<GameObject>();
    public List<NumberButtons> numberButtons = new List<NumberButtons>();
    public List<GameObject> buttonPositions = new List<GameObject>();
    public List<GameObject> buttons = new List<GameObject>();

    public int countNum;
    private int randomButton;
    private int positionRandom;

    public class NumberButtons
    {
        public Sprite numberImage;
        public int number;

        public NumberButtons(Sprite _numberImage, int _number)
        {
            numberImage = _numberImage;
            number = _number;
        }
    }


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
        cardPositions.Add(cardPosition8);
        cardPositions.Add(cardPosition1);
        cardPositions.Add(cardPosition3);
        cardPositions.Add(cardPosition5);
        cardPositions.Add(cardPosition6);
        cardPositions.Add(cardPosition4);
        cardPositions.Add(cardPosition7);
        cardPositions.Add(cardPosition10);
        cardPositions.Add(cardPosition2);
        cardPositions.Add(cardPosition9);
    }

    private void GetSpriteList()
    {
        numberButtons.Add(new NumberButtons(image2, 2));
        numberButtons.Add(new NumberButtons(image3, 3));
        numberButtons.Add(new NumberButtons(image4, 4));
        numberButtons.Add(new NumberButtons(image5, 5));
        numberButtons.Add(new NumberButtons(image6, 6));
        numberButtons.Add(new NumberButtons(image7, 7));
        numberButtons.Add(new NumberButtons(image8, 8));
        numberButtons.Add(new NumberButtons(image9, 9));
        numberButtons.Add(new NumberButtons(image10, 10));

        buttonPositions.Add(buttonPosition1);
        buttonPositions.Add(buttonPosition2);
        buttonPositions.Add(buttonPosition3);
    }

    public async void GeneratedBoardAsync()
    {
        if(uıController.canGenerate)
        {
            countText.gameObject.SetActive(false);
            GetPositionList();
            GetSpriteList();
            await CacheCards();

            countNum = Random.Range(1, 9);
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
                LeanTween.rotateZ(card, Random.Range(-25f, 25), 0);
                LeanTween.scale(card.gameObject, Vector3.one * 0.3f, 0f);
            }

            countText.text = gameAPI.Translate(countText.gameObject.name, gameAPI.ToSentenceCase(cardLocalNames[randomValueList[0]]).Replace("-", " "), selectedLangCode);
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

                card.transform.name = cardNames[randomValueList[0]];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                cards.Add(card);
                LeanTween.rotateZ(card, Random.Range(-25f, 25), 0);
                LeanTween.scale(card.gameObject, Vector3.one * 0.3f, 0f);
            }

            CreateButton();
            countText.gameObject.SetActive(true);
            uıController.GameUIActivate();
        }

    }
    private void CreateButton()
    {
        foreach(var numberButton in numberButtons)
        {
            if(numberButton.number == countNum + 1)
            {
                positionRandom = Random.Range(0, 3);
                GameObject correctButton = Instantiate(buttonPrefab, buttonPositions[positionRandom].transform.position, Quaternion.identity);
                correctButton.transform.SetParent(buttonPositions[positionRandom].transform);
                correctButton.name = "CorrectButton";
                LeanTween.scale(correctButton, Vector3.one * 1.25f, 0);
                randomButton = Random.Range(0, numberButtons.Count);
                correctButton.transform.GetChild(0).GetComponent<Image>().sprite = numberButton.numberImage;
                correctButton.GetComponent<CountButton>().value = numberButton.number;
                buttons.Add(correctButton);

                buttonPositions.RemoveAt(positionRandom);
            }
        }

        int random = Random.Range(0, numberButtons.Count - 3);    

        for(int i=0; i < buttonPositions.Count; i++)
        {
            CreateDummyButton(i, random);
        }

    }

    private void CreateDummyButton(int positionNum, int random)
    {
        if(buttonPositions[positionNum] != null)
        {

            if(random != positionRandom && random + 1 != positionRandom)   
            {
                GameObject correctButton = Instantiate(buttonPrefab, buttonPositions[positionNum].transform.position, Quaternion.identity);
                correctButton.transform.SetParent(buttonPositions[positionNum].transform);

                LeanTween.scale(correctButton, Vector3.one * 1.25f, 0);
                correctButton.transform.GetChild(0).GetComponent<Image>().sprite = numberButtons[random + positionNum].numberImage;
                correctButton.GetComponent<CountButton>().value = numberButtons[random + positionNum].number;
                buttons.Add(correctButton);
            }
            else
            {
                random = random + 1;
                GameObject correctButton = Instantiate(buttonPrefab, buttonPositions[positionNum].transform.position, Quaternion.identity);
                correctButton.transform.SetParent(buttonPositions[positionNum].transform);

                LeanTween.scale(correctButton, Vector3.one * 1.25f, 0);
                correctButton.transform.GetChild(0).GetComponent<Image>().sprite = numberButtons[random + positionNum].numberImage;
                correctButton.GetComponent<CountButton>().value = numberButtons[random + positionNum].number;
                buttons.Add(correctButton);
            }       
        }
    }

    public void ClearBoard()
    {
        foreach(var card in cards)
        {
            Destroy(card);
        }

        foreach(var button in buttons)
        {
            Destroy(button);
        }

        buttons.Clear();
        cardPositions.Clear();
        numberButtons.Clear();
        buttonPositions.Clear();
        randomValueList.Clear();

        cards.Clear();
        cardNames.Clear();
        cardLocalNames.Clear();
        cardsList.Clear();

        countNum = 0;
        randomButton = 0;
        positionRandom = 0;
    }
}
