using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientationMode : MonoBehaviour
{
    [SerializeField] public bool isPortrait;
    private string orientationMode;
    GameAPI gameAPI;
    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable()
    {
        orientationMode = isPortrait ? "portrait" : "landscape";
        StartCoroutine(RotateScreen());
    }

    IEnumerator RotateScreen()
    {
        yield return new WaitForSeconds(0.25f);
        gameAPI.ForceOrientation(orientationMode);
    }
}

