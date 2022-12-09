using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using NativeTextToSpeech;
using TMPro;

public class Speakable : MonoBehaviour
{
    [SerializeField] private bool threadSafe;
    private bool _isFinished;
    private bool _finishReceived;
    private Queue<string> errors = new Queue<string>();
    public static string locale;
    private TextToSpeech _textToSpeech;
    GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void Speak()
    {
        Debug.Log(locale);
        _textToSpeech.Speak(gameObject.GetComponent<TMP_Text>().text, locale, float.Parse("1", CultureInfo.InvariantCulture));
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
        Debug.Log("TTS finished");

    }

    private void TTSStarted()
    {
        Debug.Log("TTS started");
    }

    async void Start()
    {
        locale = await gameAPI.GetTTSPreference();
        _textToSpeech = TextToSpeech.Create(OnFinish, OnError);
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
