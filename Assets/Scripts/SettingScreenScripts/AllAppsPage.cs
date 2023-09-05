using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Defective.JSON;

// public class App
// {
//     public string appName;
//     public string appSummary;
//     public string appDescription;
//     private Image appImage;

//     public App(string _appName, string _appSummary, string _appDescription)
//     {
//         appName = _appName;
//         appSummary = _appSummary;
//         appDescription = _appDescription;
//     }
// }

public class AllAppsPage : MonoBehaviour
{
    [SerializeField] private GameObject tempAppElement;
    public AssistiveCardsSDK.AssistiveCardsSDK.Apps apps = new AssistiveCardsSDK.AssistiveCardsSDK.Apps();
    private GameObject appElement;
    private GameObject selectedAppElement;
    public List<GameObject> appElementGameObject = new List<GameObject>();
    private GameAPI gameAPI;

    private string appStoreURL = "itms-apps://apps.apple.com/tr/app/";
    private string playStoreURL = "market://details?id=org.dreamoriented.";
    public static bool didLanguageChange = false;
    bool firstTime = true;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        ListApps();
        firstTime = false;
    }

    private void OnEnable()
    {
        if (didLanguageChange && !firstTime)
        {
            ListApps();
            didLanguageChange = false;
        }

    }

    public async void ListApps()
    {
        var currentLanguageCode = await gameAPI.GetSystemLanguageCode();

        // tempAppElement.SetActive(true);

        if (appElementGameObject.Count != 0)
        {
            foreach (var item in appElementGameObject)
            {
                Destroy(item);
            }
            appElementGameObject.Clear();
        }

        apps = await gameAPI.GetApps();
        var jsonApps = JsonUtility.ToJson(apps);
        JSONObject jsonAppss = new JSONObject(jsonApps);


        for (int i = 0; i < apps.apps.Count; i++)
        {
            appElement = Instantiate(tempAppElement, transform);

            appElement.transform.GetChild(0).GetComponent<TMP_Text>().text = jsonAppss["apps"][i]["name"].ToString().Replace("\"", "");
            appElement.transform.GetChild(1).GetComponent<TMP_Text>().text = jsonAppss["apps"][i]["tagline"][currentLanguageCode].ToString().Replace("\"", "");
            appElement.transform.GetChild(2).GetComponent<TMP_Text>().text = jsonAppss["apps"][i]["description"][currentLanguageCode].ToString().Replace("\"", "");

            var appIcon = gameAPI.cachedAppIcons[i];
            appIcon.wrapMode = TextureWrapMode.Clamp;
            appIcon.filterMode = FilterMode.Bilinear;

            appElement.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = Sprite.Create(appIcon, new Rect(0.0f, 0.0f, gameAPI.cachedAppIcons[i].width, gameAPI.cachedAppIcons[i].height), new Vector2(0.5f, 0.5f), 100.0f);

            appElement.SetActive(true);
            appElement.name = apps.apps[i].slug;

            appElementGameObject.Add(appElement);
        }
        // tempAppElement.SetActive(false);
    }

    public void AppSelected(GameObject _AppElement)
    {
        string appSlug;

        selectedAppElement = _AppElement;
        if (_AppElement.transform.GetChild(0).GetComponent<TMP_Text>().text.ToLower().Contains(' '))
        {
            appSlug = _AppElement.transform.GetChild(0).GetComponent<TMP_Text>().text.ToLower().Substring(0, _AppElement.transform.GetChild(0).GetComponent<TMP_Text>().text.ToLower().IndexOf(' '));
        }
        else
        {
            appSlug = _AppElement.transform.GetChild(0).GetComponent<TMP_Text>().text.ToLower();
        }

        foreach (var app in apps.apps)
        {
            if (app.slug == appSlug)
            {
#if UNITY_IOS
                Application.OpenURL(appStoreURL + app.storeId.appStore);
#endif
#if UNITY_ANDROID
                Application.OpenURL(playStoreURL + appSlug);
#endif
            }
        }
    }
}
