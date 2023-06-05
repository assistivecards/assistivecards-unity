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
    [SerializeField] Transform[] cardSlots;
    [SerializeField] Vector3[] originalCardSlots;
    [SerializeField] GameObject targetArea;
    [SerializeField] GameObject targetAreaGhost;
    [SerializeField] GameObject tutorial;
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
    Color original;
    private DragInsideUIController UIController;
    private GameObject loadingPanel;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#3E455B", out original);
        UIController = gameObject.GetComponent<DragInsideUIController>();
        gameAPI.PlayMusic();
        loadingPanel = GameObject.Find("LoadingPanel");

        for (int i = 0; i < cardSlots.Length; i++)
        {
            originalCardSlots[i] = cardSlots[i].localPosition;
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
        DisableLoadingPanel();
        RandomizeCardSlotPositions();
        ScaleImagesUp();
        backButton.SetActive(true);
        UIController.TutorialSetActive();
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

        for (int i = 0; i < cardParents.Length; i++)
        {
            cardParents[i].transform.SetParent(cardSlots[i]);
            cardParents[i].transform.position = cardSlots[i].position;
        }

        LeanTween.color(targetArea.transform.GetChild(0).GetComponent<Image>().rectTransform, original, .2f);

        targetArea.GetComponent<DragInsideMatchDetection>().cardsInside.Clear();
        targetArea.GetComponent<DragInsideMatchDetection>().correctCardsInside.Clear();
        targetArea.GetComponent<DragInsideMatchDetection>().wrongCardsInside.Clear();

        for (int i = 0; i < cardParents.Length; i++)
        {
            cardParents[i].GetComponent<DragInsideDraggableCard>().enabled = true;
            cardParents[i].GetComponent<DragInsideDraggableCard>().isAdded = false;
        }

    }

    public void ScaleImagesUp()
    {
        LeanTween.scale(dragText.gameObject, Vector3.one, 0.15f);
        LeanTween.scale(targetArea, Vector3.one, 0.15f);
        LeanTween.scale(targetAreaGhost, Vector3.one, 0.15f);

        for (int i = 0; i < cardParents.Length; i++)
        {
            LeanTween.scale(cardParents[i].gameObject, Vector3.one, 0.15f);
        }
    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(dragText.gameObject, Vector3.zero, 0.25f);

        for (int i = 0; i < cardParents.Length; i++)
        {
            LeanTween.scale(cardParents[i].gameObject, Vector3.zero, 0.25f);
        }
    }

    public void ScaleFrameDown()
    {
        LeanTween.scale(targetArea, Vector3.zero, 0.25f);
        LeanTween.scale(targetAreaGhost, Vector3.zero, 0.25f);
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
                tutorial.GetComponent<DragInsideTutorial>().point2 = cardImagesInScene[i].transform;
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

    public void ReadCard()
    {
        gameAPI.Speak(randomCards[0].title);
    }

    public void RandomizeCardSlotPositions()
    {
        for (int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].localPosition = new Vector2(originalCardSlots[i].x + Random.Range(-50, 50), originalCardSlots[i].y + Random.Range(-20, 20));
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
