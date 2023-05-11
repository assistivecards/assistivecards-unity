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

    public List<string> cardNames = new List<string>();
    public List<string> cardDefinitionsLocale = new List<string>();
    public List<GameObject> slotableCards  = new List<GameObject>();
    private string packSlug;

    [SerializeField] private GameObject cardPrefab;
    private GameObject slotedCardsParent;
    public List<GameObject> slotedCards = new List<GameObject>();

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();
        cardDefinitions = await gameAPI.GetCards(selectedLangCode, _packSlug);
        cardTextures = await gameAPI.GetCards("en", _packSlug);
        await GenerateRandomBoardAsync(_packSlug);
        packSlug = _packSlug;
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
        GenerateRandomBoardAsync(packSelectionPanel.selectedPackElement.name);
    }

    public async Task GenerateRandomBoardAsync(string packSlug)
    {
        await CacheCards(packSlug);
        GetSlotedList();

        for(int i = 0; i < slotableCards.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab, slotedCards[i].transform.position, Quaternion.identity);
            
            int cardImageRandom = Random.Range(0, 2);
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[cardImageRandom], 512);

            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            card.transform.name = cardNames[cardImageRandom];
            card.transform.GetComponentInChildren<RawImage>().texture = cardTexture;
        }
    }
}
