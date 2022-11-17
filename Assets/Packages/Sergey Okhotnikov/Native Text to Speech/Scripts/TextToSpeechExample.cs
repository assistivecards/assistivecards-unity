using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using NativeTextToSpeech;

public class TextToSpeechExample : MonoBehaviour
{
    [SerializeField] private InputField TextInput;
    [SerializeField] private InputField LanguageInput;
    [SerializeField] private InputField RateInput;
    [SerializeField] private Button SpeakButton;
    [SerializeField] private Button StopButton;
    [SerializeField] private bool threadSafe;

    private bool _isFinished;
    private bool _finishReceived; 
    private Queue<string> errors = new Queue<string>();
    
    private TextToSpeech _textToSpeech;
    
    public void Speak()
    {
        _textToSpeech.Speak(TextInput.text, LanguageInput.text, float.Parse(RateInput.text, CultureInfo.InvariantCulture));
        TTSStarted();
    }

    public void Stop()
    {
        _textToSpeech.Stop();
        TTSFinished();
    }
    
    private void OnFinish()
    {
        if (threadSafe)
        {
            _finishReceived = true;
        }
        else
        {
            TTSFinished();
        }
    }

    private void OnError(string msg)
    {
        if (threadSafe)
        {
            errors.Enqueue(msg);
        }
        else
        {
            ShowError(msg);
        }
    }

    private void ShowError(string error)
    {
        Debug.LogWarning("Error received in Unity main thread: " + error);
    }

    private void TTSFinished()
    {
        SpeakButton.interactable = true;
        StopButton.interactable = false;
    }

    private void TTSStarted()
    {
        SpeakButton.interactable = false;
        StopButton.interactable = true;
    }

    void Start()
    {
        _textToSpeech =  TextToSpeech.Create(OnFinish,OnError);
        LanguageInput.text = "en-US";
        RateInput.text = "0.8";
    }

    
    void Update()
    {
        if (!threadSafe)
        {
            return;
        }

        if (_finishReceived)
        {
            _finishReceived = false;
            TTSFinished();
        }
        

        while (errors.Count > 0)
        {
            ShowError(errors.Dequeue());
        }
    }
}
