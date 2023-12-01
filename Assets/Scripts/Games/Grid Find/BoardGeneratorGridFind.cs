using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using PathCreation;

public class BoardGeneratorGridFind : MonoBehaviour
{
    GameAPI gameAPI;

    [SerializeField] private UIControllerGridFind uıController;

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

    [Header ("Random")]
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Game UI")]
    [SerializeField] private GameObject correctCardPosition;
    [SerializeField] private GameObject collectText;
    private Texture correctCardTexture;
    private List<GameObject> correctCards = new List<GameObject>();
    public string correctCardName;
    private GameObject correctCard;

    [Header ("Game Values")]
    [SerializeField] private GameObject grid;
    public List<int> usedRandomOrderCards = new List<int>();
    public int score;
    public int cardCount;
    public int maxLevelCount;
    public int levelCount;
    public int prefetchedCardsCount;
    private string cardName;
    public int randomOrder;
    public int cardNameLenght;
    public int matchedCardCount;
    public bool isPointerUp;
    public bool finished;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        gameAPI.PlayMusic();
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
        if(uıController.canGenerate)
        {
            packSlug = packSelectionPanel.selectedPackElement.name;
            randomValueList.Clear();
            prefetchedCardTextures.Clear();
            prefetchedCardNames.Clear();
            levelCount = 0;
            await CacheCards(packSlug);
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

    public async void GeneratedBoardAsync()
    {
        for(int i = 0; i < 20; i++)
        {
            int cardImageRandom = Random.Range(0, 10);
            GameObject card = Instantiate(cardPrefab, grid.transform.GetChild(i).transform.position, Quaternion.identity);
            var cardTexture = prefetchedCardTextures[cardImageRandom + cardCount];
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;
            card.transform.SetParent(grid.transform.GetChild(i).transform);
            card.transform.name = prefetchedCardNames[cardImageRandom + cardCount];
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            card.GetComponent<CardControllerGridFind>().cardName = card.transform.name;
            card.GetComponent<CardControllerGridFind>().isExampleCard = false;
            cards.Add(card);
            card.transform.localPosition = Vector3.zero;
        }

        int correctCardRandom = Random.Range(0, 20);
        correctCard = cards[correctCardRandom];
        correctCardName = correctCard.name;
        correctCardTexture = correctCard.transform.GetChild(0).GetComponent<RawImage>().texture;
        correctCard = Instantiate(correctCard, correctCardPosition.transform.position, Quaternion.identity);
        correctCard.transform.SetParent(correctCardPosition.transform);
        correctCard.transform.GetChild(0).GetComponent<RawImage>().color = Color.white;
        correctCard.GetComponent<CardControllerGridFind>().isExampleCard = true;
        LeanTween.scale(correctCard, Vector3.one * 0.4f, 0.75f);
        correctCard.transform.name = correctCardName;
        correctCard.transform.localPosition = Vector3.zero;

        foreach(var card in cards)
        {
            if(card.GetComponent<CardControllerGridFind>().cardName == correctCardName)
            {
                card.GetComponent<CardControllerGridFind>().isCorrect = true;
                correctCards.Add(card);
            }
        }
        UpdateScore();
        tutorial.GetComponent<TutorialGridFind>().GetPosition(correctCards);
        GameUIActivate();
    }

    public void UpdateScore()
    {
        collectText.GetComponentInChildren<TMP_Text>().text = score + " / " + correctCards.Count.ToString(); 
        collectText.GetComponentInChildren<RawImage>().texture = correctCardTexture;
        CheckIfLevelEnd();
    }

    private void CheckIfLevelEnd()
    {
        if(score >= correctCards.Count)
        {
            Invoke("GameUIScaleDown",0.5f);
        }
    }

    public void GameUIActivate()
    {
        foreach(var card in cards)
        {
            LeanTween.scale(card, Vector3.one * 0.45f, 0.3f);
        }
        uıController.GameUIActivate();
    }

    private void CreateNewLevel()
    {
        ClearBoard();
        //GeneratedBoardAsync();
    }

    private void GameUIScaleDown()
    {
        foreach(var card in cards)
        {
            LeanTween.scale(card, Vector3.zero, 0.3f);
        }
        uıController.Invoke("GameUIDeactivate", 0.3f);
        Invoke("ClearBoard", 0.3f);
    }

    private void PlaySuccess()
    {
        gameAPI.PlaySFX("Success");
    }

    public void ClearBoard()
    {
        foreach(var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
        correctCards.Clear();
        score = 0;
        Destroy(correctCard);
        cardNames.Clear();
        usedRandomOrderCards.Clear();
        levelCount++;
        if(levelCount >= maxLevelCount)
        {
            uıController.LevelChangeScreenActivate();
            levelCount = 0;
        }
        else
        {
            uıController.GameUIDeactivate();
            uıController.LoadingScreenActivation();
            GeneratedBoardAsync();
            levelCount++;
        }
    }

    public void BackButtonClear()
    {
        foreach(var card in cards)
        {
            Destroy(card);
        }
        cardLocalNames.Clear();
        cards.Clear();
        cardNames.Clear();
        randomValueList.Clear();
        usedRandomOrderCards.Clear();
        levelCount = 0;
        uıController.PackSelectionPanelActive();
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
        }
        Invoke("GeneratedBoardAsync", 2f);
        uıController.Invoke("SetTutorialActive", 2.1f);
    }
}
