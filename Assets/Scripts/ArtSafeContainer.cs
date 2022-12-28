using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Use it on a canvas with canvasScaler, 1212x726
public class ArtSafeContainer : MonoBehaviour
{

    // Start is called before the first frame update
    float deviceRatio;
    void Start()
    {
        ArtSafeScale();
    }

    public void ArtSafeScale()
    {
        float baseWidth = 1600f; // Max asset residue
        float baseHeight = 900f; // Max asset residue

        if (ScreenOrientationMode.orientationMode == "landscape")
            deviceRatio = (float)Screen.height / (float)Screen.width;
        else if (ScreenOrientationMode.orientationMode == "portrait")
            deviceRatio = (float)Screen.width / (float)Screen.height;

        float baseTippingPointWidth = 1212f; // ratioed ipad width
        float baseTippingPointHeight = 726f; // ratioed iphone height

        float SAFEAREA_RATIO = baseTippingPointWidth / baseTippingPointHeight;

        Debug.Log("safearearea " + SAFEAREA_RATIO + " " + deviceRatio);
        CanvasScaler c = GetComponent<CanvasScaler>();

        if (SAFEAREA_RATIO > deviceRatio)
        {
            Debug.Log("scale for width");
            c.matchWidthOrHeight = 0f;
        }
        else
        {
            Debug.Log("scale for height");
            c.matchWidthOrHeight = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
