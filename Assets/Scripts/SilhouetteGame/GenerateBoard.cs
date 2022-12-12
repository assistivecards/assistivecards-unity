using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateBoard : MonoBehaviour
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
        await GenerateRandomBoardAsync("animals");
    }

    public async Task GenerateRandomBoardAsync(string packSlug)
    {
        await CacheCards(packSlug);
        for (int i = 0; i < randomCards.Count; i++)
        {
            var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            if (!randomCards.Contains(cardToAdd))
            {
                randomCards[i] = cardToAdd;
            }
            else
            {
                cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
                randomCards[i] = cardToAdd;
            }

            randomImages[i] = await gameAPI.GetCardImage(packSlug, randomCards[i].slug);
            randomSprites[i] = Sprite.Create(randomImages[i], new Rect(0.0f, 0.0f, randomImages[i].width, randomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f);
        }
        cardName.text = randomCards[0].title.ToUpper();
        // gameAPI.Speak(randomCards[0].title);
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
}
