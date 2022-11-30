using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class CanvasController : MonoBehaviour
{
    [Header ("User Information")]
    public GameObject profileImage;
    public string nickname;


    [Header ("API Connection")]
    GameAPI gameAPI;

    [Header ("UI Assets")]
    [SerializeField] private TMP_InputField nicknameInputField;
    public TMP_Text nicknameText;
    [SerializeField] Canvas canvas;
    [SerializeField] private GameObject popUp;
    private GameObject backButton;
    [SerializeField] private GameObject settingScreen;

    [Header ("Screens")]
    [SerializeField] private GameObject mainSettingsScreen;
    [SerializeField] private GameObject parentLockScreen;
    [SerializeField] private GameObject profileScreen;
    [SerializeField] private GameObject languageScreen;
    [SerializeField] private GameObject ttsScreen;
    [SerializeField] private GameObject notificationScreen;
    [SerializeField] private GameObject accessibilityScreen;
    [SerializeField] private GameObject subscriptionsScreen;
    [SerializeField] private GameObject allAppsScreen;
    [SerializeField] private GameObject sendFeedbacksScreen;
    [SerializeField] private GameObject aboutApplicationScreen;
    [SerializeField] private GameObject loginPageScreen;
    [SerializeField] private GameObject avatarSelectionScreen;
    [SerializeField] private GameObject soundScreen;

    private NotificationPreferences notificationPreferences;
    private AccessibilityScreen accessibilityScreenScript;
    private TTSPanel tTSPanel;
    private LanguageController languageController;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        nickname = gameAPI.GetNickname();


        if(PlayerPrefs.GetString("Nickname", "") != "")
        {
            loginPageScreen.SetActive(false);
        }
    }

    private async void Start() 
    {
        nicknameText.text = nickname;
        profileImage.GetComponent<Image>().sprite = await gameAPI.GetAvatarImage();
    }

    public void ParentLockButtonClick()
    {
        LeanTween.scale(popUp,  Vector3.one, 0.15f);
        parentLockScreen.SetActive(true);
    }

    public void ParentLockScreenClose()
    {
        LeanTween.scale(popUp, Vector3.one * 0.15f, 0.2f);
        parentLockScreen.SetActive(false);
    }

    public void ProfileButtonClick()
    {
        LeanTween.scale(profileScreen,  Vector3.one, 0.2f);
        profileScreen.SetActive(true);
    }

    public void LanguageButtonClick()
    {
        LeanTween.scale(languageScreen,  Vector3.one, 0.2f);
        languageScreen.SetActive(true);
    }

    public void TTSButtonClicked()
    {
        LeanTween.scale(ttsScreen,  Vector3.one, 0.2f);
        ttsScreen.SetActive(true);
    }
    
    public void NotificationButtonClick()
    {
        LeanTween.scale(notificationScreen,  Vector3.one, 0.2f);
        notificationScreen.SetActive(true);
    }
    public void AccessibiltyButtonClick()
    {
        LeanTween.scale(accessibilityScreen,  Vector3.one, 0.2f);
        accessibilityScreen.SetActive(true);
    }
    public void SubscriptionsButtonClick()
    {
        LeanTween.scale(subscriptionsScreen,  Vector3.one, 0.2f);
        subscriptionsScreen.SetActive(true);
    }
    public void SoundButtonClick()
    {
        LeanTween.scale(soundScreen,  Vector3.one, 0.2f);
        soundScreen.SetActive(true);
    }

    public void AllAppsButtonClick()
    {
        LeanTween.scale(allAppsScreen,  Vector3.one, 0.2f);
        allAppsScreen.SetActive(true);
    }
    public void SendFeedbacksButtonClick()
    {
        LeanTween.scale(sendFeedbacksScreen,  Vector3.one, 0.2f);
        sendFeedbacksScreen.SetActive(true);
    }
    public void AboutApplicationButtonClick()
    {
        LeanTween.scale(aboutApplicationScreen,  Vector3.one, 0.2f);
        aboutApplicationScreen.SetActive(true);
    }
    public async void ProfilePanelUpdate()
    {
        nicknameText.text = gameAPI.GetNickname();
        profileImage.GetComponent<Image>().sprite = await gameAPI.GetAvatarImage();
    }

    public void CloseSettingClick()
    {
        settingScreen.SetActive(false);
    }
    public void SignOut()
    {
        //nicknameInputField.text = "";
        gameAPI.ClearAllPrefs();

        notificationPreferences = notificationScreen.GetComponent<NotificationPreferences>();
        notificationPreferences.reminderPreference = gameAPI.GetReminderPreference();
        notificationPreferences.usabilityTipsToggle.isOn = gameAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        notificationPreferences.promotionsNotificationToggle.isOn = gameAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
        
        accessibilityScreenScript = accessibilityScreen.GetComponent<AccessibilityScreen>();
        accessibilityScreenScript.hapticsToggle.isOn = gameAPI.GetHapticsPreference() == 1 ? true : false;
        accessibilityScreenScript.activateOnPressToggle.isOn = gameAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        accessibilityScreenScript.voiceGreetingToggle.isOn = gameAPI.GetVoiceGreetingPreference() == 1 ? true : false;

        tTSPanel = ttsScreen.GetComponentInChildren<TTSPanel>();
        //tTSPanel.selectedTtsElement = await gameAPI.GetTTSPreference();

        languageController = languageScreen.GetComponent<LanguageController>();
        languageController.selectedLanguage = null;

        if (notificationPreferences.reminderPreference == "Daily")
        {
            notificationPreferences.dailyReminderToggle.isOn = true;
        }
        else
        {
            notificationPreferences.weeklyReminderToggle.isOn = true;
        }     

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
