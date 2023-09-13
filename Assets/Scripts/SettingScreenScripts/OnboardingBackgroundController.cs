using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnboardingBackgroundController : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite background1;
    [SerializeField] private Sprite background2;
    [SerializeField] private Sprite background3;

    float deviceRatio;

    void Start(){
        float baseWidth = 1600f; // Max asset residue
        float baseHeight = 900f; // Max asset residue

        Debug.Log("Game is starting in : " + Screen.orientation);

        deviceRatio = (float)Screen.height / (float)Screen.width;

        float baseTippingPointWidth = 1212f; // ratioed ipad width
        float baseTippingPointHeight = 726f; // ratioed iphone height

        float SAFEAREA_RATIO = baseTippingPointWidth / baseTippingPointHeight;

        //backgroundImage.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

    }

    public void BackgroundAvailable()
    {
        backgroundImage.enabled = true;
    }

    public void BackgroundDisable()
    {
        backgroundImage.enabled = false;
    }

    public void SetBackground1()
    {
        backgroundImage.sprite = background1;
    }

    public void SetBackground2()
    {
        backgroundImage.sprite = background2;
    }

    public void SetBackground3()
    {
        backgroundImage.sprite = background3;
    }
}
