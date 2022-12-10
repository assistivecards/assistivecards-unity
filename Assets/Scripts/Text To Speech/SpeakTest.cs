using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakTest : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void SpeakButtonClick()
    {
        if (inputField.text != null)
            gameAPI.Speak(inputField.text);
    }

}
