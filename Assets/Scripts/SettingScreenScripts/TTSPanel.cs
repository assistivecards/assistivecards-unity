using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TTSPanel : MonoBehaviour
{
    [SerializeField] private GameObject tempTtsElement;
    [SerializeField] private Button saveButton;
    public List<string> ttsElements = new List<string>();
    private GameObject ttsElement;
    public GameObject selectedTtsElement;
    public List<GameObject> ttsElementGameObject = new List<GameObject>();
    private GameAPI gameAPI;
    public static bool didLanguageChange = true;
    public bool loadingCompleted;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }


    private async void OnEnable()
    {
        if (didLanguageChange)
        {
            var currentLang = gameAPI.GetLanguage();
            var currentTTS = await gameAPI.GetTTSPreference();

            tempTtsElement.SetActive(true);

            ttsElements.Clear();
            if (ttsElementGameObject.Count != 0)
            {
                foreach (var item in ttsElementGameObject)
                {
                    Destroy(item);
                }
                ttsElementGameObject.Clear();
            }

            ttsElements = await gameAPI.GetSystemLanguageLocales();


            for (int i = 0; i < ttsElements.Count; i++)
            {
                ttsElement = Instantiate(tempTtsElement, transform);

                ttsElement.transform.GetChild(1).GetComponent<Text>().text = currentLang;
                ttsElement.transform.GetChild(2).GetComponent<Text>().text = ttsElements[i];
                ttsElement.transform.GetChild(3).GetComponent<Text>().text = null;

                ttsElement.name = ttsElements[i];
                ttsElementGameObject.Add(ttsElement);

                if (ttsElements[i] == currentTTS)
                {
                    ttsElement.GetComponent<Toggle>().isOn = true;
                    selectedTtsElement = ttsElement;
                }
            }

            tempTtsElement.SetActive(false);
            didLanguageChange = false;
            loadingCompleted = true;
        }

    }


    public void TTSSelected(GameObject _TTSElement)
    {
        selectedTtsElement = _TTSElement;

        Debug.Log(_TTSElement.ToString());
    }

}
