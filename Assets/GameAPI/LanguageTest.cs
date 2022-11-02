using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageTest : MonoBehaviour
{
    GameAPI.SettingsAPI settingsAPI = new GameAPI.SettingsAPI();
    GameAPI gameAPI;
    GameAPI.AssistiveCardsSDK assistiveCardsSDK = new GameAPI.AssistiveCardsSDK();
    GameAPI.LanguageManager languageManager = new GameAPI.LanguageManager();
    [SerializeField] TMP_Text[] texts;
    [SerializeField] TMP_Text[] textsWithVariable;
    [SerializeField] TMP_InputField languageInputField;
    string result;
    private string nickname;
    private string completedPack;
    private int usabilityTips;
    private ArrayList variableArray = new ArrayList();

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        nickname = settingsAPI.GetNickname();
        usabilityTips = settingsAPI.GetUsabilityTipsPreference();
    }
    async void Start()
    {
        // packResult = assistiveCardsSDK.GetPackBySlug(gameAPI.cachedPacks, "animals");
        // Debug.Log(packResult.locale);
        variableArray.Add(nickname);
        variableArray.Add(usabilityTips);

        for (int i = 0; i < textsWithVariable.Length; i++)
        {
            result = await languageManager.Translate(textsWithVariable[i].name, variableArray[i].ToString());
            textsWithVariable[i].text = result;
        }

        foreach (var text in texts)
        {
            result = await languageManager.Translate(text.name);
            text.text = result;
        }
    }

    public void ChangeLanguage()
    {
        settingsAPI.SetLanguage(languageInputField.text);
    }

    public async void OnLanguageChange()
    {
        for (int i = 0; i < textsWithVariable.Length; i++)
        {
            result = await languageManager.Translate(textsWithVariable[i].name, variableArray[i].ToString());
            textsWithVariable[i].text = result;
        }

        foreach (var text in texts)
        {
            result = await languageManager.Translate(text.name);
            text.text = result;
        }
    }

}
