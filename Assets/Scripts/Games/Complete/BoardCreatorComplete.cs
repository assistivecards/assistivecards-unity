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
    [SerializeField] private GameObject cardPool;
    private List<string> cardNames = new List<string>();
    private List<string> cardDefinitionsLocale = new List<string>();

    private int tempRandomValue;
    private int randomValue;
    public List<int> randomValueList = new List<int>();
    public List<int> notUsedRandomValues = new List<int>();


    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject actualCardPrefab;
    public List<GameObject> cards  = new List<GameObject>();
    public List<GameObject> actualCards  = new List<GameObject>();
    [SerializeField] private Transform card1Position;
    [SerializeField] private Transform card2Position;
    public int cardCount;
    public string packSlug;
    public bool isBoardCreated = false;


    private void OnEnable()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async Task CacheCards(string _packSlug)
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();
        cardDefinitions = await gameAPI.GetCards(selectedLangCode, _packSlug);
        cardTextures = await gameAPI.GetCards("en", _packSlug);

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
            Debug.Log(randomValue);
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
        CreateRandomList();

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

            cards[j].transform.name = "Card" + j;

            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            cards[j].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            cards[j].transform.GetChild(0).GetComponent<RawImage>().color = Color.black;
            cards[j].GetComponent<CardElementComplete>().cardType = cardName;


            actualCards.Add(Instantiate(actualCardPrefab, Vector3.zero, Quaternion.identity));
            actualCards[j].transform.parent = cardPool.transform;

            actualCards[j].transform.name = "ActualCard" + j;

            cardTexture.wrapMode = TextureWrapMode.Clamp;
            cardTexture.filterMode = FilterMode.Bilinear;

            actualCards[j].transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
            actualCards[j].GetComponent<CardElementComplete>().cardType = cardName;
            actualCards[j].GetComponent<CardElementComplete>().moveable = true;
            actualCards[j].SetActive(false);
        }
        FillCardSlot();
        isBoardCreated = true;
    }

    public void FillCardSlot()
    {
        if(card1Position.GetComponent<CardSpawnerComplete>().hasChild == false)
        {
            var random = Random.Range(0, notUsedRandomValues.Count);
            var actualCard = actualCards[notUsedRandomValues[random]];

            if(actualCard == null)
            {
                random = Random.Range(0, notUsedRandomValues.Count);

                actualCard.SetActive(true);
                actualCard.transform.SetParent(card1Position);
                actualCard.transform.position = card1Position.position;
                notUsedRandomValues.RemoveAt(random);
            }
            else
            {
                actualCard.SetActive(true);
                actualCard.transform.SetParent(card1Position);
                actualCard.transform.position = card1Position.position;
                notUsedRandomValues.RemoveAt(random);
            }

        }
        if(card2Position.GetComponent<CardSpawnerComplete>().hasChild == false)
        {
            var random = Random.Range(0, notUsedRandomValues.Count);
            var actualCard = actualCards[notUsedRandomValues[random]];

            if(actualCard == null)
            {
                random = Random.Range(0, notUsedRandomValues.Count);

                actualCard.SetActive(true);
                actualCard.transform.SetParent(card2Position);
                actualCard.transform.position = card2Position.position;
                notUsedRandomValues.RemoveAt(random);
            }
            else
            {
                actualCard.SetActive(true);
                actualCard.transform.SetParent(card2Position);
                actualCard.transform.position = card2Position.position;
                notUsedRandomValues.RemoveAt(random);
            }
        }
    }

    private void CreateRandomList()
    {
        for(int i = 0; i < randomValueList.Count; i++)
        {
            notUsedRandomValues.Add(randomValueList[i]);
        }
    }
}
