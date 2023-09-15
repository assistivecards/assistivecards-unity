using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceGreeting : MonoBehaviour
{
    GameAPI gameAPI;
    private static bool firstTime = true;
    [SerializeField] GameObject greetingText;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }
    private void OnEnable()
    {
        if (firstTime == true)
        {
            var canGreet = gameAPI.GetVoiceGreetingPreference();
            if (canGreet == 1)
                StartCoroutine(Greet());
        }
    }

    IEnumerator Greet()
    {
        yield return new WaitForSeconds(1.5f);
        greetingText.GetComponent<Speakable>().Speak();
        firstTime = false;
    }

    // private void OnApplicationQuit()
    // {
    //     firstTime = true;
    // }

}
