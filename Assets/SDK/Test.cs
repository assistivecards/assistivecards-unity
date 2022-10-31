using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameAPI.AssistiveCardsSDK.Pack packResult = new GameAPI.AssistiveCardsSDK.Pack();
    [SerializeField] GameAPI.AssistiveCardsSDK.Card cardResult = new GameAPI.AssistiveCardsSDK.Card();
    [SerializeField] GameAPI.AssistiveCardsSDK.Activity activityResult = new GameAPI.AssistiveCardsSDK.Activity();
    [SerializeField] GameAPI.AssistiveCardsSDK.Language languageResult = new GameAPI.AssistiveCardsSDK.Language();
    GameAPI.AssistiveCardsSDK assistiveCardsSDK = new GameAPI.AssistiveCardsSDK();
    GameAPI gameAPI;
    // public TMP_InputField outputArea;
    [SerializeField] Texture2D[] cardTextures;
    [SerializeField] Texture2D[] avatarTextures;
    [SerializeField] private Texture2D testTexture;

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
        testTexture = await assistiveCardsSDK.GetPackImage("animals");
        cardTextures = await assistiveCardsSDK.GetCardImagesByPack("en", "school");
        avatarTextures = await assistiveCardsSDK.GetAvatarImagesByCategory("misc");
        packResult = assistiveCardsSDK.GetPackBySlug(gameAPI.cachedPacks, "animals");
        activityResult = assistiveCardsSDK.GetActivityBySlug(gameAPI.cachedActivities, "practicing-speaking");
        languageResult = assistiveCardsSDK.GetLanguageByCode(gameAPI.cachedLanguages, "en");
    }

}