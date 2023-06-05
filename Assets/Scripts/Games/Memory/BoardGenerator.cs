using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardGenerator : MonoBehaviour
{
    [Header ("Virtual Changes")]
    public float cardSizes;
    public int cardNumber;

    [Header ("Objects")]
    GameAPI gameAPI;
    private GameObject clone;
    [SerializeField] private GameObject transitionScreen;
    [SerializeField] private GameObject tempCardObject;
    private List<GameObject> firstHalfCards = new List<GameObject>();
    public List<GameObject> cards = new List<GameObject>();
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cardTextures;
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cardDefinitions;
    private Texture2D cardTexture;
    public string selectedLangCode;
    private List<string> cardNames = new List<string>();
    private List<string> cardDefinitionsLocale = new List<string>();
    private int randomValue;
    private int randomValueTemp;
    private CheckMatches checkMatches;
    List<int> randomValueList = new List<int>();
    public bool isInGame = false;
    [SerializeField] private GamePanelUIController gamePanelUIController;

    private void OnEnable()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        checkMatches = GetComponent<CheckMatches>();
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();
        cardDefinitions = await gameAPI.GetCards(selectedLangCode, _packSlug);
        cardTextures = await gameAPI.GetCards("en", _packSlug);

        await GenerateRandomBoardAsync(_packSlug);
    }

    private void CheckRandom()
    {
        randomValueTemp = Random.Range(0, cardTextures.cards.Length);

        if(randomValueList.IndexOf(randomValueTemp) < 0)
        {
            randomValue = randomValueTemp;
            randomValueList.Add(randomValue);
            Debug.Log(randomValue);
        }
        else
        {
            Debug.Log("Repeated!");
            CheckRandom();
        }
    }

    public async Task GenerateRandomBoardAsync(string packSlug)
    {
        for(int i = 0; i< cardTextures.cards.Length; i++)
        {
            cardNames.Add(cardTextures.cards[i].title.ToLower().Replace(" ", "-"));
            cardDefinitionsLocale.Add(cardDefinitions.cards[i].title);
        }

        for(int j = 0; j< cardNumber / 2; j++)
        {
            CheckRandom();
            cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[randomValue], 512);
            cards.Add(Instantiate(tempCardObject, Vector3.zero, Quaternion.identity));
            cards[j].transform.parent = this.transform;

            cards[j].transform.name = "Card" + j;
            cards[j].transform.GetChild(2).GetComponent<TMP_Text>().text= cardDefinitionsLocale[randomValue];
            //cards[j].transform.GetChild(2).GetComponent<TMP_Text>().fontSize = 12;

            cards[j].transform.GetChild(1).name = cardNames[randomValue];
            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;
            cards[j].transform.GetChild(1).GetComponent<RawImage>().texture = cardTexture;

            firstHalfCards.Add(cards[j]);
        }

        for(int y = 0; y < cardNumber / 2; y++)
        {
            cards.Add(Instantiate(firstHalfCards[y], Vector3.zero, Quaternion.identity));
            cards[(cardNumber/2) + y].transform.name = "Card" + ((cardNumber/2) + y);
            cards[(cardNumber/2) + y].transform.parent = this.transform;
        }
        gamePanelUIController.TutorialSetActive();
        EditBoard();
    }

    private void EditBoard()
    {
        foreach(GameObject card in cards)
        {
            card.transform.SetSiblingIndex(Random.Range(0, cardNumber));
            card.transform.LeanRotateZ(180, 0f);
            card.transform.localScale = new Vector3(cardSizes, cardSizes,1);
        }

        FadeOutTransitionScreen();
        CheckClones();
        isInGame = true;
        gamePanelUIController.GamePanelUIControl();
    }

    private void FadeOutTransitionScreen()
    {
        transitionScreen.GetComponent<Image>().CrossFadeAlpha(0, 1f, true);
        Invoke("CloseTransitionScreen", 1f);
    }

    private void CloseTransitionScreen()
    {
        RepositioningBoard();

        LeanTween.scale(this.gameObject, Vector3.one, 0.15f);
        transitionScreen.SetActive(false);
    }

    private void RepositioningBoard()
    {
        this.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2 (100, 100);
        this.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2 (0, -118);
    }

    private void ResetPosition()
    {
        this.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2 (1000, 1000);
        this.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2 (1000, -1000);
    }

    public void FadeInTransitionScreen()
    {
        transitionScreen.SetActive(true);
        transitionScreen.GetComponent<Image>().CrossFadeAlpha(1, 0.5f, false);
    }


    public void ClearBoard()
    {
        foreach(GameObject card in GameObject.FindGameObjectsWithTag("MatchedCard"))
        {
            Destroy(card);
        }
        cards.Clear();
        firstHalfCards.Clear();
        randomValueList.Clear();
        checkMatches.flippedCards.Clear();
        ResetPosition();
    }

    public void ResetBoard()
    {
        foreach(GameObject card in GameObject.FindGameObjectsWithTag("MatchedCard"))
        {
            Destroy(card);
        }
        foreach(GameObject card in GameObject.FindGameObjectsWithTag("notMatchedCard"))
        {
            Destroy(card);
        }
        cardDefinitions = null;
        cardNames.Clear();
        cardDefinitionsLocale.Clear();
        cardTextures = null;
        cards.Clear();
        firstHalfCards.Clear();
        randomValueList.Clear();
        checkMatches.flippedCards.Clear();
        ResetPosition();
    }
    public void CheckClones()
    {
        var objects0 = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Card(Clone)");
        var objects1 = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Card1(Clone)");
        var objects2 = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Card2(Clone)");
        foreach(GameObject clone in objects0)
        {
            Destroy(clone);
        }
        foreach(GameObject clone in objects1)
        {
            Destroy(clone);
        }
        foreach(GameObject clone in objects2)
        {
            Destroy(clone);
        }
    }
}
