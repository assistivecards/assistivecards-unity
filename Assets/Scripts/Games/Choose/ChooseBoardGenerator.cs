using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] Image[] cardTextures;
    public GameObject[] cardParents;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomImages = new List<Texture2D>();
    [SerializeField] List<Sprite> randomSprites = new List<Sprite>();
    public string selectedLangCode;
    public string correctCardSlug;
    [SerializeField] TMP_Text chooseText;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] GameObject loadingPanel;
    ChooseUIController UIController;
    [SerializeField] GameObject tutorial;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<ChooseUIController>();
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
        TranslateChooseCardText();
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

    }

    public void ScaleImagesUp()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            cardParents[i].GetComponent<ChooseMatchDetection>().isClicked = false;
            LeanTween.alpha(cardParents[i].GetComponent<RectTransform>(), 1, .001f);
            LeanTween.scale(cardParents[i], Vector3.one, 0.2f);
        }

        LeanTween.scale(chooseText.gameObject, Vector3.one, 0.2f);

    }

    public void ScaleImagesDown()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            LeanTween.scale(cardParents[i], Vector3.zero, 0.2f);
        }

        LeanTween.scale(chooseText.gameObject, Vector3.zero, 0.2f);
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

    public void TranslateChooseCardText()
    {
        chooseText.text = gameAPI.Translate(chooseText.gameObject.name, gameAPI.ToTitleCase(randomCards[0].title).Replace("-", " "), selectedLangCode);
    }

    public void ReadCard()
    {
        gameAPI.Speak(randomCards[0].title);
    }

    private void SetTutorialPosition()
    {

        for (int i = 0; i < cardParents.Length; i++)
        {
            if (cardParents[i].transform.GetChild(0).GetComponent<Image>().sprite.texture == randomImages[0])
            {
                tutorial.GetComponent<Tutorial>().tutorialPosition = cardParents[i].transform;
            }
        }

    }

}
