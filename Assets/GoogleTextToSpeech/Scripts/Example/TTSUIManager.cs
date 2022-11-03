using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleTextToSpeech.Scripts.Example;
using TMPro;
using System.Linq;
using GoogleTextToSpeech.Scripts.Data;

public class TTSUIManager : MonoBehaviour
{
    TextToSpeechExample tts;
    [SerializeField] GameObject ttsReference;
    [SerializeField] Button saveChangesButton;
    [SerializeField] ToggleGroup ttsOptions;




    private void Awake()
    {
        tts = ttsReference.GetComponent<TextToSpeechExample>();
    }
    // Start is called before the first frame update
    private void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeVoice()
    {
        string selectedVoice = ttsOptions.ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;
        foreach (var voice in tts.voices)
        {
            if (selectedVoice == voice.name)
            {
                tts.activeVoice = voice;
            }
        }
    }
}
