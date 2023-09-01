using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
public class NeedleThreadBoardGenerator : MonoBehaviour
{
    GameAPI gameAPI;
    [Header ("Classes")]
    [SerializeField] private NeedleThreadUIController uıController;
    [SerializeField] private NeedleMovement needleMovement;
    [SerializeField] private NeedleDraggable needleDraggable;
    [SerializeField] private NeedleThreadTutorial tutorialScript;
    
    [Header ("Cache Cards")]
    public string selectedLangCode;
    public List<string> cardLocalNames = new List<string>();
    public List<GameObject> cards = new List<GameObject>();
    private AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedCards;
    [SerializeField] private List<AssistiveCardsSDK.AssistiveCardsSDK.Card> cardsList = new List<AssistiveCardsSDK.AssistiveCardsSDK.Card>();
    private List<string> cardNames = new List<string>();
    AssistiveCardsSDK.AssistiveCardsSDK.Cards cachedLocalCards;
    [SerializeField] private PackSelectionPanel packSelectionPanel;

    [Header ("Random")]
    public List<int> randomValueList = new List<int>();
    private int tempRandomValue;
    private int randomValue;

    [Header ("Prefabs")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject tutorial;

    [Header ("Game Elements")]
    [SerializeField] private GameObject cardPositionParent;
    [SerializeField] private GameObject needle;
    public List<GameObject> cardPositions = new List<GameObject>();
    public List<GameObject> targetCards = new List<GameObject>();
    [SerializeField] private TMP_Text collectText;

    [Header ("In Game Values")]
    public bool reloaded = false;
    public bool endLevel;
    public int matchCounter;
    public string targetCard;
    public string targetCardLocal;
    public bool gameStarted;
    public int reloadCount;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        gameAPI.PlayMusic();
    }

    public async Task CacheCards()
    {
        selectedLangCode = await gameAPI.GetSystemLanguageCode();

        cachedCards = await gameAPI.GetCards("en", packSelectionPanel.selectedPackElement.name);
        cachedLocalCards = await gameAPI.GetCards(selectedLangCode, packSelectionPanel.selectedPackElement.name);

        cardsList = cachedCards.cards.ToList();

        for(int i = 0; i < cachedCards.cards.Length; i++)
        {
            cardNames.Add(cachedCards.cards[i].title.ToLower().Replace(" ", "-"));
            cardLocalNames.Add(cachedLocalCards.cards[i].title);
        }
    }

    private void CheckRandom()
    {
        tempRandomValue = Random.Range(0, cardsList.Count);

        if(!randomValueList.Contains(tempRandomValue))
        {
            randomValue = tempRandomValue;
            randomValueList.Add(randomValue);
        }
        else
        {
            CheckRandom();
        }
    }

    private void CreatePositionsList()
    {
        foreach(Transform child in cardPositionParent.transform)
        {
            cardPositions.Add(child.gameObject);
        }
    }

    private GameObject CheckIsPositionEmpty()
    {
        int randomPositionIndex = Random.Range(0, cardPositions.Count - 1);
        if(cardPositions[randomPositionIndex].transform.childCount != 0)
        {
            randomPositionIndex += 1;
            if(cardPositions[randomPositionIndex].transform.childCount != 0)
            {
                return CheckIsPositionEmpty();
            }
            else
            {
                return cardPositions[randomPositionIndex];
            }
        }
        else
        {
            return cardPositions[randomPositionIndex];
        }
    }

    public async void GeneratedBoardAsync()
    {
        if(uıController.canGenerate)
        {
            await CacheCards();
            CheckRandom();
            CreatePositionsList();
            for(int j = 0; j < 11; j++)
            {
                CheckRandom();
                GameObject parent = CheckIsPositionEmpty();
                GameObject card = Instantiate(cardPrefab, parent.transform.position, Quaternion.identity, parent.transform);

                var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, cardNames[randomValueList[j]], 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = cardNames[randomValueList[j]];
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                LeanTween.scale(card, Vector3.one * 0.75f, 0);
                LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-30, 30)), 0f);
                card.gameObject.tag = "Card";
                card.GetComponent<NeedleCardName>().cardName = cardNames[randomValueList[j]];
                cards.Add(card);
            }
            CheckRandom();
            targetCard = cardNames[randomValueList[12]];
            targetCardLocal = cardLocalNames[randomValueList[12]];
            for(int i = 11; i < 20; i++)
            {
                GameObject parent = CheckIsPositionEmpty();
                GameObject card = Instantiate(cardPrefab, parent.transform.position, Quaternion.identity, parent.transform);

                var cardTexture = await gameAPI.GetCardImage(packSelectionPanel.selectedPackElement.name, targetCard, 512);
                cardTexture.wrapMode = TextureWrapMode.Clamp;
                cardTexture.filterMode = FilterMode.Bilinear;

                card.transform.name = targetCardLocal;
                card.transform.GetChild(0).GetComponent<RawImage>().texture = cardTexture;
                card.transform.GetChild(0).GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                LeanTween.scale(card, Vector3.one * 0.75f, 0);
                LeanTween.rotate(card, new Vector3(0, 0, Random.Range(-50, 50)), 0f);
                card.gameObject.tag = "Card";
                card.GetComponent<NeedleCardName>().cardName = targetCard;
                card.GetComponent<NeedleCardName>().cardLocalName = targetCardLocal;
                targetCards.Add(card);
                cards.Add(card);
            }
            tutorialScript.card = targetCards[0].transform;
            LeanTween.scale(needle, Vector3.one, 0.2f);
            needleMovement.trailRenderer.time = 100;
            needle.transform.position = Vector3.zero;
            Invoke("GameUIActivate", 0.1f);
            collectText.text = gameAPI.Translate(collectText.gameObject.name, gameAPI.ToSentenceCase(targetCardLocal).Replace("-", " "), selectedLangCode);
            LeanTween.scale(collectText.gameObject, Vector3.one, 0.2f);
            collectText.gameObject.SetActive(true);
            reloaded = false;
        }
    }

    public void GameUIActivate()
    {
        uıController.GameUIActivate();
        gameStarted = true;
    }


    public void CheckTargetCards()
    {
        endLevel = true;
        foreach(var card in targetCards)
        {
            if(card.GetComponent<NeedleCardName>().matched == false)
            {
                endLevel = false;
                break;
            }
        }

        if(endLevel && matchCounter >= targetCards.Count && !reloaded)
        {
            needleMovement.Drop();
            needleDraggable.MoveToCenter();
            ReloadLevel();
        }
    }

    public void ScaleDownCards()
    {
        if(endLevel && matchCounter >= targetCards.Count && !reloaded)
        {
            foreach (var card in cards)
            {
                LeanTween.scale(card, Vector3.zero, 0.2f);
            }
        }
    }

    private void ReloadLevel()
    {
        if(reloadCount < 4)
        {
            reloaded = true;
            reloadCount++;
            GeneratedBoardAsync();
            uıController.LoadingScreenActivation();
        }
        else if(reloadCount == 4)
        {
            uıController.Invoke("LevelChangeScreenActivate", 0.7f);
        }
        ClearBoard();
        endLevel = true;
    }

    public void ClearBoard()
    {
        collectText.gameObject.SetActive(false);
        needleMovement.trailRenderer.time = 0;
        LeanTween.scale(needle, Vector3.zero, 0f);
        foreach (var card in cards)
        {
            Destroy(card);
        }
        targetCards.Clear();
        cardNames.Clear();
        cardsList.Clear();
        cardLocalNames.Clear();
        cards.Clear();
        randomValueList.Clear();
        cardPositions.Clear();
        matchCounter = 0;
    }
}
