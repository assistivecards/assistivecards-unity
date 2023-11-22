using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardGeneratorSpellCards : MonoBehaviour
{
    GameAPI gameAPI;

    //[SerializeField] private SpellCardsUIController uıController;

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

    [Header ("Letter Cards")]
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLetterCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> letterList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    public List<string> letterCardsNames = new List<string>();

    [Header ("Random")]
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Random Letters")]
    public List<Texture2D> letterCardTextures = new List<Texture2D>();
    public List<int> randomLetterValueList = new List<int>();
    private int tempRandomLetterValue;
    private int randomLetterValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Game UI")]
    public GameObject card;
    public GameObject cardPosition;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    private List<GameObject> buttons = new List<GameObject>();

    [Header ("Colors")]
    public Color[] colors;

    [Header ("Game Values")]
    public int cardCount;
    public int maxLevelCount;
    public int levelCount;
    public int prefetchedCardsCount;
    private string cardName;
    public string firstLetter;
    private GameObject tempCard;
    private int random;
    public int cardNameLenght;

    
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
        // if(uıController.canGenerate)
        // {
            packSlug = packSelectionPanel.selectedPackElement.name;
            randomValueList.Clear();
            prefetchedCardTextures.Clear();
            prefetchedCardNames.Clear();
            letterCardTextures.Clear();
            letterList.Clear();
            letterCardsNames.Clear();
            levelCount = 0;
            await CacheCards(packSlug);
            await CreateLetters();
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
        //}
    }

    public async Task CreateLetters()
    {
        cachedLetterCards = await gameAPI.GetCards("en", "letters");
        letterList = cachedLetterCards.cards.ToList();

        for(int i = 0; i < cachedLetterCards.cards.Length; i++)
        {
            letterCardsNames.Add(cachedLetterCards.cards[i].title.ToLower().Replace(" ", "-"));
            var letterTexture = await gameAPI.GetCardImage("letters", letterCardsNames[i], 512);
            letterTexture.wrapMode = TextureWrapMode.Clamp;
            letterTexture.filterMode = FilterMode.Bilinear;
            letterCardTextures.Add(letterTexture);

        }
    }

    private void CheckRandom()
    {
        tempRandomValue = Random.Range(0, cardNames.Count);

        if(randomValueList.IndexOf(tempRandomValue) < 0)
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
        tempRandomLetterValue = Random.Range(0, cachedLetterCards.cards.Length);

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
        // if(uıController.canGenerate)
        // {
            CreateButtonList();
            card = Instantiate(cardPrefab, cardPosition.transform.position, Quaternion.identity);
            card.transform.SetParent(cardPosition.transform);
            var cardTexture = prefetchedCardTextures[levelCount];
            card.transform.name = prefetchedCardNames[levelCount];
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            cards.Add(card);

            LeanTween.scale(card.gameObject, Vector3.one * 0.5f, 0f);
            FillButton();
        //}
    }

    private async void FillButton()
    {
        random = Random.Range(0, 3);

        if(letterCardsNames.Contains(firstLetter))
        {
            for(int i = 0; i < letterCardsNames.Count; i++)
            {
                if(firstLetter == letterCardsNames[i].Substring(0, 1))
                {
                    CheckRandomForLetters();
                    buttons[random].transform.GetChild(0).gameObject.SetActive(true);
                    buttons[random].transform.GetChild(1).gameObject.SetActive(false);
                    
                    var correctLetterTexture = letterCardTextures[i];
                    correctLetterTexture.wrapMode = TextureWrapMode.Clamp;
                    correctLetterTexture.filterMode = FilterMode.Bilinear;

                    buttons[random].transform.GetChild(0).transform.GetComponent<RawImage>().texture = correctLetterTexture;   
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
                        var letterTexture = letterCardTextures[randomLetterValueList[i]];
                        letterTexture.wrapMode = TextureWrapMode.Clamp;
                        letterTexture.filterMode = FilterMode.Bilinear;

                        buttons[i].transform.GetChild(0).transform.GetComponent<RawImage>().texture = letterTexture;
                    }
                    else
                    {
                        CheckRandomForLetters();
                        var letterTexture = letterCardTextures[randomLetterValueList[i + 1]];
                        letterTexture.wrapMode = TextureWrapMode.Clamp;
                        letterTexture.filterMode = FilterMode.Bilinear;

                        buttons[i].transform.GetChild(0).transform.GetComponent<RawImage>().texture = letterTexture;
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
                            var letterTexture = letterCardTextures[randomLetterValueList[i]];
                            letterTexture.wrapMode = TextureWrapMode.Clamp;
                            letterTexture.filterMode = FilterMode.Bilinear;

                            buttons[i].transform.GetChild(0).transform.GetComponent<RawImage>().texture = letterTexture;
                        }
                        else
                        {
                            CheckRandomForLetters();
                            var letterTexture = letterCardTextures[randomLetterValueList[i+1]];
                            letterTexture.wrapMode = TextureWrapMode.Clamp;
                            letterTexture.filterMode = FilterMode.Bilinear;

                            buttons[i].transform.GetChild(0).transform.GetComponent<RawImage>().texture = letterTexture;
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
                            }
                            else 
                            {
                                buttons[i].transform.GetChild(0).gameObject.SetActive(false);
                                buttons[i].transform.GetChild(1).gameObject.SetActive(true);
                                buttons[i].transform.GetChild(1).GetComponent<TMP_Text>().text = card.name.Substring(i + 2, 1).ToLower();
                                buttons[i].transform.GetChild(1).GetComponent<TMP_Text>().color = colors[Random.Range(0, colors.Length)];
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
        //uıController.GameUIActivate();
        foreach(GameObject button in buttons)
        {
            LeanTween.scale(button, Vector3.one, 0.1f);
        }
        gameAPI.Speak(card.name);
    }

    public void LevelEnding()
    {
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
        //uıController.Invoke("SetTutorialActive", 2.1f);
    }
}
