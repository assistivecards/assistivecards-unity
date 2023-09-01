# AssistiveCards Unity

Template for unity games made by Assistive Cards

> "Casual Game Music" and "Casual Game Sounds" packs are not licensed under the GNU General Public License v3.0

# GameAPI

This is a documentation for GameAPI, which is the combination of Assistive Cards SDK, Settings API and Language Manager scripts. This module will be accessible from anywhere in game. GameAPI consists of methods for retrieving assets data, storing user preferences and translating UI elements at runtime.

## CheckConnectionStatus

Returns an object of type Status which holds information about network connection.

```Csharp
async Task<AssistiveCardsSDK.AssistiveCardsSDK.Status> CheckConnectionStatus()
```

Example usage;

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Status status = new AssistiveCardsSDK.AssistiveCardsSDK.Status();
status = await CheckConnectionStatus();
```

## GetPacks

Takes in a language code of type string and returns an object of type Packs which holds an array of Pack objects in the specified language.

```Csharp
async Task<AssistiveCardsSDK.AssistiveCardsSDK.Packs> GetPacks(string language)
```

Example usage;

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Packs packs = new AssistiveCardsSDK.AssistiveCardsSDK.Packs();
packs = await GetPacks("en");
```

## GetCards

Takes in a language code and a pack slug of type string as parameters. Returns an object of type Cards which holds an array of Card objects in the specified pack and language.

```Csharp
async Task<AssistiveCardsSDK.AssistiveCardsSDK.Cards> GetCards(string language, string packSlug)
```

Example usage;

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Cards cards = new AssistiveCardsSDK.AssistiveCardsSDK.Cards();
cards = await GetCards("en", "animals");
```

## GetActivities

Takes in a language code of type string and returns an object of type Activities which holds an array of Activity objects in the specified language.

```Csharp
async Task<AssistiveCardsSDK.AssistiveCardsSDK.Activities> GetActivities(string language)
```

Example usage;

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Activities activities = new AssistiveCardsSDK.AssistiveCardsSDK.Activities();
activities = await GetActivities("en");
```

## GetLanguages

Returns an object of type Languages which holds an array of Language objects.

```Csharp
async Task<AssistiveCardsSDK.AssistiveCardsSDK.Languages> GetLanguages()
```

Example usage;

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Languges languages = new AssistiveCardsSDK.AssistiveCardsSDK.Languages();
languages = await GetLanguages();
```

## GetPackBySlug

Takes in an object of type Packs as the first parameter and a pack slug of type string as the second parameter. Filters the given array of packs and returns an object of type Pack corresponding to the specified pack slug.

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Pack GetPackBySlug(AssistiveCardsSDK.AssistiveCardsSDK.Packs packs, string packSlug)
```

Example usage;

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Pack pack = new AssistiveCardsSDK.AssistiveCardsSDK.Pack();
pack = GetPackBySlug(packs, "animals");
```

## GetCardBySlug

Takes in an object of type Cards as the first parameter and a card slug of type string as the second parameter. Filters the given array of cards and returns an object of type Card corresponding to the specified card slug.

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Card GetCardBySlug(AssistiveCardsSDK.AssistiveCardsSDK.Cards cards, string cardSlug)
```

Example usage;

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Card card = new AssistiveCardsSDK.AssistiveCardsSDK.Card();
card = GetCardBySlug(cards, "bee");
```

## GetActivityBySlug

Takes in an object of type Activities as the first parameter and an activity slug of type string as the second parameter. Filters the given array of activities and returns an object of type Activity corresponding to the specified activity slug.

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Activity GetActivityBySlug(AssistiveCardsSDK.AssistiveCardsSDK.Activities activities, string slug)
```

Example usage;

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Activity activity = new AssistiveCardsSDK.AssistiveCardsSDK.Activity();
activity = GetActivityBySlug(activities, "practicing-speaking");
```

## GetLanguageByCode

Takes in an object of type Languages as the first parameter and a language code of type string as the second parameter. Filters the given array of languages and returns an object of type Language corresponding to the specified language code.

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Language GetLanguageByCode(AssistiveCardsSDK.AssistiveCardsSDK.Languages languages, string languageCode)
```

