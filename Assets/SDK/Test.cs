using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{

    private AssistiveCardsSDK.Languages languages = new AssistiveCardsSDK.Languages();
    private AssistiveCardsSDK.Packs packs = new AssistiveCardsSDK.Packs();
    private AssistiveCardsSDK.Activities activities = new AssistiveCardsSDK.Activities();
    private AssistiveCardsSDK.Cards cards = new AssistiveCardsSDK.Cards();
    [SerializeField] AssistiveCardsSDK.Pack packResult = new AssistiveCardsSDK.Pack();
    [SerializeField] AssistiveCardsSDK.Card cardResult = new AssistiveCardsSDK.Card();
    [SerializeField] AssistiveCardsSDK.Activity activityResult = new AssistiveCardsSDK.Activity();
    [SerializeField] AssistiveCardsSDK.Language languageResult = new AssistiveCardsSDK.Language();
    AssistiveCardsSDK assistiveCardsSDK;
    public TMP_InputField outputArea;
    [SerializeField] private Texture2D testTexture;

    private void Awake()
    {
        assistiveCardsSDK = outputArea.GetComponent<AssistiveCardsSDK>();
        CacheData();
    }

    private async void CacheData()
    {
        var t1 = assistiveCardsSDK.GetPacks("en");
        var t2 = assistiveCardsSDK.GetCards("en", "animals");
        var t3 = assistiveCardsSDK.GetLanguages();
        var t4 = assistiveCardsSDK.GetActivities("en");
        packs = await t1;
        cards = await t2;
        languages = await t3;
        activities = await t4;
    }

    private async void Start()
    {
        testTexture = await assistiveCardsSDK.GetPackImage("animals", 512);
        packResult = assistiveCardsSDK.GetPackBySlug(packs, "animals");
        cardResult = assistiveCardsSDK.GetCardBySlug(cards, "bee");
        languageResult = assistiveCardsSDK.GetLanguageByCode(languages, "en");
        activityResult = assistiveCardsSDK.GetActivityBySlug(activities, "practicing-speaking");
    }
}