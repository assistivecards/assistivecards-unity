using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DragInsideBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] Image[] cardImagesInScene;
    [SerializeField] GameObject[] cardParents;
    [SerializeField] GameObject targetArea;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomImages = new List<Texture2D>();
    [SerializeField] List<Sprite> randomSprites = new List<Sprite>();
    public string selectedLangCode;
    [SerializeField] string correctCardSlug;
    [SerializeField] TMP_Text dragText;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
    }

    private void OnEnable()
    {
        if (isBackAfterSignOut)
        {
            gameAPI.PlayMusic();
            isBackAfterSignOut = false;
        }
    }

    public async Task CacheCards(string packName)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();
        cachedCards = await gameAPI.GetCards(selectedLangCode, packName);
    }


    public async Task GenerateRandomBoardAsync()
    {
        if (didLanguageChange)
        {
            await CacheCards(packSlug);
            didLanguageChange = false;
        }

        PopulateRandomCards();
        TranslateDragCardText();
        await PopulateRandomTextures();
        PlaceSprites();
        AssignTags();
        ScaleImagesUp();
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.15f);
    }

    public void ClearBoard()
    {
        dragText.text = "";
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].sprite = null;
        }

    }

    public void ScaleImagesUp()
    {
        LeanTween.scale(dragText.gameObject, Vector3.one, 0.15f);
        LeanTween.scale(targetArea, Vector3.one, 0.15f);

        for (int i = 0; i < cardParents.Length; i++)
        {
            LeanTween.scale(cardParents[i].gameObject, Vector3.one, 0.15f);
        }
    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(dragText.gameObject, Vector3.zero, 0.25f);
        LeanTween.scale(targetArea, Vector3.zero, 0.15f);

        for (int i = 0; i < cardParents.Length; i++)
        {
            LeanTween.scale(cardParents[i].gameObject, Vector3.zero, 0.25f);
        }
    }

    public void CheckIfCardExists(AssistiveCardsSDK.AssistiveCardsSDK.Card cardToAdd)
    {
        if (!randomCards.Contains(cardToAdd) && cardToAdd.slug != correctCardSlug)
        {
            randomCards.Add(cardToAdd);
        }
        else
        {
            cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
        }
    }

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
    }

    public void PopulateRandomCards()
    {
        for (int i = 0; i < cardImagesInScene.Length / 2; i++)
        {
            var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
        }

        correctCardSlug = randomCards[0].slug;
    }

    public void TranslateDragCardText()
    {
        dragText.text = gameAPI.Translate(dragText.gameObject.name, gameAPI.ToSentenceCase(randomCards[0].title).Replace("-", " "), selectedLangCode);
    }

    public async Task PopulateRandomTextures()
    {
        for (int i = 0; i < cardImagesInScene.Length / 2; i++)
        {
            var texture = await gameAPI.GetCardImage(packSlug, randomCards[i].slug);
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Bilinear;
            randomImages.Add(texture);
            randomSprites.Add(Sprite.Create(randomImages[i], new Rect(0.0f, 0.0f, randomImages[i].width, randomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
            randomSprites.Add(Sprite.Create(randomImages[i], new Rect(0.0f, 0.0f, randomImages[i].width, randomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
        }
    }

    public void AssignTags()
    {
        // var correctCardImageIndex = Random.Range(0, cardImagesInScene.Length);
        // cardImagesInScene[correctCardImageIndex].sprite = randomSprites[0];

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            // if (i != correctCardImageIndex)
            // {
            //     cardImagesInScene[i].tag = "WrongCard";
            //     // cardImagesInScene[i].transform.GetChild(0).tag = "WrongCard";
            // }
            // else
            // {
            //     cardImagesInScene[correctCardImageIndex].tag = "CorrectCard";
            //     // cardImagesInScene[correctCardImageIndex].transform.GetChild(0).tag = "CorrectCard";
            // }
            if (cardImagesInScene[i].sprite.texture != randomImages[0])
            {
                cardImagesInScene[i].transform.parent.tag = "WrongCard";
            }

            else
            {
                cardImagesInScene[i].transform.parent.tag = "CorrectCard";
            }
        }
    }

    public void PlaceSprites()
    {

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].gameObject.SetActive(true);
            if (cardImagesInScene[i].sprite == null)
            {
                var randomIndex = Random.Range(0, randomSprites.Count);
                var sprite = randomSprites[randomIndex];
                randomSprites.RemoveAt(randomIndex);
                cardImagesInScene[i].sprite = sprite;
            }
        }
    }

}