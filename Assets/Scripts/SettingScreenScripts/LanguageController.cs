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
    private DeviceLanguagePanel deviceLanguagePanel;
    [SerializeField] private RightToLeftTextChanger rightToLeftTextChanger;
    [SerializeField] private Button saveButton;


    private void Start() {
        deviceLanguagePanel = GetComponentInChildren<DeviceLanguagePanel>();
    }

    public void SelectLanguageElement(GameObject _languageElement)
    {   
        saveButton.interactable = true;
        selectedLanguage = _languageElement;

        deviceLanguagePanel.CreateSelectLanguageElement(_languageElement);
    }
}
