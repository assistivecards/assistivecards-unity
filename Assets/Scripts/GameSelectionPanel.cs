using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Defective.JSON;
using System;
using UnityEngine.SceneManagement;

public class GameSelectionPanel : MonoBehaviour
{
    [SerializeField] private GameObject tempGameElement;
    public AssistiveCardsSDK.AssistiveCardsSDK.Games games = new AssistiveCardsSDK.AssistiveCardsSDK.Games();
    private GameObject gameElement;
    public GameObject selectedGameElement;
    public List<GameObject> gameElementGameObject = new List<GameObject>();
    private GameAPI gameAPI;
    private Color bgColor;
    [SerializeField] string currentLanguageCode;
    public static bool didLanguageChange = false;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] GameObject gameSelectionPanel;
    public Color tempColor1;
    public Color tempColor2;
    public Color tempColor3;
    public Color tempColor4;

    [SerializeField] GameObject fadeInPanel;
    [SerializeField] GameObject settingButton;
    [SerializeField] CanvasController canvasController;
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
        loadingPanel.SetActive(false);
        currentLanguageCode = await gameAPI.GetSystemLanguageCode();

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

        tempGameElement.SetActive(true);

        for (int i = 0; i < gameAPI.twelveGameIcons.Count; i++)
        {
            gameElement = Instantiate(tempGameElement, transform);
            ColorUtility.TryParseHtmlString(jsonGamess["games"][i]["color"].ToString().Replace("\"", ""), out bgColor);
            gameElement.transform.GetChild(0).GetComponent<Image>().color = bgColor;

            for (int j = 0; j < gameElement.transform.GetChild(0).childCount; j++)
            {
                gameElement.transform.GetChild(0).GetChild(j).GetComponent<Image>().color = bgColor;
            }


            gameElement.transform.GetChild(3).GetComponent<Text>().text = gameAPI.ToSentenceCase(jsonGamess["games"][i]["name"][currentLanguageCode].ToString().Replace("\"", ""));
            var gameTexture = gameAPI.twelveGameIcons[i];
            gameTexture.wrapMode = TextureWrapMode.Clamp;
            gameTexture.filterMode = FilterMode.Bilinear;

            gameElement.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(gameTexture, new Rect(0.0f, 0.0f, gameAPI.twelveGameIcons[i].width, gameAPI.twelveGameIcons[i].height), new Vector2(0.5f, 0.5f), 100.0f);

            gameElement.name = games.games[i].slug;

            // gameElement.transform.GetChild(5).gameObject.SetActive(false);


            if (games.games[i].released == false)
            {
                gameElement.transform.GetChild(5).gameObject.SetActive(true);
            }

            gameElementGameObject.Add(gameElement);

        }
        tempGameElement.SetActive(false);

        Invoke("ScaleGameSelectionPanelUp", 0.25f);

        await GameAPI.cacheData;

        tempGameElement.SetActive(true);

        for (int i = gameAPI.twelveGameIcons.Count; i < gameAPI.cachedGames.games.Count; i++)
        {
            gameElement = Instantiate(tempGameElement, transform);
            ColorUtility.TryParseHtmlString(jsonGamess["games"][i]["color"].ToString().Replace("\"", ""), out bgColor);
            gameElement.transform.GetChild(0).GetComponent<Image>().color = bgColor;

            for (int j = 0; j < gameElement.transform.GetChild(0).childCount; j++)
            {
                gameElement.transform.GetChild(0).GetChild(j).GetComponent<Image>().color = bgColor;
            }


            gameElement.transform.GetChild(3).GetComponent<Text>().text = gameAPI.ToSentenceCase(jsonGamess["games"][i]["name"][currentLanguageCode].ToString().Replace("\"", ""));
            var gameTexture = gameAPI.cachedGameIcons[i - gameAPI.twelveGameIcons.Count];
            gameTexture.wrapMode = TextureWrapMode.Clamp;
            gameTexture.filterMode = FilterMode.Bilinear;

            gameElement.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(gameTexture, new Rect(0.0f, 0.0f, gameAPI.cachedGameIcons[i - gameAPI.twelveGameIcons.Count].width, gameAPI.cachedGameIcons[i - gameAPI.twelveGameIcons.Count].height), new Vector2(0.5f, 0.5f), 100.0f);

            gameElement.name = games.games[i].slug;

            // gameElement.transform.GetChild(5).gameObject.SetActive(true);

            if (games.games[i].released == false)
            {
                gameElement.transform.GetChild(5).gameObject.SetActive(true);
            }

            gameElementGameObject.Add(gameElement);

        }
        tempGameElement.SetActive(false);

        for (int i = gameAPI.twelveGameIcons.Count; i < gameElementGameObject.Count; i++)
        {
            var backgroundImage = gameElementGameObject[i].GetComponent<Image>();
            tempColor1 = backgroundImage.color;
            tempColor1.a = 0f;
            backgroundImage.color = tempColor1;

            var gameNameText = gameElementGameObject[i].transform.GetChild(3).GetComponent<Text>();
            tempColor2 = gameNameText.color;
            tempColor2.a = 0f;
            gameNameText.color = tempColor2;

            var gameImage = gameElementGameObject[i].transform.GetChild(1).GetComponent<Image>();
            tempColor3 = gameImage.color;
            tempColor3.a = 0f;
            gameImage.color = tempColor3;

            var premiumLabelBackGroundImage = gameElementGameObject[i].transform.GetChild(5).GetComponent<Image>();
            tempColor4 = premiumLabelBackGroundImage.color;
            tempColor4.a = 0f;
            premiumLabelBackGroundImage.color = tempColor4;

            var premiumLabelDiamondImage = gameElementGameObject[i].transform.GetChild(5).GetChild(0).GetComponent<Image>();
            premiumLabelDiamondImage.color = tempColor2;

            var premiumLabelText = gameElementGameObject[i].transform.GetChild(5).GetChild(1).GetComponent<Text>();
            premiumLabelText.color = tempColor2;

            gameElementGameObject[i].GetComponent<Button>().interactable = false;

        }

        for (int i = gameAPI.twelveGameIcons.Count; i < gameElementGameObject.Count; i++)
        {
            ColorUtility.TryParseHtmlString(jsonGamess["games"][i]["color"].ToString().Replace("\"", ""), out bgColor);
            LeanTween.color(gameElementGameObject[i].transform.GetChild(0).GetComponent<Image>().rectTransform, new Color(bgColor.r, bgColor.g, bgColor.b, 1), .5f);
            LeanTween.textAlpha(gameElementGameObject[i].transform.GetChild(3).GetComponent<Text>().rectTransform, 1, .5f);
            LeanTween.color(gameElementGameObject[i].transform.GetChild(1).GetComponent<Image>().rectTransform, new Color(tempColor3.r, tempColor3.g, tempColor3.b, 1), .5f);
            LeanTween.color(gameElementGameObject[i].transform.GetChild(5).GetComponent<Image>().rectTransform, new Color(tempColor4.r, tempColor4.g, tempColor4.b, 1), .5f);
            LeanTween.color(gameElementGameObject[i].transform.GetChild(5).GetChild(0).GetComponent<Image>().rectTransform, new Color(tempColor2.r, tempColor2.g, tempColor2.b, 1), .5f);
            LeanTween.textAlpha(gameElementGameObject[i].transform.GetChild(5).GetChild(1).GetComponent<Text>().rectTransform, 1, .5f);

            gameElementGameObject[i].GetComponent<Button>().interactable = true;

        }
    }

    public void GameSelected(GameObject _GameElement)
    {
        if (Input.touchCount == 1)
        {
            selectedGameElement = _GameElement;
            Debug.Log(_GameElement.name);

            if (gameAPI.GetPremium() == "A5515T1V3C4RD5" || gameAPI.GetSubscription() == "A5515T1V3C4RD5")
            {
                SceneManager.LoadScene(gameAPI.ToTitleCase(_GameElement.name.Replace("_", " ")));
            }

            else
            {
                for (int i = 0; i < gameAPI.cachedGames.games.Count; i++)
                {
                    if (gameAPI.cachedGames.games[i].slug == selectedGameElement.name)
                    {
                        if (gameAPI.cachedGames.games[i].released == false)
                        {
                            Debug.Log("Seçilen paket premium");
                            // canvasController.GetComponent<CanvasController>().StartFadeAnim();
                            fadeInPanel.SetActive(true);
                            settingButton.GetComponent<SettingScreenButton>().SettingButtonClickFunc();
                            canvasController.GetComponent<CanvasController>().PremiumPromoButtonClick();
                            Invoke("ResetScrollPosition", 0.3f);

                        }

                        else
                        {
                            SceneManager.LoadScene(gameAPI.ToTitleCase(_GameElement.name.Replace("_", " ")));
                        }

                    }
                }
            }
        }


    }

    public void ScaleGameSelectionPanelUp()
    {
        gameSelectionPanel.transform.GetChild(0).GetComponent<ScrollRect>().enabled = false;
        var rt = gameSelectionPanel.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(rt.offsetMax.x, 0);
        LeanTween.scale(gameSelectionPanel, Vector3.one, 0.15f);
        Invoke("EnableScrollRect", 0.15f);
    }

    public void EnableScrollRect()
    {
        gameSelectionPanel.transform.GetChild(0).GetComponent<ScrollRect>().enabled = true;
    }

    public void ResetScrollPosition()
    {
        var rt = gameSelectionPanel.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(rt.offsetMax.x, 0);
    }

}
