using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.Events;

public class LanguageController : MonoBehaviour
{
    public GameObject selectedLanguage; 
    public UnityEvent newLanguageSelected;
    private SupportedLanguagesPanel supportedLanguagesPanel;
    private DeviceLanguagePanel deviceLanguagePanel;
    [SerializeField] private Material inactiveRadioButtoMaterial;
    [SerializeField] private Material appBackgroundMatrial;
    [SerializeField] private Button saveButton;

    private void Awake() 
    {
        supportedLanguagesPanel = GetComponentInChildren<SupportedLanguagesPanel>();
        deviceLanguagePanel = GetComponentInChildren<DeviceLanguagePanel>();
    }

    public void SelectLanguageElement(GameObject _languageElement)
    {   
        foreach(GameObject language in supportedLanguagesPanel.languageGameobjects)
        {
            language.transform.GetChild(2).GetComponent<Image>().material = inactiveRadioButtoMaterial;
        }     
        deviceLanguagePanel.languageElement.transform.GetChild(2).GetComponent<Image>().material = inactiveRadioButtoMaterial;

        saveButton.interactable = true;
        selectedLanguage = _languageElement;
        selectedLanguage.transform.GetChild(2).GetComponent<Image>().material = appBackgroundMatrial;

        newLanguageSelected.Invoke();
    }
}
