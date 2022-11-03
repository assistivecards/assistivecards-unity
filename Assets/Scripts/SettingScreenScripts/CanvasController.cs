using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class CanvasController : MonoBehaviour
{

    AssistiveCardsSDK assistiveCardsSDK;
    public GameObject SDK;
    SettingsAPI settingsAPI;
    SettingsUIManager settingsUIManager;
    [SerializeField] Canvas canvas;


    [SerializeField] private GameObject profileImage;
    [SerializeField] private GameObject mainSettingsScreen;
    [SerializeField] private GameObject popUp;
    [SerializeField] private GameObject parentLockScreen;
    [SerializeField] private GameObject profileScreen;
    [SerializeField] private GameObject languageScreen;
    [SerializeField] private GameObject ttsScreen;
    [SerializeField] private GameObject notification;
    [SerializeField] private GameObject accessibility;
    [SerializeField] private GameObject subscriptions;
    private GameObject backButton;

    private void Awake()
    {
        assistiveCardsSDK = SDK.GetComponent<AssistiveCardsSDK>();
        settingsAPI = SDK.GetComponent<SettingsAPI>();
        settingsUIManager = canvas.GetComponent<SettingsUIManager>();
    }

    private async void Start() 
    {
        profileImage.GetComponent<Image>().sprite = await settingsAPI.GetAvatarImage();
    }


    public void ParentLockButtonClick()
    {
        LeanTween.scale(popUp,  Vector3.one, 0.15f);
        parentLockScreen.SetActive(true);
    }

    public void ParentLockScreenClose()
    {
        LeanTween.scale(popUp, Vector3.one * 0.15f, 0.2f);
        parentLockScreen.SetActive(false);
    }

    public void ProfileButtonClick()
    {
        LeanTween.scale(profileScreen,  Vector3.one, 0.2f);
        profileScreen.SetActive(true);
    }

    public void LanguageButtonClick()
    {
        LeanTween.scale(languageScreen,  Vector3.one, 0.2f);
        languageScreen.SetActive(true);
    }

    public void TTSButtonClicked()
    {
        LeanTween.scale(ttsScreen,  Vector3.one, 0.2f);
        ttsScreen.SetActive(true);
    }
    
    public void NotificationButtonClicked()
    {
        LeanTween.scale(notification,  Vector3.one, 0.2f);
        notification.SetActive(true);
    }
    public void AccessibiltyButtonClicked()
    {
        LeanTween.scale(accessibility,  Vector3.one, 0.2f);
        accessibility.SetActive(true);
    }
    public void SubscriptipnsButtonClicked()
    {
        LeanTween.scale(subscriptions,  Vector3.one, 0.2f);
        subscriptions.SetActive(true);
    }

}
