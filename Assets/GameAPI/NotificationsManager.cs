using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class NotificationsManager : MonoBehaviour
{
    private GameAPI gameAPI;
    private string reminderPeriod;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        AndroidNotificationCenter.CancelAllNotifications();
    }

    void CreateChannel()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notifications Channel",
            Importance = Importance.Default,
            Description = "Reminder notifications",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    void SendNotification()
    {
        AndroidNotification notification = new AndroidNotification();

        notification.Title = "Hey! We missed you!";
        notification.Text = "Come back and continue to learn!";
        notification.FireTime = System.DateTime.Now.AddSeconds(15);
        notification.RepeatInterval = new TimeSpan(0, 0, 3, 0);
        notification.ShowTimestamp = true;

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }

    private void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus == false)
        {
            CreateChannel();
            SendNotification();
        }

    }

    private void Update()
    {
        reminderPeriod = gameAPI.GetReminderPreference();
    }
}
