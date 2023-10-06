using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardRumbleBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    List<AssistiveCardsSDK.AssistiveCardsSDK.Card> prefetchedRandomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    List<Texture2D> randomImages = new List<Texture2D>();
    List<Texture2D> prefetchedRandomImages = new List<Texture2D>();
    List<Sprite> randomSprites = new List<Sprite>();
    List<Sprite> tempSprites = new List<Sprite>();
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] TMP_Text tapText;
    [SerializeField] string correctCardSlug;
    public string correctCardTitle;
    [SerializeField] Image[] cardImagesInScene;
    [SerializeField] GameObject loadingPanel;
    public GameObject[] spawnPoints;
    public GameObject[] cardParents;
    public int numOfMatchedCards;
    public int numOfCorrectCards;
    private CardRumbleUIController UIController;
    public int cardSpeed = 350;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<CardRumbleUIController>();
    }

    private void OnEnable()
    {
        if (isBackAfterSignOut)
        {
            gameAPI.PlayMusic();
            UIController.OnBackButtonClick();
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
        TranslateTapCardText();
        await PopulateRandomTextures();
        PopulateTempSprites();
        PlaceSprites();
        AssignTags();
        DisableLoadingPanel();
        ScaleImagesUp();
        backButton.SetActive(true);
        UIController.Invoke("TutorialSetActive", .3f);
        Invoke("EnableBackButton", 0.25f);
        await PrefetchNextLevelsTexturesAsync();
    }

    public void ClearBoard()
    {
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();
        tempSprites.Clear();

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].sprite = null;
        }

    }

    public void ScaleImagesUp()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            cardParents[i].transform.rotation = Quaternion.Euler(0, 0, -20);
            cardParents[i].transform.position = spawnPoints[i].transform.position;
            cardParents[i].GetComponent<CardRumbleMatchDetection>().enabled = true;
            LeanTween.scale(cardParents[i], Vector3.one, 0.2f);
            cardParents[i].GetComponent<CardRumbleCardMovement>().InitiateCardMovement();
            numOfMatchedCards = 0;
            cardParents[i].transform.GetComponent<CardRumbleMatchDetection>().isClicked = false;
        }

        LeanTween.scale(tapText.gameObject, Vector3.one, 0.2f);
    }

    public void ScaleImagesDown()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            LeanTween.scale(cardParents[i], Vector3.zero, 0.25f);
        }

        LeanTween.scale(tapText.gameObject, Vector3.zero, 0.25f);
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

    public void CheckIfCardExistsPrefetch(AssistiveCardsSDK.AssistiveCardsSDK.Card prefetchedCardToAdd)
    {
        if (!prefetchedRandomCards.Contains(prefetchedCardToAdd) && prefetchedCardToAdd.slug != correctCardSlug)
        {
            prefetchedRandomCards.Add(prefetchedCardToAdd);
        }
        else
        {
            prefetchedCardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExistsPrefetch(prefetchedCardToAdd);
        }
    }

    public void EnableBackButton()
    {
        backButton.SetActive(true);
        backButton.GetComponent<Button>().interactable = true;
    }

    public async Task PopulateRandomTextures()
    {
        if (UIController.levelsCompleted == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                var texture = await gameAPI.GetCardImage(packSlug, randomCards[i].slug);
                texture.wrapMode = TextureWrapMode.Clamp;
                texture.filterMode = FilterMode.Bilinear;
                texture.name = randomCards[i].title;
                randomImages.Add(texture);
                randomSprites.Add(Sprite.Create(randomImages[i], new Rect(0.0f, 0.0f, randomImages[i].width, randomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
                randomSprites[i].name = randomImages[i].name;
            }
        }

    }

    private void PopulateTempSprites()
    {

        if (UIController.levelsCompleted != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                randomSprites.Add(Sprite.Create(prefetchedRandomImages[i], new Rect(0.0f, 0.0f, prefetchedRandomImages[i].width, prefetchedRandomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
                randomSprites[i].name = prefetchedRandomImages[i].name;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            tempSprites.Add(randomSprites[0]);
        }

        for (int i = 2; i < 4; i++)
        {
            tempSprites.Add(randomSprites[i - 1]);
        }

        for (int i = 4; i < cardImagesInScene.Length; i++)
        {
            var randomSpriteToAdd = randomSprites[Random.Range(0, randomSprites.Count)];
            tempSprites.Add(randomSpriteToAdd);
        }

    }

    public void PlaceSprites()
    {

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {

            if (cardImagesInScene[i].sprite == null)
            {
                var randomIndex = Random.Range(0, tempSprites.Count);
                var sprite = tempSprites[randomIndex];
                tempSprites.RemoveAt(randomIndex);
                cardImagesInScene[i].sprite = sprite;
            }
        }
    }

    public void PopulateRandomCards()
    {
        if (UIController.levelsCompleted == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
                CheckIfCardExists(cardToAdd);
            }

            correctCardSlug = randomCards[0].slug;
            correctCardTitle = randomCards[0].title;
        }

    }

    private void DisableLoadingPanel()
    {
        loadingPanel.SetActive(false);

    }

    public void TranslateTapCardText()
    {
        tapText.text = gameAPI.Translate(tapText.gameObject.name, gameAPI.ToTitleCase(UIController.levelsCompleted == 0 ? randomCards[0].title : prefetchedRandomCards[0].title).Replace("-", " "), selectedLangCode);
    }

    public void AssignTags()
    {
        if (UIController.levelsCompleted == 0)
        {
            for (int i = 0; i < cardImagesInScene.Length; i++)
            {
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
        else
        {
            for (int i = 0; i < cardImagesInScene.Length; i++)
            {
                if (cardImagesInScene[i].sprite.texture != prefetchedRandomImages[0])
                {
                    cardImagesInScene[i].transform.parent.tag = "WrongCard";
                }

                else
                {
                    cardImagesInScene[i].transform.parent.tag = "CorrectCard";
                }
            }
        }


        numOfCorrectCards = cardParents.Where(card => card.tag == "CorrectCard").ToList().Count;
    }

    private async Task PrefetchNextLevelsTexturesAsync()
    {
        prefetchedRandomCards.Clear();
        prefetchedRandomImages.Clear();

        for (int i = 0; i < 3; i++)
        {
            var prefetchedCardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExistsPrefetch(prefetchedCardToAdd);

            var texture = await gameAPI.GetCardImage(packSlug, prefetchedRandomCards[i].slug);
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Bilinear;
            texture.name = prefetchedRandomCards[i].title;
            prefetchedRandomImages.Add(texture);

        }

        correctCardSlug = prefetchedRandomCards[0].slug;
        correctCardTitle = prefetchedRandomCards[0].title;

    }

}
