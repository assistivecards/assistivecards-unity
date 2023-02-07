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
    GameAPI gameAPI;
    public GameObject selectedLanguage; 
    private DeviceLanguagePanel deviceLanguagePanel;

    private void Start() 
    {
        deviceLanguagePanel = GetComponentInChildren<DeviceLanguagePanel>();
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void SelectLanguageElement(GameObject _languageElement)
    {   
        selectedLanguage = _languageElement;

        //deviceLanguagePanel.CreateSelectLanguageElement(_languageElement);
    }
}
