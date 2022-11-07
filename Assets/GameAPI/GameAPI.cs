using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using System.IO;
using Defective.JSON;

public class GameAPI : MonoBehaviour
{
    AssistiveCardsSDK assistiveCardsSDK = new AssistiveCardsSDK();
    LanguageManager languageManager = new LanguageManager();
    public static string selectedLangCode;
    public AssistiveCardsSDK.Packs cachedPacks = new AssistiveCardsSDK.Packs();
    public AssistiveCardsSDK.Activities cachedActivities = new AssistiveCardsSDK.Activities();
    public AssistiveCardsSDK.Languages cachedLanguages = new AssistiveCardsSDK.Languages();
    public AssistiveCardsSDK.Apps cachedApps = new AssistiveCardsSDK.Apps();
    public static Task cacheData;

    private async void Awake()
    {
        cacheData = CacheData();
        await cacheData;
    }

    public async Task CacheData()
    {
        selectedLangCode = await languageManager.GetSystemLanguageCode();
        cachedPacks = await assistiveCardsSDK.GetPacks(selectedLangCode);
        cachedActivities = await assistiveCardsSDK.GetActivities(selectedLangCode);
        cachedLanguages = await assistiveCardsSDK.GetLanguages();
        cachedApps = await assistiveCardsSDK.GetApps();
    }
    public class AssistiveCardsSDK
    {
        private int boyAvatarArrayLength = 33;
        private int girlAvatarArrayLength = 27;
        private int miscAvatarArrayLength = 29;
        private const string api = "https://api.assistivecards.com/";
        private const string metadata = "https://api.assistivecards.com/apps/metadata.json";

        [Serializable]
        public class Pack
        {
            public int id;
            public string slug;
            public string color;
            public int premium;
            public string locale;
            public int count;
        }

        [Serializable]
        public class Packs
        {
            public Pack[] packs;
        }

        [Serializable]
        public class Phrase
        {
            public string type;
            public string phrase;
        }

        [Serializable]
        public class Card
        {
            public string slug;
            public string title;
            public Phrase[] phrases;
        }

        [Serializable]
        public class Cards
        {
            public Card[] cards;
        }

        [Serializable]
        public class Activity
        {
            public string slug;
            public string title;
            public string search;
        }

        [Serializable]
        public class Activities
        {
            public Activity[] activities;
        }

        [Serializable]
        public class Language
        {
            public string code;
            public List<string> locale;
            public List<string> support;
            public string title;
            public string native;
            public bool rightToLeft;
            public bool readproof;
        }

        [Serializable]
        public class Languages
        {
            public Language[] languages;
        }

        [Serializable]
        public class App
        {
            public string slug;
            public string name;
            public string color;
            public Tagline tagline;
            public Description description;
            public StoreId storeId;
            public bool advertise;
        }

        [Serializable]
        public class Description
        {
            public string en;
            public string es;
            public string fr;
            public string de;
            public string it;
            public string ja;
            public string ko;
            public string zh;
            public string ar;
            public string cs;
            public string da;
            public string nl;
            public string fi;
            public string el;
            public string he;
            public string hi;
            public string hu;
            public string id;
            public string nb;
            public string pl;
            public string pt;
            public string ro;
            public string ru;
            public string sk;
            public string sv;
            public string th;
            public string tr;
            public string ur;
            public string bn;
            public string et;
            public string fil;
            public string jv;
            public string km;
            public string ne;
            public string si;
            public string uk;
            public string vi;
        }

        [Serializable]
        public class Apps
        {
            public List<App> apps;
        }

        [Serializable]
        public class StoreId
        {
            public int appStore;
            public object googlePlay;
        }

        [Serializable]
        public class Tagline
        {
            public string en;
            public string es;
            public string fr;
            public string de;
            public string it;
            public string ja;
            public string ko;
            public string zh;
            public string ar;
            public string cs;
            public string da;
            public string nl;
            public string fi;
            public string el;
            public string he;
            public string hi;
            public string hu;
            public string id;
            public string nb;
            public string pl;
            public string pt;
            public string ro;
            public string ru;
            public string sk;
            public string sv;
            public string th;
            public string tr;
            public string ur;
            public string bn;
            public string et;
            public string fil;
            public string jv;
            public string km;
            public string ne;
            public string si;
            public string uk;
            public string vi;
        }

        public Packs packs = new Packs();
        public Cards cards = new Cards();
        public Activities activities = new Activities();
        public Languages languages = new Languages();
        public Apps apps = new Apps();

