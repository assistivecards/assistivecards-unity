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
    [SerializeField] GameObject[] texts;
    [SerializeField] GameObject[] textsWithVariable;
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
        texts = GameObject.FindGameObjectsWithTag("Plain Text");
        textsWithVariable = GameObject.FindGameObjectsWithTag("Text With Variable");
        // packResult = assistiveCardsSDK.GetPackBySlug(gameAPI.cachedPacks, "animals");
        // Debug.Log(packResult.locale);
        variableArray.Add(nickname);
        variableArray.Add(usabilityTips);

        for (int i = 0; i < textsWithVariable.Length; i++)
        {
            result = await languageManager.Translate(textsWithVariable[i].name, variableArray[i].ToString());
            textsWithVariable[i].GetComponent<TMP_Text>().text = result;
        }

        foreach (var text in texts)
        {
            result = await languageManager.Translate(text.name);
            text.GetComponent<TMP_Text>().text = result;
        }
    }

    async public void ChangeLanguage()
    {
        settingsAPI.SetLanguage(languageInputField.text);
        Speakable.locale = await languageManager.GetSelectedLocale();
    }

    public async void OnLanguageChange()
    {
        for (int i = 0; i < textsWithVariable.Length; i++)
        {
            result = await languageManager.Translate(textsWithVariable[i].name, variableArray[i].ToString());
            textsWithVariable[i].GetComponent<TMP_Text>().text = result;
        }

        foreach (var text in texts)
        {
            result = await languageManager.Translate(text.name);
            text.GetComponent<TMP_Text>().text = result;
        }
    }

}
