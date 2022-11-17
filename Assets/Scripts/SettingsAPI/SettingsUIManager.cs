using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Threading.Tasks;

public class SettingsUIManager : MonoBehaviour
{
    GameAPI gameAPI;
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
        gameAPI = Camera.main.GetComponent<GameAPI>();
        nickname = gameAPI.GetNickname();
        language = gameAPI.GetLanguage();

        isUsabilityTipsActive = gameAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        isPromotionsNotificationActive = gameAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
        isHapticsActive = gameAPI.GetHapticsPreference() == 1 ? true : false;
        isPressInActive = gameAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        isVoiceGreetingActive = gameAPI.GetVoiceGreetingPreference() == 1 ? true : false;

    }
    private async void Start()
    {
        ttsPreference = await gameAPI.GetTTSPreference();
        nicknameInputField.text = nickname;
        selectAvatarButton.image.sprite = await gameAPI.GetAvatarImage();
        reminderPreference = gameAPI.GetReminderPreference();
        usabilityTipsToggle.isOn = gameAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        hapticsToggle.isOn = gameAPI.GetHapticsPreference() == 1 ? true : false;
        activateOnPressToggle.isOn = gameAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        promotionsNotificationToggle.isOn = gameAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
        voiceGreetingToggle.isOn = gameAPI.GetVoiceGreetingPreference() == 1 ? true : false;
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
        nickname = gameAPI.GetNickname();
        language = gameAPI.GetLanguage();
        isHapticsActive = gameAPI.GetHapticsPreference() == 1 ? true : false;
        isPressInActive = gameAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        isVoiceGreetingActive = gameAPI.GetVoiceGreetingPreference() == 1 ? true : false;
        reminderPreference = gameAPI.GetReminderPreference();
        isUsabilityTipsActive = gameAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        isPromotionsNotificationActive = gameAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
        greetingMessage.text = "Hello " + nickname + ", you have selected the language " + language + ". Your preferred TTS voice is " + ttsPreference + ". Your reminder period preference is " + reminderPreference + ". You " + (isUsabilityTipsActive ? "will" : "won't") + " receive usability tips. You " + (isPromotionsNotificationActive ? "will" : "won't") + " receive promotion notifications. Haptics are " + (isHapticsActive ? "on" : "off") + ". Activate on press in is " + (isPressInActive ? "on" : "off") + ". Voice greeting is " + (isVoiceGreetingActive ? "on." : "off.");
    }

    public async void SaveSettings()
    {
        gameAPI.SetNickname(nicknameInputField.text);
        gameAPI.SetLanguage(languages.ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text);
        gameAPI.SetTTSPreference(await gameAPI.GetSelectedLocale());
        gameAPI.SetReminderPreference(dailyReminderToggle.isOn ? "Daily" : "Weekly");
        gameAPI.SetUsabilityTipsPreference(usabilityTipsToggle.isOn ? 1 : 0);
        gameAPI.SetPromotionsNotificationPreference(promotionsNotificationToggle.isOn ? 1 : 0);
        gameAPI.SetHapticsPreference(hapticsToggle.isOn ? 1 : 0);
        gameAPI.SetActivateOnPressInPreference(activateOnPressToggle.isOn ? 1 : 0);
        gameAPI.SetVoiceGreetingPreference(voiceGreetingToggle.isOn ? 1 : 0);
        ttsPreference = await gameAPI.GetTTSPreference();
        foreach (var toggle in TTSVoices.GetComponentsInChildren<Toggle>())
        {
            if (toggle.name == ttsPreference)
            {
                toggle.isOn = true;
            }
        }
    }

    public async void SignOut()
    {
        nicknameInputField.text = "";
        gameAPI.ClearAllPrefs();
        selectAvatarButton.image.sprite = await gameAPI.GetAvatarImage();
        reminderPreference = gameAPI.GetReminderPreference();
        usabilityTipsToggle.isOn = gameAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        hapticsToggle.isOn = gameAPI.GetHapticsPreference() == 1 ? true : false;
        activateOnPressToggle.isOn = gameAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        promotionsNotificationToggle.isOn = gameAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
        voiceGreetingToggle.isOn = gameAPI.GetVoiceGreetingPreference() == 1 ? true : false;
        ttsPreference = await gameAPI.GetTTSPreference();

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
}
