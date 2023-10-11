using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MatchPairsBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    private AssistiveCardsSDK.AssistiveCardsSDK.Card cardToAdd;
    List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    List<AssistiveCardsSDK.AssistiveCardsSDK.Card> prefetchedRandomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    List<Texture2D> randomTextures = new List<Texture2D>();
    List<Texture2D> prefetchedRandomImages = new List<Texture2D>();
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    public GameObject[] puzzlePieceParents;
    [SerializeField] GameObject[] puzzlePieceSlots;
    [SerializeField] List<Image> pieceImages = new List<Image>();
    private List<Sprite> pieceSprites = new List<Sprite>();
    private MatchPairsUIController UIController;
    [SerializeField] GameObject loadingPanel;
    private MatchPairsLevelProgressChecker progressChecker;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        gameAPI.PlayMusic();
        UIController = gameObject.GetComponent<MatchPairsUIController>();
        progressChecker = gameObject.GetComponent<MatchPairsLevelProgressChecker>();
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
        DivideTextures();
        PlaceIntoSlots();
        DisableLoadingPanel();
        ScaleImagesUp();
        RoundCardCorners();
        DestroyTempParents();
        backButton.SetActive(true);
        UIController.TutorialSetActive();
        Invoke("EnableBackButton", 0.15f);
        await PrefetchNextLevelsTexturesAsync();
    }

    private static void DestroyTempParents()
    {
        var tempParents = GameObject.FindGameObjectsWithTag("Temp");
        for (int i = 0; i < tempParents.Length; i++)
        {
            Destroy(tempParents[i]);
        }
    }

    private void RoundCardCorners()
    {
        for (int i = 0; i < puzzlePieceParents.Length; i++)
        {
            puzzlePieceParents[i].GetComponent<MatchPairsRoundedBackground>().DetermineCornerRoundness();
        }
    }

    private void DivideTextures()
    {
        if (progressChecker.levelsCompleted == 0)
        {
            for (int i = 0; i < randomTextures.Count; i++)
            {
                Divide(randomTextures[i], randomTextures[i].name);
            }
        }
        else
        {
            for (int i = 0; i < prefetchedRandomImages.Count; i++)
            {
                Divide(prefetchedRandomImages[i], prefetchedRandomImages[i].name);
            }
        }

    }

    public void ClearBoard()
    {
        cardToAdd = null;
        pieceSprites.Clear();
        randomCards.Clear();
        randomTextures.Clear();
        for (int i = 0; i < pieceImages.Count; i++)
        {
            pieceImages[i].sprite = null;
        }
    }

    public void ScaleImagesUp()
    {
        for (int i = 0; i < puzzlePieceSlots.Length; i++)
        {
            puzzlePieceParents[i].transform.SetParent(puzzlePieceSlots[i].transform);
            puzzlePieceParents[i].transform.position = puzzlePieceSlots[i].transform.position;
            puzzlePieceParents[i].GetComponent<MatchPairsDraggablePiece>().enabled = true;
            var boxColliders = puzzlePieceParents[i].GetComponents<BoxCollider2D>();
            foreach (var collider in boxColliders)
            {
                if (collider.size.x == 75)
                    collider.isTrigger = false;
            }
            // if (puzzlePieceParents[i].transform.GetChild(1).name.Contains("0"))
            // {
            //     puzzlePieceParents[i].transform.rotation = Quaternion.Euler(0, 0, Random.Range(5, 25));
            // }
            // else if (puzzlePieceParents[i].transform.GetChild(1).name.Contains("1"))
            // {
            //     puzzlePieceParents[i].transform.rotation = Quaternion.Euler(0, 0, Random.Range(-25, -5));
            // }

            puzzlePieceParents[i].transform.rotation = Quaternion.Euler(0, 0, Random.Range(-25, 25));


        }

        for (int i = 0; i < puzzlePieceParents.Length; i++)
        {
            LeanTween.scale(puzzlePieceParents[i], Vector3.one, 0.15f);
            puzzlePieceParents[i].GetComponent<MatchPairsMatchDetection>().isMatched = false;
        }
    }

    public void ScaleImagesDown()
    {
        for (int i = 0; i < puzzlePieceParents.Length; i++)
        {
            if (puzzlePieceParents[i].transform.parent.name != "TempParent(Clone)")
            {
                LeanTween.scale(puzzlePieceParents[i], Vector3.zero, .15f);
            }
            else
                LeanTween.scale(puzzlePieceParents[i].transform.parent.gameObject, Vector3.zero, .15f);

        }

    }

    public void ReadCard(string cardName)
    {
        gameAPI.Speak(cardName);
    }

    public void EnableBackButton()
    {
        backButton.GetComponent<Button>().interactable = true;
    }

    public void Divide(Texture2D texture, string name)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                Sprite newSprite = Sprite.Create(texture, new Rect(i * 128, j * 128, 128, 256), new Vector2(0.5f, 0.5f));
                newSprite.name = name + i;
                pieceSprites.Add(newSprite);
            }
        }
    }

    public void PlaceIntoSlots()
    {
        for (int i = 0; i < pieceImages.Count; i++)
        {
            if (pieceImages[i].sprite == null)
            {
                var randomIndex = Random.Range(0, pieceSprites.Count);
                var sprite = pieceSprites[randomIndex];
                pieceSprites.RemoveAt(randomIndex);
                pieceImages[i].sprite = sprite;
                pieceImages[i].name = sprite.name;
            }
        }
    }

    public void CheckIfCardExists(AssistiveCardsSDK.AssistiveCardsSDK.Card cardToAdd)
    {
        if (!randomCards.Contains(cardToAdd))
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
        if (!prefetchedRandomCards.Contains(prefetchedCardToAdd))
        {
            prefetchedRandomCards.Add(prefetchedCardToAdd);
        }
        else
        {
            prefetchedCardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExistsPrefetch(prefetchedCardToAdd);
        }
    }

    public void ClearRandomCards()
    {
        randomCards.Clear();
    }

    public void PopulateRandomCards()
    {
        if (progressChecker.levelsCompleted == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                cardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
                CheckIfCardExists(cardToAdd);
            }
        }

    }

    public async Task PopulateRandomTextures()
    {
        if (progressChecker.levelsCompleted == 0)
        {
            for (int i = 0; i < randomCards.Count; i++)
            {
                var texture = await gameAPI.GetCardImage(packSlug, randomCards[i].slug);
                texture.wrapMode = TextureWrapMode.Clamp;
                texture.filterMode = FilterMode.Bilinear;
                texture.name = randomCards[i].title;
                randomTextures.Add(texture);
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

    private async Task PrefetchNextLevelsTexturesAsync()
    {
        prefetchedRandomCards.Clear();
        prefetchedRandomImages.Clear();

        for (int i = 0; i < 3; i++)
        {
            var prefetchedCardToAdd = cachedCards.cards[Random.Range(0, cachedCards.cards.Length)];
            CheckIfCardExistsPrefetch(prefetchedCardToAdd);

            var texture = await gameAPI.GetCardImage(packSlug, prefetchedRandomCards[i].slug);
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Bilinear;
            texture.name = prefetchedRandomCards[i].title;
            prefetchedRandomImages.Add(texture);

        }

    }
}
