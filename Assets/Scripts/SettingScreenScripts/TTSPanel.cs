using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TTSPanel : MonoBehaviour
{
    [SerializeField] private GameObject tempTtsElement;
    [SerializeField] private Material inactiveRadioButtoMaterial;
    [SerializeField] private Material appBackgroundMatrial;
    [SerializeField] private Button saveButton;
    private List<string> ttsElements= new List<string>();
    private GameObject ttsElement;
    private GameObject selectedTtsElement;
    private List<GameObject> ttsElementGameObject = new List<GameObject>();


    private void Start() 
    {
        ttsElements.Add("Alex");
        ttsElements.Add("Karen");
        ttsElements.Add("Daniel");

        ttsElements.Add("Alex");
        ttsElements.Add("Karen");
        ttsElements.Add("Daniel");

        ttsElements.Add("Alex");
        ttsElements.Add("Karen");
        ttsElements.Add("Daniel");

        for(int i = 0; i< ttsElements.Count; i++)
        {
            ttsElement = Instantiate(tempTtsElement, transform);

            ttsElement.transform.GetChild(0).GetComponent<TMP_Text>().text = ttsElements[i];
            ttsElement.transform.GetChild(4).GetComponent<Image>().material = inactiveRadioButtoMaterial;
            ttsElement.name = ttsElements[i];         
            ttsElementGameObject.Add(ttsElement);

            ttsElement.GetComponent<Button>().AddEventListener(ttsElement, TTSButtonClicked); 
        }

        Destroy(tempTtsElement);
    }

    private void TTSButtonClicked(GameObject _TTSElement)
    {
        selectedTtsElement = _TTSElement;
        saveButton.interactable = true;
        
        foreach(GameObject ttsElement in ttsElementGameObject)
        {
            if(ttsElement != selectedTtsElement)
            {
                ttsElement.transform.GetChild(4).GetComponent<Image>().material = inactiveRadioButtoMaterial;
            }
        }
        _TTSElement.transform.GetChild(4).GetComponent<Image>().material = appBackgroundMatrial;
    }
}
