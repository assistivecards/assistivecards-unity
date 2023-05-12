using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DrawShapesBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedShapeCards;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomImages = new List<Texture2D>();
    [SerializeField] List<Sprite> randomSprites = new List<Sprite>();
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] TMP_Text drawText;
    [SerializeField] string correctCardSlug;
    [SerializeField] Image[] cardImagesInScene;
    [SerializeField] List<string> shapes;
    [SerializeField] List<GameObject> paths;
    [SerializeField] List<GameObject> randomPaths;
    [SerializeField] List<GameObject> pathsParents;
    private string selectedShape;

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
        cachedShapeCards = await gameAPI.GetCards(selectedLangCode, "shapes");
    }


    public async Task GenerateRandomBoardAsync()
    {
        if (didLanguageChange)
        {
            await CacheCards(packSlug);
            didLanguageChange = false;
        }

        PopulateRandomCards();
        ChooseRandomPaths();
        TranslateDrawText();
        await PopulateRandomTextures();
        PlaceSprites();
        ScalePathsUp();
        Invoke("TriggerUpdatePaths", .15f);
        ScaleImagesUp();
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.15f);
    }

    public void ClearBoard()
    {
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
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            LeanTween.scale(cardImagesInScene[i].gameObject, Vector3.one, 0.2f);
        }

        LeanTween.scale(drawText.gameObject, Vector3.one, 0.2f);

    }

    public void ScaleImagesDown()
    {
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            LeanTween.scale(cardImagesInScene[i].gameObject, Vector3.zero, 0.2f);
        }

        LeanTween.scale(drawText.gameObject, Vector3.zero, 0.2f);
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

    public async Task PopulateRandomTextures()
    {
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            var texture = await gameAPI.GetCardImage(packSlug, randomCards[i].slug);
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Bilinear;
            randomImages.Add(texture);
            randomSprites.Add(Sprite.Create(randomImages[i], new Rect(0.0f, 0.0f, randomImages[i].width, randomImages[i].height), new Vector2(0.5f, 0.5f), 100.0f));
        }
    }

    public void PlaceSprites()
    {
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {

            if (cardImagesInScene[i].sprite == null)
            {
                var randomIndex = Random.Range(0, randomSprites.Count);
                var sprite = randomSprites[randomIndex];
                randomSprites.RemoveAt(randomIndex);
                cardImagesInScene[i].sprite = sprite;
            }
        }
    }

    public void PopulateRandomCards()
    {
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
        }

        correctCardSlug = randomCards[0].slug;
    }

    private void ChooseRandomPaths()
    {
        selectedShape = paths[Random.Range(0, paths.Count)].name;
        Debug.Log("Selected Shape: " + selectedShape);

        var selectedPaths = paths.Where(path => path.name == selectedShape).ToList();
        randomPaths = selectedPaths;

        for (int i = 0; i < randomPaths.Count; i++)
        {
            randomPaths[i].SetActive(true);
        }

    }

    private void ScalePathsUp()
    {
        for (int i = 0; i < pathsParents.Count; i++)
        {
            LeanTween.scale(pathsParents[i], Vector3.one, .15f);
        }
    }

    private void TriggerUpdatePaths()
    {
        for (int i = 0; i < randomPaths.Count; i++)
        {
            randomPaths[i].GetComponent<PathCreation.Examples.PathPlacer>().TriggerUpdate();
        }
    }

    private void TranslateDrawText()
    {
        drawText.text = gameAPI.Translate(drawText.gameObject.name, gameAPI.ToSentenceCase(randomCards[0].title).Replace("-", " "), selectedLangCode);
        var shape = cachedShapeCards.cards.Where(card => card.slug == selectedShape.ToLower()).FirstOrDefault();

        drawText.text = drawText.text.Replace("$2", shape.title);

    }

}
