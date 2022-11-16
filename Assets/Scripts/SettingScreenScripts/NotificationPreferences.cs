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

    [SerializeField] private Material inactiveRadioButtoMaterial;
    [SerializeField] private Material appBackgroundMatrial;

    private GameObject button;
    private string reminderPreference;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }


    private void Start() 
    {
        reminderPreference = gameAPI.GetReminderPreference();

        if (reminderPreference == "Daily")
        {
            dailyReminderToggle.isOn = true;
        }
        else if(reminderPreference == "Weekly")
        {
            weeklyReminderToggle.isOn = true;
        }    
    }

    private void Update() 
    {
        reminderPreference = gameAPI.GetReminderPreference();
    }

}
