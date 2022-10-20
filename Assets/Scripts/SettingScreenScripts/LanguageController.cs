using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class LanguageController : MonoBehaviour
{
    private struct Language
    {
        private string language;
    }
    public static List<string> languagesTestList = new List<string>();
    private GameObject languageTemplateElement;

    private GameObject languageElement;

    private void Start() 
    {

        languagesTestList.Add("Turkish");
        languagesTestList.Add("English");

        languageTemplateElement = transform.GetChild(0).gameObject;
        
        for(int i=0 ; i < languagesTestList.Count; i++)
        {
            Debug.Log(languagesTestList[i]);
            languageElement = Instantiate(languageTemplateElement, transform);
            languageElement.transform.GetChild(0).GetComponent<TMP_Text> ().text = languagesTestList[i];
            languageElement.transform.GetChild(1).GetComponent<TMP_Text> ().text = languagesTestList[i]; // native name of the language will be here

            //languageElement.GetComponent<Button>().onClick.AddListener(); // choosing language action
            
        }

        Destroy(languageTemplateElement);
    }
}
