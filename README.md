# unity-template

Template for unity games made by Assistive Cards

# AssistiveCards SDK

This is a documentation for the AssistiveCards SDK, this module will be accessible from anywhere in game.

## GetPacks

Takes in a language code of type string and returns an object of type Packs which holds an array of Pack objects in the specified language.

```Csharp
async Task<Packs> GetPacks(string language)
```

Example usage;

```Csharp
Packs packs = new Packs();
packs = await GetPacks("en");
```

## GetCards

Takes in a language code and a pack slug of type string as parameters. Returns an object of type Cards which holds an array of Card objects in the specified pack and language.

```Csharp
async Task<Cards> GetCards(string language, string packSlug)
```

Example usage;

```Csharp
Cards cards = new Cards();
cards = await GetCards("en", "animals");
```

## GetActivities

Takes in a language code of type string and returns an object of type Activities which holds an array of Activity objects in the specified language.

```Csharp
async Task<Activities> GetActivities(string language)
```

Example usage;

```Csharp
Activities activities = new Activities();
activities = await GetActivities("en");
```

## GetLanguages

Returns an object of type Languages which holds an array of Language objects.

```Csharp
async Task<Languages> GetLanguages()
```

Example usage;

```Csharp
Languges languages = new Languages();
languages = await GetLanguages();
```

## GetPackBySlug

Takes in an object of type Packs as the first parameter and a pack slug of type string as the second parameter. Filters the given array of packs and returns an object of type Pack corresponding to the specified pack slug.

```Csharp
Pack GetPackBySlug(Packs packs, string packSlug)
```

Example usage;

```Csharp
Pack pack = new Pack();
pack = GetPackBySlug(packs, "animals");
```

## GetCardBySlug

Takes in an object of type Cards as the first parameter and a card slug of type string as the second parameter. Filters the given array of cards and returns an object of type Card corresponding to the specified card slug.

```Csharp
Card GetCardBySlug(Cards cards, string cardSlug)
```

Example usage;

```Csharp
Card card = new Card();
card = GetCardBySlug(cards, "bee");
```

## GetActivityBySlug

Takes in an object of type Activities as the first parameter and an activity slug of type string as the second parameter. Filters the given array of activities and returns an object of type Activity corresponding to the specified activity slug.

```Csharp
Activity GetActivityBySlug(Activities activities, string slug)
```

Example usage;

```Csharp
Activity activity = new Activity();
activity = GetActivityBySlug(activities, "practicing-speaking");
```

## GetLanguageByCode

Takes in an object of type Languages as the first parameter and a language code of type string as the second parameter. Filters the given array of languages and returns an object of type Language corresponding to the specified language code.

```Csharp
Language GetLanguageByCode(Languages languages, string languageCode)
```

Example usage;

```Csharp
Language language = new Language();
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
async Task<Apps> GetApps()
```

Example usage;

```Csharp
Apps apps = new Apps();
apps = await GetApps();
```

## GetAppIcon

Takes in an app slug of type string and returns an object of type Texture2D corresponding to the specified app slug.

```Csharp
async Task<Texture2D> GetAppIcon(string appSlug)
```

Example usage;

```Csharp
Texture2D texture;
texture = await GetAppIcon("leeloo");
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

# Settings API

This is a documentation for the AssistiveCards Settings API, used for storing user preferences.

## SetNickname

Takes in a nickname of type string and stores it in PlayerPrefs.

```Csharp
public void SetNickname(string nickname)
```

## GetNickname

Retrieves the nickname data stored in PlayerPrefs.

> Default value is "John Doe".

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

> Default value is "English".

```Csharp
public string GetLanguage()
```

## SetAvatarImage

Takes in an avatarID of type string and stores it in PlayerPrefs.

```Csharp
public void SetAvatarImage(string avatarID)
```

## GetAvatarImage

Returns a sprite corresponding to the avatarID data stored in PlayerPrefs.

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

> Default value is 0.

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

Retrieves the TTS voice preference data stored in PlayerPrefs.

> Default value is "Alex".

```Csharp
public string GetTTSPreference()
```

## SetHapticsPreference

Takes in a single parameter of type integer named isHapticsActive and stores it in PlayerPrefs.

```Csharp
public void SetHapticsPreference(int isHapticsActive)
```

## GetHapticsPreference

Retrieves the haptics preference data stored in PlayerPrefs.

> Default value is 0.

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

> Default value is 0.

```Csharp
public int GetVoiceGreetingPreference()
```
