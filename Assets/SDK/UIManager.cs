using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject SDK;
    AssistiveCardsSDK assistiveCardsSDK;
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

    private void Start()
    {
        assistiveCardsSDK = SDK.GetComponent<AssistiveCardsSDK>();
        cardImageSizeInput.text = "256";
        avatarImageSizeInput.text = "256";
        packImageSizeInput.text = "256";
    }

    public async void DisplayPacks(string language)
    {
        var result = await assistiveCardsSDK.GetPacks(language);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public async void DisplayCards()
    {
        var language = cardLanguageInput.text;
        var packSlug = cardPackSlugInput.text;
        var result = await assistiveCardsSDK.GetCards(language, packSlug);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public async void DisplayLanguages()
    {
        var result = await assistiveCardsSDK.GetLanguages();
        outputArea.text = JsonUtility.ToJson(result);
    }

    public async void DisplayActivities(string language)
    {
        var result = await assistiveCardsSDK.GetActivities(language);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public async void DisplayActivityImage(string activitySlug)
    {
        var texture = await assistiveCardsSDK.GetActivityImage(activitySlug);
        rawImage.texture = texture;
    }

    public async void DisplayAvatarImage()
    {
        var id = avatarIdInput.text;
        int size = Int32.Parse(avatarImageSizeInput.text);
        var texture = await assistiveCardsSDK.GetAvatarImage(id, size);
        rawImage.texture = texture;
    }

    public async void DisplayPackImage()
    {
        var slug = packSlugInput.text;
        int size = Int32.Parse(packImageSizeInput.text);
        var texture = await assistiveCardsSDK.GetPackImage(slug, size);
        rawImage.texture = texture;
    }

    public async void DisplayCardImage()
    {
        var packSlug = cardImagePackSlugInput.text;
        var cardSlug = cardImageCardSlugInput.text;
        int size = Int32.Parse(cardImageSizeInput.text);
        var texture = await assistiveCardsSDK.GetCardImage(packSlug, cardSlug, size);
        rawImage.texture = texture;
    }

    public async void DisplayAppIcon(string appSlug)
    {
        var texture = await assistiveCardsSDK.GetAppIcon(appSlug);
        rawImage.texture = texture;
    }

    public async void DisplayApps()
    {
        var result = await assistiveCardsSDK.GetApps();
        outputArea.text = JsonUtility.ToJson(result);
    }

    public void DisplayPackBySlug()
    {
        var result = assistiveCardsSDK.GetPackBySlug(assistiveCardsSDK.packs, packBySlugInput.text);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public void DisplayCardBySlug()
    {
        var result = assistiveCardsSDK.GetCardBySlug(assistiveCardsSDK.cards, cardBySlugInput.text);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public void DisplayActivityBySlug()
    {
        var result = assistiveCardsSDK.GetActivityBySlug(assistiveCardsSDK.activities, activitySlugInput.text);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public void DisplayLanguageByCode()
    {
        var result = assistiveCardsSDK.GetLanguageByCode(assistiveCardsSDK.languages, languageCodeInput.text);
        outputArea.text = JsonUtility.ToJson(result);
    }
}
