using System;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;
using UnityEngine.Android;

namespace NativeTextToSpeech
{

    public class TextToSpeech : AndroidJavaProxy, AndroidTTSCallback
    {
        private readonly Action _finish;
        private readonly Action<string> _error;
        
        private static TextToSpeech _instance;

        public static TextToSpeech Instance => _instance;

#if UNITY_ANDROID 
        private AndroidJavaObject activity;
        private AndroidJavaObject _javaObject;
#endif 
        #region Declare external C interface    
#if UNITY_IOS 

        [DllImport("__Internal")]
        private static extern void stop_tts();

        [DllImport("__Internal")]
        private static extern void start_tts(Action onFinish, Action<string> onError);

        [DllImport("__Internal")]
        private static extern void speak_tts(string text, string language, float rate);

        [MonoPInvokeCallback(typeof(Action<string>))] 
        private static void on_finish() {
            _instance?.onFinish();
        }
        
        [MonoPInvokeCallback(typeof(Action<string>))] 
        private static void on_error(string msg) {
            _instance?.onError(msg);
        }

#endif
        #endregion
        
        public void Start()
        {
            Debug.Log("Starting native tts");

#if UNITY_IOS 
            start_tts(on_finish,on_error);
#endif
#if UNITY_ANDROID 
            activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                _javaObject.Call("start");
            }));
#endif            
        }
        

        public void Stop()
        {
            Debug.Log("Stopping tts");
#if UNITY_IOS 
            stop_tts();
#endif
#if UNITY_ANDROID 
            activity.Call("runOnUiThread", new AndroidJavaRunnable(StopAndroid));
#endif
        }
        private void StopAndroid()
        {
#if UNITY_ANDROID            
            _javaObject.Call("stop");
#endif
        }

        public void Speak(string text, string language, float rate)
        {
            Debug.Log("Start speaking from Unity");
#if UNITY_IOS 
            speak_tts(text, language, rate);
#endif
#if UNITY_ANDROID 
            activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                _javaObject.Call("speak",text, language, rate);
            }));
#endif
        }
        
        public static TextToSpeech Create(Action finish, Action<string> error)
        {
            _instance?.Stop();

            _instance = new TextToSpeech(finish, error);
            _instance.Start();
            Debug.Log("Created new TextToSpeech instance ");
            return _instance;
        }

        private TextToSpeech(Action finish, Action<string> error)  : base("net.okhotnikov.tts.TTSCallbackReceiver")
        {
            _finish = finish;
            _error = error;
#if UNITY_ANDROID 
            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
            activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
            _javaObject = new AndroidJavaObject("net.okhotnikov.tts.TextToSpeechBridge", activity, this);
#endif
        }

        public void onFinish()
        {
            Debug.Log("TTS finished ");
            _finish();
        }

        public void onError(string error)
        {
            Debug.LogError("Error received: " + error);
            _error(error);
        }
    }
}