using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientationMode : MonoBehaviour
{
    [SerializeField] bool isPortrait;
    private string orientationMode;
    GameAPI gameAPI;
    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable()
    {
        orientationMode = isPortrait ? "portrait" : "landscape";
        gameAPI.ForceOrientation(orientationMode);
    }
}

