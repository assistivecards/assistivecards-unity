using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class StackCardsBoardGenerator : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomImages = new List<Texture2D>();
    [SerializeField] List<Sprite> randomSprites = new List<Sprite>();
    [SerializeField] List<Sprite> tempSprites = new List<Sprite>();
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] TMP_Text stackText;
    [SerializeField] string correctCardSlug;
    [SerializeField] Image[] fixedCardImagesInScene;
    [SerializeField] Image[] cardImagesInScene;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] GameObject[] assistiveCardsPlaceholders;
    [SerializeField] GameObject[] cardSlots;
    [SerializeField] StackCardsTutorial stackCardsTutorial;
    public GameObject[] stackParents;
    private StackCardsUIController UIController;


    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<StackCardsUIController>();
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
        stackCardsTutorial.ClearTutorial();
        if (didLanguageChange)
        {
            await CacheCards(packSlug);
            didLanguageChange = false;
        }

        PopulateRandomCards();
        TranslateStackCardsText();
        await PopulateRandomTextures();
        PopulateTempSprites();
        PlaceSprites();
        DisableLoadingPanel();
        ScaleImagesUp();
        UIController.TutorialSetActive();
        // backButton.SetActive(true);
        Invoke("EnableBackButton", 0.8f);
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
        for (int i = 0; i < stackParents.Length; i++)
        {
            LeanTween.scale(stackParents[i], Vector3.one, 0.001f);
        }
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            cardImagesInScene[i].transform.parent.rotation = Quaternion.Euler(0, 0, Random.Range(-30, -10));
            cardImagesInScene[i].transform.parent.SetParent(cardSlots[i].transform);
            cardImagesInScene[i].transform.parent.position = cardSlots[i].transform.position;
            cardImagesInScene[i].transform.parent.GetComponent<StackCardsDraggableCards>().enabled = true;
            cardImagesInScene[i].transform.parent.GetComponent<StackCardsMatchDetection>().numOfMatchedCards = 0;
            cardImagesInScene[i].transform.parent.GetComponent<StackCardsMatchDetection>().isMatched = false;
            cardImagesInScene[i].transform.parent.tag = "Untagged";
            stackCardsTutorial.slotList.Add(cardSlots[i]);
        }

        for (int i = 0; i < assistiveCardsPlaceholders.Length; i++)
        {
            LeanTween.scale(assistiveCardsPlaceholders[i], Vector3.one, 0.2f);
        }

        Invoke("ScaleFixedCardsUp", 0.3f);
        Invoke("ScaleCardsUp", 0.6f);

        LeanTween.scale(stackText.gameObject, Vector3.one, 0.2f);

    }

    public void ScaleImagesDown()
    {
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            if (cardImagesInScene[i].transform.parent.parent.name.StartsWith("CardSlot"))
            {
                LeanTween.scale(cardImagesInScene[i].transform.parent.gameObject, Vector3.zero, 0.25f);
            }
        }

        for (int i = 0; i < stackParents.Length; i++)
        {
            LeanTween.scale(stackParents[i], Vector3.zero, 0.25f);
        }

        Invoke("ScalePlaceholdersAndFixedCardsDown", 0.25f);

        LeanTween.scale(stackText.gameObject, Vector3.zero, 0.25f);
    }

    private void ScalePlaceholdersAndFixedCardsDown()
    {
        for (int i = 0; i < assistiveCardsPlaceholders.Length; i++)
        {
            LeanTween.scale(assistiveCardsPlaceholders[i], Vector3.zero, 0.001f);
            LeanTween.scale(fixedCardImagesInScene[i].transform.parent.gameObject, Vector3.zero, 0.001f);
        }
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
        backButton.SetActive(true);
        backButton.GetComponent<Button>().interactable = true;
    }

    public void TranslateStackCardsText()
    {
        stackText.text = gameAPI.Translate(stackText.gameObject.name, selectedLangCode);
    }

    public async Task PopulateRandomTextures()
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

    private void PopulateTempSprites()
    {

        for (int i = 0; i < 3; i++)
        {
            tempSprites.Add(randomSprites[i]);
        }

        for (int i = 3; i < cardImagesInScene.Length; i++)
        {
            var randomSpriteToAdd = randomSprites[Random.Range(0, randomSprites.Count)];
            tempSprites.Add(randomSpriteToAdd);
        }

    }

    public void PlaceSprites()
    {
        for (int i = 0; i < fixedCardImagesInScene.Length; i++)
        {
            fixedCardImagesInScene[i].sprite = randomSprites[i];
        }

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
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            var cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExists(cardToAdd);
        }

        correctCardSlug = randomCards[0].slug;
    }

    private void DisableLoadingPanel()
    {
        // if (loadingPanel.activeInHierarchy)
        // {
        loadingPanel.SetActive(false);
        // }
    }

    private void ScaleFixedCardsUp()
    {
        for (int i = 0; i < fixedCardImagesInScene.Length; i++)
        {
            LeanTween.scale(fixedCardImagesInScene[i].transform.parent.gameObject, Vector3.one, 0.2f);
        }
    }

    private void ScaleCardsUp()
    {
        // StartCoroutine("ScaleCardsUpCoroutine");

        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            LeanTween.scale(cardImagesInScene[i].transform.parent.gameObject, Vector3.one, 0.2f);
        }
    }

    private IEnumerator ScaleCardsUpCoroutine()
    {
        for (int i = 0; i < cardImagesInScene.Length; i++)
        {
            LeanTween.scale(cardImagesInScene[i].transform.parent.gameObject, Vector3.one, 0.2f);
            yield return new WaitForSeconds(0.05f);
        }
    }

}