        ///<summary>
        ///Takes in a language code of type string and returns an object of type Packs which holds an array of Pack objects in the specified language.
        ///</summary>
        public async Task<Packs> GetPacks(string language)
        {
            var result = await asyncGetPacks(language);
            return result;
        }

        private async Task<Packs> asyncGetPacks(string language)
        {

            string uri = api + "packs/" + language + "/metadata.json";

            UnityWebRequest request = UnityWebRequest.Get(uri);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                return null;
            else
            {
                var packs = JsonUtility.FromJson<Packs>("{\"packs\":" + request.downloadHandler.text + "}");
                return packs;
            }
        }

        ///<summary>
        ///Takes in a language code and a pack slug of type string as parameters. Returns an object of type Cards which holds an array of Card objects in the specified pack and language.
        ///</summary>

        public async Task<Cards> GetCards(string language, string packSlug)
        {
            var result = await asyncGetCards(language, packSlug);
            return result;
        }

        private async Task<Cards> asyncGetCards(string language, string packSlug)
        {

            string uri = api + "packs/" + language + "/" + packSlug + ".json";

            UnityWebRequest request = UnityWebRequest.Get(uri);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                return null;
            else
            {
                return cards = JsonUtility.FromJson<Cards>("{\"cards\":" + request.downloadHandler.text + "}");
            }
        }

        ///<summary>
        ///Takes in a language code of type string and returns an object of type Activities which holds an array of Activity objects in the specified language.
        ///</summary>
        public async Task<Activities> GetActivities(string language)
        {
            var result = await asyncGetActivities(language);
            return result;
        }

        private async Task<Activities> asyncGetActivities(string language)
        {

            string uri = api + "activities/" + language + "/metadata.json";

            UnityWebRequest request = UnityWebRequest.Get(uri);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                return null;
            else
            {
                var activities = JsonUtility.FromJson<Activities>("{\"activities\":" + request.downloadHandler.text + "}");
                return activities;
            }
        }

        ///<summary>
        ///Returns an object of type Languages which holds an array of Language objects.
        ///</summary>
        public async Task<Languages> GetLanguages()
        {
            var result = await asyncGetLanguages();
            return result;
        }

        private async Task<Languages> asyncGetLanguages()
        {

            string uri = api + "languages.json";

            UnityWebRequest request = UnityWebRequest.Get(uri);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                return null;
            else
            {
                var languages = JsonUtility.FromJson<Languages>(request.downloadHandler.text);
                return languages;
            }
        }

        ///<summary>
        ///Takes in an activity slug of type string and returns an object of type Texture2D corresponding to the specified activity slug.
        ///</summary>
        public async Task<Texture2D> GetActivityImage(string activitySlug)
        {
            var result = await asyncGetActivityImage(activitySlug);
            return result;
        }

        private async Task<Texture2D> asyncGetActivityImage(string activitySlug)
        {

            string uri = api + "activities/assets/" + activitySlug + ".png";

            UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                return null;
            else
            {
                var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                return texture;
            }
        }

        ///<summary>
        ///Takes in an avatar ID of type string as the first parameter and an optional image size of type integer as the second parameter. Returns an object of type Texture2D corresponding to the specified avatar ID and image size.
        ///</summary>
        public async Task<Texture2D> GetAvatarImage(string avatarId, int imgSize = 256)
        {
            var result = await asyncGetAvatarImage(avatarId, imgSize);
            return result;
        }

        private async Task<Texture2D> asyncGetAvatarImage(string avatarId, int imgSize = 256)
        {
            string uri = "";
            if (imgSize == 256)
            {
                uri = api + "cards/avatar/" + avatarId + ".png";
            }
            else if (imgSize == 512)
            {
                uri = api + "cards/avatarHD/" + avatarId + ".png";
            }
            else
            {
                Debug.Log("Please enter a valid image size.");
            }

            UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                return null;
            else
            {
                var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                return texture;
            }
        }

        ///<summary>
        ///Takes in a pack slug of type string as the first parameter and an optional image size of type integer as the second parameter. Returns an object of type Texture2D corresponding to the specified pack slug and image size.
        ///</summary>
        public async Task<Texture2D> GetPackImage(string packSlug, int imgSize = 256)
        {
            var result = await asyncGetPackImage(packSlug, imgSize);
            return result;
        }

        private async Task<Texture2D> asyncGetPackImage(string packSlug, int imgSize = 256)
        {
            string uri = "";
            if (imgSize == 256)
            {
                uri = api + "cards/icon/" + packSlug + ".png";
            }
            else if (imgSize == 512)
            {
                uri = api + "cards/icon/" + packSlug + "@2x.png";
            }
            else
            {
                Debug.Log("Please enter a valid image size.");
            }

            UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                return null;
            else
            {
                var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                return texture;
            }
        }

