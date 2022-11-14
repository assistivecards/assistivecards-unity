using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeviceLanguagePanel : MonoBehaviour
{
    [SerializeField] private SupportedLanguagesPanel supportedLanguagesPanel;
    [SerializeField] private GameObject selectedLanguageDummy;
    AssistiveCardsSDK assistiveCardsSDK;
    public TMP_InputField outputArea;
    private LanguageController languageController;

    private void Awake() 
    {
        assistiveCardsSDK = outputArea.GetComponent<AssistiveCardsSDK>();
        languageController = GetComponentInParent<LanguageController>();
        
    }

    public void CreateSelectLanguageElement(GameObject _selectedLanguage)
    {
        if(_selectedLanguage.name == Application.systemLanguage.ToString())
        {
            transform.GetChild(0).GetComponent<Toggle>().isOn = true;
            transform.GetChild(0).GetChild(1).GetComponent<Text>().text = _selectedLanguage.transform.GetChild(1).GetComponent<Text>().text;
            transform.GetChild(0).GetChild(2).GetComponent<Text>().text = _selectedLanguage.transform.GetChild(2).GetComponent<Text>().text;
        }
        else if(_selectedLanguage.name != Application.systemLanguage.ToString())
        {
            Debug.Log(_selectedLanguage.name);
            selectedLanguageDummy.SetActive(true);
            selectedLanguageDummy.GetComponent<Toggle>().isOn = true;
            selectedLanguageDummy.transform.GetChild(1).GetComponent<Text>().text = _selectedLanguage.transform.GetChild(1).GetComponent<Text>().text;
            selectedLanguageDummy.transform.GetChild(2).GetComponent<Text>().text = _selectedLanguage.transform.GetChild(2).GetComponent<Text>().text;
        }
    }
}
