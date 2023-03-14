using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardGenerateCardChain : MonoBehaviour
{
    GameAPI gameAPI;
    public string selectedLangCode;

    AssistiveCardsSDK.AssistiveCardsSDK.Cards cardDefinitions;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cardTextures;
    [SerializeField] private PackSelectionPanel packSelectionPanel;

    private int tempRandomValue;
    private int randomValue;

    private List<string> cardNames = new List<string>();
    private List<string> cardDefinitionsLocale = new List<string>();
    public List<GameObject> cards  = new List<GameObject>();

    public List<int> randomValueList = new List<int>();
    public List<int> usedRandomValues = new List<int>();

    [SerializeField] private GameObject cardPrefab;
    public int cardCount;
    public string packSlug;
    public bool isBoardCreated = false;


    private void OnEnable()
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

    private void CheckRandom()
    {
        tempRandomValue = Random.Range(0, cardTextures.cards.Length);

        if(randomValueList.IndexOf(tempRandomValue) < 0)
        {
            randomValue = tempRandomValue;
            randomValueList.Add(randomValue);
        }
        else
        {
            CheckRandom();
        }
    }

    public async Task GenerateRandomBoardAsync(string packSlug)
    {
        for(int x = 0; x < cardCount; x++)
        {
            CheckRandom();
        }

        for(int i = 0; i< cardTextures.cards.Length; i++)
        {
            cardNames.Add(cardTextures.cards[i].title.ToLower().Replace(" ", "-"));
            cardDefinitionsLocale.Add(cardDefinitions.cards[i].title);
        }

        for(int j = 0; j < cardCount; j++)
        {
            cards.Add(Instantiate(cardPrefab, Vector3.zero, Quaternion.identity));
            cards[j].transform.parent = this.transform;
            LeanTween.scale(cards[j], Vector3.one * 1.18f, 0);
            cards[j].transform.name = "Card" + j;

            var cardName = cardNames[randomValueList[Random.Range(0, randomValueList.Count)]];
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardName, 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;
            cards[j].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;

            var cardName2 = cardNames[randomValueList[Random.Range(0, randomValueList.Count)]];
            var cardTexture2 = await gameAPI.GetCardImage(packSlug, cardName2, 512);
            cardTexture2.wrapMode = TextureWrapMode.Clamp;
            cardTexture2.filterMode = FilterMode.Bilinear;
            cards[j].transform.GetChild(1).GetComponent<RawImage>().texture = cardTexture2;
        }
        Invoke("FillCardSlot", 0.5f);
        isBoardCreated = true;
    }

    public async void CreateBoard()
    {
        await CacheCards(packSelectionPanel.selectedPackElement.name);
    }
}
