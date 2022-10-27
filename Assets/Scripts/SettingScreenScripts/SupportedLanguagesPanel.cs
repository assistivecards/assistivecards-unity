using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

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
public class SupportedLanguagesPanel : MonoBehaviour
{
    AssistiveCardsSDK assistiveCardsSDK;
    public TMP_InputField outputArea;
    private LanguageController languageController;
    [SerializeField] private Material inactiveRadioButtoMaterial;
    [SerializeField] private Material appBackgroundMatrial;
    private AssistiveCardsSDK.Language[] languageArray;
    private GameObject languageTemplateElement;
    private GameObject languageElement;
    public List<GameObject> languageGameobjects = new List<GameObject>();

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
        
        for(int i=0 ; i < languageArray.Length; i++)
        {
            languageElement = Instantiate(languageTemplateElement, transform);

            languageElement.transform.GetChild(2).GetComponent<Image>().material = inactiveRadioButtoMaterial;
            languageElement.transform.GetChild(0).GetComponent<TMP_Text> ().text = languageArray[i].title;
            languageElement.transform.GetChild(1).GetComponent<TMP_Text> ().text = languageArray[i].native; 
            languageElement.name = languageArray[i].title;

            languageGameobjects.Add(languageElement);

            languageElement.GetComponent<Button>().AddEventListener  (languageElement, languageController.SelectLanguageElement);       
        }

        Destroy(languageTemplateElement);
    }
}
