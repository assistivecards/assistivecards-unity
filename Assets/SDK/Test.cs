using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameAPI.Pack packResult = new GameAPI.Pack();
    [SerializeField] GameAPI.Activity activityResult = new GameAPI.Activity();
    [SerializeField] GameAPI.Language languageResult = new GameAPI.Language();
    GameAPI gameAPI;
    // public TMP_InputField outputArea;
    [SerializeField] Texture2D[] cardTextures;
    [SerializeField] Texture2D[] avatarTextures;
    [SerializeField] private Texture2D testTexture;
    [SerializeField] private GameAPI.Cards cardsTest;

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
        testTexture = await gameAPI.GetPackImage("animals");
        cardsTest = await gameAPI.GetCards(await gameAPI.GetSystemLanguageCode(), "sports");
        cardTextures = await gameAPI.GetCardImagesByPack("en", "school");
        avatarTextures = await gameAPI.GetAvatarImagesByCategory("misc");
        packResult = gameAPI.GetPackBySlug(gameAPI.cachedPacks, "animals");
        activityResult = gameAPI.GetActivityBySlug(gameAPI.cachedActivities, "practicing-speaking");
        languageResult = gameAPI.GetLanguageByCode(gameAPI.cachedLanguages, "en");
    }

}