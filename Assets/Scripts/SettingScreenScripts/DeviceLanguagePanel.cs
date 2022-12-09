using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeviceLanguagePanel : MonoBehaviour
{
    [SerializeField] private SupportedLanguagesPanel supportedLanguagesPanel;
    private string deviceLanguage;
    private GameObject tempSelectedLanguage;

    public GameObject deviceLanguageObject;

    private void Awake() 
    {
        deviceLanguage = Application.systemLanguage.ToString();       
    }

    public void CreateSelectLanguageElement(GameObject _selectedLanguage)
    {
        if(_selectedLanguage.name == deviceLanguage)
        {
            _selectedLanguage.transform.parent = this.transform;
            deviceLanguageObject = _selectedLanguage;
        }
        else
        {
            if(tempSelectedLanguage != null)
            {
                tempSelectedLanguage.transform.parent = supportedLanguagesPanel.transform;
                _selectedLanguage.transform.parent = this.transform;
                tempSelectedLanguage = _selectedLanguage;

            }
            else
            {
                tempSelectedLanguage = _selectedLanguage;
            }
        }
    }

}
