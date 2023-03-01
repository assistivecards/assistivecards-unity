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
    [SerializeField] private LevelChangeScreenHatchMatch levelChangeScreenHatchMatch;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject actualCardPrefab;
    [SerializeField] private Transform card1Position;
    [SerializeField] private Transform card2Position;
    [SerializeField] private Transform card3Position;
    [SerializeField] private Transform cardPosition;
    [SerializeField] private GameObject egg;
    public int cardTypeCount;
    public int levelCount;

    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    public List<string> cardNames = new List<string>();
    public int tempRandomValue;
    public List<int> randomValues = new List<int>();

    public List<GameObject> cards = new List<GameObject>();
    public bool levelEnd;
    public bool boardCreated = false;

    public GameObject card;
    public GameObject[] clones;
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cacheLocalNames;

    private List<string> cardsLocalNames = new List<string>();

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
        var cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[randomValues[_randomValue]], 512);
        
        GameObject card1 = Instantiate(cardPrefab, _cardPosition.position, Quaternion.identity);

        cardTexture.wrapMode = TextureWrapMode.Clamp;
        cardTexture.filterMode = FilterMode.Bilinear;

        card1.transform.name = cardNames[randomValues[_randomValue]];
        card1.transform.SetParent(this.transform);
        card1.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

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
    }

    public async void GeneratStylized()
    {
        await CacheCards(packSelectionPanel.selectedPackElement.name);
        CreateRandomValue();

        GenerateCard(packSelectionPanel.selectedPackElement.name, card1Position, 1);
        GenerateCard(packSelectionPanel.selectedPackElement.name, card2Position, 2);
        GenerateCard(packSelectionPanel.selectedPackElement.name, card3Position, 3);
        egg.SetActive(true);
        LeanTween.scale(egg, Vector3.one, 1f);
        Invoke("GenerateStylizedCard", 0.5f);
    }

    private void GenerateStylizedCard()
    {
        GenerateActualCard(packSelectionPanel.selectedPackElement.name, cardPosition, Random.Range(1,4));
        boardCreated = true;
    }

    public void NewLevel() 
    {
        ReloadBoard();
        levelEnd = false;
    }

    private void ReloadBoard()
    {
        foreach (var card in cards)
        {
            LeanTween.scale(card, Vector3.zero, 0.15f);
            Destroy(card);
        }
        cards.Clear();
        egg.GetComponent<EggController>().clickCount = 0;
        randomValues.Clear();
        CreateRandomValue();
        boardCreated = false;
        Invoke("GeneratStylized", 1f);     
        levelCount++;
        ClearLevel();
    }

    public void ResetBoard()
    {
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
        egg.GetComponent<EggController>().clickCount = 0;
        LeanTween.scale(egg, Vector3.zero, 0.1f);
        randomValues.Clear();
        boardCreated = false;    
        ClearLevel();
    }

    public void ActivateLevelChange()
    {
        levelChangeScreenHatchMatch.gameObject.SetActive(true);
        levelChangeScreenHatchMatch.LevelScreenTween();
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
    }

    private void ClearLevel()
    {
        clones = GameObject.FindGameObjectsWithTag("cardBlast");

        foreach(var clone in clones)
        {
            Destroy(clone);
        }
    }
}
