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
    [SerializeField] private GameObject congratulationsScreen;

    public void OnOkButtonClick()
    {
        
        settingScreenButton.SetAvatarImageOnGamePanel();
        LeanTween.scale(congratulationsScreen, Vector3.one * 0.9f, 0f);
        LeanTween.scale(this.gameObject, Vector3.zero, 0f);

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
