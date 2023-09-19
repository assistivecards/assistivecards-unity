using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using PathCreation;

public class DrawLinesBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] Image cardToBeMatched;
    [SerializeField] List<Image> options = new List<Image>();
    [SerializeField] List<GameObject> pathGroup1;
    [SerializeField] List<GameObject> pathGroup2;
    [SerializeField] List<GameObject> pathGroup3;
    [SerializeField] List<Transform> handles;
    public List<GameObject> randomPaths;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    private AssistiveCardsSDK.AssistiveCardsSDK.Card cardToAdd;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomTextures = new List<Texture2D>();
    private List<Sprite> randomSprites = new List<Sprite>();
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    private DrawLinesUIController UIController;
    private string shownImageSlug;
    public int correctMatchIndex;
    [SerializeField] DragHandle dragHandle;
    private float refWidth = 1170;
    private float refHeight = 2532;
    [SerializeField] Canvas gameCanvas;
    private bool isScreenSmall = false;

    public TutorialDrawLines tutorialDrawLines;
    [SerializeField] GameObject loadingPanel;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<DrawLinesUIController>();
        if (Screen.width < 1000 || Screen.height < 1000)
            isScreenSmall = true;
        else
            isScreenSmall = false;

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
        await PopulateRandomTextures();
        ChooseRandomPaths();
        PlaceSprites();
        FindCorrectMatchIndex();
        DisableLoadingPanel();
        ScalePathsUp();
        Invoke("TriggerUpdatePaths", .15f);
        Invoke("PlaceHandles", .25f);
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.50f);
        UIController.TutorialActivate();
    }

    public void ClearBoard()
    {
        cardToAdd = null;
        randomCards.Clear();
        randomTextures.Clear();
        randomSprites.Clear();
        randomPaths.Clear();
        for (int i = 0; i < options.Count; i++)
        {
            options[i].sprite = null;
        }

    }

    public void ScalePathsUp()
    {
        if (isScreenSmall)
        {
            for (int i = 0; i < pathGroup1.Count; i++)
            {
                pathGroup1[i].transform.localPosition = new Vector3(pathGroup1[i].transform.localPosition.x, 50, 0);
                pathGroup2[i].transform.localPosition = new Vector3(40, pathGroup2[i].transform.localPosition.y, 0);
                pathGroup3[i].transform.localPosition = new Vector3(pathGroup3[i].transform.localPosition.x, -50, 0);
            }
        }

        for (int i = 0; i < randomPaths.Count; i++)
        {
            // LeanTween.scale(randomPaths[i], new Vector3((refHeight / Screen.width), (refWidth / Screen.height), 1), .15f);
            if (isScreenSmall)
                LeanTween.scale(randomPaths[i], Vector3.one * 1.3f, .15f);
            else
                LeanTween.scale(randomPaths[i], Vector3.one, .15f);
            handles[i].SetParent(randomPaths[i].transform);
        }

    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(cardToBeMatched.gameObject, Vector3.zero, .25f);
        for (int i = 0; i < options.Count; i++)
        {
            LeanTween.scale(options[i].gameObject, Vector3.zero, .25f);
            LeanTween.scale(randomPaths[i], Vector3.zero, .25f);
            LeanTween.scale(handles[i].gameObject, Vector3.zero, 0.25f);
        }
        Invoke("ResetWaypointColors", .25f);
        Invoke("DisablePathsAndHandles", .25f);
    }

    public void ReadCard()
    {
        gameAPI.Speak(randomCards[0].title);
    }

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
    }

    public void PlaceSprites()
    {
        cardToBeMatched.sprite = randomSprites[0];

        for (int i = 0; i < options.Count; i++)
        {
            if (options[i].sprite == null)
            {
                var randomIndex = Random.Range(0, randomSprites.Count);
                var sprite = randomSprites[randomIndex];
                randomSprites.RemoveAt(randomIndex);
                options[i].sprite = sprite;
            }
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

    public void ClearRandomCards()
    {
        randomCards.Clear();
    }

    public void PopulateRandomCards()
    {
        for (int i = 0; i < 3; i++)
        {
            cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
        }
        shownImageSlug = randomCards[0].slug;
    }

    public async Task PopulateRandomTextures()
    {
        for (int i = 0; i < randomCards.Count; i++)
        {
            var texture = await gameAPI.GetCardImage(packSlug, randomCards[i].slug);
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Bilinear;
            texture.name = randomCards[i].title;
            randomTextures.Add(texture);
            randomSprites.Add(Sprite.Create(randomTextures[i], new Rect(0.0f, 0.0f, randomTextures[i].width, randomTextures[i].height), new Vector2(0.5f, 0.5f), 100.0f));
        }
    }

    public void ChooseRandomPaths()
    {
        randomPaths.Add(pathGroup1[Random.Range(0, pathGroup1.Count)]);
        randomPaths.Add(pathGroup2[Random.Range(0, pathGroup2.Count)]);
        randomPaths.Add(pathGroup3[Random.Range(0, pathGroup3.Count)]);
        for (int i = 0; i < randomPaths.Count; i++)
        {
            // randomPaths[i].transform.localScale = Vector3.zero;
            randomPaths[i].SetActive(true);
            // randomPaths[i].GetComponent<PathCreator>().bezierPath.NotifyPathModified();

        }
    }

    public void PlaceHandles()
    {
        for (int i = 0; i < handles.Count; i++)
        {
            handles[i].position = randomPaths[i].GetComponent<PathCreator>().path.GetPoint(0);
            handles[i].gameObject.SetActive(true);
            LeanTween.scale(handles[i].gameObject, Vector3.one * 0.5f, .15f);
            handles[i].gameObject.GetComponent<DragHandle>().enabled = true;
        }

        ScaleOptionsUp();
    }

    public void DisablePathsAndHandles()
    {
        for (int i = 0; i < randomPaths.Count; i++)
        {
            randomPaths[i].SetActive(false);
            handles[i].gameObject.SetActive(false);
            handles[i].SetParent(GameObject.Find("GamePanel").transform);
        }
    }

    public void TriggerUpdatePaths()
    {
        for (int i = 0; i < randomPaths.Count; i++)
        {
            randomPaths[i].GetComponent<PathCreation.Examples.PathPlacer>().TriggerUpdate();
        }
    }

    public void FindCorrectMatchIndex()
    {
        for (int i = 0; i < options.Count; i++)
        {
            if (options[i].sprite == cardToBeMatched.sprite)
            {
                correctMatchIndex = i;
                tutorialDrawLines.targetPosition = options[i].transform;

            }
        }
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

    public void ScaleOptionsUp()
    {
        cardToBeMatched.transform.position = new Vector3(handles[0].position.x, cardToBeMatched.transform.position.y, 0);
        float xPos = Mathf.Abs(cardToBeMatched.transform.localPosition.x);
        LeanTween.scale(cardToBeMatched.gameObject, Vector3.one, .15f);
        for (int i = 0; i < options.Count; i++)
        {
            options[i].transform.localPosition = new Vector3(xPos, options[i].transform.localPosition.y, options[i].transform.localPosition.z);
            LeanTween.alpha(options[i].gameObject.GetComponent<RectTransform>(), 1f, .01f);
            LeanTween.scale(options[i].gameObject, Vector3.one, .15f);
        }
    }

    private void DisableLoadingPanel()
    {
        // if (loadingPanel.activeInHierarchy)
        // {
        loadingPanel.SetActive(false);
        // }
    }

}