Example usage;

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Language language = new AssistiveCardsSDK.AssistiveCardsSDK.Language();
language = GetLanguageByCode(languages, "en");
```

## GetPackImage

Takes in a pack slug of type string as the first parameter and an image size of type integer as the second parameter. Returns an object of type Texture2D corresponding to the specified pack slug and image size.

```Csharp
async Task<Texture2D> GetPackImage(string packSlug, int imgSize)
```

Example usage;

```Csharp
Texture2D texture;
texture = await GetPackImage("animals", 512);
```

## GetCardImage

Takes in a pack slug of type string as the first parameter, a card slug of type string as the second parameter and an image size of type integer as the third parameter. Returns an object of type Texture2D corresponding to the specified pack slug, card slug and image size.

```Csharp
async Task<Texture2D> GetCardImage(string packSlug, string cardSlug, int imgSize)
```

Example usage;

```Csharp
Texture2D texture;
texture = await GetCardImage("animals", "bee", 512);
```

## GetActivityImage

Takes in an activity slug of type string and returns an object of type Texture2D corresponding to the specified activity slug.

> Note that the image size is 1200x800

```Csharp
async Task<Texture2D> GetActivityImage(string activitySlug)
```

Example usage;

```Csharp
Texture2D texture;
texture = await GetActivityImage("brushing-teeth");
```

## GetAvatarImage

Takes in an avatar ID of type string as the first parameter and an image size of type integer as the second parameter. Returns an object of type Texture2D corresponding to the specified avatar ID and image size.

> Note that avatar types have a maximum of 33 assets for the category "boy", 27 assets for the category "girl" and 29 assets for the category "misc".
> <span style="color:crimson">e.g.</span> boy13, girl23, misc05

```Csharp
async Task<Texture2D> GetAvatarImage(string avatarId, int imgSize)
```

Example usage;

```Csharp
Texture2D texture;
texture = await GetAvatarImage("girl23",512);
```

## GetApps

Returns an object of type Apps which holds an array of App objects.

```Csharp
async Task<AssistiveCardsSDK.AssistiveCardsSDK.Apps> GetApps()
```

Example usage;

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Apps apps = new AssistiveCardsSDK.AssistiveCardsSDK.Apps();
apps = await GetApps();
```

## GetAppIcon

Takes in an app slug of type string as the first parameter and an optional image size of type integer as the second parameter. Returns an object of type Texture2D corresponding to the specified app slug and image size.

> Default image size is 1024x1024

```Csharp
async Task<Texture2D> GetAppIcon(string appSlug, int imgSize)
```

Example usage;

```Csharp
Texture2D texture;
texture = await GetAppIcon("leeloo", 683);
```

## GetGames

Returns an object of type Games which holds an array of Game objects.

```Csharp
public AssistiveCardsSDK.AssistiveCardsSDK.Games GetGames()
```

Example usage;

```Csharp
AssistiveCardsSDK.AssistiveCardsSDK.Games games = new AssistiveCardsSDK.AssistiveCardsSDK.Games();
games = GetGames();
```

## GetGameIcon

Takes in a game slug of type string as the first parameter and an optional image size of type integer as the second parameter. Returns an object of type Texture2D corresponding to the specified game slug and image size.

> Default image size is 1024x1024

```Csharp
public async Task<Texture2D> GetGameIcon(string gameSlug, int imgSize)
```

Example usage;

```Csharp
Texture2D texture;
texture = await GetGameIcon("memory", 256);
```

## GetCardImagesByPack

Takes in a language code of type string as the first parameter, a pack slug of type string as the second parameter and an optional image size of type integer as the third parameter. Returns an array of Texture2D objects corresponding to the specified language, pack slug and image size.

> Default image size is 256x256

```Csharp
async Task<Texture2D[]> GetCardImagesByPack(string languageCode, string packSlug, int imgSize)
```

Example usage;

```Csharp
Texture2D[] textures;
texture = await GetCardImagesByPack("en", "school", 512);
```

## GetAvatarImagesByCategory

Takes in a category of type string as the first parameter and an optional image size of type integer as the second parameter. Returns an array of Texture2D objects corresponding to the specified category and image size.

> Default image size is 256x256

```Csharp
async Task<Texture2D[]> GetAvatarImagesByCategory(string category, int imgSize)
```

Example usage;

```Csharp
Texture2D[] textures;
texture = await GetAvatarImagesByCategory("misc",512);
```

## SetNickname

Takes in a nickname of type string and stores it in PlayerPrefs.

```Csharp
public void SetNickname(string nickname)
```

## GetNickname

Retrieves the nickname data stored in PlayerPrefs.

> Default value is "".

```Csharp
public string GetNickname()
```

## SetLanguage

Takes in a language of type string and stores it in PlayerPrefs.

```Csharp
public void SetLanguage(string language)
```

