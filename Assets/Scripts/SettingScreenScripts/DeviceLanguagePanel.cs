using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeviceLanguagePanel : MonoBehaviour
{
    AssistiveCardsSDK assistiveCardsSDK;
    public GameObject languageElement;
    public GameObject dummyLanguageElement;
    public TMP_InputField outputArea;
    public List<GameObject> languageGameobjects = new List<GameObject>();
    private LanguageController languageController;
    [SerializeField] private Material appBackgroundMatrial;
    private AssistiveCardsSDK.Language[] languageArray;
    private GameObject languageTemplateElement;

    private void Awake() 
    {
        assistiveCardsSDK = outputArea.GetComponent<AssistiveCardsSDK>();

        languageTemplateElement = transform.GetChild(0).gameObject;
        languageController = GetComponentInParent<LanguageController>();
    }

    private async void Start() 
    {
        var languages = await assistiveCardsSDK.GetLanguages();
        languageArray = languages.languages;

        foreach(AssistiveCardsSDK.Language language in languageArray)
        {
            if(language.title == Application.systemLanguage.ToString())
            {
                languageTemplateElement.transform.GetChild(2).GetComponent<Image>().material = appBackgroundMatrial;
                languageElement = Instantiate(languageTemplateElement, transform);

                languageElement.transform.GetChild(0).GetComponent<TMP_Text> ().text = language.title;
                languageElement.transform.GetChild(1).GetComponent<TMP_Text> ().text = language.native; 
                languageElement.name = language.title;

                languageGameobjects.Add(languageElement);

                Destroy(languageTemplateElement);

                if(languageController.selectedLanguage == null)
                {
                    languageController.selectedLanguage = languageElement;
                }
                languageElement.GetComponent<Button>().AddEventListener  (languageElement, languageController.SelectLanguageElement);
            }
        }

            dummyLanguageElement = Instantiate(languageElement, transform);
            dummyLanguageElement.transform.GetChild(2).GetComponent<Image>().material = null;
            dummyLanguageElement.transform.GetChild(0).GetComponent<TMP_Text> ().text = null;
            dummyLanguageElement.transform.GetChild(1).GetComponent<TMP_Text> ().text = null; 
            
            languageGameobjects.Add(languageElement);
    }

    public void NewLanguageSelected()
    {
        foreach(AssistiveCardsSDK.Language language in languageArray)
        {
            if(language.title == languageController.selectedLanguage.name && language.title != Application.systemLanguage.ToString())
            {
                dummyLanguageElement.transform.GetChild(2).GetComponent<Image>().material = appBackgroundMatrial;
                dummyLanguageElement.transform.GetChild(0).GetComponent<TMP_Text> ().text = language.title;
                dummyLanguageElement.transform.GetChild(1).GetComponent<TMP_Text> ().text = language.native; 
                dummyLanguageElement.name = language.title;
            }
            else if(languageController.selectedLanguage.name == Application.systemLanguage.ToString())
            {
                dummyLanguageElement.transform.GetChild(2).GetComponent<Image>().material = null;
                dummyLanguageElement.transform.GetChild(0).GetComponent<TMP_Text> ().text = null;
                dummyLanguageElement.transform.GetChild(1).GetComponent<TMP_Text> ().text = null; 
            }
        }
    }
}
