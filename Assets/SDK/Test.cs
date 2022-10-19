using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{

    AssistiveCardsSDK.Languages result = new AssistiveCardsSDK.Languages();
    AssistiveCardsSDK assistiveCardsSDK;
    public TMP_InputField outputArea;

    [SerializeField] private Texture2D testTexture;

    private void Awake()
    {
        assistiveCardsSDK = outputArea.GetComponent<AssistiveCardsSDK>();
    }


    private async void Start()
    {

        result = await assistiveCardsSDK.GetLanguages();
        Debug.Log(result.languages[1].native);
        testTexture = await assistiveCardsSDK.GetPackImage("animals", 512);
    }
}
