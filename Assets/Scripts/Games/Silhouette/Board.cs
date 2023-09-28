using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Board : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] Image shown;
    [SerializeField] Image[] silhouettes;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    List<AssistiveCardsSDK.AssistiveCardsSDK.Card> prefetchedRandomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    List<Texture2D> randomImages = new List<Texture2D>();
    List<Texture2D> prefetchedRandomImages = new List<Texture2D>();
    List<Sprite> randomSprites = new List<Sprite>();
    [SerializeField] TMP_Text cardName;
    public string selectedLangCode;
    [SerializeField] Transform shownImageSlot;
    [SerializeField] string shownImageSlug;
    public string packSlug;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject tutorial;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] DetectMatch detectMatchScript;
    private bool firstTime = true;
    public Image correctSilhoutte;
    [SerializeField] GameObject loadingPanel;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void TutorialSetActive()
    {
        if (firstTime || gameAPI.GetTutorialPreference() == 1)
        {
            tutorial.SetActive(true);
        }
        firstTime = false;
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
            detectMatchScript.OnBackButtonClick();
            isBackAfterSignOut = false;
        }
    }

    public async Task CacheCards(string packName)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();
        cachedCards = await gameAPI.GetCards(selectedLangCode, packName);

        if (packName == "shapes")
        {
            var cardsList = cachedCards.cards.ToList();
            var ring = cardsList.Single(card => card.slug == "ring");
            cardsList.Remove(ring);
            cachedCards.cards = cardsList.ToArray();
        }
    }


    public async Task GenerateRandomBoardAsync()
    {

        if (didLanguageChange)
        {
            await CacheCards(packSlug);
            didLanguageChange = false;
        }

        PopulateRandomCards();
        await PopulateRandomTextures();
        PlaceSprites();
        DisableLoadingPanel();
        ScaleImagesUp();
        backButton.SetActive(true);
        tutorial.GetComponent<SilhouetteTutorial>().point2 = correctSilhoutte.transform;
        TutorialSetActive();
        Invoke("EnableBackButton", 0.2f);
        await PrefetchNextLevelsTexturesAsync();
    }

    private async Task PopulateRandomTextures()
    {
        if (DetectMatch.correctMatches == 0)
        {
            for (int i = 0; i < silhouettes.Length; i++)
            {
                randomImages.Add(await gameAPI.GetCardImage(packSlug, randomCards[i].slug));
                randomImages[i].wrapMode = TextureWrapMode.Clamp;
                randomImages[i].filterMode = FilterMode.Bilinear;
                randomSprites.Add(Sprite.Create(randomImages[i], new Rect(0.0f, 0.0f, randomImages[i].width, randomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
            }
        }

    }

    private void PopulateRandomCards()
    {
        if (DetectMatch.correctMatches == 0)
        {
            for (int i = 0; i < silhouettes.Length; i++)
            {
                var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
                CheckIfCardExists(cardToAdd);
            }

            shownImageSlug = randomCards[0].slug;
        }

    }

    private void PlaceSprites()
    {
        if (DetectMatch.correctMatches != 0)
        {
            for (int i = 0; i < silhouettes.Length; i++)
            {
                randomSprites.Add(Sprite.Create(prefetchedRandomImages[i], new Rect(0.0f, 0.0f, prefetchedRandomImages[i].width, prefetchedRandomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
            }
        }

        shown.sprite = randomSprites[0];
        correctSilhoutte = silhouettes[Random.Range(0, silhouettes.Length)];
        correctSilhoutte.sprite = randomSprites[0];

        for (int i = 0; i < silhouettes.Length; i++)
        {
            silhouettes[i].gameObject.SetActive(true);
            if (silhouettes[i].sprite == null)
            {
                var randomIndex = Random.Range(1, randomSprites.Count);
                var sprite = randomSprites[randomIndex];
                randomSprites.RemoveAt(randomIndex);
                silhouettes[i].sprite = sprite;
            }
        }
    }

    public void ClearBoard()
    {
        cardName.text = "";
        shown.sprite = null;
        randomCards.Clear();
        // prefetchedRandomCards.Clear();
        randomImages.Clear();
        // prefetchedRandomImages.Clear();
        randomSprites.Clear();

        for (int i = 0; i < silhouettes.Length; i++)
        {
            silhouettes[i].sprite = null;
            silhouettes[i].color = new Color32(0, 0, 0, 200);
        }

    }

    public void ScaleImagesUp()
    {
        cardName.text = DetectMatch.correctMatches == 0 ? gameAPI.ToSentenceCase(randomCards[0].title) : gameAPI.ToSentenceCase(prefetchedRandomCards[0].title);
        shown.transform.position = shownImageSlot.position;
        shown.GetComponent<Draggable>().enabled = true;

        LeanTween.scale(cardName.gameObject, Vector3.one, 0.15f);
        LeanTween.scale(shown.gameObject, Vector3.one, 0.15f);
        for (int i = 0; i < silhouettes.Length; i++)
        {
            LeanTween.scale(silhouettes[i].gameObject, Vector3.one, 0.15f);
        }

    }

    public void CheckIfCardExists(AssistiveCardsSDK.AssistiveCardsSDK.Card cardToAdd)
    {
        if (!randomCards.Contains(cardToAdd) && cardToAdd.slug != shownImageSlug)
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
        if (!prefetchedRandomCards.Contains(prefetchedCardToAdd) && prefetchedCardToAdd.slug != shownImageSlug)
        {
            prefetchedRandomCards.Add(prefetchedCardToAdd);
        }
        else
        {
            prefetchedCardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExistsPrefetch(prefetchedCardToAdd);
        }
    }

    public void ReadCard()
    {
        if (DetectMatch.correctMatches == 0)
        {
            gameAPI.Speak(randomCards[0].title);
        }

        else
        {
            gameAPI.Speak(prefetchedRandomCards[0].title);
        }
    }

    private void DisableLoadingPanel()
    {
        // if (loadingPanel.activeInHierarchy)
        // {
        loadingPanel.SetActive(false);
        // }
    }

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
    }

    private async Task PrefetchNextLevelsTexturesAsync()
    {
        prefetchedRandomCards.Clear();
        prefetchedRandomImages.Clear();

        for (int i = 0; i < silhouettes.Length; i++)
        {
            var prefetchedCardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExistsPrefetch(prefetchedCardToAdd);

            prefetchedRandomImages.Add(await gameAPI.GetCardImage(packSlug, prefetchedRandomCards[i].slug));
            prefetchedRandomImages[i].wrapMode = TextureWrapMode.Clamp;
            prefetchedRandomImages[i].filterMode = FilterMode.Bilinear;

        }

        shownImageSlug = prefetchedRandomCards[0].slug;

    }


}
