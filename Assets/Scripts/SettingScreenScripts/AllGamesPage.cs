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
    public static bool didLanguageChange = true;
    private string appStoreURL = "itms-apps://apps.apple.com/tr/app/";
    private string playStoreURL = "market://details?id=com.assistivecards.";

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private async void OnEnable()
    {
        if (didLanguageChange)
        {
            var currentLanguageCode = await gameAPI.GetSystemLanguageCode();

            tempGameElement.SetActive(true);

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


            for (int i = 0; i < games.games.Count; i++)
            {
                gameElement = Instantiate(tempGameElement, transform);

                gameElement.transform.GetChild(0).GetComponent<TMP_Text>().text = jsonGamess["games"][i]["name"][currentLanguageCode].ToString().Replace("\"", "");
                // gameElement.transform.GetChild(1).GetComponent<TMP_Text>().text = jsonGamess["games"][i]["tagline"][currentLanguageCode].ToString().Replace("\"", "");
                // gameElement.transform.GetChild(2).GetComponent<TMP_Text>().text = jsonGamess["games"][i]["description"][currentLanguageCode].ToString().Replace("\"", "");
                gameElement.transform.GetChild(2).GetComponent<TMP_Text>().text = jsonGamess["games"][i]["tagline"][currentLanguageCode].ToString().Replace("\"", "");

                var gameIcon = gameAPI.cachedGameIcons[i];
                gameIcon.wrapMode = TextureWrapMode.Clamp;
                gameIcon.filterMode = FilterMode.Bilinear;

                gameElement.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = Sprite.Create(gameIcon, new Rect(0.0f, 0.0f, gameAPI.cachedGameIcons[i].width, gameAPI.cachedGameIcons[i].height), new Vector2(0.5f, 0.5f), 100.0f);

                gameElement.name = games.games[i].slug;

                gameElementGameObject.Add(gameElement);
            }
            tempGameElement.SetActive(false);
            didLanguageChange = false;
        }

    }

    public void GameSelected(GameObject _GameElement)
    {
        string gameSlug;

        selectedGameElement = _GameElement;

        if (_GameElement.transform.GetChild(0).GetComponent<TMP_Text>().text.ToLower().Contains(' '))
        {
            gameSlug = _GameElement.transform.GetChild(0).GetComponent<TMP_Text>().text.ToLower().Substring(0, _GameElement.transform.GetChild(0).GetComponent<TMP_Text>().text.ToLower().IndexOf(' '));
        }
        else
        {
            gameSlug = _GameElement.transform.GetChild(0).GetComponent<TMP_Text>().text.ToLower();
        }

        foreach (var game in games.games)
        {
            if (game.slug == gameSlug)
            {
#if UNITY_IOS
                Application.OpenURL(appStoreURL + app.storeId.appStore);
#endif
#if UNITY_ANDROID
                Application.OpenURL(playStoreURL + gameSlug);
#endif
            }
        }
    }

}
