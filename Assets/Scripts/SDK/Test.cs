using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Pack packResult = new AssistiveCardsSDK.AssistiveCardsSDK.Pack();
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Activity activityResult = new AssistiveCardsSDK.AssistiveCardsSDK.Activity();
    [SerializeField] AssistiveCardsSDK.AssistiveCardsSDK.Language languageResult = new AssistiveCardsSDK.AssistiveCardsSDK.Language();
    GameAPI gameAPI;
    [SerializeField] Texture2D[] cardTextures;
    [SerializeField] Texture2D[] avatarTextures;
    [SerializeField] private Texture2D testTexture;
    [SerializeField] private AssistiveCardsSDK.AssistiveCardsSDK.Cards cardsTest;
    [SerializeField] private List<string> locales;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();

    }

    private async void Start()
    {
        await gameAPI.CachePacks();
        await gameAPI.CacheData();
        packResult = gameAPI.GetPackBySlug(gameAPI.cachedPacks, "animals");
        activityResult = gameAPI.GetActivityBySlug(gameAPI.cachedActivities, "practicing-speaking");
        languageResult = gameAPI.GetLanguageByCode(gameAPI.cachedLanguages, "en");
        locales = await gameAPI.GetSystemLanguageLocales();
        testTexture = await gameAPI.GetPackImage("animals");
        cardsTest = await gameAPI.GetCards(await gameAPI.GetSystemLanguageCode(), "sports");
        cardTextures = await gameAPI.GetCardImagesByPack("en", "school");
        avatarTextures = await gameAPI.GetAvatarImagesByCategory("misc");
    }

}