## GetLanguage

Retrieves the language data stored in PlayerPrefs.

> Default value is system language.

```Csharp
public string GetLanguage()
```

## SetAvatarImage

Takes in an avatarID of type string and stores it in PlayerPrefs.

```Csharp
public void SetAvatarImage(string avatarID)
```

## GetAvatarImage

Retrieves a sprite corresponding to the avatarID data stored in PlayerPrefs.

> Default value is "default".

```Csharp
public async Task<Sprite> GetAvatarImage()
```

## SetReminderPreference

Takes in a period of type string and stores it in PlayerPrefs.

```Csharp
public void SetReminderPreference(string period)
```

## GetReminderPreference

Retrieves the reminder period preference data stored in PlayerPrefs.

> Default value is "Weekly".

```Csharp
public string GetReminderPreference()
```

## SetUsabilityTipsPreference

Takes in a single parameter of type integer named isUsabilityTipsActive and stores it in PlayerPrefs.

```Csharp
public void SetUsabilityTipsPreference(int isUsabilityTipsActive)
```

## GetUsabilityTipsPreference

Retrieves the usability tips preference data stored in PlayerPrefs.

> Default value is 1.

```Csharp
public int GetUsabilityTipsPreference()
```

## SetPromotionsNotificationPreference

Takes in a single parameter of type integer named isPromotionsNotificationActive and stores it in PlayerPrefs.

```Csharp
public void SetPromotionsNotificationPreference(int isPromotionsNotificationActive)
```

## GetPromotionsNotificationPreference

Retrieves the promotions notification preference data stored in PlayerPrefs.

> Default value is 0.

```Csharp
public int GetPromotionsNotificationPreference()
```

## SetTTSPreference

Takes in a single parameter of type string named TTSPreference and stores it in PlayerPrefs.

```Csharp
public void SetTTSPreference(string TTSPreference)
```

## GetTTSPreference

Retrieves the TTS preference data stored in PlayerPrefs.

> Default value is locale of the system language.

```Csharp
async public Task<string> GetTTSPreference()
```

## SetHapticsPreference

Takes in a single parameter of type integer named isHapticsActive and stores it in PlayerPrefs.

```Csharp
public void SetHapticsPreference(int isHapticsActive)
```

## GetHapticsPreference

Retrieves the haptics preference data stored in PlayerPrefs.

> Default value is 1.

```Csharp
public int GetHapticsPreference()
```

## SetActivateOnPressInPreference

Takes in a single parameter of type integer named isPressInActive and stores it in PlayerPrefs.

```Csharp
public void SetActivateOnPressInPreference(int isPressInActive)
```

## GetActivateOnPressInPreference

Retrieves the activate on press in preference data stored in PlayerPrefs.

> Default value is 0.

```Csharp
public int GetActivateOnPressInPreference()
```

## SetVoiceGreetingPreference

Takes in a single parameter of type integer named isVoiceGreetingActive and stores it in PlayerPrefs.

```Csharp
public void SetVoiceGreetingPreference(int isVoiceGreetingActive)
```

## GetVoiceGreetingPreference

Retrieves the voice greeting on start preference data stored in PlayerPrefs.

> Default value is 1.

```Csharp
public int GetVoiceGreetingPreference()
```

## SetPremium

Takes in a single parameter of type string named isPremium and stores it in PlayerPrefs.

```Csharp
public void SetPremium(string isPremium)
```

## GetPremium

Retrieves the premium status data stored in PlayerPrefs.

> Default value is 0.

```Csharp
public string GetPremium()
```

## SetSubscription

Takes in a single parameter of type string named isSubscribed and stores it in PlayerPrefs.

```Csharp
public void SetSubscription(string isSubscribed)
```

## GetSubscription

Retrieves the subscription status data stored in PlayerPrefs.

> Default value is 0.

```Csharp
public string GetSubscription()
```

## SetSFXPreference

Takes in a single parameter of type integer named isSFXOn and stores it in PlayerPrefs.

```Csharp
public void SetSFXPreference(int isSFXOn)
```

## GetSFXPreference

Retrieves the SFX preference data stored in PlayerPrefs.

> Default value is 1.

```Csharp
public int GetSFXPreference()
```

## SetMusicPreference

Takes in a single parameter of type integer named isMusicOn and stores it in PlayerPrefs.

```Csharp
public void SetMusicPreference(int isMusicOn)
```

## GetMusicPreference

Retrieves the music preference data stored in PlayerPrefs.

