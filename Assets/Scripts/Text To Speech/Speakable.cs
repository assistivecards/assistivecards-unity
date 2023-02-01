using System;
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
      try {
        var canGreet = gameAPI.GetVoiceGreetingPreference();
        if (canGreet == 1)
            _textToSpeech.Speak(gameObject.GetComponent<TMP_Text>().text, locale, 1);
        TTSStarted();
      } catch (Exception e) {
        Debug.Log("Tried to greet" + gameObject.GetComponent<TMP_Text>().text + "(" +locale+ ")");
      }
    }

    public void Speak(string text)
    {
        try {
          _textToSpeech.Speak(text, locale, 1);
          TTSStarted();
        } catch (Exception e) {
          Debug.Log("Tried to speak: " + text + "(" +locale+ ")");
        }
    }

    public void Stop()
    {
      try {
        _textToSpeech.Stop();
        TTSFinished();
      } catch (Exception e) {
        // don't catch
      }

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
