using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_IOS
    using Unity.Notifications.iOS;
#elif UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;


public class PermissionNotificationScreen : MonoBehaviour
{
    [SerializeField] private SettingScreenButton settingScreenButton;

    public void OnOkButtonClick()
    {
        
        settingScreenButton.SetAvatarImageOnGamePanel();

#if UNITY_IOS

        StartCoroutine(RequestAuthorization());
        this.gameObject.SetActive(false);
#endif
        this.gameObject.SetActive(false);
    }

#if UNITY_IOS
    IEnumerator RequestAuthorization()
    {
        using (var req = new AuthorizationRequest(AuthorizationOption.Alert | AuthorizationOption.Badge, true))
        {
            while (!req.IsFinished)
            {
                yield return null;
            };

            string result = "\n RequestAuthorization: \n";
            result += "\n finished: " + req.IsFinished;
            result += "\n granted :  " + req.Granted;
            result += "\n error:  " + req.Error;
            result += "\n deviceToken:  " + req.DeviceToken;
            Debug.Log(result);
        }
    }
#endif

}
