using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitScreenOrientation : MonoBehaviour
{
    GameAPI gameAPI;
    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }
    private void OnEnable()
    {
        gameAPI.ForceOrientation("portrait");
    }
}
