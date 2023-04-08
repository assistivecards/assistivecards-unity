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

    private async void GeneratedDropableAsync(string _packSlug)
    {
        await CacheCards(_packSlug);
        for(int i=0; i < cardNames.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);

            var cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[i], 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            card.transform.name = cardNames[i];
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
