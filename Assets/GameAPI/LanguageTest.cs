using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageTest : MonoBehaviour
{
    GameAPI.SettingsAPI settingsAPI = new GameAPI.SettingsAPI();
    GameAPI.LanguageManager languageManager = new GameAPI.LanguageManager();
    [SerializeField] TMP_Text[] texts;
    [SerializeField] TMP_Text[] textsWithVariable;
    string result;
    private string nickname;
    private int usabilityTips;
    private ArrayList variableArray = new ArrayList();

    private void Awake()
    {
        usabilityTips = settingsAPI.GetUsabilityTipsPreference();
    }
    async void Start()
    {
        nickname = settingsAPI.GetNickname();
        variableArray.Add(nickname);
        variableArray.Add(usabilityTips);

        for (int i = 0; i < textsWithVariable.Length; i++)
        {
            result = await languageManager.Translate(textsWithVariable[i].text, variableArray[i].ToString());
            textsWithVariable[i].text = result;
        }

        foreach (var text in texts)
        {
            result = await languageManager.Translate(text.text);
            text.text = result;
        }
    }

}
