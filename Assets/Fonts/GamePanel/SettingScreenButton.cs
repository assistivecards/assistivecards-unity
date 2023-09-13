using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class SettingScreenButton : MonoBehaviour
{
    [Header("MAIN CANVAS VARIABLES")]
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private GameObject settingPrefab;
    [SerializeField] private GameObject topAppBar;
    [SerializeField] private GameObject mainSettingScreen;
    [SerializeField] private GameObject promoScreen;
    [SerializeField] private GameObject promoScreenUniApp;

    [Header("Screen Setting Variables")]

    [SerializeField] private GameObject gamePrefab;
    GameAPI gameAPI;
    private ScreenOrientationMode screenOrientationMode;
    [SerializeField] private GameObject settingButtonObject;
    [SerializeField] private Button settingButton;
    [SerializeField] private GameObject nickNameText;
    [SerializeField] GameObject fadeOutPanel;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        screenOrientationMode = this.GetComponentInParent<ScreenOrientationMode>();
    }


    private void Start()
    {
        if (PlayerPrefs.GetString("Nickname", "") != "")
        {
            SetAvatarImageOnGamePanel();
        }
    }

    public async void SetAvatarImageOnGamePanel()
    {
        nickNameText.SetActive(true);

        // if (settingButton.IsActive())
        // {
        settingButton.image.sprite = await gameAPI.GetAvatarImage();
        // }
    }

    public void SettingButtonClickFunc()
    {
        promoScreen.SetActive(false);
        promoScreenUniApp.SetActive(false);
        Invoke("SettingButtonClick", 0.3f);
    }

    // IEnumerator SettingButtonClick()
    // {
    //     // settingPrefab.SetActive(true);
    //     // mainSettingScreen.SetActive(true);
    //     // topAppBar.SetActive(true);
    //     // gamePrefab.SetActive(false);
    //     yield return new WaitForSeconds(0.3f);
    //     fadeOutPanel.SetActive(true);
    //     gamePrefab.SetActive(false);
    //     settingPrefab.SetActive(true);
    //     mainSettingScreen.SetActive(true);
    //     topAppBar.SetActive(true);
    //     // canvasController.StartFade();
    // }

    public void SettingButtonClick()
    {
        fadeOutPanel.SetActive(true);
        gamePrefab.SetActive(false);
        settingPrefab.SetActive(true);
        mainSettingScreen.SetActive(true);
        topAppBar.SetActive(true);
    }
}
