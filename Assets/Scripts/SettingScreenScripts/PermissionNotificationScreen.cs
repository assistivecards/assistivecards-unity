using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_IOS
    using Unity.Notifications.iOS;
#elif UNITY_ANDROID
using Unity.Notifications.Android;
using Unity.Notifications.iOS;
#endif
using UnityEngine;


public class PermissionNotificationScreen : MonoBehaviour
{
    public void OnOkButtonClick()
    {
#if UNITY_IOS

        StartCoroutine(RequestAuthorization());
#endif
    }


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
}
