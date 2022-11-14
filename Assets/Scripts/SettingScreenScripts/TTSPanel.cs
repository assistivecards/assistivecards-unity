using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TTSPanel : MonoBehaviour
{
    [SerializeField] private GameObject tempTtsElement;
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
                                            //adding tts to the list
        ttsElements.Add("Alex");
        ttsElements.Add("Karen");
        ttsElements.Add("Daniel");

        ttsElements.Add("Alex");
        ttsElements.Add("Karen");
        ttsElements.Add("Daniel");

        for(int i = 0; i< ttsElements.Count; i++)
        {
            ttsElement = Instantiate(tempTtsElement, transform);

            ttsElement.transform.GetChild(1).GetComponent<Text>().text = ttsElements[i];

            ttsElement.name = ttsElements[i];         
            ttsElementGameObject.Add(ttsElement);
        }

        Destroy(tempTtsElement);
    }

    public void TTSSelected(GameObject _TTSElement)
    {
        saveButton.interactable = true;
        //changing tts process
        
        Debug.Log(_TTSElement.ToString());
    }
}
