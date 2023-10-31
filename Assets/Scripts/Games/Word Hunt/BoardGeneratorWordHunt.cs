using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardGeneratorWordHunt : MonoBehaviour
{
    GameAPI gameAPI;

    //[SerializeField] private uıcontroller uıController;

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
    [SerializeField] private GameObject grid;

    [Header ("Game Values")]
    public int cardCount;
    public int maxLevelCount;
    public int levelCount;
    public int prefetchedCardsCount;
    private string cardName;
    public int randomOrder;
    public List<int> usedRandomOrderCards = new List<int>();
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
        // if(uıController.canGenerate)
        // {
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
        //}
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
        finished = false;
        for(int i = 0; i < 10; i++)
        {
            GameObject card = Instantiate(cardPrefab, grid.transform.position, Quaternion.identity);

            var cardTexture = prefetchedCardTextures[i + (levelCount * cardCount)];
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;
            card.transform.SetParent(grid.transform);
            card.transform.name = prefetchedCardNames[i + (levelCount * cardCount)];
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            card.transform.GetChild(1).GetComponent<TMP_Text>().text = prefetchedCardNames[i + (levelCount * cardCount)];
            card.GetComponent<SwapCardsCardController>().cardType = prefetchedCardNames[i + (levelCount * cardCount)];
            card.GetComponent<SwapCardsCardController>().parentName = card.transform.parent.transform.tag;
            cards.Add(card);
            card.transform.localScale = new Vector3(0.45f, 0.45f, 0f);
            card.transform.localPosition = Vector3.zero;
        }
        GameUIActivate();
    }

    public void GameUIActivate()
    {
        foreach(var card in cards)
        {
            LeanTween.scale(card, Vector3.one * 0.45f, 0.3f);
        }
        //uıController.GameUIActivate();
    }

    private void CreateNewLevel()
    {
        ClearBoard();
        GeneratedBoardAsync();
    }

    private void GameUIScaleDown()
    {
        foreach(var card in cards)
        {
            LeanTween.scale(card, Vector3.zero, 0.3f);
        }
        //uıController.Invoke("GameUIDeactivate", 0.3f);
        //Invoke("ClearBoard", 0.3f);
    }

    public void CheckLevelEnding()
    {
    }

    private void LevelEndAnimation() // match animation
    {
        foreach(var card in cards)
        {
            LeanTween.scale(card, Vector3.zero, 0.5f);
        }
        Invoke("ClearBoard", 0.5f);
    }

    private void PlaySuccess()
    {
        gameAPI.PlaySFX("Success");
    }

    public void ClearBoard()
    {
        matchedCardCount = 0;
        foreach(var card in cards)
        {
            Destroy(card);
        }
        // cardLocalNames.Clear();
        // cards.Clear();
        // cloneCards.Clear();
        // cardNames.Clear();
        // randomValueList.Clear();
        // usedRandomOrderCards.Clear();
        // cardTextures.Clear();
        // cardPositions.Clear();
        // levelCount++;
        if(levelCount >= maxLevelCount)
        {
            //uıController.LevelChangeScreenActivate();
            levelCount = 0;
        }
        else
        {
            // uıController.GameUIDeactivate();
            // uıController.LoadingScreenActivation();
            GeneratedBoardAsync();
        }
    }

    public void BackButtonClear()
    {
        matchedCardCount = 0;
        foreach(var card in cards)
        {
            Destroy(card);
        }
        cardLocalNames.Clear();
        cards.Clear();
        cardNames.Clear();
        randomValueList.Clear();
        usedRandomOrderCards.Clear();
        //uıController.PackSelectionPanelActive();
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
