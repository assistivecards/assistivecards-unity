using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SettingsUIManager : MonoBehaviour
{
    SettingsAPI settingsAPI;
    [SerializeField] GameObject api;
    public TMP_InputField nicknameInputField;
    public TMP_Text greetingMessage;
    public Button selectAvatarButton;
    public Toggle dailyReminderToggle;
    public Toggle weeklyReminderToggle;
    public Toggle usabilityTipsToggle;
    public Toggle promotionsNotificationToggle;
    public Toggle hapticsToggle;
    public Toggle activateOnPressToggle;
    public Toggle voiceGreetingToggle;
    public ToggleGroup languages;
    public ToggleGroup TTSVoices;
    private string nickname;
    private string language;
    private string tts;
    private string reminderPreference;
    private bool isUsabilityTipsActive;
    private bool isPromotionsNotificationActive;
    private bool isHapticsActive;
    private bool isPressInActive;
    private bool isVoiceGreetingActive;

    private void Awake()
    {
        settingsAPI = api.GetComponent<SettingsAPI>();
        nickname = settingsAPI.GetNickname();
        language = settingsAPI.GetLanguage();
        tts = settingsAPI.GetTTSPreference();
        isUsabilityTipsActive = settingsAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        isPromotionsNotificationActive = settingsAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
        isHapticsActive = settingsAPI.GetHapticsPreference() == 1 ? true : false;
        isPressInActive = settingsAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        isVoiceGreetingActive = settingsAPI.GetVoiceGreetingPreference() == 1 ? true : false;
        nicknameInputField.text = nickname;
    }
    private async void Start()
    {
        selectAvatarButton.image.sprite = await settingsAPI.GetAvatarImage();
        reminderPreference = settingsAPI.GetReminderPreference();
        usabilityTipsToggle.isOn = settingsAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        hapticsToggle.isOn = settingsAPI.GetHapticsPreference() == 1 ? true : false;
        activateOnPressToggle.isOn = settingsAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        promotionsNotificationToggle.isOn = settingsAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
        voiceGreetingToggle.isOn = settingsAPI.GetVoiceGreetingPreference() == 1 ? true : false;
        foreach (var toggle in languages.GetComponentsInChildren<Toggle>())
        {
            if (toggle.name == language)
            {
                toggle.isOn = true;
            }
        }

        foreach (var toggle in TTSVoices.GetComponentsInChildren<Toggle>())
        {
            if (toggle.name == tts)
            {
                toggle.isOn = true;
            }
        }

        greetingMessage.text = "Hello " + nickname + ", you have selected the language " + language + ". Your preferred TTS voice is " + tts + ". Your reminder period preference is " + reminderPreference + ". You " + (isUsabilityTipsActive ? "will" : "won't") + " receive usability tips. You " + (isPromotionsNotificationActive ? "will" : "won't") + " receive promotion notifications. Haptics are " + (isHapticsActive ? "on" : "off") + ". Activate on press in is " + (isPressInActive ? "on" : "off") + ". Voice greeting is " + (isVoiceGreetingActive ? "on." : "off.");
        if (reminderPreference == "Daily")
        {
            dailyReminderToggle.isOn = true;
        }
        else
        {
            weeklyReminderToggle.isOn = true;
        }

    }
    private void Update()
    {
        nickname = settingsAPI.GetNickname();
        language = settingsAPI.GetLanguage();
        tts = settingsAPI.GetTTSPreference();
        isHapticsActive = settingsAPI.GetHapticsPreference() == 1 ? true : false;
        isPressInActive = settingsAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        isVoiceGreetingActive = settingsAPI.GetVoiceGreetingPreference() == 1 ? true : false;
        reminderPreference = settingsAPI.GetReminderPreference();
        isUsabilityTipsActive = settingsAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        isPromotionsNotificationActive = settingsAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
        greetingMessage.text = "Hello " + nickname + ", you have selected the language " + language + ". Your preferred TTS voice is " + tts + ". Your reminder period preference is " + reminderPreference + ". You " + (isUsabilityTipsActive ? "will" : "won't") + " receive usability tips. You " + (isPromotionsNotificationActive ? "will" : "won't") + " receive promotion notifications. Haptics are " + (isHapticsActive ? "on" : "off") + ". Activate on press in is " + (isPressInActive ? "on" : "off") + ". Voice greeting is " + (isVoiceGreetingActive ? "on." : "off.");
    }

    public void SaveSettings()
    {
        settingsAPI.SetNickname(nicknameInputField.text);
        settingsAPI.SetLanguage(languages.ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text);
        settingsAPI.SetTTSPreference(TTSVoices.ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text);
        settingsAPI.SetReminderPreference(dailyReminderToggle.isOn ? "Daily" : "Weekly");
        settingsAPI.SetUsabilityTipsPreference(usabilityTipsToggle.isOn ? 1 : 0);
        settingsAPI.SetPromotionsNotificationPreference(promotionsNotificationToggle.isOn ? 1 : 0);
        settingsAPI.SetHapticsPreference(hapticsToggle.isOn ? 1 : 0);
        settingsAPI.SetActivateOnPressInPreference(activateOnPressToggle.isOn ? 1 : 0);
        settingsAPI.SetVoiceGreetingPreference(voiceGreetingToggle.isOn ? 1 : 0);
    }
}
