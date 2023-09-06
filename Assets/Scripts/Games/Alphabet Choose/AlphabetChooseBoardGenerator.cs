using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class AlphabetChooseBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;

    [SerializeField] private AlphabetChooseUIController uıController;
    [Header ("Cache Cards")]
    public string selectedLangCode;
    public List<string> cardLocalNames = new List<string>();
    public List<GameObject> cards = new List<GameObject>();
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    [SerializeField] private PackSelectionPanel packSelectionPanel;

    [Header ("Letter Cards")]
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLetterCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> letterList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    public List<string> letterCardsNames = new List<string>();

    [Header ("Random")]
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Game UI")]
    public GameObject cardPosition;
    public GameObject firstLetterText;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    private List<GameObject> buttons = new List<GameObject>();

    [Header ("Colors")]
    public Color[] colors;

    public int levelCount;
    private string cardName;
    private GameObject letterCard;
    private GameObject correctButton;
    private int random;
    public int cardNameLenght;
    public string firstLetter;
    public string formerLetter;

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

    public async Task CreateLetters()
    {
        cachedLetterCards = await gameAPI.GetCards("en", "letters");
        letterList = cachedLetterCards.cards.ToList();

        for(int i = 0; i < cachedLetterCards.cards.Length; i++)
        {
            letterCardsNames.Add(cachedLetterCards.cards[i].title.ToLower().Replace(" ", "-"));
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

    private void CreateButtonList()
    {
        buttons.Add(button1);
        buttons.Add(button2);
        buttons.Add(button3);
    }

    public async void GeneratedBoardAsync()
    {
        if(uıController.canGenerate)
        {
            await CacheCards();
            await CreateLetters();
            CreateButtonList();

            for(int i = 0; i < 3; i++)
            {
                CheckRandom();
                var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[i]], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                buttons[i].transform.name = cardLocalNames[randomValueList[i]];
                buttons[i].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                buttons[i].transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                cards.Add(buttons[i]);
            }
        }
        formerLetter = firstLetter;
        FillLetterCard();
        Invoke("GameUIActivate", 0.3f);
    }

    private async void FillLetterCard()
    {
        random = Random.Range(0,3);
        GetFirstLetter(cards[random]);
        if(formerLetter == firstLetter)
        {
            random = Random.Range(0,3);
            GetFirstLetter(cards[random]);
        }
        correctButton = cards[random];
        letterCard = Instantiate(cardPrefab, cardPosition.transform.position, Quaternion.identity);
        letterCard.transform.SetParent(cardPosition.transform);

        if(letterCardsNames.Contains(firstLetter))
        {
            foreach(var letter in letterCardsNames)
            {
                if(firstLetter == letter.Substring(0, 1))
                {
                    letterCard.transform.GetChild(0).gameObject.SetActive(true);
                    letterCard.transform.GetChild(1).gameObject.SetActive(false);

                    var correctLetterTexture = await gameAPI.GetCardImage("letters", letter, 512);
                    correctLetterTexture.wrapMode = TextureWrapMode.Clamp;
                    correctLetterTexture.filterMode = FilterMode.Bilinear;

                    letterCard.transform.GetChild(0).transform.GetComponent<RawImage>().texture = correctLetterTexture;   
                    LeanTween.scale(letterCard.gameObject, Vector3.one * 0.5f, 0f);
                }
            }
        }
        else
        {
            letterCard.transform.GetChild(0).gameObject.SetActive(false);
            letterCard.transform.GetChild(1).gameObject.SetActive(true);
            letterCard.transform.GetChild(1).GetComponent<TMP_Text>().text = firstLetter.ToLower();
            letterCard.transform.GetChild(1).GetComponent<TMP_Text>().color = colors[Random.Range(0, colors.Length)];
        }
        firstLetterText.GetComponent<TMP_Text>().text = gameAPI.Translate(firstLetterText.gameObject.name, gameAPI.ToSentenceCase(firstLetter).Replace("-", " "), selectedLangCode);
    }

    private void GetFirstLetter(GameObject _card)
    {
        _card.GetComponent<AlphabetChooseButtonController>().firstLetter = _card.name.Substring(0, 1).ToLower();
        cardName = _card.name;
        firstLetter = cardName.Substring(0, 1).ToLower();
        cardNameLenght = _card.name.Length;
    }

    public void GameUIActivate()
    {
        uıController.GameUIActivate();

        buttons[0].transform.localPosition = new Vector3(-300, -190, 0);
        buttons[1].transform.localPosition = new Vector3(0, -190, 0);
        buttons[2].transform.localPosition = new Vector3(300, -190, 0);

        foreach(GameObject button in buttons)
        {
            LeanTween.scale(button, Vector3.one, 0.1f);
        }


        LeanTween.scale(firstLetterText, Vector3.one, 0.1f);
        tutorial.GetComponent<AlphabetChooseTutorial>().SetPosition(cards[random].transform);

    }

    public void LevelEnding()
    {
        LeanTween.moveLocal(correctButton, Vector3.zero, 0.2f).setOnComplete(ScaleUpCard);
        foreach(var button in buttons)
        {
            if(button != correctButton)
                LeanTween.scale(button, Vector3.zero, 0.1f);
        }
        LeanTween.scale(letterCard, Vector3.zero, 0.1f);
        LeanTween.scale(firstLetterText, Vector3.zero, 0.1f);
    }

    private void ScaleUpCard()
    {
        LeanTween.scale(correctButton, Vector3.one * 1.5f, 0.5f).setOnComplete(ScaleDownCard);
    }

    private void ScaleDownCard()
    {
        LeanTween.scale(correctButton, Vector3.zero, 0.4f);
    }

    private void CreateNewLevel()
    {
        ClearBoard();
        GeneratedBoardAsync();
    }

    public void ClearBoard()
    {
        cardLocalNames.Clear();
        cards.Clear();
        cardNames.Clear();
        letterList.Clear();
        letterCardsNames.Clear();

        randomValueList.Clear();

        foreach(GameObject button in buttons)
        {
            LeanTween.scale(button, Vector3.zero, 0.1f);
            button.name = "Button";

            if (EventSystem.current.currentSelectedGameObject == button)
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
        buttons.Clear();

        Destroy(letterCard);

    }
}
