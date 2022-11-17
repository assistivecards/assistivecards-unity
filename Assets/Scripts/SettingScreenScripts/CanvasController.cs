using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;



public class CanvasController : MonoBehaviour
{
    [Header ("User Information")]
    public GameObject profileImage;
    public string nickname;


    [Header ("API Connection")]
    GameAPI gameAPI;

    [Header ("UI Assets")]
    public TMP_Text nicknameText;
    [SerializeField] Canvas canvas;
    [SerializeField] private GameObject popUp;
    private GameObject backButton;

    [Header ("Screens")]
    [SerializeField] private GameObject mainSettingsScreen;
    [SerializeField] private GameObject parentLockScreen;
    [SerializeField] private GameObject profileScreen;
    [SerializeField] private GameObject languageScreen;
    [SerializeField] private GameObject ttsScreen;
    [SerializeField] private GameObject notificationScreen;
    [SerializeField] private GameObject accessibilityScreen;
    [SerializeField] private GameObject subscriptionsScreen;
    [SerializeField] private GameObject allAppsScreen;
    [SerializeField] private GameObject sendFeedbacksScreen;
    [SerializeField] private GameObject aboutApplicationScreen;
    [SerializeField] private GameObject loginPageScreen;
    [SerializeField] private GameObject avatarSelectionScreen;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        nickname = gameAPI.GetNickname();


        if(PlayerPrefs.GetString("Nickname", "") != "")
        {
            loginPageScreen.SetActive(false);
        }
    }

    private async void Start() 
    {
        nicknameText.text = nickname;
        profileImage.GetComponent<Image>().sprite = await gameAPI.GetAvatarImage();
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
        LeanTween.scale(notificationScreen,  Vector3.one, 0.2f);
        notificationScreen.SetActive(true);
    }
    public void AccessibiltyButtonClicked()
    {
        LeanTween.scale(accessibilityScreen,  Vector3.one, 0.2f);
        accessibilityScreen.SetActive(true);
    }
    public void SubscriptionsButtonClicked()
    {
        LeanTween.scale(subscriptionsScreen,  Vector3.one, 0.2f);
        subscriptionsScreen.SetActive(true);
    }

    public void AllAppsButtonClicked()
    {
        LeanTween.scale(allAppsScreen,  Vector3.one, 0.2f);
        allAppsScreen.SetActive(true);
    }
    public void SendFeedbacksButtonClicked()
    {
        LeanTween.scale(sendFeedbacksScreen,  Vector3.one, 0.2f);
        sendFeedbacksScreen.SetActive(true);
    }
    public void AboutApplicationButtonClicked()
    {
        LeanTween.scale(aboutApplicationScreen,  Vector3.one, 0.2f);
        aboutApplicationScreen.SetActive(true);
    }
    public async void ProfilePanelUpdate()
    {
        nicknameText.text = gameAPI.GetNickname();
        profileImage.GetComponent<Image>().sprite = await gameAPI.GetAvatarImage();
    }

}
