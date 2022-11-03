using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleTextToSpeech.Scripts.Example;
using TMPro;

public class Speakable : MonoBehaviour
{
    [SerializeField] TextToSpeechExample textToSpeechExample;
    public void Speak()
    {
        textToSpeechExample.Speak(gameObject.GetComponent<TMP_Text>().text);

    }
}
