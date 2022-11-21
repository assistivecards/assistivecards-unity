using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    GameAPI gameAPI;
    AssistiveCardsSDK.AssistiveCardsSDK assistiveCardsSDK;
    public TMP_InputField outputArea;
    public RawImage rawImage;
    public TMP_InputField avatarImageSizeInput;
    public TMP_InputField avatarIdInput;
    public TMP_InputField packImageSizeInput;
    public TMP_InputField packSlugInput;
    public TMP_InputField cardImagePackSlugInput;
    public TMP_InputField cardImageCardSlugInput;
    public TMP_InputField cardImageSizeInput;
    public TMP_InputField cardLanguageInput;
    public TMP_InputField cardPackSlugInput;
    public TMP_InputField languageCodeInput;
    public TMP_InputField activitySlugInput;
    public TMP_InputField cardBySlugInput;
    public TMP_InputField packBySlugInput;

    private void Awake()
    {
        assistiveCardsSDK = Camera.main.GetComponent<AssistiveCardsSDK.AssistiveCardsSDK>();
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        cardImageSizeInput.text = "256";
        avatarImageSizeInput.text = "256";
        packImageSizeInput.text = "256";
    }

    public async void DisplayPacks(string language)
    {
        var result = await gameAPI.GetPacks(language);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public async void DisplayCards()
    {
        var language = cardLanguageInput.text;
        var packSlug = cardPackSlugInput.text;
        var result = await gameAPI.GetCards(language, packSlug);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public async void DisplayLanguages()
    {
        var result = await gameAPI.GetLanguages();
        outputArea.text = JsonUtility.ToJson(result);
    }

    public async void DisplayActivities(string language)
    {
        var result = await gameAPI.GetActivities(language);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public async void DisplayActivityImage(string activitySlug)
    {
        var texture = await gameAPI.GetActivityImage(activitySlug);
        rawImage.texture = texture;
    }

    public async void DisplayAvatarImage()
    {
        var id = avatarIdInput.text;
        int size = Int32.Parse(avatarImageSizeInput.text);
        var texture = await gameAPI.GetAvatarImage(id, size);
        rawImage.texture = texture;
    }

    public async void DisplayPackImage()
    {
        var slug = packSlugInput.text;
        int size = Int32.Parse(packImageSizeInput.text);
        var texture = await gameAPI.GetPackImage(slug, size);
        rawImage.texture = texture;
    }

    public async void DisplayCardImage()
    {
        var packSlug = cardImagePackSlugInput.text;
        var cardSlug = cardImageCardSlugInput.text;
        int size = Int32.Parse(cardImageSizeInput.text);
        var texture = await gameAPI.GetCardImage(packSlug, cardSlug, size);
        rawImage.texture = texture;
    }

    public async void DisplayAppIcon(string appSlug)
    {
        var texture = await gameAPI.GetAppIcon(appSlug);
        rawImage.texture = texture;
    }

    public async void DisplayApps()
    {
        var result = await gameAPI.GetApps();
        outputArea.text = JsonUtility.ToJson(result);
    }

    public void DisplayPackBySlug()
    {
        var result = gameAPI.GetPackBySlug(gameAPI.cachedPacks, packBySlugInput.text);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public void DisplayCardBySlug()
    {
        var result = gameAPI.GetCardBySlug(assistiveCardsSDK.cards, cardBySlugInput.text);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public void DisplayActivityBySlug()
    {
        var result = gameAPI.GetActivityBySlug(gameAPI.cachedActivities, activitySlugInput.text);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public void DisplayLanguageByCode()
    {
        var result = gameAPI.GetLanguageByCode(gameAPI.cachedLanguages, languageCodeInput.text);
        outputArea.text = JsonUtility.ToJson(result);
    }
}
