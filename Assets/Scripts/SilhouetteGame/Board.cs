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
    [SerializeField] List<Texture2D> cachedCardImages;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomImages = new List<Texture2D>();
    [SerializeField] List<Sprite> randomSprites = new List<Sprite>();
    [SerializeField] TMP_Text cardName;
    public string selectedLangCode;
    [SerializeField] Transform shownImageSlot;
    public string packSlug;


    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards(string packName)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();
        cachedCards = await gameAPI.GetCards(selectedLangCode, packName);
        // for (int i = 0; i < cachedCards.cards.Length; i++)
        // {
        //     var cardImage = await gameAPI.GetCardImage(packSlug, cachedCards.cards[i].slug);
        //     cachedCardImages.Add(cardImage);
        // }
    }

    public async void Start()
    {
        // await GenerateRandomBoardAsync();
    }

    public async Task GenerateRandomBoardAsync()
    {
        shown.transform.position = shownImageSlot.position;
        await CacheCards(packSlug);
        for (int i = 0; i < silhouettes.Length; i++)
        {
            var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            // var index = Random.Range(0, cachedCards.cards.Length);
            // var cardToAdd = cachedCards.cards[index];
            if (!randomCards.Contains(cardToAdd))
            {

                randomCards.Add(cardToAdd);
                // randomImages.Add(cachedCardImages[index]);

            }
            else
            {
                cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
                // var indexSecondRoll = Random.Range(0, cachedCards.cards.Length);
                // cardToAdd = cachedCards.cards[indexSecondRoll];
                randomCards.Add(cardToAdd);
                // randomImages.Add(cachedCardImages[indexSecondRoll]);
            }

            randomImages.Add(await gameAPI.GetCardImage(packSlug, randomCards[i].slug));
            randomSprites.Add(Sprite.Create(randomImages[i], new Rect(0.0f, 0.0f, randomImages[i].width, randomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
        }
        cardName.text = randomCards[0].title;
        shown.sprite = randomSprites[0];
        silhouettes[Random.Range(0, silhouettes.Length)].sprite = randomSprites[0];

        for (int i = 0; i < silhouettes.Length; i++)
        {
            if (silhouettes[i].sprite == null)
            {
                var randomIndex = Random.Range(1, randomSprites.Count);
                var sprite = randomSprites[randomIndex];
                randomSprites.RemoveAt(randomIndex);
                silhouettes[i].sprite = sprite;
            }
        }

        ScaleImagesUp();
    }

    public void ClearBoard()
    {
        cardName.text = "";
        shown.sprite = null;
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();
        for (int i = 0; i < silhouettes.Length; i++)
        {
            silhouettes[i].sprite = null;
            silhouettes[i].color = Color.black;
        }

    }

    public void ScaleImagesUp()
    {
        LeanTween.scale(cardName.gameObject, Vector3.one, 0.25f);
        LeanTween.scale(shown.gameObject, Vector3.one, 0.25f);
        for (int i = 0; i < silhouettes.Length; i++)
        {
            LeanTween.scale(silhouettes[i].gameObject, Vector3.one, 0.25f);
        }

    }
}
