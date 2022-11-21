using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Pack packResult = new AssistiveCardsSDK.AssistiveCardsSDK.Pack();
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Activity activityResult = new AssistiveCardsSDK.AssistiveCardsSDK.Activity();
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Language languageResult = new AssistiveCardsSDK.AssistiveCardsSDK.Language();
    GameAPI gameAPI;
    // public TMP_InputField outputArea;
    [SerializeField] Texture2D[] cardTextures;
    [SerializeField] Texture2D[] avatarTextures;
    [SerializeField] private Texture2D testTexture;
    [SerializeField] private AssistiveCardsSDK.AssistiveCardsSDK.Cards cardsTest;
    [SerializeField] private List<string> locales;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    // private async void CacheData()
    // {
    //     var t1 = assistiveCardsSDK.GetPacks("en");
    //     var t2 = assistiveCardsSDK.GetCards("en", "animals");
    //     var t3 = assistiveCardsSDK.GetLanguages();
    //     var t4 = assistiveCardsSDK.GetActivities("en");
    //     packs = await t1;
    //     cards = await t2;
    //     languages = await t3;
    //     activities = await t4;
    // }

    private async void Start()
    {
        locales = await gameAPI.GetSystemLanguageLocales();
        testTexture = await gameAPI.GetPackImage("animals");
        cardsTest = await gameAPI.GetCards(await gameAPI.GetSystemLanguageCode(), "sports");
        cardTextures = await gameAPI.GetCardImagesByPack("en", "school");
        avatarTextures = await gameAPI.GetAvatarImagesByCategory("misc");
        packResult = gameAPI.GetPackBySlug(gameAPI.cachedPacks, "animals");
        activityResult = gameAPI.GetActivityBySlug(gameAPI.cachedActivities, "practicing-speaking");
        languageResult = gameAPI.GetLanguageByCode(gameAPI.cachedLanguages, "en");
    }

}