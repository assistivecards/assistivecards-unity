using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class FirstLetterBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;

    [SerializeField] private FirstLetterUIController uıController;
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
    [SerializeField] private GameObject tutorial;

    [Header ("Game UI")]
    public GameObject card;
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
    public string firstLetter;
    private GameObject tempCard;
    private int random;
    public int cardNameLenght;

    
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

            firstLetterText.GetComponent<TMP_Text>().text = gameAPI.Translate(firstLetterText.gameObject.name, selectedLangCode);
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
        cardNameLenght = card.name.Length;
    }

    private async void FillButton()
    {
        random = Random.Range(0, 3);

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
                    buttons[random].GetComponent<FirstLetterButtonController>().letter = firstLetter;
                    buttons[random].name = "Correct";

                }
            }
        }
        else if(!letterCardsNames.Contains(firstLetter))
        {
            buttons[random].transform.GetChild(0).gameObject.SetActive(false);
            buttons[random].transform.GetChild(1).gameObject.SetActive(true);
            buttons[random].transform.GetChild(1).GetComponent<TMP_Text>().text = firstLetter.ToLower();
            buttons[random].transform.GetChild(1).GetComponent<TMP_Text>().color = colors[Random.Range(0, colors.Length)];
            buttons[random].GetComponent<FirstLetterButtonController>().letter = firstLetter;
            buttons[random].name = "Correct";
        }

        for(int i = 0; i < 3; i++)
        {
            CheckRandomForLetters();
            if(buttons[i].name != "Correct")
            {
                if(letterCardsNames.Contains(firstLetter))
                {
                    CheckRandomForLetters();
                    buttons[i].transform.GetChild(0).gameObject.SetActive(true);
                    buttons[i].transform.GetChild(1).gameObject.SetActive(false);

                    if(letterCardsNames[randomLetterValueList[i]] != firstLetter)
                    {
                        var letterTexture = await gameAPI.GetCardImage("letters", letterCardsNames[randomLetterValueList[i]], 512);
                        letterTexture.wrapMode = TextureWrapMode.Clamp;
                        letterTexture.filterMode = FilterMode.Bilinear;

                        buttons[i].transform.GetChild(0).transform.GetComponent<RawImage>().texture = letterTexture;
                        buttons[i].GetComponent<FirstLetterButtonController>().letter = letterCardsNames[randomLetterValueList[i]];
                    }
                    else
                    {
                        CheckRandomForLetters();
                        var letterTexture = await gameAPI.GetCardImage("letters", letterCardsNames[randomLetterValueList[i + 1]], 512);
                        letterTexture.wrapMode = TextureWrapMode.Clamp;
                        letterTexture.filterMode = FilterMode.Bilinear;

                        buttons[i].transform.GetChild(0).transform.GetComponent<RawImage>().texture = letterTexture;
                        buttons[i].GetComponent<FirstLetterButtonController>().letter = letterCardsNames[randomLetterValueList[i + 1]];
                    }
                }
                else if(!letterCardsNames.Contains(firstLetter))
                {
                    if(cardNameLenght <= 3)
                    {                    
                        CheckRandomForLetters();
                        buttons[i].transform.GetChild(0).gameObject.SetActive(true);
                        buttons[i].transform.GetChild(1).gameObject.SetActive(false);

                        if(letterCardsNames[randomLetterValueList[i]] != firstLetter)
                        {
                            var letterTexture = await gameAPI.GetCardImage("letters", letterCardsNames[randomLetterValueList[i]], 512);
                            letterTexture.wrapMode = TextureWrapMode.Clamp;
                            letterTexture.filterMode = FilterMode.Bilinear;

                            buttons[i].transform.GetChild(0).transform.GetComponent<RawImage>().texture = letterTexture;
                            buttons[i].GetComponent<FirstLetterButtonController>().letter = letterCardsNames[randomLetterValueList[i]];
                        }
                        else
                        {
                            CheckRandomForLetters();
                            var letterTexture = await gameAPI.GetCardImage("letters", letterCardsNames[randomLetterValueList[i + 1]], 512);
                            letterTexture.wrapMode = TextureWrapMode.Clamp;
                            letterTexture.filterMode = FilterMode.Bilinear;

                            buttons[i].transform.GetChild(0).transform.GetComponent<RawImage>().texture = letterTexture;
                            buttons[i].GetComponent<FirstLetterButtonController>().letter = letterCardsNames[randomLetterValueList[i + 1]];
                        }
                    }
                    else if(cardNameLenght > 3)
                    {
                        if(!letterCardsNames.Contains(card.name.Substring(i + 1, 1).ToLower()))
                        {
                            if(card.name.Substring(i + 1, 1) != firstLetter)
                            {
                                buttons[i].transform.GetChild(0).gameObject.SetActive(false);
                                buttons[i].transform.GetChild(1).gameObject.SetActive(true);
                                buttons[i].transform.GetChild(1).GetComponent<TMP_Text>().text = card.name.Substring(i + 1, 1).ToLower();
                                buttons[i].transform.GetChild(1).GetComponent<TMP_Text>().color = colors[Random.Range(0, colors.Length)];
                                buttons[i].GetComponent<FirstLetterButtonController>().letter = card.name.Substring(i + 1, 1).ToLower();
                            }
                            else 
                            {
                                buttons[i].transform.GetChild(0).gameObject.SetActive(false);
                                buttons[i].transform.GetChild(1).gameObject.SetActive(true);
                                buttons[i].transform.GetChild(1).GetComponent<TMP_Text>().text = card.name.Substring(i + 2, 1).ToLower();
                                buttons[i].transform.GetChild(1).GetComponent<TMP_Text>().color = colors[Random.Range(0, colors.Length)];
                                buttons[i].GetComponent<FirstLetterButtonController>().letter = card.name.Substring(i + 2, 1).ToLower();
                            }
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
            LeanTween.scale(button, Vector3.one, 0.1f);
        }

        LeanTween.scale(firstLetterText, Vector3.one, 0.1f);
        gameAPI.Speak(card.name);
        Debug.Log(card.name);

        tutorial.GetComponent<FirstLetterTutorial>().SetPosition(buttons[random].transform);
    }

    public void LevelEnding()
    {
        LeanTween.moveLocal(card, new Vector3(0, -80, 0), 0.2f).setOnComplete(ScaleUpCard);
        foreach(var button in buttons)
        {
            LeanTween.scale(button, Vector3.zero, 0.1f);
        }
        LeanTween.scale(firstLetterText, Vector3.zero, 0.1f);
    }

    private void ScaleUpCard()
    {
        LeanTween.scale(card, Vector3.one, 0.5f).setOnComplete(ScaleDownCard);
    }

    private void ScaleDownCard()
    {
        LeanTween.scale(card, Vector3.zero, 0.5f);
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
            button.name = "Button";

            if (EventSystem.current.currentSelectedGameObject == button)
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
        buttons.Clear();

        Destroy(card);

    }
}
