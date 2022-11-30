using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NotificationPreferences : MonoBehaviour
{
    GameAPI gameAPI;
    public Toggle dailyReminderToggle;
    public Toggle weeklyReminderToggle;
    public Toggle usabilityTipsToggle;
    public Toggle promotionsNotificationToggle;
    public string reminderPreference;
    public bool isUsabilityTipsActive;
    public bool isPromotionsNotificationActive;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();

        isUsabilityTipsActive = gameAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        isPromotionsNotificationActive = gameAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
    }


    private void Start() 
    {
        reminderPreference = gameAPI.GetReminderPreference();
        promotionsNotificationToggle.isOn = gameAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
        usabilityTipsToggle.isOn = gameAPI.GetUsabilityTipsPreference() == 1 ? true : false;

        isUsabilityTipsActive = gameAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        isPromotionsNotificationActive = gameAPI.GetPromotionsNotificationPreference() == 1 ? true : false;


        if (reminderPreference == "Daily")
        {
            dailyReminderToggle.isOn = true;
        }
        else
        {
            weeklyReminderToggle.isOn = true;
        }   
    }

    private void Update() 
    {
        reminderPreference = gameAPI.GetReminderPreference();
        isUsabilityTipsActive = gameAPI.GetUsabilityTipsPreference() == 1 ? true : false;
        isPromotionsNotificationActive = gameAPI.GetPromotionsNotificationPreference() == 1 ? true : false;
    }

}
