using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DropControllerBucket : MonoBehaviour
{   
    GameAPI gameAPI;
    public string selectedLangCode;
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    public List<string> cardLocalNames = new List<string>();
    private string packSlug;

    [SerializeField] private GameObject parentalObject;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    public List<GameObject> cards = new List<GameObject>();

    private List<int> randomValues = new List<int>();
    private List<int> usedRandomValues = new List<int>();
    private int random;

    public GameObject moveCard;
    public bool isBoardCreated;
    public int matchCount;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();

        cachedCards = await gameAPI.GetCards("en", _packSlug);
        cachedLocalCards = await gameAPI.GetCards(selectedLangCode, _packSlug);
        packSlug = _packSlug;

        cardsList = cachedCards.cards.ToList();

        for(int i = 0; i < cachedCards.cards.Length; i++)
        {
            cardNames.Add(cachedCards.cards[i].title.ToLower().Replace(" ", "-"));
            cardLocalNames.Add(cachedLocalCards.cards[i].title);
        }
    }

    private void CreateIntValues()
    {
        random = Random.Range(0, cardNames.Count);
        Debug.Log("random :" + random);
        Debug.Log("card list :" + cardNames.Count);
    }

    private async void GeneratedDropableAsync(string _packSlug)
    {
        await CacheCards(_packSlug);
        CreateIntValues();
        for(int i=0; i < 30; i++)
        {
            GameObject card = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);

            int randomCard = Random.Range(random, random + 5);
            var cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[randomCard], 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            card.transform.name = cardNames[randomCard];
            card.transform.SetParent(parentalObject.transform);
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            card.GetComponent<CardControllerBucket>().cardLocalName = cardLocalNames[i];
            cards.Add(card);
        }
        Invoke("SelectMoveCard", 1.25f);
    }

    public void SelectMoveCard()
    {
        var random = Random.Range(0, cards.Count);
        moveCard = cards[random];
        isBoardCreated = true;
    }

    public void GenerateDropable()
    {
        GeneratedDropableAsync(packSelectionPanel.selectedPackElement.name);
    }
}
