using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Defective.JSON;

public class AllGamesPage : MonoBehaviour
{
    [SerializeField] private GameObject tempGameElement;
    public AssistiveCardsSDK.AssistiveCardsSDK.Games games = new AssistiveCardsSDK.AssistiveCardsSDK.Games();
    private GameObject gameElement;
    private GameObject selectedGameElement;
    public List<GameObject> gameElementGameObject = new List<GameObject>();
    private GameAPI gameAPI;
    public static bool didLanguageChange = false;
    private string appStoreURL = "itms-apps://apps.apple.com/tr/app/";
    private string playStoreURL = "market://details?id=com.assistivecards.";
    private Texture2D gameIcon;
    bool firstTime = true;

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
            gameElement = Instantiate(tempGameElement, transform);

            gameElement.transform.GetChild(0).GetComponent<TMP_Text>().text = gameAPI.ToTitleCase(jsonGamess["games"][i]["name"][currentLanguageCode].ToString().Replace("\"", ""));
            gameElement.transform.GetChild(1).GetComponent<TMP_Text>().text = jsonGamess["games"][i]["tagline"][currentLanguageCode].ToString().Replace("\"", "");
            // gameElement.transform.GetChild(2).GetComponent<TMP_Text>().text = jsonGamess["games"][i]["description"][currentLanguageCode].ToString().Replace("\"", "");
            // gameElement.transform.GetChild(2).GetComponent<TMP_Text>().text = jsonGamess["games"][i]["tagline"][currentLanguageCode].ToString().Replace("\"", "");

            if (!games.games[i].released)
            {
                gameElement.transform.GetChild(4).GetComponent<Image>().color = new Color32(255, 255, 255, 75);
            }

            gameIcon = gameAPI.twelveGameIcons[i];

            // var gameIcon = await gameAPI.GetGameIcon(games.games[i].slug);
            gameIcon.wrapMode = TextureWrapMode.Clamp;
            gameIcon.filterMode = FilterMode.Bilinear;

            gameElement.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = Sprite.Create(gameIcon, new Rect(0.0f, 0.0f, gameIcon.width, gameIcon.height), new Vector2(0.5f, 0.5f), 100.0f);

            gameElement.SetActive(true);


            gameElement.name = games.games[i].slug;

            gameElementGameObject.Add(gameElement);
            didLanguageChange = false;
        }

        await GameAPI.cacheData;

        for (int i = gameAPI.twelveGameIcons.Count; i < gameAPI.cachedGames.games.Count; i++)
        {
            gameElement = Instantiate(tempGameElement, transform);

            gameElement.transform.GetChild(0).GetComponent<TMP_Text>().text = gameAPI.ToTitleCase(jsonGamess["games"][i]["name"][currentLanguageCode].ToString().Replace("\"", ""));
            gameElement.transform.GetChild(1).GetComponent<TMP_Text>().text = jsonGamess["games"][i]["tagline"][currentLanguageCode].ToString().Replace("\"", "");
            // gameElement.transform.GetChild(2).GetComponent<TMP_Text>().text = jsonGamess["games"][i]["description"][currentLanguageCode].ToString().Replace("\"", "");
            // gameElement.transform.GetChild(2).GetComponent<TMP_Text>().text = jsonGamess["games"][i]["tagline"][currentLanguageCode].ToString().Replace("\"", "");

            if (!games.games[i].released)
            {
                gameElement.transform.GetChild(4).GetComponent<Image>().color = new Color32(255, 255, 255, 75);
            }

            gameIcon = gameAPI.cachedGameIcons[i - gameAPI.twelveGameIcons.Count];

            // var gameIcon = await gameAPI.GetGameIcon(games.games[i].slug);
            gameIcon.wrapMode = TextureWrapMode.Clamp;
            gameIcon.filterMode = FilterMode.Bilinear;

            gameElement.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = Sprite.Create(gameIcon, new Rect(0.0f, 0.0f, gameIcon.width, gameIcon.height), new Vector2(0.5f, 0.5f), 100.0f);

            gameElement.SetActive(true);


            gameElement.name = games.games[i].slug;

            gameElementGameObject.Add(gameElement);
            didLanguageChange = false;
        }
        // tempGameElement.SetActive(false);
        // didLanguageChange = false;
    }

    public void GameSelected(GameObject _GameElement)
    {
        selectedGameElement = _GameElement;

        foreach (var game in games.games)
        {
            if (game.slug == selectedGameElement.name && game.released)
            {
#if UNITY_IOS
                        Application.OpenURL(appStoreURL + game.storeId.appStore);
#endif
#if UNITY_ANDROID
                Application.OpenURL(playStoreURL + game.slug);
#endif
            }
        }
    }

}
