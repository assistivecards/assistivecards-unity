using System;
using System.Collections.Generic;
#if UNITY_IOS
using Unity.Notifications.iOS;
#elif UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class NotificationsManager : MonoBehaviour
{
    private GameAPI gameAPI;
    private string reminderPeriod;
    private string notificationTitle = "setup_notification_badge_title";
    private string notificationBody = "setup_notification_badge_description";
    [SerializeField] private List<string> notificationContent = new List<string>();
    [SerializeField] private List<string> translatedNotificationContent = new List<string>();

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private async void Start()
    {
        var langCode = await gameAPI.GetSystemLanguageCode();
        notificationContent.Add(notificationTitle);
        notificationContent.Add(notificationBody);
        // AndroidNotificationCenter.CancelAllDisplayedNotifications();
        foreach (var text in notificationContent)
        {
            var result = gameAPI.Translate(text, langCode);
            translatedNotificationContent.Add(result);
        }

    }

    void SendNotification()
    {

#if UNITY_ANDROID
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notifications Channel",
            Importance = Importance.Default,
            Description = "Reminder notifications",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        AndroidNotification notification = new AndroidNotification();

        notification.Title = translatedNotificationContent[0];
        notification.Text = translatedNotificationContent[1];
        // notification.FireTime = System.DateTime.Now.AddSeconds(15);
        // notification.RepeatInterval = new TimeSpan(0, 0, 3, 0);
        notification.FireTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0).AddDays(1);
        notification.RepeatInterval = reminderPeriod == "Weekly" ? new TimeSpan(7, 0, 0, 0) : new TimeSpan(1, 0, 0, 0);
        notification.ShouldAutoCancel = true;
        notification.Style = NotificationStyle.BigTextStyle;

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
#endif

#if UNITY_IOS
        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = reminderPeriod == "Weekly" ? new TimeSpan(7, 0, 0, 0) : new TimeSpan(1, 0, 0, 0),
            // TimeInterval = new TimeSpan(0,0,3,0),
            Repeats = true
        };

        var notificationIOS = new iOSNotification()
        {
            Identifier = "_notification_01",
            Title = translatedNotificationContent[0],
            Body = "",
            Subtitle = translatedNotificationContent[1],
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger,
        };

        iOSNotificationCenter.ScheduleNotification(notificationIOS);
#endif
    }

    private void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus == false)
            SendNotification();
    }

    private void Update()
    {
        reminderPeriod = gameAPI.GetReminderPreference();
    }

    public async void OnLanguageChange()
    {
        var langCode = await gameAPI.GetSystemLanguageCode();
        translatedNotificationContent.Clear();
        foreach (var text in notificationContent)
        {
            var result = gameAPI.Translate(text, langCode);
            translatedNotificationContent.Add(result);
        }
    }


}
