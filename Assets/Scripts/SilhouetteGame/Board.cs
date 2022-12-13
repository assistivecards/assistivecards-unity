using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Board : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] Image shown;
    [SerializeField] Image[] silhouettes;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomImages = new List<Texture2D>();
    [SerializeField] List<Sprite> randomSprites = new List<Sprite>();
    [SerializeField] TMP_Text cardName;
    public string selectedLangCode;
    [SerializeField] Transform shownImageSlot;
    private string packSlug = "animals";


    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards(string packName)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();
        cachedCards = await gameAPI.GetCards(selectedLangCode, packName);
    }

    public async void Start()
    {
        await GenerateRandomBoardAsync();
    }

    public async Task GenerateRandomBoardAsync()
    {
        shown.transform.position = shownImageSlot.position;
        await CacheCards(packSlug);
        for (int i = 0; i < silhouettes.Length; i++)
        {
            var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            if (!randomCards.Contains(cardToAdd))
            {
                randomCards.Add(cardToAdd);
            }
            else
            {
                cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
                randomCards.Add(cardToAdd);
            }

            randomImages.Add(await gameAPI.GetCardImage(packSlug, randomCards[i].slug));
            randomSprites.Add(Sprite.Create(randomImages[i], new Rect(0.0f, 0.0f, randomImages[i].width, randomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
        }
        cardName.text = randomCards[0].title.ToUpper();
        shown.sprite = randomSprites[0];
        silhouettes[Random.Range(0, silhouettes.Length)].sprite = randomSprites[0];

        foreach (var silhouette in silhouettes)
        {
            if (silhouette.sprite == null)
            {
                var randomIndex = Random.Range(1, randomSprites.Count);
                var sprite = randomSprites[randomIndex];
                randomSprites.RemoveAt(randomIndex);
                silhouette.sprite = sprite;
            }

        }
    }

    public void ClearBoard()
    {
        cardName.text = "";
        shown.sprite = null;
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();
        foreach (var silhouette in silhouettes)
        {
            silhouette.sprite = null;
            silhouette.color = Color.black;
        }
    }
}
