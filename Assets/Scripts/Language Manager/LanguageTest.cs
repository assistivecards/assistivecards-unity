using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageTest : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] TMP_Text[] texts;
    [SerializeField] List<TMP_Text> plainTexts;
    [SerializeField] List<TMP_Text> textsWithVariable;
    [SerializeField] TMP_InputField languageInputField;
    [SerializeField] TMP_InputField localeInputField;
    [SerializeField] Canvas canvas;
    string result;
    private string nickname;
    private string completedPack;
    private int usabilityTips;
    private ArrayList variableArray = new ArrayList();

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        nickname = gameAPI.GetNickname();
        usabilityTips = gameAPI.GetUsabilityTipsPreference();
    }
    async void Start()
    {
        // texts = GameObject.FindGameObjectsWithTag("Plain Text");
        var langCode = await gameAPI.GetSystemLanguageCode();
        texts = canvas.GetComponentsInChildren<TMP_Text>(true);
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
        // textsWithVariable = GameObject.FindGameObjectsWithTag("Text With Variable");
        // packResult = assistiveCardsSDK.GetPackBySlug(gameAPI.cachedPacks, "animals");
        // Debug.Log(packResult.locale);
        variableArray.Add(nickname);
        variableArray.Add(usabilityTips);

        for (int i = 0; i < textsWithVariable.Count; i++)
        {
            result = gameAPI.Translate(textsWithVariable[i].name, variableArray[i].ToString(), langCode);
            textsWithVariable[i].GetComponent<TMP_Text>().text = result;
        }

        foreach (var text in plainTexts)
        {
            result = gameAPI.Translate(text.name, langCode);
            text.GetComponent<TMP_Text>().text = result;
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
        var langCode = await gameAPI.GetSystemLanguageCode();
        for (int i = 0; i < textsWithVariable.Count; i++)
        {
            result = gameAPI.Translate(textsWithVariable[i].name, variableArray[i].ToString(), langCode);
            textsWithVariable[i].GetComponent<TMP_Text>().text = result;
        }

        foreach (var text in plainTexts)
        {
            result = gameAPI.Translate(text.name, langCode);
            text.GetComponent<TMP_Text>().text = result;
        }
    }

}
