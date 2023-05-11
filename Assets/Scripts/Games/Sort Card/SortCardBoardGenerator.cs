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

    AssistiveCardsSDK.AssistiveCardsSDK.Cards cardDefinitions;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cardTextures;
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    public List<string> cardLocalNames = new List<string>();
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;

    public List<string> cardNames = new List<string>();
    public List<string> cardDefinitionsLocale = new List<string>();
    public List<GameObject> slotableCards  = new List<GameObject>();
    public string packSlug;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject slotedCardsParent;
    public List<GameObject> slotedCards = new List<GameObject>();

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
        foreach (Transform child in slotedCardsParent.transform)
        {
            slotedCards.Add(child.gameObject);
        }
    }

    public void GeneratStylized()
    {
        GetSlotedList();
        packSlug = packSelectionPanel.selectedPackElement.name;
        GenerateRandomBoardAsync(packSlug);
    }

    public async void GenerateRandomBoardAsync(string packSlug)
    {
        await CacheCards(packSlug);
        for(int i = 0; i < slotedCards.Count; i++)
        {

            GameObject card = Instantiate(cardPrefab, slotedCards[i].transform.position, Quaternion.identity);
            card.transform.SetParent(slotedCards[i].transform);
            Debug.Log(i);
            
            // int cardImageRandom = Random.Range(0, 2);
            // var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[cardImageRandom], 512);

            // cardTexture.wrapMode = TextureWrapMode.Clamp;
            // cardTexture.filterMode = FilterMode.Bilinear;

            // card.transform.name = cardNames[cardImageRandom];
            // card.transform.GetComponentInChildren<RawImage>().texture = cardTexture;
        }
    }
}
