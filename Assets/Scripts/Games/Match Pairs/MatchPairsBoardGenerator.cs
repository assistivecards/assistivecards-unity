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
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Card> randomCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    [SerializeField] List<Texture2D> randomTextures = new List<Texture2D>();
    public string selectedLangCode;
    public string packSlug;
    [SerializeField] GameObject backButton;
    public static bool didLanguageChange = true;
    public static bool isBackAfterSignOut = false;
    [SerializeField] GameObject[] puzzlePieceParents;
    [SerializeField] GameObject[] puzzlePieceSlots;
    [SerializeField] List<Image> pieceImages = new List<Image>();
    private List<Sprite> pieceSprites = new List<Sprite>();

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

        for (int i = 0; i < randomTextures.Count; i++)
        {
            Divide(randomTextures[i], randomTextures[i].name);
        }

        PlaceIntoSlots();
        ScaleImagesUp();
        backButton.SetActive(true);
        Invoke("EnableBackButton", 0.15f);
    }

    public void ClearBoard()
    {
        cardToAdd = null;
        // randomImage = null;
        pieceSprites.Clear();
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
            if (puzzlePieceParents[i].transform.GetChild(1).name.Contains("0"))
            {
                puzzlePieceParents[i].transform.rotation = Quaternion.Euler(0, 0, Random.Range(5, 25));
            }
            else if (puzzlePieceParents[i].transform.GetChild(1).name.Contains("1"))
            {
                puzzlePieceParents[i].transform.rotation = Quaternion.Euler(0, 0, Random.Range(-25, -5));
            }


        }

        for (int i = 0; i < puzzlePieceParents.Length; i++)
        {
            LeanTween.scale(puzzlePieceParents[i], Vector3.one, 0.15f);
        }
    }

    public void ScaleImagesDown()
    {

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
    }

    public async Task PopulateRandomTextures()
    {
        for (int i = 0; i < randomCards.Count; i++)
        {
            var texture = await gameAPI.GetCardImage(packSlug, randomCards[i].slug);
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Bilinear;
            texture.name = randomCards[i].slug;
            randomTextures.Add(texture);
        }
    }
}
