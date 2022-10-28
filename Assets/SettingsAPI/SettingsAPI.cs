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

    ///<summary>
    ///Takes in a nickname of type string and stores it in PlayerPrefs.
    ///</summary>
    public void SetNickname(string nickname)
    {
        PlayerPrefs.SetString("Nickname", nickname);
    }

    ///<summary>
    ///Retrieves the nickname data stored in PlayerPrefs. Default value is "John Doe".
    ///</summary>
    public string GetNickname()
    {
        return PlayerPrefs.GetString("Nickname", "John Doe");
    }

    ///<summary>
    ///Takes in a language of type string and stores it in PlayerPrefs.
    ///</summary>
    public void SetLanguage(string language)
    {
        PlayerPrefs.SetString("Language", language);
    }

    ///<summary>
    ///Retrieves the language data stored in PlayerPrefs. Default value is "English".
    ///</summary>
    public string GetLanguage()
    {
        return PlayerPrefs.GetString("Language", "English");
    }

    ///<summary>
    ///Takes in an avatarID of type string and stores it in PlayerPrefs.
    ///</summary>
    public void SetAvatarImage(string avatarID)
    {
        PlayerPrefs.SetString("AvatarID", avatarID);
    }

    ///<summary>
    ///Returns a sprite corresponding to the avatarID data stored in PlayerPrefs. Default value is "default".
    ///</summary>
    public async Task<Sprite> GetAvatarImage()
    {
        var tex = await assistiveCardsSDK.GetAvatarImage(PlayerPrefs.GetString("AvatarID", "default"));
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        return sprite;
    }

    ///<summary>
    ///Takes in a period of type string and stores it in PlayerPrefs.
    ///</summary>
    public void SetReminderPreference(string period)
    {
        PlayerPrefs.SetString("ReminderPeriod", period);
    }

    ///<summary>
    ///Retrieves the reminder period preference data stored in PlayerPrefs. Default value is "Weekly".
    ///</summary>
    public string GetReminderPreference()
    {
        return PlayerPrefs.GetString("ReminderPeriod", "Weekly");
    }

    ///<summary>
    ///Takes in a single parameter of type integer named isUsabilityTipsActive and stores it in PlayerPrefs.
    ///</summary>
    public void SetUsabilityTipsPreference(int isUsabilityTipsActive)
    {
        PlayerPrefs.SetInt("UsabilityTipsPreference", isUsabilityTipsActive);
    }

    ///<summary>
    ///Retrieves the usability tips preference data stored in PlayerPrefs. Default value is 0.
    ///</summary>
    public int GetUsabilityTipsPreference()
    {
        return PlayerPrefs.GetInt("UsabilityTipsPreference", 0);
    }

    ///<summary>
    ///Takes in a single parameter of type integer named isPromotionsNotificationActive and stores it in PlayerPrefs.
    ///</summary>
    public void SetPromotionsNotificationPreference(int isPromotionsNotificationActive)
    {
        PlayerPrefs.SetInt("PromotionsNotificationPreference", isPromotionsNotificationActive);
    }

    ///<summary>
    ///Retrieves the promotions notification preference data stored in PlayerPrefs. Default value is 0.
    ///</summary>
    public int GetPromotionsNotificationPreference()
    {
        return PlayerPrefs.GetInt("PromotionsNotificationPreference", 0);
    }

    ///<summary>
    ///Takes in a single parameter of type string named TTSPreference and stores it in PlayerPrefs.
    ///</summary>
    public void SetTTSPreference(string TTSPreference)
    {
        PlayerPrefs.SetString("TTSPreference", TTSPreference);
    }

    ///<summary>
    ///Retrieves the TTS voice preference data stored in PlayerPrefs. Default value is "Alex".
    ///</summary>
    public string GetTTSPreference()
    {
        return PlayerPrefs.GetString("TTSPreference", "Alex");
    }

    ///<summary>
    ///Takes in a single parameter of type integer named isHapticsActive and stores it in PlayerPrefs.
    ///</summary>
    public void SetHapticsPreference(int isHapticsActive)
    {
        PlayerPrefs.SetInt("HapticPreference", isHapticsActive);
    }

    ///<summary>
    ///Retrieves the haptics preference data stored in PlayerPrefs. Default value is 0.
    ///</summary>
    public int GetHapticsPreference()
    {
        return PlayerPrefs.GetInt("HapticPreference", 0);
    }

    ///<summary>
    ///Takes in a single parameter of type integer named isPressInActive and stores it in PlayerPrefs.
    ///</summary>
    public void SetActivateOnPressInPreference(int isPressInActive)
    {
        PlayerPrefs.SetInt("ActivateOnPressInPreference", isPressInActive);
    }

    ///<summary>
    ///Retrieves the activate on press in preference data stored in PlayerPrefs. Default value is 0.
    ///</summary>
    public int GetActivateOnPressInPreference()
    {
        return PlayerPrefs.GetInt("ActivateOnPressInPreference", 0);
    }

    ///<summary>
    ///Takes in a single parameter of type integer named isVoiceGreetingActive and stores it in PlayerPrefs.
    ///</summary>
    public void SetVoiceGreetingPreference(int isVoiceGreetingActive)
    {
        PlayerPrefs.SetInt("VoiceGreetingPreference", isVoiceGreetingActive);
    }

    ///<summary>
    ///Retrieves the voice greeting on start preference data stored in PlayerPrefs. Default value is 0.
    ///</summary>
    public int GetVoiceGreetingPreference()
    {
        return PlayerPrefs.GetInt("VoiceGreetingPreference", 0);
    }

}
