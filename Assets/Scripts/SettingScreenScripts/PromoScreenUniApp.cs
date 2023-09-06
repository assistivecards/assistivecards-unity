using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Defective.JSON;
using System;

public class PromoScreenUniApp : MonoBehaviour
{
    [SerializeField] private GameObject tempGameElement;
    public AssistiveCardsSDK.AssistiveCardsSDK.Games games = new AssistiveCardsSDK.AssistiveCardsSDK.Games();
    private GameObject gameElement;
    // private GameObject selectedAppElement;
    public List<GameObject> gameElementGameObject = new List<GameObject>();
    private GameAPI gameAPI;
    private Color bgColor;
    public static bool didLanguageChange = false;
    bool firstTime = true;
    private Texture2D gameIcon;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        ListGames();
        firstTime = false;
    }

    private void OnEnable()
    {
        if (didLanguageChange && !firstTime)
        {
            ListGames();
            didLanguageChange = false;

        }

    }

    public async void ListGames()
    {

        await GameAPI.cacheTwelveGameIcons;
        Debug.Log("didLanguageChange: " + didLanguageChange);
        var currentLanguageCode = await gameAPI.GetSystemLanguageCode();

        // tempGameElement.SetActive(true);

        if (gameElementGameObject.Count != 0)
        {
            foreach (var item in gameElementGameObject)
            {
                Destroy(item);
            }
            gameElementGameObject.Clear();
        }

        games = gameAPI.GetGames();
        var jsonGames = JsonUtility.ToJson(games);
        JSONObject jsonGamess = new JSONObject(jsonGames);


        for (int i = 0; i < gameAPI.twelveGameIcons.Count; i++)
        {
            if (games.games[i].released == false)
            {
                gameElement = Instantiate(tempGameElement, transform);

                ColorUtility.TryParseHtmlString(jsonGamess["games"][i]["color"].ToString().Replace("\"", ""), out bgColor);
                gameElement.GetComponent<Image>().color = bgColor;

                gameElement.transform.GetChild(0).GetComponent<TMP_Text>().text = gameAPI.ToTitleCase(jsonGamess["games"][i]["name"][currentLanguageCode].ToString().Replace("\"", ""));

                gameIcon = gameAPI.twelveGameIcons[i];

                // var gameIcon = await gameAPI.GetGameIcon(games.games[i].slug);
                gameIcon.wrapMode = TextureWrapMode.Clamp;
                gameIcon.filterMode = FilterMode.Bilinear;

                gameElement.transform.GetChild(2).GetComponent<Image>().sprite = Sprite.Create(gameIcon, new Rect(0.0f, 0.0f, gameIcon.width, gameIcon.height), new Vector2(0.5f, 0.5f), 100.0f);

                gameElement.SetActive(true);

                gameElement.name = games.games[i].slug;

                gameElementGameObject.Add(gameElement);
                didLanguageChange = false;
            }

        }

        await GameAPI.cacheData;

        for (int i = gameAPI.twelveGameIcons.Count; i < gameAPI.cachedGames.games.Count; i++)
        {
            if (games.games[i].released == false)
            {
                gameElement = Instantiate(tempGameElement, transform);

                ColorUtility.TryParseHtmlString(jsonGamess["games"][i]["color"].ToString().Replace("\"", ""), out bgColor);
                gameElement.GetComponent<Image>().color = bgColor;

                gameElement.transform.GetChild(0).GetComponent<TMP_Text>().text = gameAPI.ToTitleCase(jsonGamess["games"][i]["name"][currentLanguageCode].ToString().Replace("\"", ""));

                gameIcon = gameAPI.cachedGameIcons[i - gameAPI.twelveGameIcons.Count];

                // var gameIcon = await gameAPI.GetGameIcon(games.games[i].slug);
                gameIcon.wrapMode = TextureWrapMode.Clamp;
                gameIcon.filterMode = FilterMode.Bilinear;

                gameElement.transform.GetChild(2).GetComponent<Image>().sprite = Sprite.Create(gameIcon, new Rect(0.0f, 0.0f, gameIcon.width, gameIcon.height), new Vector2(0.5f, 0.5f), 100.0f);

                gameElement.SetActive(true);

                gameElement.name = games.games[i].slug;

                gameElementGameObject.Add(gameElement);
                didLanguageChange = false;
            }

        }

        tempGameElement.SetActive(false);
        // didLanguageChange = false;

    }
}
