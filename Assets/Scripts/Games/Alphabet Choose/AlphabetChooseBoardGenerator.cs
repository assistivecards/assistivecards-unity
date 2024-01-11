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
    public List<GameObject> cards = new List<GameObject>();
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    private List<string> cardNames = new List<string>();
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
    public List<Texture2D> letterCardTextures = new List<Texture2D>();

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
    public int maxLevelCount;
    public int levelCount;
    public int buttonCount = 3;
    public Color[] colors;
    private string cardName;
    public GameObject letterCard;
    public GameObject correctButton;
    private int random;
    public int cardNameLenght;
    public string firstLetter;
    public string formerLetter;

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

    public async void PrefetchCardTextures()
    {
        if(uıController.canGenerate)
        {
            packSlug = packSelectionPanel.selectedPackElement.name;
            randomValueList.Clear();
            prefetchedCardTextures.Clear();
            prefetchedCardNames.Clear();
            letterCardTextures.Clear();
            letterCardsNames.Clear();
            await CacheCards(packSlug);
            await CreateLetters();
            for(int i = 0; i < (maxLevelCount * buttonCount); i++)
            {
                CheckRandom();
            }
            PrefetchNextLevelsTexturesAsync();
        }
    }

    public async void GeneratedBoardAsync()
    {
        CreateButtonList();
        for(int i = 0; i < buttonCount; i++)
        {
            var cardTexture = prefetchedCardTextures[i + (buttonCount * levelCount)];
            buttons[i].transform.name = prefetchedCardNames[i + (buttonCount * levelCount)];
            buttons[i].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            buttons[i].transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            cards.Add(buttons[i]);
        }
        formerLetter = firstLetter;
        FillLetterCard();
        Invoke("GameUIActivate", 0.5f);
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
            for(int i = 0; i < letterCardsNames.Count; i++)
            {
                if(firstLetter == letterCardsNames[i].Substring(0, 1))
                {
                    letterCard.transform.GetChild(0).gameObject.SetActive(true);
                    letterCard.transform.GetChild(1).gameObject.SetActive(false);

                    var correctLetterTexture = letterCardTextures[i];
                    correctLetterTexture.wrapMode = TextureWrapMode.Clamp;
                    correctLetterTexture.filterMode = FilterMode.Bilinear;

                    letterCard.transform.GetChild(0).transform.GetComponent<RawImage>().texture = correctLetterTexture;   
                    LeanTween.scale(letterCard.gameObject, Vector3.one * 0.5f, 0f);
                }
            }
        }
        else if(!letterCardsNames.Contains(firstLetter))
        {
            letterCard.transform.GetChild(0).gameObject.SetActive(false);
            letterCard.transform.GetChild(1).gameObject.SetActive(true);
            letterCard.transform.GetChild(1).GetComponent<TMP_Text>().text = firstLetter.ToUpper();
            letterCard.transform.GetChild(1).GetComponent<TMP_Text>().color = colors[Random.Range(0, colors.Length)];
        }
        firstLetterText.GetComponent<TMP_Text>().text = gameAPI.Translate(firstLetterText.gameObject.name, gameAPI.ToSentenceCase(firstLetter).Replace("-", " "), selectedLangCode);
        Invoke("SetTutorialPosition", 0.5f);
    }

    private void SetTutorialPosition()
    {
        tutorial.GetComponent<AlphabetChooseTutorial>().SetPosition(correctButton.transform);
        tutorial.GetComponent<Tutorial>().tutorialPosition = correctButton.transform;
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
            LeanTween.scale(button, Vector3.one * 1.1f, 0.1f);
        }

        LeanTween.scale(firstLetterText, Vector3.one, 0.1f);
    }

    public void LevelEnding()
    {
        LeanTween.moveLocal(correctButton, Vector3.zero, 0.2f).setOnComplete(ScaleUpCard);
        LeanTween.scale(letterCard, Vector3.zero, 0.1f);
        foreach(var button in buttons)
        {
            if(button != correctButton)
                LeanTween.scale(button, Vector3.zero, 0.1f);
        }
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
        cards.Clear();
        cardNames.Clear();
        cardLocalNames.Clear();
        letterList.Clear();
        Destroy(letterCard);
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

    }

    private async Task PrefetchNextLevelsTexturesAsync()
    {
        for(int i = 0; i < (maxLevelCount * buttonCount); i++)
        {
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[randomValueList[i]], 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear; 
            prefetchedCardNames.Add(cardLocalNames[randomValueList[i]]);
            prefetchedCardTextures.Add(cardTexture);
        }
        Invoke("GeneratedBoardAsync", 0.5f);
        uıController.Invoke("SetTutorialActive", 1.5f);
    }
}
