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
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    private string packSlug;

    [Header ("Card Ninja Classes")]
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    [SerializeField] private CardNinjaCutController cutController;
    [SerializeField] private CardNinjaUIController uıController;

    [Header ("Game Objects & UI")]
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject cutPrefab;
    [SerializeField] private TMP_Text cutText;
    [SerializeField] private GameObject tutorial;
    private GameObject selectedCard;
    private string selectedCardLocal;

    [Header ("Random")]
    public GameObject randomCard;
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;


    [Header ("Level End")]
    [SerializeField] private GameObject selectedCardObject;
    [SerializeField] private GameObject selectedCardPosition;

    [SerializeField] private List<Sprite> cardPieces = new List<Sprite>();
    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> usedCards = new List<GameObject>();
    public int formerCardInt;
    public string selectedCardTag;

    
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
        if(uıController.canGenerate)
        {
            cutPrefab.SetActive(false);
            GetComponent<GridLayoutGroup>().enabled = true;
            packSlug = packSelectionPanel.selectedPackElement.name;
            await CacheCards();
            CheckRandom();
            var random = Random.Range(0, randomValueList.Count);

            if(random == formerCardInt)
            {
                random = Random.Range(0, randomValueList.Count);
            }

            for(int i=0; i < 10; i++)
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
                card.GetComponent<CardNinjaCardMovement>().cardType = cardNames[randomValueList[i]];
                card.GetComponent<CardNinjaCardMovement>().cardLocalName = cardLocalNames[randomValueList[i]];

                // selected card creation

    

                selectedCard = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);

                var selectedCardTexture = await gameAPI.GetCardImage(packSlug, cardNames[randomValueList[random]], 512);
                selectedCardTexture.wrapMode = TextureWrapMode.Clamp;
                selectedCardTexture.filterMode = FilterMode.Bilinear;

                selectedCard.transform.name = cardNames[randomValueList[random]];
                selectedCardLocal = cardLocalNames[randomValueList[random]];
                selectedCard.transform.SetParent(grid.transform);
                LeanTween.scale(selectedCard.gameObject, Vector3.one * 0.5f, 0f);
                selectedCard.transform.GetChild(0).GetComponent<RawImage>().texture = selectedCardTexture;
                cards.Add(selectedCard);
                DivideHorizontal(selectedCardTexture, selectedCard.transform.GetChild(1).GetComponent<Image>(), selectedCard.transform.GetChild(2).GetComponent<Image>(),
                selectedCard.transform.GetChild(3).GetComponent<Image>(), selectedCard.transform.GetChild(4).GetComponent<Image>());
                selectedCard.GetComponent<CardNinjaCardMovement>().cardType = cardNames[randomValueList[random]];
                selectedCard.GetComponent<CardNinjaCardMovement>().cardLocalName = cardLocalNames[randomValueList[random]];
                selectedCardTag = cardNames[randomValueList[random]];
                formerCardInt = random;

                cutText.text = gameAPI.Translate(cutText.gameObject.name, gameAPI.ToSentenceCase(selectedCard.name).Replace("-", " "), selectedLangCode);
            }

            if(selectedCardPosition.transform.childCount > 0)
            {
                foreach(Transform child in selectedCardPosition.transform)
                {
                    Destroy(child.gameObject);
                }
            }


            selectedCardObject = Instantiate(selectedCard, selectedCardPosition.transform.position, Quaternion.identity);
            selectedCardObject.transform.SetParent(selectedCardPosition.transform);
            selectedCardObject.GetComponent<BoxCollider2D>().enabled = false;
            LeanTween.scale(selectedCardObject, Vector3.zero, 0);

            uıController.Invoke("TutorialSetActive", 0.25f);
            uıController.GameUIActivate();
            Invoke("ReleaseFromGrid", 0.1f);
            Invoke("EnableCutCollider", 0.2f);
            Invoke("ThrowCards", 0.5f);

        }
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
        cutPrefab.SetActive(true);
    }

    public void ThrowCards()
    {
        cutController.LevelEndCheck();
        if(!uıController.levelEnd && cards.Count > 0 && cutController.cutCount < 10)
        {
            randomCard = cards[Random.Range(0, cards.Count)];

            if(randomCard != null && !usedCards.Contains(randomCard))
            {
                randomCard.GetComponent<CardNinjaCardMovement>().Throw();
                usedCards.Add(randomCard);
                cards.Remove(randomCard);
            }
            else
            {
                randomCard = cards[Random.Range(0, cards.Count)];

                if(randomCard != null && !usedCards.Contains(randomCard))
                {
                    randomCard.GetComponent<CardNinjaCardMovement>().Throw();
                    usedCards.Add(randomCard);
                    cards.Remove(randomCard);
                }
            }
        }
    }

    public void LevelEndCardScale()
    {
        LeanTween.scale(selectedCardObject, Vector3.one, 0.5f);
        gameAPI.Speak(selectedCardLocal);
        Debug.Log(selectedCardLocal);
        Invoke("LevelEndDownScale", 1.5f);
    }

    private void LevelEndDownScale()
    {
        gameAPI.PlaySFX("Finished");
        LeanTween.scale(selectedCardObject, Vector3.zero, 0.5f);
    }

    public void ClearBoard()
    {
        if(cutController.levelEndedCount >= 2)
            cutController.cutCount = 0;

        cutController.throwedCount = 0;
        cutPrefab.SetActive(false);

        foreach(var card in cards)
        {
            Destroy(card);
        }

        foreach(var card in usedCards)
        {
            Destroy(card);
        }

        cards.Clear();
        cardLocalNames.Clear();
        cardsList.Clear();
        cardNames.Clear();
        usedCards.Clear();
        cardPieces.Clear();
        randomValueList.Clear();
    }
}
