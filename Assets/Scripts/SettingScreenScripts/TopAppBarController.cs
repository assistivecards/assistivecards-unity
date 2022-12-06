using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopAppBarController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private GameObject canvas;

    [Header ("Top App Bar UI")]
    private GameObject backButton;
    private GameObject saveButton;

    [Header ("Classes")]
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

    [Header ("Misc")]
    [SerializeField] private SampleWebView sampleWebView;
    [SerializeField] private SettingScreenButton settingScreenButton;


    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void BackButtonClicked()
    {
        if (GetComponentInParent<SendFeedbackPage>() != null)
        {
            sampleWebView.webViewObject.SetVisibility(false);
            LeanTween.scale(this.transform.parent.gameObject, Vector3.one * 0.9f, 0.15f);
            Invoke("SceneSetActiveFalse", 0.15f);
        }
        else
        {
            LeanTween.scale(this.transform.parent.gameObject, Vector3.one * 0.9f, 0.15f);
            Invoke("SceneSetActiveFalse", 0.15f);
        }
    }

    private void SceneSetActiveFalse()
    {
        this.transform.parent.gameObject.SetActive(false);
    }

    public async void SaveButtonClicked()
    {
        if (GetComponentInParent<ProfileEditor>() != null)
        {
            profileEditor = GetComponentInParent<ProfileEditor>();
            gameAPI.SetNickname(profileEditor.nicknameInputField.text);
            canvas.GetComponent<CanvasController>().ProfilePanelUpdate();
            settingScreenButton.SetAvatarImageOnGamePanel();
        }
        if (GetComponentInParent<AccessibilityScreen>() != null)
        {
            gameAPI.SetHapticsPreference(hapticsToggle.isOn ? 1 : 0);
            gameAPI.SetActivateOnPressInPreference(activateOnPressToggle.isOn ? 1 : 0);
            gameAPI.SetVoiceGreetingPreference(voiceGreetingToggle.isOn ? 1 : 0);
        }
        if (GetComponentInParent<NotificationPreferences>() != null)
        {
            gameAPI.SetReminderPreference(dailyReminderToggle.isOn ? "Daily" : "Weekly");
            gameAPI.SetUsabilityTipsPreference(usabilityTipsToggle.isOn ? 1 : 0);
            gameAPI.SetPromotionsNotificationPreference(promotionsNotificationToggle.isOn ? 1 : 0);
        }
        if (GetComponentInParent<LanguageController>() != null)
        {
            languageController = GetComponentInParent<LanguageController>();
            gameAPI.SetLanguage(languageController.selectedLanguage.name);
            gameAPI.SetTTSPreference(await gameAPI.GetSelectedLocale());
            canvas.GetComponent<LanguageTest>().OnLanguageChange();
            Camera.main.GetComponent<NotificationsManager>().OnLanguageChange();

            if (languageController.selectedLanguage.name == "Arabic" || languageController.selectedLanguage.name == "Urdu")
            {
                canvas.GetComponent<RightToLeftTextChanger>().RightToLeftLangugeChanged();
            }
            else
            {
                canvas.GetComponent<RightToLeftTextChanger>().LeftToRightLanguageChanged();
            }
        }
        if (transform.parent.GetComponentInChildren<TTSPanel>() != null)
        {
            gameAPI.SetTTSPreference(ttsPanel.selectedTtsElement.name);
        }
        if(transform.parent.name == "Sound")
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
        
        LeanTween.scale(this.transform.parent.gameObject, Vector3.one * 0.9f, 0.15f);
        Invoke("SceneSetActiveFalse", 0.15f);
    }
}
