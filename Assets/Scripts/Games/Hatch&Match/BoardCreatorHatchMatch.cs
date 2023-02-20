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
    [SerializeField] private Transform card1Position;
    [SerializeField] private Transform card2Position;
    [SerializeField] private Transform card3Position;
    public int cardTypeCount;

    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    private int tempRandomValue;
    private List<int> randomValues = new List<int>();

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();

        cachedCards = await gameAPI.GetCards("en", _packSlug);

        cardsList = cachedCards.cards.ToList();

        for(int i = 0; i < cachedCards.cards.Length; i++)
        {
            cardNames.Add(cachedCards.cards[i].title.ToLower().Replace(" ", "-"));
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
                    CreateRandomValue();
                }
            }

        }
    }

    private async void  GenerateCard(string _packSlug, Transform _cardPosition, int _randomValue)
    {
        await CacheCards(_packSlug);
        CreateRandomValue();
        var cardTexture = await gameAPI.GetCardImage(_packSlug, cardNames[randomValues[_randomValue]], 512);
        
        GameObject card1 = Instantiate(cardPrefab, _cardPosition.position, Quaternion.identity);
        

        cardTexture.wrapMode = TextureWrapMode.Clamp;
        cardTexture.filterMode = FilterMode.Bilinear;

        card1.transform.name = cardNames[randomValues[_randomValue]];
        card1.transform.SetParent(this.transform);
        card1.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
    }

    public void GeneratStylized()
    {
        GenerateCard(packSelectionPanel.selectedPackElement.name, card1Position, 1);
        GenerateCard(packSelectionPanel.selectedPackElement.name, card2Position, 2);
        GenerateCard(packSelectionPanel.selectedPackElement.name, card3Position, 3);
    }

}
