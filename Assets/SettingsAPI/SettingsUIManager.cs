using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Threading.Tasks;

public class SettingsUIManager : MonoBehaviour
{
    GameAPI.SettingsAPI settingsAPI;
    GameAPI.LanguageManager languageManager;
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
    private string ttsPreference;
    private string reminderPreference;
    private bool isUsabilityTipsActive;
    private bool isPromotionsNotificationActive;
    private bool isHapticsActive;
    private bool isPressInActive;
    private bool isVoiceGreetingActive;

    private void Awake()
    {
        settingsAPI = new GameAPI.SettingsAPI();
        languageManager = new GameAPI.LanguageManager();
        nickname = settingsAPI.GetNickname();
        language = settingsAPI.GetLanguage();

        isUsabilityTipsActive = settingsAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        isPromotionsNotificationActive = settingsAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
        isHapticsActive = settingsAPI.GetHapticsPreference() == 1 ? true : false;
        isPressInActive = settingsAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        isVoiceGreetingActive = settingsAPI.GetVoiceGreetingPreference() == 1 ? true : false;

    }
    private async void Start()
    {

        await GameAPI.cacheData;
        // ttsPreference = await settingsAPI.GetTTSPreference();
        // foreach (var voice in tts.voices)
        // {
        //     if (ttsPreference == voice.name)
        //     {
        //         tts.activeVoice = voice;
        //     }
        // }
        nicknameInputField.text = nickname;
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
            if (toggle.name == ttsPreference)
            {
                toggle.isOn = true;
            }
        }

        greetingMessage.text = "Hello " + nickname + ", you have selected the language " + language + ". Your preferred TTS voice is " + ttsPreference + ". Your reminder period preference is " + reminderPreference + ". You " + (isUsabilityTipsActive ? "will" : "won't") + " receive usability tips. You " + (isPromotionsNotificationActive ? "will" : "won't") + " receive promotion notifications. Haptics are " + (isHapticsActive ? "on" : "off") + ". Activate on press in is " + (isPressInActive ? "on" : "off") + ". Voice greeting is " + (isVoiceGreetingActive ? "on." : "off.");
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
        isHapticsActive = settingsAPI.GetHapticsPreference() == 1 ? true : false;
        isPressInActive = settingsAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        isVoiceGreetingActive = settingsAPI.GetVoiceGreetingPreference() == 1 ? true : false;
        reminderPreference = settingsAPI.GetReminderPreference();
        isUsabilityTipsActive = settingsAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        isPromotionsNotificationActive = settingsAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
        greetingMessage.text = "Hello " + nickname + ", you have selected the language " + language + ". Your preferred TTS voice is " + ttsPreference + ". Your reminder period preference is " + reminderPreference + ". You " + (isUsabilityTipsActive ? "will" : "won't") + " receive usability tips. You " + (isPromotionsNotificationActive ? "will" : "won't") + " receive promotion notifications. Haptics are " + (isHapticsActive ? "on" : "off") + ". Activate on press in is " + (isPressInActive ? "on" : "off") + ". Voice greeting is " + (isVoiceGreetingActive ? "on." : "off.");
    }

    public async void SaveSettings()
    {
        settingsAPI.SetNickname(nicknameInputField.text);
        settingsAPI.SetLanguage(languages.ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text);
        GameAPI.selectedLangCode = await languageManager.GetSystemLanguageCode();
        // var didLanguageChange = await DidLanguageChange(GameAPI.selectedLangCode);
        // var availableVoices = tts.GetAvailableVoices(tts.voices, GameAPI.selectedLangCode);
        // settingsAPI.SetTTSPreference(didLanguageChange ? availableVoices[0].name : TTSVoices.ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text);
        // ttsPreference = await settingsAPI.GetTTSPreference();
        // foreach (var voice in tts.voices)
        // {
        //     if (ttsPreference == voice.name)
        //     {
        //         tts.activeVoice = voice;
        //     }
        // }
        foreach (var toggle in TTSVoices.GetComponentsInChildren<Toggle>())
        {
            if (toggle.name == ttsPreference)
            {
                toggle.isOn = true;
            }
        }
        settingsAPI.SetReminderPreference(dailyReminderToggle.isOn ? "Daily" : "Weekly");
        settingsAPI.SetUsabilityTipsPreference(usabilityTipsToggle.isOn ? 1 : 0);
        settingsAPI.SetPromotionsNotificationPreference(promotionsNotificationToggle.isOn ? 1 : 0);
        settingsAPI.SetHapticsPreference(hapticsToggle.isOn ? 1 : 0);
        settingsAPI.SetActivateOnPressInPreference(activateOnPressToggle.isOn ? 1 : 0);
        settingsAPI.SetVoiceGreetingPreference(voiceGreetingToggle.isOn ? 1 : 0);
    }

    public async void SignOut()
    {
        nicknameInputField.text = "";
        settingsAPI.ClearAllPrefs();
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
            if (toggle.name == ttsPreference)
            {
                toggle.isOn = true;
            }
        }

        greetingMessage.text = "Hello " + nickname + ", you have selected the language " + language + ". Your preferred TTS voice is " + ttsPreference + ". Your reminder period preference is " + reminderPreference + ". You " + (isUsabilityTipsActive ? "will" : "won't") + " receive usability tips. You " + (isPromotionsNotificationActive ? "will" : "won't") + " receive promotion notifications. Haptics are " + (isHapticsActive ? "on" : "off") + ". Activate on press in is " + (isPressInActive ? "on" : "off") + ". Voice greeting is " + (isVoiceGreetingActive ? "on." : "off.");
        if (reminderPreference == "Daily")
        {
            dailyReminderToggle.isOn = true;
        }
        else
        {
            weeklyReminderToggle.isOn = true;
        }
    }

    // public async Task<bool> DidLanguageChange(string langCode)
    // {

    //     // var ttsPreference = await settingsAPI.GetTTSPreference();

    //     if (ttsPreference.StartsWith(langCode))
    //     {
    //         return false;
    //     }
    //     return true;
    // }
}
