using System.Threading.Tasks;
using UnityEngine;


public class SettingsAPI : MonoBehaviour
{
    AssistiveCardsSDK assistiveCardsSDK;
    public GameObject SDK;

    private void Awake()
    {
        assistiveCardsSDK = SDK.GetComponent<AssistiveCardsSDK>();
    }
    public void SetNickname(string nickname)
    {
        PlayerPrefs.SetString("Nickname", nickname);
    }

    public string GetNickname()
    {
        return PlayerPrefs.GetString("Nickname", "John Doe");
    }

    public void SetLanguage(string language)
    {
        PlayerPrefs.SetString("Language", language);
    }

    public string GetLanguage()
    {
        return PlayerPrefs.GetString("Language", "English");
    }


    public void SetAvatarImage(string avatarID)
    {
        PlayerPrefs.SetString("AvatarID", avatarID);
    }

    public async Task<Sprite> GetAvatarImage()
    {
        var tex = await assistiveCardsSDK.GetAvatarImage(PlayerPrefs.GetString("AvatarID", "default"));
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        return sprite;
    }

    public void SetReminderPreference(string period)
    {
        PlayerPrefs.SetString("ReminderPeriod", period);
    }

    public string GetReminderPreference()
    {
        return PlayerPrefs.GetString("ReminderPeriod", "Weekly");
    }

    public void SetUsabilityTipsPreference(int isUsabilityTipsActive)
    {
        PlayerPrefs.SetInt("UsabilityTipsPreference", isUsabilityTipsActive);
    }

    public int GetUsabilityTipsPreference()
    {
        return PlayerPrefs.GetInt("UsabilityTipsPreference", 0);
    }

    public void SetPromotionsNotificationPreference(int isPromotionsNotificationActive)
    {
        PlayerPrefs.SetInt("PromotionsNotificationPreference", isPromotionsNotificationActive);
    }

    public int GetPromotionsNotificationPreference()
    {
        return PlayerPrefs.GetInt("PromotionsNotificationPreference", 0);
    }

    public void SetTTSPreference(string TTSPreference)
    {
        PlayerPrefs.SetString("TTSPreference", TTSPreference);
    }

    public string GetTTSPreference()
    {
        return PlayerPrefs.GetString("TTSPreference", "Alex");
    }

    public void SetHapticsPreference(int isHapticsActive)
    {
        PlayerPrefs.SetInt("HapticPreference", isHapticsActive);
    }

    public int GetHapticsPreference()
    {
        return PlayerPrefs.GetInt("HapticPreference", 0);
    }

    public void SetActivateOnPressInPreference(int isPressInActive)
    {
        PlayerPrefs.SetInt("ActivateOnPressInPreference", isPressInActive);
    }

    public int GetActivateOnPressInPreference()
    {
        return PlayerPrefs.GetInt("ActivateOnPressInPreference", 0);
    }

    public void SetVoiceGreetingPreference(int isVoiceGreetingActive)
    {
        PlayerPrefs.SetInt("VoiceGreetingPreference", isVoiceGreetingActive);
    }

    public int GetVoiceGreetingPreference()
    {
        return PlayerPrefs.GetInt("VoiceGreetingPreference", 0);
    }

}
