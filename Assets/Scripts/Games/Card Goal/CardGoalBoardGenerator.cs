using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardGoalBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] SpriteRenderer[] cardTextures;
    public GameObject[] cardParents;
    public Transform[] cardSlots;
    public GameObject goalPost;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomImages = new List<Texture2D>();
    [SerializeField] List<Sprite> randomSprites = new List<Sprite>();
    public string selectedLangCode;
    public string correctCardSlug;
    [SerializeField] TMP_Text throwText;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] GameObject loadingPanel;
    private CardGoalUIController UIController;
    [SerializeField] GameObject tutorial;
    [SerializeField] GameObject settingsButton;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<CardGoalUIController>();
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
        TranslateThrowCardText();
        await PopulateRandomTextures();
        PlaceSprites();
        DisableLoadingPanel();
        ScaleImagesUp();
        Invoke("SetTutorialPosition", .3f);
        backButton.SetActive(true);
        UIController.Invoke("TutorialSetActive", .3f);
        Invoke("EnableBackButton", 0.15f);
    }

    public void ClearBoard()
    {
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();

        for (int i = 0; i < cardTextures.Length; i++)
        {
            cardTextures[i].sprite = null;
        }

        for (int i = 0; i < cardParents.Length; i++)
        {
            cardParents[i].GetComponent<CardGoalFlickManager>().canThrow = true;
            cardParents[i].GetComponent<CardGoalFlickManager>().isValid = false;
            cardParents[i].GetComponent<BoxCollider2D>().isTrigger = true;
            cardParents[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            cardParents[i].GetComponent<Rigidbody2D>().isKinematic = true;
            cardParents[i].GetComponent<Rigidbody2D>().freezeRotation = true;

        }

    }

    public void ScaleImagesUp()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            cardParents[i].transform.SetParent(cardSlots[i]);
            cardParents[i].transform.position = cardSlots[i].position;
            cardParents[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            cardParents[i].GetComponent<Rigidbody2D>().freezeRotation = false;
            LeanTween.alpha(cardParents[i], 1, .001f);
            LeanTween.scale(cardParents[i], Vector3.one * 12, 0.2f);
            cardParents[i].GetComponent<SpriteRenderer>().sortingOrder = 2;
            cardParents[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 3;
        }

        LeanTween.scale(throwText.gameObject, Vector3.one, 0.2f);
        LeanTween.scale(goalPost.gameObject, Vector3.one * .75f, 0.2f);
        settingsButton.GetComponent<Button>().interactable = true;

    }

    public void ScaleImagesDown()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            LeanTween.scale(cardParents[i], Vector3.zero, 0.2f);
        }

        LeanTween.scale(throwText.gameObject, Vector3.zero, 0.2f);
    }

    public void ScaleGoalPostDown()
    {
        LeanTween.scale(goalPost.gameObject, Vector3.zero, 0.2f);
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
        for (int i = 0; i < cardParents.Length; i++)
        {
            var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
        }

        correctCardSlug = randomCards[0].slug;
    }

    public async Task PopulateRandomTextures()
    {
        for (int i = 0; i < cardTextures.Length; i++)
        {
            var texture = await gameAPI.GetCardImage(packSlug, randomCards[i].slug);
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Bilinear;
            texture.name = randomCards[i].slug;
            randomImages.Add(texture);
            randomSprites.Add(Sprite.Create(randomImages[i], new Rect(0.0f, 0.0f, randomImages[i].width, randomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
            randomSprites[i].name = randomImages[i].name;
        }
    }

    public void PlaceSprites()
    {
        for (int i = 0; i < cardTextures.Length; i++)
        {
            if (cardTextures[i].sprite == null)
            {
                var randomIndex = Random.Range(0, randomSprites.Count);
                var sprite = randomSprites[randomIndex];
                randomSprites.RemoveAt(randomIndex);
                cardTextures[i].sprite = sprite;
            }
        }
    }

    private void DisableLoadingPanel()
    {
        loadingPanel.SetActive(false);
    }

    public void ReadCard()
    {
        gameAPI.Speak(randomCards[0].title);
    }

    public void TranslateThrowCardText()
    {
        throwText.text = gameAPI.Translate(throwText.gameObject.name, gameAPI.ToSentenceCase(randomCards[0].title).Replace("-", " "), selectedLangCode);
    }

    private void SetTutorialPosition()
    {

        for (int i = 0; i < cardParents.Length; i++)
        {
            if (cardParents[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.texture == randomImages[0])
            {
                tutorial.transform.SetParent(cardParents[i].transform.parent);
                tutorial.GetComponent<Tutorial>().tutorialPosition = cardParents[i].transform.parent;
            }
        }

    }

}
