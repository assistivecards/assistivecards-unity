using System;
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

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        // AndroidNotificationCenter.CancelAllDisplayedNotifications();
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

        notification.Title = "Hey! We missed you!";
        notification.Text = "Come back and practice!";
        notification.FireTime = System.DateTime.Now.AddSeconds(15);
        notification.RepeatInterval = new TimeSpan(0, 0, 3, 0);
        // notification.FireTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0).AddDays(1);
        // notification.RepeatInterval = reminderPeriod == "Weekly" ? new TimeSpan(7, 0, 0, 0) : new TimeSpan(1, 0, 0, 0);
        notification.ShouldAutoCancel = true;

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
            // TimeInterval = reminderPeriod == "Weekly" ? new TimeSpan(7, 0, 0, 0) : new TimeSpan(1, 0, 0, 0);
            TimeInterval = new TimeSpan(0,0,3,0),
            Repeats = true
        };

        var notificationIOS = new iOSNotification()
        {
            Identifier = "_notification_01",
            Title = "Hey! We missed you!",
            Body = "",
            Subtitle = "Come back and practice!",
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
}