        ///<summary>
        ///Takes in an app slug of type string and returns an object of type Texture2D corresponding to the specified app slug.
        ///</summary>
        public async Task<Texture2D> GetAppIcon(string appSlug)
        {
            var result = await asyncGetAppIcon(appSlug);
            return result;
        }

        private async Task<Texture2D> asyncGetAppIcon(string appSlug)
        {

            string uri = api + "apps/icon/" + appSlug + "@3x.png";

            UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                return null;
            else
            {
                var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                return texture;
            }
        }

        ///<summary>
        ///Takes in a pack slug of type string as the first parameter, a card slug of type string as the second parameter and an optional image size of type integer as the third parameter. Returns an object of type Texture2D corresponding to the specified pack slug, card slug and image size.
        ///</summary>
        public async Task<Texture2D> GetCardImage(string packSlug, string cardSlug, int imgSize = 256)
        {
            var result = await asyncGetCardImage(packSlug, cardSlug, imgSize);
            return result;
        }

        private async Task<Texture2D> asyncGetCardImage(string packSlug, string cardSlug, int imgSize = 256)
        {
            string uri = "";
            if (imgSize == 256)
            {
                uri = api + "cards/" + packSlug + "/" + cardSlug + ".png";
            }
            else if (imgSize == 512)
            {
                uri = api + "cards/" + packSlug + "/" + cardSlug + "@2x.png";
            }
            else
            {
                Debug.Log("Please enter a valid image size.");
            }

            UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                return null;
            else
            {
                var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                return texture;
            }
        }

        ///<summary>
        ///Returns an object of type Apps which holds an array of App objects.
        ///</summary>
        public async Task<Apps> GetApps()
        {
            var result = await asyncGetApps();
            return result;
        }

        private async Task<Apps> asyncGetApps()
        {
            UnityWebRequest request = UnityWebRequest.Get(metadata);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                return null;
            else
            {
                var apps = JsonUtility.FromJson<Apps>(request.downloadHandler.text);
                return apps;
            }
        }

        ///<summary>
        ///Takes in an object of type Packs as the first parameter and a pack slug of type string as the second parameter. Filters the given array of packs and returns an object of type Pack corresponding to the specified pack slug.
        ///</summary>
        public Pack GetPackBySlug(Packs packs, string packSlug)
        {

            for (int i = 0; i < packs.packs.Length; i++)
            {
                if (packs.packs[i].slug == packSlug)
                    return packs.packs[i];
            }
            return null;
        }

        ///<summary>
        ///Takes in an object of type Cards as the first parameter and a card slug of type string as the second parameter. Filters the given array of cards and returns an object of type Card corresponding to the specified card slug.
        ///</summary>
        public Card GetCardBySlug(Cards cards, string cardSlug)
        {
            for (int i = 0; i < cards.cards.Length; i++)
            {
                if (cards.cards[i].slug == cardSlug)
                    return cards.cards[i];
            }
            return null;
        }

        ///<summary>
        ///Takes in an object of type Activities as the first parameter and a activity slug of type string as the second parameter. Filters the given array of activities and returns an object of type Activity corresponding to the specified activity slug.
        ///</summary>
        public Activity GetActivityBySlug(Activities activities, string slug)
        {
            for (int i = 0; i < activities.activities.Length; i++)
            {
                if (activities.activities[i].slug == slug)
                    return activities.activities[i];
            }
            return null;
        }

        ///<summary>
        ///Takes in an object of type Languages as the first parameter and a language code of type string as the second parameter. Filters the given array of languages and returns an object of type Language corresponding to the specified language code.
        ///</summary>
        public Language GetLanguageByCode(Languages languages, string languageCode)
        {
            for (int i = 0; i < languages.languages.Length; i++)
            {
                if (languages.languages[i].code == languageCode)
                    return languages.languages[i];
            }
            return null;
        }

        ///<summary>
        ///Takes in a language code of type string as the first parameter, a pack slug of type string as the second parameter and an optional image size of type integer as the third parameter. Returns an array of Texture2D objects corresponding to the specified language, pack slug and image size.
        ///</summary>
        public async Task<Texture2D[]> GetCardImagesByPack(string languageCode, string packSlug, int imgSize = 256)
        {
            var cards = await GetCards(languageCode, packSlug);
            Texture2D[] textures = new Texture2D[cards.cards.Length];
            for (int i = 0; i < cards.cards.Length; i++)
            {
                textures[i] = await GetCardImage(packSlug, cards.cards[i].slug);
            }
            return textures;
        }

