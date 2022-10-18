using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{

    AssistiveCardsSDK.Languages result = new AssistiveCardsSDK.Languages();
    public TMP_InputField outputArea;

    private async void Start()
    {

        result = await outputArea.GetComponent<AssistiveCardsSDK>().GetLanguages();
        Debug.Log(result.languages[1].native);
    }
}