> Default value is 1.

```Csharp
public int GetMusicPreference()
```

## SetTTSStatusPreference

Takes in a single parameter of type integer named isTTSOn and stores it in PlayerPrefs.

```Csharp
public void SetTTSStatusPreference(int isTTSOn)
```

## GetTTSStatusPreference

Retrieves the TTS status preference data stored in PlayerPrefs.

> Default value is 1.

```Csharp
public int GetTTSStatusPreference()
```

## SetExp

Takes in a single parameter of type integer named totalExp and stores it in PlayerPrefs.

```Csharp
public void SetExp(int totalExp)
```

## GetExp

Retrieves the total experience point stored in PlayerPrefs.

> Default value is 0.

```Csharp
public int GetExp()
```

## AddExp

Takes in a single parameter of type integer named exp and adds it to the total experience point stored in PlayerPrefs.

```Csharp
public void AddExp(int exp)
```

## RemoveExp

Takes in a single parameter of type integer named exp,fits it into a range and adds it to the total experience point stored in PlayerPrefs.

```Csharp
public void RemoveExp(int exp)
```

## CalculateExp

Takes in a single parameter of type integer named level and calculates the total experience point required.

```Csharp
public int CalculateExp(int level)
```

## CalculateLevel

Takes in a single parameter of type integer named exp and calculates the corresponding level.

```Csharp
public int CalculateLevel(int exp)
```

## AddSessionExp

Adds the amount of exp set via inspector to the total experience point of the current session.

```Csharp
public void AddSessionExp()
```

## RemoveSessionExp

Subtracts the amount of exp set via inspector from the total experience point of the current session.

```Csharp
public void RemoveSessionExp()
```

## ResetSessionExp

Resets the total experience point of the current session to 0.

```Csharp
public void ResetSessionExp()
```

## ClearAllPrefs

Deletes all the data stored in PlayerPrefs on sign out.

```Csharp
public void ClearAllPrefs()
```

## GetSystemLanguageCode

Returns the language code corresponding to the language data stored in PlayerPrefs.

> <span style="color:crimson">e.g.</span> "en" for English, "tr" for Turkish etc.

```Csharp
public async Task<string> GetSystemLanguageCode()
```

## GetSelectedLocale

Returns the locale corresponding to the language data stored in PlayerPrefs.

> <span style="color:crimson">e.g.</span> "en-US" for English, "tr-TR" for Turkish etc.

```Csharp
public async Task<string> GetSelectedLocale()
```

## GetSystemLanguageLocales

Returns the list of all available locales corresponding to the language data stored in PlayerPrefs.

> <span style="color:crimson">e.g.</span> "en-US", "en-GB", "en-AU", "en-CA", "en-CB", "en-IN", "en-NZ" for English, "fr-FR", "fr-CA" for French etc.

```Csharp
public async Task<List<string>> GetSystemLanguageLocales()
```

## Translate

Takes in a single parameter of type string named UITextID and returns the translation corresponding to the selected language which is stored in PlayerPrefs.

> Use this method for plain texts.

```Csharp
public async Task<string> Translate(string UITextID)
```

Takes in a first parameter of type string named UITextID and a second parameter of type string named variable. Returns the translation corresponding to the selected language which is stored in PlayerPrefs.

> Use this method for texts with variables.

```Csharp
public async Task<string> Translate(string UITextID, string variable)
```

## ForceOrientation

Takes in a single parameter of type string named orientationMode and forces the screen orientation accordingly.

> <span style="color:crimson">e.g.</span> "portrait", to force portrait orientation, "landscape" to force landscape orientaiton.

```Csharp
public void ForceOrientation(string orientationMode)
```

## PlayMusic

Plays an audio clip according to the music preference data stored in PlayerPrefs.

```Csharp
public void PlayMusic()
```

## PlaySFX

Takes in a single parameter of type string named clipName and plays the corresponding audio clip, according to the SFX preference data stored in PlayerPrefs.

```Csharp
public void PlaySFX(string clipName)
```

## VibrateWeak

Makes the device vibrate for 50ms.

```Csharp
public void VibrateWeak()
```

## VibrateStrong

Makes the device vibrate for 100ms.

```Csharp
public void VibrateStrong()
```

## VibrateWeakTriple

Makes the device vibrate three times, 50ms each.

```Csharp
public void VibrateWeakTriple()
```

## Speak

Takes in a single parameter of type string named text and passes it to TTS GameObject's Speak() function.

```Csharp
public void Speak(string text)
```
