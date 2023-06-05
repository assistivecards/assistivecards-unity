using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class RopeCutBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] SpriteRenderer[] cardImagesInScene;
    [SerializeField] GameObject[] anchorPoints;
    [SerializeField] GameObject[] cardParents;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomImages = new List<Texture2D>();
    [SerializeField] List<Sprite> randomSprites = new List<Sprite>();
    public string selectedLangCode;
    [SerializeField] string correctCardSlug;
    [SerializeField] TMP_Text cutText;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] GameObject ropeCutManager;
    [SerializeField] GameObject trailManager;
    [SerializeField] GameObject tutorial;
    private RopeCutUIController UIController;
    [SerializeField] GameObject loadingPanel;


    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = GameObject.Find("GamePanel").GetComponent<RopeCutUIController>();
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
        TranslateCutRopeText();
        await PopulateRandomTextures();
        AssignTags();
        PlaceSprites();
        DisableLoadingPanel();
        ScaleImagesUp();
        backButton.SetActive(true);
        UIController.TutorialSetActive();
        Invoke("EnableBackButton", 0.15f);
    }

    public void ClearBoard()
    {
        cutText.text = "";
        randomCards.Clear();
        randomImages.Clear();
        randomSprites.Clear();
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].sprite = null;
            Destroy(cardImagesInScene[i].transform.parent.GetComponent<HingeJoint2D>());
            cardImagesInScene[i].transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            // cardImagesInScene[i].transform.parent.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        var ropeClones = GameObject.FindGameObjectsWithTag("Rope");

        for (int i = 0; i < ropeClones.Length; i++)
        {
            Destroy(ropeClones[i]);
        }

        trailManager.transform.localPosition = new Vector2(-1000, -1000);

    }

    public void ScaleImagesUp()
    {
        LeanTween.scale(cutText.gameObject, Vector3.one, 0.2f);

        // for (int i = 0; i < cardParents.Length; i++)
        // {
        //     cardParents[i].GetComponent<Rigidbody2D>().isKinematic = false;
        // }

        for (int i = 0; i < anchorPoints.Length; i++)
        {
            LeanTween.scale(anchorPoints[i].gameObject, Vector3.one * 5, 0.2f);
            LeanTween.scale(cardParents[i].gameObject, Vector3.one * 10, 0.2f);
            // cardParents[i].GetComponent<Rigidbody2D>().isKinematic = false;
            anchorPoints[i].GetComponent<RopeGenerator>().GenerateRope();
            cardParents[i].GetComponent<BoxCollider2D>().enabled = true;

        }

        ropeCutManager.SetActive(true);
        trailManager.SetActive(true);
        ropeCutManager.GetComponent<RopeCutManager>().canCut = true;
        // LeanTween.alpha(trailManager, 1, .00001f);
        // trailManager.SetActive(true);

    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(cutText.gameObject, Vector3.zero, 0.2f);
        for (int i = 0; i < anchorPoints.Length; i++)
        {
            LeanTween.scale(anchorPoints[i].gameObject, Vector3.zero * 5, 0.2f);
            LeanTween.scale(cardParents[i].gameObject, Vector3.zero * 10, 0.2f);
            // anchorPoints[i].GetComponent<RopeGenerator>().enabled = false;
        }

        ropeCutManager.SetActive(false);
        trailManager.SetActive(false);
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
    public void ReadCard()
    {
        gameAPI.Speak(randomCards[0].title);
    }

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
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

    public void TranslateCutRopeText()
    {
        cutText.text = gameAPI.Translate(cutText.gameObject.name, gameAPI.ToSentenceCase(randomCards[0].title).Replace("-", " "), selectedLangCode);
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
                var randomIndex = Random.Range(1, randomSprites.Count);
                var sprite = randomSprites[randomIndex];
                randomSprites.RemoveAt(randomIndex);
                cardImagesInScene[i].sprite = sprite;
            }
        }
    }

    public void AssignTags()
    {
        var correctCardImageIndex = Random.Range(0, cardImagesInScene.Length);
        cardImagesInScene[correctCardImageIndex].sprite = randomSprites[0];

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            if (i != correctCardImageIndex)
                cardImagesInScene[i].transform.parent.tag = "WrongCard";
            else
                cardImagesInScene[correctCardImageIndex].transform.parent.tag = "CorrectCard";
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
