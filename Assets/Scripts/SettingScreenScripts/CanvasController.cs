using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Linq;



public class CanvasController : MonoBehaviour
{
    [Header("GAME CANVAS")]
    public GameObject gamePrefab;

    [Header("User Information")]
    public GameObject profileImage;
    public string nickname;
    [SerializeField] GameObject fadeInPanel;


    [Header("API Connection")]
    GameAPI gameAPI;

    [Header("UI Assets")]
    [SerializeField] private TMP_InputField nicknameInputField;
    public TMP_Text nicknameText;
    [SerializeField] Canvas canvas;
    [SerializeField] public GameObject popUp;
    private GameObject backButton;
    [SerializeField] private GameObject settingScreen;
    [SerializeField] private Image settingScreenFadePanel;
    [SerializeField] GameObject fadeOutPanel;
    [SerializeField] private TMP_Text versionText;

    [Header("Screens")]
    [SerializeField] private GameObject mainSettingsScreen;
    [SerializeField] private GameObject parentLockScreen;
    [SerializeField] private GameObject profileScreen;
    [SerializeField] private GameObject languageScreen;
    [SerializeField] private GameObject ttsScreen;
    [SerializeField] private GameObject notificationScreen;
    [SerializeField] private GameObject accessibilityScreen;
    [SerializeField] private GameObject subscriptionsScreen;
    [SerializeField] private GameObject subscriptionsScreenUniApp;
    [SerializeField] private GameObject allAppsScreen;
    [SerializeField] private GameObject allGamesScreen;
    [SerializeField] private GameObject promoScreen;
    [SerializeField] private GameObject promoScreenUniApp;
    [SerializeField] private GameObject sendFeedbacksScreen;
    [SerializeField] private GameObject aboutApplicationScreen;
    [SerializeField] private GameObject loginPageScreen;
    [SerializeField] private GameObject avatarSelectionScreen;
    [SerializeField] private GameObject soundScreen;

    [Header("Screen Prefab")]
    [SerializeField] private GameObject loginPrefab;
    [SerializeField] private GameObject settingPrefab;
    [SerializeField] private GameObject topAppBar;
    [SerializeField] private GameObject noInternetScreen;

    [Header("Classes")]
    [SerializeField] private OnboardingBackgroundController onboardingBackgroundController;
    private NotificationPreferences notificationPreferences;
    private AccessibilityScreen accessibilityScreenScript;
    private SoundManagerUI soundManagerUI;
    private TTSPanel tTSPanel;
    private LanguageController languageController;

    [Header("Misc")]
    private GameObject deviceLanguage;
    public GameObject currentScreen;
    private TopAppBarController topAppBarController;
    public string version;
    private bool loadScene = false;
    private Color settingsFillColor;


    private void Awake()
    {
        settingsFillColor = gameObject.GetComponent<Image>().color;
        gameAPI = Camera.main.GetComponent<GameAPI>();
        CheckConnection();
        nickname = gameAPI.GetNickname();
        topAppBarController = topAppBar.GetComponent<TopAppBarController>();

        if (PlayerPrefs.GetString("Nickname", "") != "")
        {
            settingsFillColor.a = 0f;
            loginPrefab.SetActive(false);
            loginPageScreen.SetActive(false);
            gamePrefab.SetActive(true);
            onboardingBackgroundController.BackgroundDisable();
        }
        else
        {
            settingsFillColor.a = 1f;
            gamePrefab.SetActive(false);
        }

        gameObject.GetComponent<Image>().color = settingsFillColor;
    }

