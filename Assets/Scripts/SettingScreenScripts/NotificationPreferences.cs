using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NotificationPreferences : MonoBehaviour
{
    [SerializeField] private Material inactiveRadioButtoMaterial;
    [SerializeField] private Material appBackgroundMatrial;
    private GameObject button;

    public void DailyReminderSelected()
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

    public void WeeklyReminderSelected()
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

    public void UsabilityTipsSelected()
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

    public void PromotionsSelected()
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
