using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardNinjaBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;

    [Header ("Cache Cards")]
    public string selectedLangCode;
    public List<string> cardLocalNames = new List<string>();
    public List<GameObject> cards = new List<GameObject>();
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    private string packSlug;

    [Header ("Card Ninja Classes")]
    [SerializeField] private PackSelectionPanel packSelectionPanel;

    [Header ("Game Objects & UI")]
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject cutPrefab;

    [Header ("Random")]
    private List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [SerializeField] private List<Sprite> cardPieces = new List<Sprite>();

    
    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards()
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();

        cachedCards = await gameAPI.GetCards("en", packSlug);
        cachedLocalCards = await gameAPI.GetCards(selectedLangCode, packSlug);

        cardsList = cachedCards.cards.ToList();

        for(int i = 0; i < cachedCards.cards.Length; i++)
        {
            cardNames.Add(cachedCards.cards[i].title.ToLower().Replace(" ", "-"));
            cardLocalNames.Add(cachedLocalCards.cards[i].title);
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
        packSlug = packSelectionPanel.selectedPackElement.name;
        await CacheCards();
        for(int i=0; i < 18; i++)
        {
            CheckRandom();
            GameObject card = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);

            var cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[randomValueList[i]], 512);
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            card.transform.name = cardNames[randomValueList[i]];
            card.transform.SetParent(grid.transform);
            LeanTween.scale(card.gameObject, Vector3.one * 0.5f, 0f);
            card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            cards.Add(card);
            DivideHorizontal(cardTexture, card.transform.GetChild(1).GetComponent<Image>(), card.transform.GetChild(2).GetComponent<Image>(),
            card.transform.GetChild(3).GetComponent<Image>(), card.transform.GetChild(4).GetComponent<Image>());
        }
        Invoke("ReleaseFromGrid", 0.15f);
        Invoke("EnableCutCollider", 0.2f);
    }

    public void DivideHorizontal(Texture2D texture, Image piece1, Image piece2, Image piece3, Image piece4)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Sprite newSprite = Sprite.Create(texture, new Rect(i * 256, j * 256, 256, 256), new Vector2(0.5f, 0.5f));

                if(j == 0 && i == 0)
                {
                    piece3.sprite = newSprite;
                }
                else if(j == 1 && i == 0)
                {
                    piece1.sprite = newSprite;
                }
                else if(j == 0 && i == 1)
                {
                    piece4.sprite = newSprite;
                }
                else if(j == 1 && i == 1)
                {
                    piece2.sprite = newSprite;
                }
            }
        }
    }

    private void ReleaseFromGrid()
    {
        GetComponent<GridLayoutGroup>().enabled = false;
    }

    private void EnableCutCollider()
    {
        cutPrefab.GetComponent<BoxCollider2D>().enabled = true;
    }
}
