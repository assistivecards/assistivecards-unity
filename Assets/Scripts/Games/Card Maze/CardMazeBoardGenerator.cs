using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardMazeBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] SpriteRenderer cardTexture;
    public GameObject cardParent;
    [SerializeField] GameObject[] mazes;
    [SerializeField] GameObject[] keyPositions;
    public GameObject selectedMaze;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] Texture2D randomImage;
    [SerializeField] Sprite randomSprite;
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> uniqueCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] TMP_Text throwText;
    [SerializeField] GameObject loadingPanel;
    private CardMazeUIController UIController;
    [SerializeField] GameObject tutorial;
    public bool isFlipped;
    [SerializeField] GameObject spawnPointsParent;
    [SerializeField] GameObject keyspawnPointsParent;
    [SerializeField] GameObject key;
    public GameObject settingsButton;
    [SerializeField] GameObject[] finishPoints;


    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<CardMazeUIController>();
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
            for (int i = 0; i < uniqueCards.Count; i++)
            {
                uniqueCards[i] = cachedCards.cards.Where(card => card.slug == uniqueCards[i].slug).ToList()[0];
            }
            didLanguageChange = false;
        }

        TranslateMazeText();
        await PopulateRandomTextures();
        PlaceSprites();
        DisableLoadingPanel();
        SelectRandomMaze();
        ScaleImagesUp();
        backButton.SetActive(true);
        UIController.Invoke("TutorialSetActive", .5f);
        Invoke("EnableBackButton", 0.4f);
    }

    public void ClearBoard()
    {
        var rb = cardParent.GetComponent<Rigidbody2D>();
        randomImage = null;
        randomSprite = null;
        cardTexture.sprite = null;
        key.GetComponent<CardMazeKey>().isCollected = false;

        for (int i = 0; i < finishPoints.Length; i++)
        {
            finishPoints[i].GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    public void ScaleImagesUp()
    {
        LeanTween.scale(throwText.gameObject, Vector3.one, 0.2f);
        LeanTween.scale(selectedMaze, Vector3.one, 0.2f).setOnComplete(SelectRandomSpawnPoint);
        settingsButton.GetComponent<Button>().interactable = true;

    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(key, Vector3.zero, 0.2f);
        LeanTween.scale(cardParent, Vector3.zero, 0.2f).setOnComplete(ScaleMazeDown);
        LeanTween.scale(throwText.gameObject, Vector3.zero, 0.2f);
    }

    public void CheckIfCardExists(AssistiveCardsSDK.AssistiveCardsSDK.Card cardToAdd)
    {
        if (!uniqueCards.Contains(cardToAdd))
        {
            uniqueCards.Add(cardToAdd);
        }
        else
        {
            cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
        }
    }

    public void ReadCard()
    {
        gameAPI.Speak(uniqueCards[UIController.correctMatches - 1].title);
    }

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
    }

    public void PopulateUniqueCards()
    {

        for (int i = 0; i < 3; i++)
        {
            var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            // Debug.Log("Log before checkifcardexists " + cardToAdd.slug);
            CheckIfCardExists(cardToAdd);
        }

    }

    public void ClearUniqueCards()
    {
        uniqueCards.Clear();
    }

    public async Task PopulateRandomTextures()
    {

        var texture = await gameAPI.GetCardImage(packSlug, uniqueCards[UIController.correctMatches].slug);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Bilinear;
        randomImage = texture;
        randomSprite = Sprite.Create(randomImage, new Rect(0.0f, 0.0f, randomImage.width, randomImage.height), new Vector2(0.5f, 0.5f), 100.0f);

    }

    public void PlaceSprites()
    {
        if (cardTexture.sprite == null)
        {
            var sprite = randomSprite;
            cardTexture.sprite = sprite;
        }
    }

    private void DisableLoadingPanel()
    {
        loadingPanel.SetActive(false);
    }

    public void TranslateMazeText()
    {
        throwText.text = gameAPI.Translate(throwText.gameObject.name, gameAPI.ToSentenceCase(uniqueCards[UIController.correctMatches].title).Replace("-", " "), selectedLangCode);
    }

    public void SelectRandomSpawnPoint()
    {
        var selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        cardParent.transform.position = selectedSpawnPoint.transform.position;
        tutorial.GetComponent<Tutorial>().tutorialPosition = cardParent.transform;
        LeanTween.scale(cardParent, Vector3.one * 10, 0.2f);
        cardParent.GetComponent<CardMazeDraggableCard>().enabled = true;
        cardParent.GetComponent<CircleCollider2D>().enabled = true;

        var selectedKeySpawnPoint = keyPositions[Random.Range(0, keyPositions.Length)];
        key.transform.position = selectedKeySpawnPoint.transform.position;
        LeanTween.scale(key, Vector3.one * 17, 0.2f);

        for (int i = 0; i < finishPoints.Length; i++)
        {
            finishPoints[i].GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    public void ScaleMazeDown()
    {
        LeanTween.scale(selectedMaze, Vector3.zero, 0.2f).setOnComplete(ResetFlip);

    }

    public void SelectRandomMaze()
    {
        selectedMaze = mazes[Random.Range(0, mazes.Length)];
        selectedMaze.SetActive(true);
        isFlipped = Random.value > 0.5f;

        if (isFlipped)
        {
            FlipMaze();
        }

        key.GetComponent<CardMazeKey>().originalPosition = GameObject.Find("Door").transform.localPosition;
    }

    public void FlipMaze()
    {
        selectedMaze.transform.rotation = Quaternion.Euler(0, 180, 0);
        spawnPointsParent.transform.rotation = Quaternion.Euler(0, 180, 0);
        keyspawnPointsParent.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public void ResetFlip()
    {
        GameObject.Find("Door").transform.localPosition = key.GetComponent<CardMazeKey>().originalPosition;
        selectedMaze.SetActive(false);
        selectedMaze.transform.rotation = Quaternion.Euler(0, 0, 0);
        spawnPointsParent.transform.rotation = Quaternion.Euler(0, 0, 0);
        keyspawnPointsParent.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