        ///<summary>
        ///Takes in a category of type string as the first parameter and an optional image size of type integer as the second parameter. Returns an array of Texture2D objects corresponding to the specified category and image size.
        ///</summary>
        public async Task<Texture2D[]> GetAvatarImagesByCategory(string category, int imgSize = 256)
        {
            Texture2D[] textures;
            if (category == "boy")
            {
                textures = new Texture2D[boyAvatarArrayLength];

                for (int i = 0; i < boyAvatarArrayLength; i++)
                {
                    textures[i] = await GetAvatarImage("boy" + (i + 1).ToString("D2"));
                }
                return textures;
            }
            else if (category == "girl")
            {
                textures = new Texture2D[girlAvatarArrayLength];

                for (int i = 0; i < girlAvatarArrayLength; i++)
                {
                    textures[i] = await GetAvatarImage("girl" + (i + 1).ToString("D2"));
                }
                return textures;
            }
            else if (category == "misc")
            {
                textures = new Texture2D[miscAvatarArrayLength];

                for (int i = 0; i < miscAvatarArrayLength; i++)
                {
                    textures[i] = await GetAvatarImage("misc" + (i + 1).ToString("D2"));
                }
                return textures;
            }
            return null;
        }
    }

    public class SettingsAPI
    {
        GameAPI.AssistiveCardsSDK assistiveCardsSDK = new GameAPI.AssistiveCardsSDK();

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
            return PlayerPrefs.GetString("Nickname", "");
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
            return PlayerPrefs.GetString("Language", Application.systemLanguage.ToString());
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
            return PlayerPrefs.GetInt("UsabilityTipsPreference", 1);
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
            // await cacheData;
            // var availableVoices = GameAPI.tts.GetAvailableVoices(GameAPI.tts.voices, GameAPI.selectedLangCode);
            return PlayerPrefs.GetString("TTSPreference", "Default");
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

        public void ClearAllPrefs()
        {
            PlayerPrefs.DeleteAll();
        }

    }

    public class LanguageManager
    {
        AssistiveCardsSDK assistiveCardsSDK = new AssistiveCardsSDK();
        SettingsAPI settingsAPI = new SettingsAPI();

