using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LanguageTest : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] TMP_Text[] texts;
    [SerializeField] Text[] legacyTexts;
    [SerializeField] List<TMP_Text> plainTexts;
    [SerializeField] List<Text> plainLegacyTexts;
    [SerializeField] List<TMP_Text> textsWithVariable;
    [SerializeField] TMP_InputField languageInputField;
    [SerializeField] TMP_InputField localeInputField;
    [SerializeField] Canvas canvas;
    string result;
    private string nickname;
    private string completedPack;
    private int usabilityTips;
    private ArrayList mainCanvasVariableArray = new ArrayList();
    private ArrayList gameCanvasVariableArray = new ArrayList();

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        nickname = gameAPI.GetNickname();
        usabilityTips = gameAPI.GetUsabilityTipsPreference();
    }

    async void Start()
    {

        var langCode = await gameAPI.GetSystemLanguageCode();
        texts = canvas.GetComponentsInChildren<TMP_Text>(true);
        legacyTexts = canvas.GetComponentsInChildren<Text>(true);
        foreach (var text in texts)
        {
            if (text.tag == "Plain Text")
            {
                plainTexts.Add(text);
            }
            else if (text.tag == "Text With Variable")
            {
                textsWithVariable.Add(text);
            }
        }

        foreach (var text in legacyTexts)
        {
            if (text.tag == "Plain Text")
            {
                plainLegacyTexts.Add(text);
            }
        }

        // mainCanvasVariableArray.Add(gameAPI.ToSentenceCase(Application.productName));
        // mainCanvasVariableArray.Add(gameAPI.ToSentenceCase(Application.productName));
        mainCanvasVariableArray.Add(nickname);
        gameCanvasVariableArray.Add(nickname);

        if (gameObject.name == "Settings")
        {
            for (int i = 0; i < textsWithVariable.Count; i++)
            {
                result = gameAPI.Translate(textsWithVariable[i].name, mainCanvasVariableArray[i].ToString(), langCode);
                textsWithVariable[i].GetComponent<TMP_Text>().text = result;
            }
        }
        else if (gameObject.name == "GameCanvas")
        {
            for (int i = 0; i < textsWithVariable.Count; i++)
            {
                result = gameAPI.Translate(textsWithVariable[i].name, gameCanvasVariableArray[i].ToString(), langCode);
                textsWithVariable[i].GetComponent<TMP_Text>().text = result;
            }
        }

        foreach (var text in plainTexts)
        {
            result = gameAPI.Translate(text.name, langCode);
            text.GetComponent<TMP_Text>().text = result;
        }

        foreach (var text in plainLegacyTexts)
        {
            result = gameAPI.Translate(text.name, langCode);
            text.GetComponent<Text>().text = result;
        }

    }

    async public void ChangeLanguage()
    {
        gameAPI.SetLanguage(languageInputField.text);
        Speakable.locale = await gameAPI.GetSelectedLocale();
    }

    async public void ChangeTTS()
    {
        gameAPI.SetTTSPreference(localeInputField.text);
        Speakable.locale = await gameAPI.GetTTSPreference();
    }

    public async void OnLanguageChange()
    {
        Speakable.locale = await gameAPI.GetSelectedLocale();
        var langCode = await gameAPI.GetSystemLanguageCode();

        if (gameObject.name == "Settings")
        {
            for (int i = 0; i < textsWithVariable.Count; i++)
            {
                result = gameAPI.Translate(textsWithVariable[i].name, mainCanvasVariableArray[i].ToString(), langCode);
                textsWithVariable[i].GetComponent<TMP_Text>().text = result;
            }
        }
        else if (gameObject.name == "GameCanvas")
        {
            for (int i = 0; i < textsWithVariable.Count; i++)
            {
                result = gameAPI.Translate(textsWithVariable[i].name, gameCanvasVariableArray[i].ToString(), langCode);
                textsWithVariable[i].GetComponent<TMP_Text>().text = result;
            }
        }

        foreach (var text in plainTexts)
        {
            result = gameAPI.Translate(text.name, langCode);
            text.GetComponent<TMP_Text>().text = result;
        }

        foreach (var text in plainLegacyTexts)
        {
            result = gameAPI.Translate(text.name, langCode);
            text.GetComponent<Text>().text = result;
        }
    }

    public async void OnTTSChange()
    {
        Speakable.locale = await gameAPI.GetTTSPreference();
    }

    public async void OnNicknameChange()
    {
        var langCode = await gameAPI.GetSystemLanguageCode();
        nickname = gameAPI.GetNickname();

        mainCanvasVariableArray.Clear();
        gameCanvasVariableArray.Clear();
        // mainCanvasVariableArray.Add(gameAPI.ToSentenceCase(Application.productName));
        // mainCanvasVariableArray.Add(gameAPI.ToSentenceCase(Application.productName));
        mainCanvasVariableArray.Add(nickname);
        gameCanvasVariableArray.Add(nickname);

        if (gameObject.name == "Settings")
        {
            for (int i = 0; i < textsWithVariable.Count; i++)
            {
                result = gameAPI.Translate(textsWithVariable[i].name, mainCanvasVariableArray[i].ToString(), langCode);
                textsWithVariable[i].GetComponent<TMP_Text>().text = result;
            }
        }
        else if (gameObject.name == "GameCanvas")
        {
            for (int i = 0; i < textsWithVariable.Count; i++)
            {
                result = gameAPI.Translate(textsWithVariable[i].name, gameCanvasVariableArray[i].ToString(), langCode);
                textsWithVariable[i].GetComponent<TMP_Text>().text = result;
            }
        }

    }

}
