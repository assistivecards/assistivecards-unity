using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AccessibilityScreen : MonoBehaviour
{
    [SerializeField] private Material inactiveRadioButtoMaterial;
    [SerializeField] private Material appBackgroundMatrial;
    private GameObject button;

    public void HapticVibrationSelected()
    {
        button = EventSystem.current.currentSelectedGameObject;

        if(button.GetComponentInChildren<Image>().material == inactiveRadioButtoMaterial)
        {
            button.GetComponentInChildren<Image>().material = appBackgroundMatrial;                           //SELECTED
        }
        else if(button.GetComponentInChildren<Image>().material == appBackgroundMatrial)
        {
            button.GetComponentInChildren<Image>().material = inactiveRadioButtoMaterial;                     //NOT SELECTED
        }
    }

    public void ActivateOnPressInSelected()
    {
        button = EventSystem.current.currentSelectedGameObject;

        if(button.GetComponentInChildren<Image>().material == inactiveRadioButtoMaterial)
        {
            button.GetComponentInChildren<Image>().material = appBackgroundMatrial;                           //SELECTED
        }
        else if(button.GetComponentInChildren<Image>().material == appBackgroundMatrial)
        {
            button.GetComponentInChildren<Image>().material = inactiveRadioButtoMaterial;                     //NOT SELECTED
        }
    }

    public void VoiceGreedingOnStart()
    {
        button = EventSystem.current.currentSelectedGameObject;

        if(button.GetComponentInChildren<Image>().material == inactiveRadioButtoMaterial)
        {
            button.GetComponentInChildren<Image>().material = appBackgroundMatrial;                           //SELECTED
        }
        else if(button.GetComponentInChildren<Image>().material == appBackgroundMatrial)
        {
            button.GetComponentInChildren<Image>().material = inactiveRadioButtoMaterial;                     //NOT SELECTED
        }
    }
}
