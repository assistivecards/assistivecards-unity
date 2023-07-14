using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    [Header ("Random Letters")]
    public List<int> randomLetterValueList = new List<int>();
    private int tempRandomLetterValue;
    private int randomLetterValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;

    [Header ("Game UI")]
    public GameObject card;
    public GameObject cardPosition;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    private List<GameObject> buttons = new List<GameObject>();

    [Header ("Colors")]
    public Color[] colors;

    public int levelCount;
    private string cardName;
    public string firstLetter;
    private GameObject tempCard;

    
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

    
    private void CheckRandomForLetters()
    {
        tempRandomLetterValue = Random.Range(0, letterList.Count);

        if(!randomLetterValueList.Contains(tempRandomLetterValue))
        {
            randomLetterValue = tempRandomLetterValue;
            randomLetterValueList.Add(randomLetterValue);
        }
        else
        {
            CheckRandomForLetters();
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
            CheckRandom();
            card = Instantiate(cardPrefab, cardPosition.transform.position, Quaternion.identity);
            card.transform.SetParent(cardPosition.transform);

            var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[0]], 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            card.transform.name = cardLocalNames[randomValueList[0]];
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            cards.Add(card);
            LeanTween.scale(card.gameObject, Vector3.one * 0.5f, 0f);
            GetFirstLetter();
            FillButton();
        }
    }

    private void GetFirstLetter()
    {
        cardName = card.name;
        firstLetter = cardName.Substring(0, 1).ToLower();
    }

    private async void FillButton()
    {
        int random = Random.Range(0, 3);

        if(letterCardsNames.Contains(firstLetter))
        {
            foreach(var letter in letterCardsNames)
            {
                if(firstLetter == letter.Substring(0, 1))
                {
                    CheckRandomForLetters();
                    buttons[random].transform.GetChild(0).gameObject.SetActive(true);
                    buttons[random].transform.GetChild(1).gameObject.SetActive(false);

                    var correctLetterTexture = await gameAPI.GetCardImage("letters", letter, 512);
                    correctLetterTexture.wrapMode = TextureWrapMode.Clamp;
                    correctLetterTexture.filterMode = FilterMode.Bilinear;

                    buttons[random].transform.GetChild(0).transform.GetComponent<RawImage>().texture = correctLetterTexture;   
                    buttons[random].GetComponent<AlphabetChooseButtonController>().letter = firstLetter;
                    buttons[random].name = "Correct";

                }
            }
        }
        else if(!letterCardsNames.Contains(firstLetter))
        {
            buttons[random].transform.GetChild(0).gameObject.SetActive(false);
            buttons[random].transform.GetChild(1).gameObject.SetActive(true);
            buttons[random].transform.GetChild(1).GetComponent<TMP_Text>().text = firstLetter.ToUpper();
            buttons[random].transform.GetChild(1).GetComponent<TMP_Text>().color = colors[Random.Range(0, colors.Length)];
            buttons[random].GetComponent<AlphabetChooseButtonController>().letter = firstLetter;
            buttons[random].name = "Correct";
        }

        for(int i = 0; i < 3; i++)
        {
            if(buttons[i].name != "Correct")
            {
                if(letterCardsNames.Contains(firstLetter))
                {
                    CheckRandomForLetters();
                    buttons[i].transform.GetChild(0).gameObject.SetActive(true);
                    buttons[i].transform.GetChild(1).gameObject.SetActive(false);

                    var letterTexture = await gameAPI.GetCardImage("letters", letterCardsNames[randomLetterValueList[i]], 512);
                    letterTexture.wrapMode = TextureWrapMode.Clamp;
                    letterTexture.filterMode = FilterMode.Bilinear;

                    buttons[i].transform.GetChild(0).transform.GetComponent<RawImage>().texture = letterTexture;
                    buttons[i].GetComponent<AlphabetChooseButtonController>().letter = letterCardsNames[randomLetterValueList[i]];
                }
                else if(!letterCardsNames.Contains(firstLetter))
                {
                    if(card.name.Substring(i + 1, 1) == null)
                    {                    
                        CheckRandomForLetters();
                        buttons[i].transform.GetChild(0).gameObject.SetActive(true);
                        buttons[i].transform.GetChild(1).gameObject.SetActive(false);

                        var letterTexture = await gameAPI.GetCardImage("letters", letterCardsNames[randomLetterValueList[i]], 512);
                        letterTexture.wrapMode = TextureWrapMode.Clamp;
                        letterTexture.filterMode = FilterMode.Bilinear;
                        buttons[i].transform.GetChild(0).transform.GetComponent<RawImage>().texture = letterTexture;
                        buttons[i].GetComponent<AlphabetChooseButtonController>().letter = letterCardsNames[randomLetterValueList[i]];
                    }
                    else if(card.name.Substring(i + 1, 1) !=null)
                    {
                        if(!letterCardsNames.Contains(card.name.Substring(i + 1, 1).ToLower()))
                        {
                            buttons[i].transform.GetChild(0).gameObject.SetActive(false);
                            buttons[i].transform.GetChild(1).gameObject.SetActive(true);
                            buttons[i].transform.GetChild(1).GetComponent<TMP_Text>().text = card.name.Substring(i + 1, 1).ToUpper();
                            buttons[i].transform.GetChild(1).GetComponent<TMP_Text>().color = colors[Random.Range(0, colors.Length)];
                            buttons[i].GetComponent<AlphabetChooseButtonController>().letter = card.name.Substring(i + 1, 1).ToUpper();
                        }
                    }
                }
            }
        }

        Invoke("GameUIActivate", 0.25f);
    }

    public void GameUIActivate()
    {
        uıController.GameUIActivate();
        foreach(GameObject button in buttons)
        {
            //button.SetActive(true);
            LeanTween.scale(button, Vector3.one, 0.1f);
        }
    }

    public void LevelEnding()
    {
        //tts
        LeanTween.moveLocal(card, new Vector3(0, -80, 0), 0.2f).setOnComplete(ScaleUpCard);
        foreach(var button in buttons)
        {
            LeanTween.scale(button, Vector3.zero, 0.1f);
        }
    }

    private void ScaleUpCard()
    {
        LeanTween.scale(card, Vector3.one, 0.5f).setOnComplete(ScaleDownCard);
    }

    private void ScaleDownCard()
    {
        LeanTween.scale(card, Vector3.zero, 0.5f).setOnComplete(CreateNewLevel);
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
        randomLetterValueList.Clear();

        foreach(GameObject button in buttons)
        {
            LeanTween.scale(button, Vector3.zero, 0.1f);
            //button.SetActive(false);
            button.name = "Button";
        }
        buttons.Clear();

        Destroy(card);

    }
}
