using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckConnectionTest : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] TMPro.TMP_InputField status;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }
    public async void CheckConnection()
    {
        var result = await gameAPI.CheckConnectionStatus();
        status.text = JsonUtility.ToJson(result);
    }

}
