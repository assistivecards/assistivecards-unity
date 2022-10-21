using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public static class SelectLanguage
{
    public static void AddEventListener<T>(this Button languageElementButton, T language, Action<T> OnClick)
    {
        languageElementButton.onClick.AddListener(delegate()
        {
            OnClick(language);
        });
    }
}
public class LanguageController : MonoBehaviour
{
    public static List<Language> languagesTestList = new List<Language>();
    private GameObject languageTemplateElement;
    private GameObject languageElement;

    private Color purple = new Color(0.3882353f, 0.427451f, 0.7098039f, 1);
    private Color gray = new Color(0.7735849f, 0.7735849f, 0.7735849f, 0.4901961f);
    private bool isSaveButtonActive = false;


    private void Start() 
    {
        languagesTestList.AddRange(new List<Language>{
            new Language("Turkish", false, "Türkçe"),
            new Language("English", false, "English"),
        });


        languageTemplateElement = transform.GetChild(0).gameObject;
        
        for(int i=0 ; i < languagesTestList.Count; i++)
        {
            languageElement = Instantiate(languageTemplateElement, transform);

            languageElement.transform.GetChild(0).GetComponent<TMP_Text> ().text = languagesTestList[i].LanguageName;
            languageElement.transform.GetChild(1).GetComponent<TMP_Text> ().text = languagesTestList[i].LocalName; 
            languageElement.name = languagesTestList[i].LanguageName;

            languageElement.GetComponent<Button>().AddEventListener  (languageElement.GetComponent<Language>(), SelectLanguageElement);       
        }

        Destroy(languageTemplateElement);
    }

    public void SelectLanguageElement(Language _languageElement)
    {
        
        if(!_languageElement.IsSelected)
        {
            _languageElement.IsSelected = true;
            _languageElement.transform.GetChild(2).GetComponent<Image>().color = purple;
        }
        else if(_languageElement.IsSelected)
        {
            _languageElement.IsSelected = false;
            _languageElement.transform.GetChild(2).GetComponent<Image>().color = gray;
        }

        
    }
}
