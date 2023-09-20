using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardCreatorHatchMatch : MonoBehaviour
{
    GameAPI gameAPI;
    public string selectedLangCode;

    [SerializeField] private PackSelectionPanel packSelectionPanel;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject actualCardPrefab;
    [SerializeField] private Transform card1Position;
    [SerializeField] private Transform card2Position;
    [SerializeField] private Transform card3Position;
    [SerializeField] private Transform cardPosition;
    [SerializeField] private GameObject egg;
    [SerializeField] private PackSelectionScreenUIController packageSelectManager;
    [SerializeField] private HatchMatchUIController uıController;
    public int cardTypeCount;
    public int levelCount;

    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    public List<string> cardNames = new List<string>();
    public int tempRandomValue;
    public List<int> randomValues = new List<int>();

    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> guessCards = new List<GameObject>();
    public bool levelEnd;
    public bool boardCreated = false;

    public GameObject card;
    public GameObject[] clones;
    public AssistiveCardsSDK.AssistiveCardsSDK.Cards cacheLocalNames;

    public List<string> cardsLocalNames = new List<string>();

    public string previousCard;
    public string actualCardType;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        gameAPI.PlayMusic();
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();

        cachedCards = await gameAPI.GetCards("en", _packSlug);

        cacheLocalNames = await gameAPI.GetCards(selectedLangCode, _packSlug);

        cardsList = cachedCards.cards.ToList();

        for(int i = 0; i < cachedCards.cards.Length; i++)
        {
            cardNames.Add(cachedCards.cards[i].title.ToLower().Replace(" ", "-"));
            cardsLocalNames.Add(cacheLocalNames.cards[i].title);
        }
    }


    private void CreateRandomValue()
    {
        for(int i = 0; i <= cardTypeCount; i++)
        {
            tempRandomValue = Random.Range(0, cardsList.Count);

            if(!randomValues.Contains(tempRandomValue))
            {
                randomValues.Add(tempRandomValue);
            }
            else if(randomValues.Contains(tempRandomValue))
            {
                tempRandomValue = Random.Range(0, cardsList.Count);

                if(!randomValues.Contains(tempRandomValue))
                {
                    randomValues.Add(tempRandomValue);
                }
                else
                {
                    tempRandomValue = Random.Range(0, cardsList.Count);
                    randomValues.Add(tempRandomValue);
                }
            }

        }
    }

    private async void  GenerateCard(string _packSlug, Transform _cardPosition, int _randomValue)
    {
        egg.GetComponent<EggController>().ResetEgg();
        var cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[randomValues[_randomValue]], 512);
        
        GameObject card1 = Instantiate(cardPrefab, _cardPosition.position, Quaternion.identity);

        cardTexture.wrapMode = TextureWrapMode.Clamp;
        cardTexture.filterMode = FilterMode.Bilinear;

        card1.transform.name = cardNames[randomValues[_randomValue]];
        card1.transform.SetParent(this.transform);
        card1.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

        guessCards.Add(card1);
        cards.Add(card1);
    }

    private async void  GenerateActualCard(string _packSlug, Transform _cardPosition, int _randomValue)
    {
        var cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[randomValues[_randomValue]], 512);
        
        GameObject card1 = Instantiate(actualCardPrefab, _cardPosition.position, Quaternion.identity);

        cardTexture.wrapMode = TextureWrapMode.Clamp;
        cardTexture.filterMode = FilterMode.Bilinear;

        card1.transform.name = cardNames[randomValues[_randomValue]];
        card1.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
        card = card1;
        card1.transform.SetParent(this.transform);
        card1.GetComponent<CardElementHatchMatch>().cardName = cardsLocalNames[randomValues[_randomValue]];
        cards.Add(card1);

        actualCardType = cardNames[randomValues[_randomValue]];
    }

    public async void GeneratStylized()
    {
        if(packageSelectManager.canGenerate)
        {
            await CacheCards(packSelectionPanel.selectedPackElement.name);
            CreateRandomValue();

            GenerateCard(packSelectionPanel.selectedPackElement.name, card1Position, 1);
            GenerateCard(packSelectionPanel.selectedPackElement.name, card2Position, 2);
            GenerateCard(packSelectionPanel.selectedPackElement.name, card3Position, 3);
            egg.SetActive(true);
            LeanTween.scale(egg, Vector3.one * 1.25f, 1f);
            Invoke("GenerateStylizedCard", 0.5f);
            uıController.GameUIActivate();
            Invoke("ScaleUpCards", 1f);
        }
    }

    private void GenerateStylizedCard()
    {
        if(uıController.canGenerate)
        {
            GenerateActualCard(packSelectionPanel.selectedPackElement.name, cardPosition, Random.Range(1,4));

            if(actualCardType != previousCard)
            {
                previousCard = actualCardType;
                boardCreated = true;
            }
            else if(actualCardType == previousCard)
            {
                GenerateActualCard(packSelectionPanel.selectedPackElement.name, cardPosition, Random.Range(1,4));
                boardCreated = true;
                previousCard = actualCardType;
            }
        }
    }

    private void ScaleUpCards()
    {
        foreach(var card in guessCards)
        {
            card.transform.localScale = Vector3.one * 0.5f;
        }
    }

    public void NewLevel() 
    {
        ReloadBoard();
        levelEnd = false;
    }

    private void ReloadBoard()
    {
        LevelEndAnimationStart();
        cards.Clear();
        guessCards.Clear();
        egg.GetComponent<EggController>().clickCount = 0;
        randomValues.Clear();
        CreateRandomValue();
        boardCreated = false;
        Invoke("GeneratStylized", 1f);     
        levelCount++;
        Invoke(nameof(ClearLevel), 0.25f);
    }

    public void ResetBoard()
    {
        LevelEndAnimationStart();
        cards.Clear();
        guessCards.Clear();
        egg.GetComponent<EggController>().clickCount = 0;
        LeanTween.scale(egg, Vector3.zero, 0.1f);
        randomValues.Clear();
        boardCreated = false;    
        Invoke(nameof(ClearLevel), 0.25f);
    }

    public void ActivateLevelChange()
    {
        uıController.LevelChangeScreenActivate();
        gameAPI.AddExp(gameAPI.sessionExp);
    }


    public void ResetLevelCount()
    {
        levelCount = 0;
        cardsList.Clear();
        cardNames.Clear();
        cardsLocalNames.Clear();
        tempRandomValue = 0;
        randomValues.Clear();
        cards.Clear();
        guessCards.Clear();
    }

    private void ClearLevel()
    {
        clones = GameObject.FindGameObjectsWithTag("cardBlast");

        foreach(var clone in clones)
        {
            Destroy(clone);
        }

        foreach (var card in cards)
        {
            Destroy(card);
        }
    }

    private void LevelEndAnimationStart()
    {
        foreach (var card in cards)
        {
            LeanTween.scale(card, Vector3.zero, 0.25f);
        }
        uıController.LoadingScreenActivation();
    }
}