        [Serializable]
        public class IDs
        {
            public string hello_you;
            public string settings_packs;
            public string settings_cards;
            public string this_is_test_voice;
            public string settings_selection_account;
            public string settings_account_description;
            public string settings_account_section1_title;
            public string settings_account_section1_description;
            public string settings_change_avatar_title;
            public string settings_change_avatar_description;
            public string settings_selection_language;
            public string settings_language_description;
            public string settings_language_basedOnYourDevice;
            public string settings_language_basedOnYourDevice_description;
            public string settings_language_supportedLanguages;
            public string settings_language_supportedLanguages_description;
            public string settings_selection_accent;
            public string settings_accent_description;
            public string settings_selection_voice;
            public string settings_voice_description;
            public string settings_voice_basedOnYourLocation;
            public string settings_voice_basedOnYourLocation_description;
            public string settings_voice_supportedVoice;
            public string settings_voice_supportedVoice_description;
            public string settings_selection_notifications;
            public string settings_notifications_description;
            public string settings_notifications_reminders;
            public string settings_notifications_reminders_description;
            public string settings_notifications_reminders_daily;
            public string settings_notifications_reminders_daily_description;
            public string settings_notifications_reminders_weekly;
            public string settings_notifications_reminders_weekly_description;
            public string settings_notifications_tipsAndPromo;
            public string settings_notifications_tipsAndPromo_description;
            public string settings_notifications_tipsAndPromo_tips;
            public string settings_notifications_tipsAndPromo_tips_description;
            public string settings_notifications_tipsAndPromo_promotion;
            public string settings_notifications_tipsAndPromo_promotion_description;
            public string settings_selection_subscriptions;
            public string settings_subscriptions_description;
            public string settings_subscriptions_cancel_notice;
            public string settings_subscriptions_downgrade_notice;
            public string settings_subscriptions_oneTimePayment;
            public string settings_subscriptions_recurringPayment;
            public string settings_selection_apps;
            public string settings_selection_apps_new;
            public string settings_apps_description;
            public string settings_selection_signout;
            public string settings_selection_sendFeedback;
            public string settings_selection_openSourceLicenses;
            public string settings_selection_privacyPolicy;
            public string settings_selection_termsOfService;
            public string settings_selection_removeMyData;
            public string settings_selection_aboutapp;
            public string settings_aboutapp_description;
            public string settings_selection_company;
            public string settings_selection_accessibility;
            public string settings_accessibility_description;
            public string settings_accessibility_sensory;
            public string settings_accessibility_sensory_description;
            public string settings_accessibility_sensory_haptic;
            public string settings_accessibility_sensory_haptic_description;
            public string settings_accessibility_sensory_pressIn;
            public string settings_accessibility_sensory_pressIn_description;
            public string settings_accessibility_greeding_on_start;
            public string settings_accessibility_greeding_on_start_description;
            public string settings_removeMyData_description;
            public string settings_removeMyData_p1;
            public string settings_removeMyData_p2;
            public string settings_removeMyData_p3;
            public string settings_removeMyData_p4;
            public string settings_removeMyData_button;
            public string settings_locked_title;
            public string settings_locked_description;
            public string settings_share_title;
            public string settings_share_message;
            public string settings_share_url;
            public string settings_selection_share_the_app;
            public string settings_selection_rate_the_app;
            public string settings_profile_active;
            public string settings_restore_purchases;
            public string settings_restore_purchases_desc;
            public string settings_restore_purchases_final;
            public string settings_redeem_promo;
            public string settings_redeem_promo_desc;
            public string setup_create_profile_title;
            public string setup_create_profile_description;
            public string setup_your_name;
            public string setup_avatar_title;
            public string setup_avatar_description;
            public string setup_label_boy;
            public string setup_label_girl;
            public string setup_label_mixed;
            public string setup_notification_title;
            public string setup_notification_description;
            public string setup_notification_badge_title;
            public string setup_notification_badge_description;
            public string setup_congrats_title;
            public string setup_congrats_description;
            public string setup_welcome_description;
            public string search_input_placeholder;
            public string training_button_skip;
            public string training_button_listen;
            public string training_tip;
            public string training_button_choose;
            public string training_button_restart;
            public string training_title_great_work;
            public string training_desc_done;
            public string home_title;
            public string home_premium;
            public string home_settings;
            public string premium_title;
            public string premium_description;
            public string premium_monthly;
            public string premium_yearly;
            public string premium_yearly_sub;
            public string premium_then_info;
            public string premium_lifetime;
            public string premium_lifetime_oneTime;
            public string premium_save_percent;
            public string premium_monthly_priceShow;
            public string premium_yearly_priceShow;
            public string premium_see_title;
            public string premium_see_description;
            public string premium_card_count;
            public string premium_phrase_count;
            public string premium_trial_title;
            public string premium_trial_description;
            public string premium_details1;
            public string premium_details2;
            public string premium_details3;
            public string premium_details4;
            public string premium_details5;
            public string premium_promo_title;
            public string premium_promo_desc1;
            public string premium_promo_desc2;
            public string card_header_subtitle;
            public string card_button_start_training;
            public string button_next;
            public string button_start;
            public string button_use;
            public string button_using;
            public string button_add;
            public string button_remove;
            public string button_get_started;
            public string edit_profile;
            public string alert_yourDeviceDoesNotSupportTTS;
            public string alert_ok;
            public string alert_cancel;
            public string congrats_title;
            public string congrats_description;
            public string yesterday;
            public string today;
            public string tomorrow;
            public string yesterday_add;
            public string today_add;
            public string tomorrow_add;
            public string no_tasks_yet;
            public string no_tasks_yet_desc;
            public string add_tasks_title;
            public string edit_list;
            public string complete_editing;
        }

        public async Task<string> Translate(string UITextID)
        {
            string code = await GetSystemLanguageCode();
            var path = Application.dataPath + "/Resources/" + code + ".json";
            string contents = File.ReadAllText(path);
            JSONObject obj = new JSONObject(contents);
            return obj[UITextID].ToString().Replace("\"", "");
        }

        public async Task<string> Translate(string UITextID, string variable)
        {
            string code = await GetSystemLanguageCode();
            var path = Application.dataPath + "/Resources/" + code + ".json";
            string contents = File.ReadAllText(path);
            JSONObject obj = new JSONObject(contents);
            return (obj[UITextID].ToString().Replace("$1", variable)).Replace("\"", "");
        }

        public async Task<string> GetSystemLanguageCode()
        {
            var langs = await assistiveCardsSDK.GetLanguages();
            var selectedLang = settingsAPI.GetLanguage();

            foreach (var lang in langs.languages)
            {
                if (selectedLang == lang.title)
                {
                    return lang.code;
                }
            }
            return null;
        }
    }
}
