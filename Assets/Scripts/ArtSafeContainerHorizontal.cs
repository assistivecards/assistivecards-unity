using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Use it on a canvas with canvasScaler, 1212x726
public class ArtSafeContainerHorizontal : MonoBehaviour
{

    // Start is called before the first frame update
    float deviceRatio;
    void Start()
    {
        float baseWidth = 900f; // Max asset residue
        float baseHeight = 1600f; // Max asset residue

        Debug.Log("Game is starting in : " + Screen.orientation);

        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
            deviceRatio = (float)Screen.width / (float)Screen.height;
        else
            deviceRatio = (float)Screen.height / (float)Screen.width;

        float baseTippingPointWidth = 1212f; // ratioed ipad width
        float baseTippingPointHeight = 726f; // ratioed iphone height

        float SAFEAREA_RATIO = baseTippingPointWidth / baseTippingPointHeight;

        Debug.Log("safearearea " + SAFEAREA_RATIO + " " + deviceRatio);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
