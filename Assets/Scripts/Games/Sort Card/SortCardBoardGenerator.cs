using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SortCardBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;
    public string selectedLangCode;

    [SerializeField] private SortCardOrderDetection orderDetection;
    [SerializeField] private SortCardsLevelEnding levelEnd;
    [SerializeField] private SortCardUIController UIController;
    [SerializeField] private TutorialSortCard tutorialSortCard;

    AssistiveCardsSDK.AssistiveCardsSDK.Cards cardDefinitions;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cardTextures;
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    public List<string> cardLocalNames = new List<string>();
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    public List<int> usedRandoms = new List<int>();

    public List<string> cardNames = new List<string>();
    public List<GameObject> cardListTransforms  = new List<GameObject>();
    public List<GameObject> slotableCardTransforms  = new List<GameObject>();
    public List<GameObject> listedCards = new List<GameObject>();
    public List<GameObject> slotableCards = new List<GameObject>();
    public List<string> cards = new List<string>();
    public List<int> randomCard = new List<int>();
    public string packSlug;

    public string Card1;
    public string Card2;
    public string Card3;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject cardListParent;
    [SerializeField] private GameObject slotableCardsParent;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();

        cachedCards = await gameAPI.GetCards("en", _packSlug);
        cachedLocalCards = await gameAPI.GetCards(selectedLangCode, _packSlug);

        for(int i = 0; i < cachedCards.cards.Length; i++)
        {
            cardNames.Add(cachedCards.cards[i].title.ToLower().Replace(" ", "-"));
            cardLocalNames.Add(cachedLocalCards.cards[i].title);
        }
    }

    private void GetSlotedList()
    {
        foreach (Transform child in cardListParent.transform)
        {
            cardListTransforms.Add(child.gameObject);
        }

        foreach (Transform child in slotableCardsParent.transform)
        {
            slotableCardTransforms.Add(child.gameObject);

        }
    }

    public void GeneratStylized()
    {
        if(UIController.canGenerate)
        {
            packSlug = packSelectionPanel.selectedPackElement.name;
            GenerateRandomBoardAsync(packSlug);
        }
    }

    private void GenerateRandomValue()
    {
        int tempRandom = Random.Range(0, cardNames.Count);
        if(usedRandoms.Contains(tempRandom))
        {
            GenerateRandomValue();
        }
        else if(!usedRandoms.Contains(tempRandom))
        {
            usedRandoms.Add(tempRandom);
        }
    }

    private async void GenerateRandomBoardAsync(string packSlug)
    {
        await CacheCards(packSlug);
        GetSlotedList();
        tutorialSortCard.ClearLists();
        for(int i = 0; i < cardListTransforms.Count; i++)
        {
            GenerateRandomValue();

            GameObject card = Instantiate(cardPrefab, cardListTransforms[i].transform.position, Quaternion.identity);
            tutorialSortCard.cards.Add(card.transform);
            card.transform.SetParent(cardListTransforms[i].transform);
            listedCards.Add(card);
            
            int cardImageRandom = usedRandoms[i];
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[cardImageRandom], 512);

            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            card.transform.name = cardNames[cardImageRandom];
            card.transform.GetComponentInChildren<RawImage>().texture = cardTexture;
            card.GetComponent<SortCardDraggable>().cardType = cardLocalNames[cardImageRandom];
            cards.Add(cardLocalNames[cardImageRandom]);
        }
        GetCardOrder();
        GenerateSortableCards();
        UIController.TutorialSetActive();
    }

    private void GetCardOrder()
    {
        Card1 = cards[0];
        Card2 = cards[1];
        Card3 = cards[2];
    }

    private void CreateRandomList()
    {
        int tempValue = Random.Range(0,3);
        if(randomCard.Contains(tempValue))
        {
            CreateRandomList();
        }
        else
        {
            randomCard.Add(tempValue);
        }
    }

    private void GenerateSortableCards()
    {
        for(int call = 0; call < 3; call++)
            CreateRandomList();

        for(int i = 0; i < cardListTransforms.Count; i++)
        {
            GameObject card = Instantiate(listedCards[i], slotableCardTransforms[randomCard[i]].transform.position, Quaternion.identity);
            tutorialSortCard.slots.Add(card.transform);
            card.transform.SetParent(slotableCardTransforms[randomCard[i]].transform);
            card.GetComponent<SortCardDraggable>().draggable = true;
            card.GetComponent<SortCardDraggable>().startingParent = slotableCardTransforms[randomCard[i]];
            LeanTween.scale(card, Vector3.one * 0.5f, 0.5f);
            card.transform.rotation = Quaternion.Euler(card.transform.rotation.x, card.transform.rotation.y, Random.Range(40, -40));
            LeanTween.moveLocal(card, new Vector3(card.transform.localPosition.x, card.transform.localPosition.y + Random.Range(-50, 50), card.transform.localPosition.z), 0f);
            slotableCards.Add(card);
        }
        UIController.GameUIActivate();
    }

    public void ClearBoard()
    {
        cardNames.Clear();
        cardListTransforms.Clear();
        slotableCardTransforms.Clear();
        randomCard.Clear();
        cards.Clear();
        cardLocalNames.Clear();
        usedRandoms.Clear();
        foreach(var card in slotableCards)
        {
            Destroy(card);
        }
        foreach(var card in listedCards)
        {
            Destroy(card);
        }
        listedCards.Clear();
        slotableCards.Clear();
        orderDetection.ClearLists();
        levelEnd.correct = 0;
        levelEnd.count = 0;
    }
}
