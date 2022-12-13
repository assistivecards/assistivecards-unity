using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class SettingScreenButton : MonoBehaviour
{
    GameAPI gameAPI;
    private ScreenOrientationMode screenOrientationMode;
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private GameObject settingButtonObject;
    [SerializeField] private Button settingButton;
    [SerializeField] private GameObject nickNameText;
    [SerializeField] private GameObject settingPrefab;
    [SerializeField] private GameObject gamePrefab;
    [SerializeField] private GameObject topAppBar;
    [SerializeField] private GameObject mainSettingScreen;

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

        if (settingButton.IsActive())
        {
            settingButton.image.sprite = await gameAPI.GetAvatarImage();
        }
    }

    public void SettingButtonClickFunc()
    {
        StartCoroutine(SettingButtonClick());
    }

    IEnumerator SettingButtonClick()
    {
        yield return new WaitForSeconds(0.25f);
        settingPrefab.SetActive(true);
        mainSettingScreen.SetActive(true);
        topAppBar.SetActive(true);
        gamePrefab.SetActive(false);

        // canvasController.StartFade();
    }
}
