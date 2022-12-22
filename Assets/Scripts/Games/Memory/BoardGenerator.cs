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
    [SerializeField] private float cardSizes;
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
    private CheckMatches checkMatches;
    List<int> randomValueList = new List<int>();
    private void OnEnable()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        checkMatches = GetComponent<CheckMatches>();
    }

    public async Task CacheCards(string packName)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();
        cardTextures = await gameAPI.GetCards("en", packName);
        cardDefinitions = await gameAPI.GetCards(selectedLangCode, packName);
    }

    public async Task GenerateRandomBoardAsync(string packSlug)
    {
        await CacheCards(packSlug);
        Debug.Log(packSlug);
        for(int i = 0; i< cardTextures.cards.Length; i++)
        {
            cardNames.Add(cardTextures.cards[i].title.ToLower().Replace(" ", "-"));
            cardDefinitionsLocale.Add(cardDefinitions.cards[i].title);
        }

        for(int j = 0; j< cardNumber / 2; j++)
        {
            randomValue = Random.Range(0, cardTextures.cards.Length);
            if(randomValueList.Contains(randomValue))
            {
                randomValue = Random.Range(0, cardTextures.cards.Length);
            }
            else
            {
                randomValueList.Add(randomValue);
            }

            cardTexture = await gameAPI.GetCardImage(packSlug, cardNames[randomValue], 512);
            cards.Add(Instantiate(tempCardObject, Vector3.zero, Quaternion.identity));
            cards[j].transform.parent = this.transform;

            cards[j].transform.name = "Card" + j;
            cards[j].transform.GetChild(2).GetComponent<TMP_Text>().text= cardDefinitionsLocale[randomValue];
            cards[j].transform.GetChild(1).name = cardNames[randomValue];
            cards[j].transform.GetChild(1).GetComponent<RawImage>().texture = cardTexture;

            firstHalfCards.Add(cards[j]);
        }

        for(int y = 0; y < cardNumber / 2; y++)
        {
            cards.Add(Instantiate(firstHalfCards[y], Vector3.zero, Quaternion.identity));
            cards[(cardNumber/2) + y].transform.name = "Card" + ((cardNumber/2) + y);
            cards[(cardNumber/2) + y].transform.parent = this.transform;
        }

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
    }

    private void FadeOutTransitionScreen()
    {
        transitionScreen.GetComponent<Image>().CrossFadeAlpha(0, 1f, true);
        Invoke("CloseTransitionScreen", 1f);
    }

    private void CloseTransitionScreen()
    {
        transitionScreen.GetComponent<TransitionScreenManager>().loadingBar.value = 0;
        transitionScreen.SetActive(false);
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
        cards.Clear();
        firstHalfCards.Clear();
        randomValueList.Clear();
        checkMatches.flippedCards.Clear();
    }
    public void CheckClones()
    {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Card(Clone)");
        foreach(GameObject clone in objects)
        {
            Destroy(clone);
        }
    }
}
