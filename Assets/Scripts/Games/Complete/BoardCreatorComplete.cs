using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BoardCreatorComplete : MonoBehaviour
{
    GameAPI gameAPI;
    public string selectedLangCode;

    AssistiveCardsSDK.AssistiveCardsSDK.Cards cardDefinitions;
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Cards cardTextures;
    [SerializeField] private UIControllerComplete uıControllerComplete;
    [SerializeField] private TutorialComplete tutorialComplete;
    [SerializeField] private GameObject cardPool;

    private int tempRandomValue;
    private int randomValue;

    private List<string> cardNames = new List<string>();
    private List<string> cardDefinitionsLocale = new List<string>();

    public List<int> randomValueList = new List<int>();
    public List<int> usedRandomValues = new List<int>();


    public List<GameObject> cards  = new List<GameObject>();
    public List<GameObject> actualCards  = new List<GameObject>();

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject gridBackground;
    [SerializeField] private GameObject actualCardPrefab;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private Transform card1Position;
    [SerializeField] private Transform card2Position;

    public int cardCount;
    public string packSlug;
    public bool isBoardCreated = false;
    public bool levelEnded;
    public int matchCount;

    [SerializeField] private Color dark;
    private bool oneTime;


    private void OnEnable()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards(string _packSlug)
    {
        uıControllerComplete.LoadingScreenActivate();
        LeanTween.scale(gridBackground, Vector3.one, 0);
        selectedLangCode = await gameAPI.GetSystemLanguageCode();
        cardDefinitions = await gameAPI.GetCards(selectedLangCode, _packSlug);
        cardTextures = await gameAPI.GetCards("en", _packSlug);
        gridBackground.SetActive(true);
        await GenerateRandomBoardAsync(_packSlug);
        packSlug = _packSlug;
    }

    private void CheckRandom()
    {
        tempRandomValue = Random.Range(0, cardTextures.cards.Length);

        if(randomValueList.IndexOf(tempRandomValue) < 0)
        {
            randomValue = tempRandomValue;
            randomValueList.Add(randomValue);
        }
        else
        {
            CheckRandom();
        }
    }

    public async Task GenerateRandomBoardAsync(string packSlug)
    {
        for(int x = 0; x < cardCount; x++)
        {
            CheckRandom();
        }

        for(int i = 0; i< cardTextures.cards.Length; i++)
        {
            cardNames.Add(cardTextures.cards[i].title.ToLower().Replace(" ", "-"));
            cardDefinitionsLocale.Add(cardDefinitions.cards[i].title);
        }

        for(int j = 0; j < cardCount; j++)
        {
            var cardName = cardNames[randomValueList[j]];
            var cardTexture = await gameAPI.GetCardImage(packSlug, cardName, 512);

            cards.Add(Instantiate(cardPrefab, Vector3.zero, Quaternion.identity));
            cards[j].transform.parent = this.transform;
            LeanTween.scale(cards[j], Vector3.one * 1.18f, 0);

            cards[j].transform.name = "Card" + j;

            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            cards[j].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            cards[j].transform.GetChild(0).GetComponent<RawImage>().color = dark;
            cards[j].GetComponent<CardElementComplete>().cardType = cardName;


            actualCards.Add(Instantiate(actualCardPrefab, Vector3.zero, Quaternion.identity));
            actualCards[j].transform.parent = cardPool.transform;

            actualCards[j].transform.name = "ActualCard" + j;

            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            actualCards[j].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            actualCards[j].GetComponent<CardElementComplete>().cardType = cardName;
            actualCards[j].GetComponent<CardElementComplete>().moveable = true;
            actualCards[j].GetComponent<CardElementComplete>().localName = cardDefinitionsLocale[randomValueList[j]];
            actualCards[j].SetActive(false);
        }
        Invoke("FillCardSlot", 0.5f);
        isBoardCreated = true;
        oneTime = true;
        uıControllerComplete.LoadingScreenDeactivate();
    }

    public void CheckChilds()
    {
        card1Position.GetComponent<CardSpawnerComplete>().CheckChild();
        card2Position.GetComponent<CardSpawnerComplete>().CheckChild();
    }

    public void FillCardSlot()
    {
        if(usedRandomValues.Count < 12 && !levelEnded)
        {
            if(card1Position.GetComponent<CardSpawnerComplete>().hasChild == false)
            {
                var random = UnityEngine.Random.Range(0, 12);
                while(usedRandomValues.Contains(random))
                {
                    random = UnityEngine.Random.Range(0, 12);
                }
                usedRandomValues.Add(random);
                var actualCard = actualCards[random];

                if(actualCard == null)
                {
                    random = Random.Range(0, 12);

                    actualCard.SetActive(true);
                    actualCard.transform.position = card1Position.position;
                    LeanTween.scale(actualCard, Vector3.one * 5, 0.8f);
                    actualCard.transform.SetParent(card1Position);
                }
                else
                {
                    actualCard.SetActive(true);
                    actualCard.transform.position = card1Position.position;
                    actualCard.GetComponent<CardElementComplete>().startPosition = card1Position.position;
                    LeanTween.scale(actualCard, Vector3.one * 5, 0.8f);
                    actualCard.transform.SetParent(card1Position);
                }

            }
            if(card2Position.GetComponent<CardSpawnerComplete>().hasChild == false)
            {
                var random = UnityEngine.Random.Range(0, 12);
                while(usedRandomValues.Contains(random))
                {
                    random = UnityEngine.Random.Range(0, 12);
                }
                usedRandomValues.Add(random);
                var actualCard = actualCards[random];

                if(actualCard == null)
                {
                    random = UnityEngine.Random.Range(0, 12);

                    actualCard.SetActive(true);
                    actualCard.transform.position = card2Position.position;
                    LeanTween.scale(actualCard, Vector3.one * 5, 0.8f);
                    actualCard.transform.SetParent(card2Position);
                }
                else
                {
                    actualCard.SetActive(true);
                    actualCard.transform.position = card2Position.position;
                    actualCard.GetComponent<CardElementComplete>().startPosition = card2Position.position;
                    LeanTween.scale(actualCard, Vector3.one * 5, 0.8f);
                    actualCard.transform.SetParent(card2Position);
                }
            }
        }

        if(oneTime)
        {
            uıControllerComplete.TutorialSetActive(tutorial);
            tutorialComplete.DetectDestination();
            oneTime = false;
        }
    }

    public void ResetLevel()
    {
        foreach (var card in cards)
        {
            Destroy(card);
        }
        foreach (var card in actualCards)
        {
            Destroy(card);
        }
        cardNames.Clear();
        randomValueList.Clear();
        usedRandomValues.Clear();
        cardDefinitionsLocale.Clear();
        cards.Clear();
        actualCards.Clear();
        matchCount = 0;
    }

    public void  EndLevel()
    {
        if(matchCount >= 12)
        {
            gameAPI.PlaySFX("Finished");
            gameAPI.AddExp(gameAPI.sessionExp);
            uıControllerComplete.LevelEnd();
            ResetLevel();
        }
    }

    public void BoardCreatedFalse()
    {
        isBoardCreated = false;
    }
}
