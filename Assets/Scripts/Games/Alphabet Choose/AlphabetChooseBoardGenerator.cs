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
    private List<string> letterCardsNames = new List<string>();

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

    private string cardName;
    public string firstLetter;

    
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
        //if(uıController.canGenerate)

                await CacheCards();
                CreateButtonList();
                CheckRandom();

                card = Instantiate(cardPrefab, cardPosition.transform.position, Quaternion.identity);
                card.transform.SetParent(cardPosition.transform);

                var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[0]], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = cardNames[randomValueList[0]];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                cards.Add(card);
                LeanTween.scale(card.gameObject, Vector3.one * 0.5f, 0f);
                GetFirstLetter();
                FillButton();

        //uıController.GameUIActivate();
    }

    private void GetFirstLetter()
    {
        cardName = card.name;
        firstLetter = cardName.Substring(0, 1);
    }

    private async void FillButton()
    {
        await CreateLetters();

        foreach(var letter in letterCardsNames)
        {
            if(firstLetter == letter.Substring(0, 1))
            {
                CheckRandomForLetters();
                int random = Random.Range(0, 3);
                var correctLetterTexture = await gameAPI.GetCardImage("letters", letter, 512);
                correctLetterTexture.wrapMode = TextureWrapMode.Clamp;
                correctLetterTexture.filterMode = FilterMode.Bilinear;

                buttons[random].transform.GetChild(0).transform.GetComponent<RawImage>().texture = correctLetterTexture;   
                buttons[random].name = "Correct";
            }
        }

        for(int i = 0; i < buttons.Count; i++)
        {
            if(buttons[i].name != "Correct")
            {
                CheckRandomForLetters();
                var letterTexture = await gameAPI.GetCardImage("letters", letterCardsNames[randomLetterValueList[i]], 512);
                letterTexture.wrapMode = TextureWrapMode.Clamp;
                letterTexture.filterMode = FilterMode.Bilinear;

                buttons[i].transform.GetChild(0).transform.GetComponent<RawImage>().texture = letterTexture;
            }
        }

    }
}
