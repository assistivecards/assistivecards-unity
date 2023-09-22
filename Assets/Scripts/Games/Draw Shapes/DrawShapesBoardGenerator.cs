using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using PathCreation;

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
    public Image[] cardImagesInScene;
    [SerializeField] List<string> shapes;
    [SerializeField] List<GameObject> paths;
    public List<GameObject> randomPaths;
    public List<GameObject> pathsParents;
    private string selectedShape;
    public List<Transform> handles;
    public int correctCardIndex;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] DrawShapesDragHandle dragHandle;
    private bool isScreenSmall = false;
    private DrawShapesUIController UIController;
    private bool isScreenLarge = false;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<DrawShapesUIController>();
        if (Screen.width < 1000 || Screen.height < 1000)
            isScreenSmall = true;
        else
            isScreenSmall = false;

        if ((Screen.width == 2360 && Screen.height == 1640) || (Screen.width == 2732 && Screen.height == 2048) || (Screen.width == 2388 && Screen.height == 1668) || (Screen.width == 2224 && Screen.height == 1668))
        {
            isScreenLarge = true;
        }
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
        await PopulateRandomTextures();
        ChooseRandomPaths();
        TranslateDrawText();
        PlaceSprites();
        FindCorrectCardIndex();
        DisableLoadingPanel();
        ScalePathsUp();
        Invoke("TriggerUpdatePaths", .20f);
        Invoke("PlaceHandles", .25f);
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.5f);
        UIController.Invoke("TutorialActivate", 1);
    }

    public void ClearBoard()
    {
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();
        randomPaths.Clear();

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].sprite = null;
        }

    }

    public void ScaleImagesUp()
    {
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            LeanTween.alpha(cardImagesInScene[i].gameObject.GetComponent<RectTransform>(), 1f, .01f);
            LeanTween.scale(cardImagesInScene[i].gameObject, Vector3.one, 0.2f);
        }

        LeanTween.scale(drawText.gameObject, Vector3.one, 0.2f);

    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(drawText.gameObject, Vector3.zero, 0.2f);

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            LeanTween.scale(cardImagesInScene[i].gameObject, Vector3.zero, 0.2f);
            LeanTween.scale(pathsParents[i], Vector3.zero, .25f);
            LeanTween.scale(handles[i].gameObject, Vector3.zero, 0.25f);
        }

        Invoke("ResetWaypointColors", .25f);
        Invoke("DisablePathsAndHandles", .25f);

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
            // LeanTween.scale(pathsParents[i], Vector3.one, .15f);
            if (isScreenSmall)
                LeanTween.scale(pathsParents[i], Vector3.one * 1.25f, .15f);
            else if (isScreenLarge)
            {
                LeanTween.scale(pathsParents[i], Vector3.one * 0.9f, .15f);
            }
            else
                LeanTween.scale(pathsParents[i], Vector3.one, .15f);
            handles[i].SetParent(randomPaths[i].transform);
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

    private void PlaceHandles()
    {
        for (int i = 0; i < handles.Count; i++)
        {
            handles[i].position = randomPaths[i].GetComponent<PathCreator>().path.GetPoint(0);
            handles[i].gameObject.SetActive(true);
            if (isScreenSmall)
            {
                LeanTween.scale(handles[i].gameObject, Vector3.one * 0.45f, .15f);
            }
            else
                LeanTween.scale(handles[i].gameObject, Vector3.one * 0.5f, .15f);
            handles[i].gameObject.GetComponent<DrawShapesDragHandle>().enabled = true;
            handles[i].gameObject.GetComponent<DrawShapesMatchDetection>().isMatched = false; ;
            handles[i].GetComponent<CircleCollider2D>().enabled = true;
        }

        ScaleImagesUp();
    }

    private void FindCorrectCardIndex()
    {
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            if (cardImagesInScene[i].sprite.texture == randomImages[0])
            {
                correctCardIndex = i;

            }
        }
    }

    private void DisableLoadingPanel()
    {
        // if (loadingPanel.activeInHierarchy)
        // {
        loadingPanel.SetActive(false);
        // }
    }

    public void ResetWaypointColors()
    {
        for (int i = 0; i < randomPaths.Count; i++)
        {
            for (int j = 0; j < randomPaths[i].transform.GetChild(0).childCount; j++)
            {
                randomPaths[i].transform.GetChild(0).GetChild(j).GetComponent<Image>().color = dragHandle.waypointGrey;
            }
        }
    }

    public void DisablePathsAndHandles()
    {
        for (int i = 0; i < randomPaths.Count; i++)
        {
            randomPaths[i].SetActive(false);
            handles[i].gameObject.SetActive(false);
            handles[i].SetParent(GameObject.FindObjectsOfType<Transform>(true).Where(transform => transform.gameObject.name == "GamePanel").FirstOrDefault());
        }
    }

    public void ReadCard()
    {
        gameAPI.Speak(randomCards[0].title);
    }

}
