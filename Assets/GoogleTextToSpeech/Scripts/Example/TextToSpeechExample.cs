using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleTextToSpeech.Scripts.Data;
using TMPro;
using UnityEngine;

namespace GoogleTextToSpeech.Scripts.Example
{
    public class TextToSpeechExample : MonoBehaviour
    {
        GameAPI.LanguageManager languageManager = new GameAPI.LanguageManager();
        public VoiceScriptableObject activeVoice;
        [SerializeField] private TextToSpeech textToSpeech;
        [SerializeField] private AudioSource audioSource;
        public List<VoiceScriptableObject> voices;
        private Action<AudioClip> _audioClipReceived;
        private Action<BadRequestData> _errorReceived;

        public void Speak(string textToconvert)
        {
            _errorReceived += ErrorReceived;
            _audioClipReceived += AudioClipReceived;
            textToSpeech.GetSpeechAudioFromGoogle(textToconvert, activeVoice, _audioClipReceived, _errorReceived);

        }

        private void ErrorReceived(BadRequestData badRequestData)
        {
            Debug.Log($"Error {badRequestData.error.code} : {badRequestData.error.message}");
        }

        private void AudioClipReceived(AudioClip clip)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }

        public List<VoiceScriptableObject> GetAvailableVoices(List<VoiceScriptableObject> voices, string languageCode)
        {
            List<VoiceScriptableObject> availableVoices = new List<VoiceScriptableObject>();
            foreach (var voice in voices)
            {
                if (voice.name.StartsWith(languageCode))
                {
                    availableVoices.Add(voice);
                }
            }
            return availableVoices;
        }
    }
}
