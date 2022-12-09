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
        languageElementButton.onClick.AddListener(delegate ()
        {
            OnClick(language);
        });
    }
}
public class SupportedLanguagesPanel : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private DeviceLanguagePanel deviceLanguagePanel;
    public GameObject deviceLanguageObject;
    private LanguageController languageController;
    private AssistiveCardsSDK.AssistiveCardsSDK.Language[] languageArray;
    private GameObject languageTempElement;
    private GameObject languageElement;
    public List<GameObject> languageGameobjects = new List<GameObject>();

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        languageTempElement = transform.GetChild(0).gameObject;
        languageController = GetComponentInParent<LanguageController>();
    }

    private async void Start()
    {
        AssistiveCardsSDK.AssistiveCardsSDK.Languages languages = new AssistiveCardsSDK.AssistiveCardsSDK.Languages();
        languages = await gameAPI.GetLanguages();

        languageArray = languages.languages;

        for (int i = 0; i < languageArray.Length; i++)
        {
            languageElement = Instantiate(languageTempElement, transform);

            languageElement.transform.GetChild(1).GetComponent<Text>().text = languageArray[i].title;
            languageElement.transform.GetChild(2).GetComponent<TMP_Text>().text = languageArray[i].native;
            languageElement.name = languageArray[i].title;
            languageGameobjects.Add(languageElement);

            if (languageArray[i].title == Application.systemLanguage.ToString())
            {
                deviceLanguageObject = languageElement;

                deviceLanguagePanel.CreateSelectLanguageElement(deviceLanguageObject);
            }
            if (languageArray[i].title == gameAPI.GetLanguage())
            {
                languageElement.GetComponent<Toggle>().isOn = true;
                deviceLanguagePanel.CreateSelectLanguageElement(languageElement);
            }
        }
        Destroy(languageTempElement);
    }
}
