using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtSafeContainerHorizontal : MonoBehaviour
{
    private CanvasScaler loginCanvasScaler;
    float deviceRatio;
    void Start()
    {
        CheckCanvasSize();
    }
    private void CheckCanvasSize()
    {
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
            deviceRatio = (float)Screen.width / (float)Screen.height;
        else
            deviceRatio = (float)Screen.height / (float)Screen.width;

        float baseTippingPointWidth = 726; // ratioed ipad width
        float baseTippingPointHeight = 1212; // ratioed iphone height

        float SAFEAREA_RATIO = baseTippingPointWidth / baseTippingPointHeight;
        loginCanvasScaler = GetComponent<CanvasScaler>();

        if (SAFEAREA_RATIO > deviceRatio)
        {
            loginCanvasScaler.matchWidthOrHeight = 0f;
        }
        else
        {
            loginCanvasScaler.matchWidthOrHeight = 1f;
        }
    }
}
