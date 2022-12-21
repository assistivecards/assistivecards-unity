using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopAppBarController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject gameCanvas;

    [Header("Top App Bar UI")]
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject saveButton;
    [SerializeField] private GameObject parentLockButton;
    [SerializeField] private GameObject closeButton;

    [Header("Classes")]
    private ProfileEditor profileEditor;
    private LanguageController languageController;
    [SerializeField] TTSPanel ttsPanel;
    private SoundManagerUI soundManagerUI;

    [Header("UI Elements Accessility")]
    public Toggle hapticsToggle;
    public Toggle activateOnPressToggle;
    public Toggle voiceGreetingToggle;

    [Header("UI Elements Noficication")]

    public Toggle dailyReminderToggle;
    public Toggle weeklyReminderToggle;
    public Toggle usabilityTipsToggle;
    public Toggle promotionsNotificationToggle;

    [Header("Misc")]
    [SerializeField] private SampleWebView sendFeedbackSampleWebView;
    [SerializeField] private SettingScreenButton profileEditorSettingScreenButton;
    private CanvasController canvasController;
    [SerializeField] private GameObject profileScreen;
    public bool onMain = false;
    public bool onAvatarSelection = false;


    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        canvasController = canvas.GetComponent<CanvasController>();
    }
    private void OnEnable()
    {
        ChangeTopAppBarType(2);
    }

    public void ChangeTopAppBarType(int i)
    {
        switch (i)
        {
            case 0:
                //main screen top app bar
                onMain = true;
                backButton.SetActive(true);
                parentLockButton.SetActive(true);

                saveButton.SetActive(false);
                closeButton.SetActive(false);
                break;

            case 1:
                //saveable screens top app bar
                onMain = false;
                saveButton.SetActive(true);
                backButton.SetActive(true);

                parentLockButton.SetActive(false);
                closeButton.SetActive(false);
                break;

            case 2:
                //only back button top app bar
                onMain = false;
                backButton.SetActive(true);

                saveButton.SetActive(false);
                parentLockButton.SetActive(false);
                closeButton.SetActive(false);
                break;
            case 3:
                //about application interior pages top app bar
                onMain = false;
                closeButton.SetActive(true);

                saveButton.SetActive(false);
                parentLockButton.SetActive(false);
                backButton.SetActive(false);
                break;

        }
    }

    public void BackButtonClicked()
    {
        if (canvasController.currentScreen.name == "ParentLock")
        {
            canvasController.CloseSettingClick();
            // canvasController.StartFadeAnim();
            ChangeTopAppBarType(2);
        }
        if (canvasController.currentScreen.name == "AvatarSelectionSettings")
        {
            LeanTween.scale(canvasController.currentScreen, Vector3.one * 0.9f, 0.15f);
            Invoke("SceneSetActiveFalse", 0.15f);
            Invoke("CloseAvatarSelectionScreen", 0.16f);
        }
        else
        {
            if (onMain)
            {
                canvasController.CloseSettingClick();
            }
            else
            {
                if (canvasController.currentScreen.name == "SendFeedback")
                {
                    sendFeedbackSampleWebView.webViewObject.SetVisibility(false);
                    LeanTween.scale(canvasController.currentScreen, Vector3.one * 0.9f, 0.15f);
                    Invoke("SceneSetActiveFalse", 0.15f);
                }
                else
                {
                    LeanTween.scale(canvasController.currentScreen, Vector3.one * 0.9f, 0.15f);
                    Invoke("SceneSetActiveFalse", 0.15f);
                    ChangeTopAppBarType(0);
                }
            }
        }
    }

    private void CloseAvatarSelectionScreen()
    {
        canvasController.currentScreen = profileScreen;
    }

    private void SceneSetActiveFalse()
    {
        canvasController.currentScreen.SetActive(false);
    }

    public async void SaveButtonClicked()
    {
        if (canvasController.currentScreen.name == "AvatarSelectionSettings")
        {
            LeanTween.scale(canvasController.currentScreen, Vector3.one * 0.9f, 0.15f);
            Invoke("SceneSetActiveFalse", 0.15f);
            Invoke("CloseAvatarSelectionScreen", 0.16f);
        }
        else
        {

            if (canvasController.currentScreen.name == "Profile")
            {
                profileEditor = canvasController.currentScreen.GetComponentInParent<ProfileEditor>();
                gameAPI.SetNickname(profileEditor.nicknameInputField.text);
                canvas.GetComponent<CanvasController>().ProfilePanelUpdate();
                profileEditorSettingScreenButton.SetAvatarImageOnGamePanel();
            }
            if (canvasController.currentScreen.name == "Accessibility")
            {
                gameAPI.SetHapticsPreference(hapticsToggle.isOn ? 1 : 0);
                gameAPI.SetActivateOnPressInPreference(activateOnPressToggle.isOn ? 1 : 0);
                gameAPI.SetVoiceGreetingPreference(voiceGreetingToggle.isOn ? 1 : 0);
            }
            if (canvasController.currentScreen.name == "Notifications")
            {
                gameAPI.SetReminderPreference(dailyReminderToggle.isOn ? "Daily" : "Weekly");
                gameAPI.SetUsabilityTipsPreference(usabilityTipsToggle.isOn ? 1 : 0);
                gameAPI.SetPromotionsNotificationPreference(promotionsNotificationToggle.isOn ? 1 : 0);
            }
            if (canvasController.currentScreen.name == "Languages")
            {
                languageController = canvasController.currentScreen.GetComponentInParent<LanguageController>();
                gameAPI.SetLanguage(languageController.selectedLanguage.name);
                gameAPI.SetTTSPreference(await gameAPI.GetSelectedLocale());
                canvas.GetComponent<LanguageTest>().OnLanguageChange();
                gameCanvas.GetComponent<LanguageTest>().OnLanguageChange();
                Camera.main.GetComponent<NotificationsManager>().OnLanguageChange();
                PackSelectionPanel.didLanguageChange = true;
                AllAppsPage.didLanguageChange = true;
                TTSPanel.didLanguageChange = true;
                PromoScreen.didLanguageChange = true;
                Board.didLanguageChange = true;

                if (languageController.selectedLanguage.name == "Arabic" || languageController.selectedLanguage.name == "Urdu")
                {
                    canvas.GetComponent<RightToLeftTextChanger>().RightToLeftLangugeChanged();
                }
                else
                {
                    canvas.GetComponent<RightToLeftTextChanger>().LeftToRightLanguageChanged();
                }
            }
            if (canvasController.currentScreen.name == "TTS")
            {
                gameAPI.SetTTSPreference(ttsPanel.selectedTtsElement.name);
                canvas.GetComponent<LanguageTest>().OnTTSChange();
            }
            if (canvasController.currentScreen.name == "Sound")
            {
                soundManagerUI = canvas.GetComponent<SoundManagerUI>();
                gameAPI.SetMusicPreference(soundManagerUI.musicToggle.isOn ? 1 : 0);
                gameAPI.SetSFXPreference(soundManagerUI.sfxToggle.isOn ? 1 : 0);
                soundManagerUI.musicSource.mute = soundManagerUI.musicToggle.isOn ? false : true;
                soundManagerUI.sfxSource.mute = soundManagerUI.sfxToggle.isOn ? false : true;
                if (soundManagerUI.musicToggle.isOn == false)
                {
                    soundManagerUI.musicSource.Stop();
                }
                else if (soundManagerUI.musicToggle.isOn == true)
                {
                    soundManagerUI.musicSource.Play();
                }
            }

            LeanTween.scale(canvasController.currentScreen, Vector3.one * 0.9f, 0.15f);
            Invoke("SceneSetActiveFalse", 0.15f);
            ChangeTopAppBarType(0);
        }
    }
}