    public async void CheckConnection()
    {
        AssistiveCardsSDK.AssistiveCardsSDK.Status status = new AssistiveCardsSDK.AssistiveCardsSDK.Status();
        status = await gameAPI.CheckConnectionStatus();
        if (status == null || status.status == false)
        {
            noInternetScreen.SetActive(true);
            Debug.Log("NO INTERNET");
            if (loadScene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("RELOAD SCENE");
            }
            loadScene = true;
        }
        else
        {
            if (loadScene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            noInternetScreen.SetActive(false);
            version = status.version;
            loadScene = false;
            Debug.Log("CONNECTION STATUS: " + status.versionCode);
        }

        versionText.text = "Version: " + version;
    }

    private void OnEnable()
    {
        topAppBarController.ChangeTopAppBarType(2);
        currentScreen = parentLockScreen;
    }

    private async void Start()
    {
        nicknameText.text = nickname;
        profileImage.GetComponent<Image>().sprite = await gameAPI.GetAvatarImage();
    }

    public void ParentLockButtonClick()
    {
        currentScreen = parentLockScreen;
        LeanTween.scale(popUp, Vector3.one, 0.15f);
        parentLockScreen.SetActive(true);
    }

    public void ParentLockScreenClose()
    {
        currentScreen = mainSettingsScreen;
        LeanTween.scale(popUp, Vector3.one * 0.15f, 0.2f);
        parentLockScreen.SetActive(false);
    }

    public void ProfileButtonClick()
    {
        topAppBarController.ChangeTopAppBarType(1);
        currentScreen = profileScreen;
        LeanTween.scale(profileScreen, Vector3.one, 0.2f);
        profileScreen.SetActive(true);
    }

    public void LanguageButtonClick()
    {
        topAppBarController.ChangeTopAppBarType(1);
        currentScreen = languageScreen;
        LeanTween.scale(languageScreen, Vector3.one, 0.2f);
        languageScreen.SetActive(true);
    }

    public void TTSButtonClicked()
    {
        topAppBarController.ChangeTopAppBarType(1);
        currentScreen = ttsScreen;
        LeanTween.scale(ttsScreen, Vector3.one, 0.2f);
        ttsScreen.SetActive(true);
    }

    public void NotificationButtonClick()
    {
        topAppBarController.ChangeTopAppBarType(1);
        currentScreen = notificationScreen;
        LeanTween.scale(notificationScreen, Vector3.one, 0.2f);
        notificationScreen.SetActive(true);
    }
    public void AccessibiltyButtonClick()
    {
        topAppBarController.ChangeTopAppBarType(1);
        currentScreen = accessibilityScreen;
        LeanTween.scale(accessibilityScreen, Vector3.one, 0.2f);
        accessibilityScreen.SetActive(true);
    }
    public void SubscriptionsButtonClick()
    {
        if (Application.productName == "Zumo")
        {
            topAppBarController.ChangeTopAppBarType(2);
            currentScreen = subscriptionsScreenUniApp;
            LeanTween.scale(subscriptionsScreenUniApp, Vector3.one, 0.2f);
            subscriptionsScreenUniApp.SetActive(true);
        }

        else
        {
            topAppBarController.ChangeTopAppBarType(2);
            currentScreen = subscriptionsScreen;
            LeanTween.scale(subscriptionsScreen, Vector3.one, 0.2f);
            subscriptionsScreen.SetActive(true);
        }

    }
    public void SoundButtonClick()
    {
        topAppBarController.ChangeTopAppBarType(1);
        currentScreen = soundScreen;
        LeanTween.scale(soundScreen, Vector3.one, 0.2f);
        soundScreen.SetActive(true);
    }

    public void AllAppsButtonClick()
    {
        topAppBarController.ChangeTopAppBarType(2);
        currentScreen = allAppsScreen;
        LeanTween.scale(allAppsScreen, Vector3.one, 0.2f);
        allAppsScreen.SetActive(true);
    }

    public void AllGamesButtonClick()
    {
        topAppBarController.ChangeTopAppBarType(2);
        currentScreen = allGamesScreen;
        LeanTween.scale(allGamesScreen, Vector3.one, 0.2f);
        allGamesScreen.SetActive(true);
    }

    public void PremiumPromoButtonClick()
    {
        if (Application.productName == "Zumo")
        {
            topAppBarController.ChangeTopAppBarType(2);
            currentScreen = promoScreenUniApp;
            LeanTween.scale(promoScreenUniApp, Vector3.one, 0.2f);
            promoScreenUniApp.SetActive(true);
        }

        else
        {
            topAppBarController.ChangeTopAppBarType(2);
            currentScreen = promoScreen;
            LeanTween.scale(promoScreen, Vector3.one, 0.2f);
            promoScreen.SetActive(true);
        }

    }
    public void SendFeedbacksButtonClick()
    {
        topAppBarController.ChangeTopAppBarType(2);
        currentScreen = sendFeedbacksScreen;
        LeanTween.scale(sendFeedbacksScreen, Vector3.one, 0.2f);
        sendFeedbacksScreen.SetActive(true);
    }
    public void AboutApplicationButtonClick()
    {
        topAppBarController.ChangeTopAppBarType(2);
        currentScreen = aboutApplicationScreen;
        LeanTween.scale(aboutApplicationScreen, Vector3.one, 0.2f);
        aboutApplicationScreen.SetActive(true);
    }
    public async void ProfilePanelUpdate()
    {
        nicknameText.text = gameAPI.GetNickname();
        profileImage.GetComponent<Image>().sprite = await gameAPI.GetAvatarImage();
    }

    public void CloseSettingClick()
    {
        currentScreen = parentLockScreen;
        topAppBarController.onMain = false;
        //Fade Out
        // settingScreenFadePanel.gameObject.SetActive(true);
        // settingScreenFadePanel.CrossFadeAlpha(1, 0.25f, false);
        // Invoke("OpenGamePanel", 0.1f);
        // StartFadeAnim();
        // Invoke("OpenGamePanel", 0.3f);
        OpenGamePanel();

    }
    private void OpenGamePanel()
    {
        // yield return new WaitForSeconds(0.3f);
        // settingPrefab.SetActive(false);
        // topAppBar.SetActive(false);
        // gamePrefab.SetActive(true);
        fadeOutPanel.SetActive(true);
        gamePrefab.SetActive(true);
        settingPrefab.SetActive(false);
        topAppBar.SetActive(false);

    }
    public void StartFade()
    {
        //Fade In
        // settingScreenFadePanel.CrossFadeAlpha(0, 0.25f, false);
        // Invoke("SetFadePanelFalse", 0.25f);
    }

    private void SetFadePanelFalse()
    {
        settingScreenFadePanel.gameObject.SetActive(false);
    }
    public void SignOut()
    {
        if (GameObject.FindObjectsOfType<GameObject>(true).Where(obj => obj.name == "LevelChangeScreen").FirstOrDefault().activeSelf)
        {
            GameObject.FindObjectsOfType<GameObject>(true).Where(obj => obj.name == "LevelChangeScreen").FirstOrDefault().SetActive(false);
        }

        gameAPI.ClearAllPrefs();

        notificationPreferences = notificationScreen.GetComponent<NotificationPreferences>();
        notificationPreferences.reminderPreference = gameAPI.GetReminderPreference();
        notificationPreferences.usabilityTipsToggle.isOn = gameAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        notificationPreferences.promotionsNotificationToggle.isOn = gameAPI.GetPromotionsNotificationPreference() == 1 ? true : false;

        accessibilityScreenScript = accessibilityScreen.GetComponent<AccessibilityScreen>();
        accessibilityScreenScript.hapticsToggle.isOn = gameAPI.GetHapticsPreference() == 1 ? true : false;
        accessibilityScreenScript.activateOnPressToggle.isOn = gameAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        accessibilityScreenScript.voiceGreetingToggle.isOn = gameAPI.GetVoiceGreetingPreference() == 1 ? true : false;

        soundManagerUI = this.GetComponent<SoundManagerUI>();

        soundManagerUI.musicToggle.isOn = gameAPI.GetMusicPreference() == 1 ? true : false;
        soundManagerUI.sfxToggle.isOn = gameAPI.GetSFXPreference() == 1 ? true : false;
        soundManagerUI.ttsStatusToggle.isOn = gameAPI.GetTTSStatusPreference() == 1 ? true : false;
        soundManagerUI.musicSource.mute = soundManagerUI.musicToggle.isOn ? false : true;
        soundManagerUI.sfxSource.mute = soundManagerUI.sfxToggle.isOn ? false : true;


        tTSPanel = ttsScreen.GetComponentInChildren<TTSPanel>();


        loginPrefab.SetActive(true);
        settingsFillColor.a = 1f;
        gameObject.GetComponent<Image>().color = settingsFillColor;
        loginPrefab.transform.GetChild(3).gameObject.SetActive(true);
        settingPrefab.SetActive(false);
        Camera.main.transform.GetChild(0).GetComponent<AudioSource>().Pause();
        topAppBar.SetActive(false);
        profileScreen.SetActive(false);
        loginPageScreen.GetComponent<LoginContoller>().nicknameInputField.text = "";
        loginPageScreen.SetActive(true);
        nicknameInputField.text = "";
        onboardingBackgroundController.BackgroundAvailable();
        languageController = languageScreen.GetComponent<LanguageController>();
        PlayerPrefs.SetString("Language", Application.systemLanguage.ToString());
        this.GetComponent<LanguageTest>().OnLanguageChange();
        gamePrefab.GetComponent<LanguageTest>().OnLanguageChange();
        // this.GetComponent<LanguageTest>().ChangeLanguage();
        TTSPanel.didLanguageChange = true;
        AllAppsPage.didLanguageChange = true;
        AllGamesPage.didLanguageChange = true;
        PackSelectionPanel.didLanguageChange = true;
        PromoScreen.didLanguageChange = true;
        PromoScreenUniApp.didLanguageChange = true;
        Board.isBackAfterSignOut = true;
        BoardGeneration.isBackAfterSignOut = true;
        SplitPuzzleBoardGenerator.isBackAfterSignOut = true;
        MatchPairsBoardGenerator.isBackAfterSignOut = true;
        DrawLinesBoardGenerator.isBackAfterSignOut = true;
        ScratcherBoardGenerator.isBackAfterSignOut = true;
        FingerPaintBoardGenerator.isBackAfterSignOut = true;
        PiecePuzzleBoardGenerator.isBackAfterSignOut = true;
        RopeCutBoardGenerator.isBackAfterSignOut = true;
        SlingBoardGenerator.isBackAfterSignOut = true;
        DragInsideBoardGenerator.isBackAfterSignOut = true;
        PressCardsBoardGenerator.isBackAfterSignOut = true;
        DrawShapesBoardGenerator.isBackAfterSignOut = true;
        StackCardsBoardGenerator.isBackAfterSignOut = true;
        CardWhackBoardGenerator.isBackAfterSignOut = true;
        FindCardBoardGenerator.isBackAfterSignOut = true;
        SizePuzzleBoardGenerator.isBackAfterSignOut = true;
        ChooseBoardGenerator.isBackAfterSignOut = true;
        AlphabetOrderBoardGenerator.isBackAfterSignOut = true;
        CardRumbleBoardGenerator.isBackAfterSignOut = true;
        ThrowCardsBoardGenerator.isBackAfterSignOut = true;
        CardGoalBoardGenerator.isBackAfterSignOut = true;
        CardMazeBoardGenerator.isBackAfterSignOut = true;
        GameSelectionPanel.didLanguageChange = true;

        if (notificationPreferences.reminderPreference == "Daily")
        {
            notificationPreferences.dailyReminderToggle.isOn = true;
        }
        else
        {
            notificationPreferences.weeklyReminderToggle.isOn = true;
        }
    }

    public void FadeInOnParentLockButtonClick()
    {
        fadeInPanel.SetActive(true);
        Invoke("CloseSettingClick", 0.3f);
        Invoke("ParentLockButtonClick", 0.3f);
    }
}
