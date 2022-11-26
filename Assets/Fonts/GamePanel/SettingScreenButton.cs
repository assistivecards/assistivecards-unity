using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class SettingScreenButton : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private Button settingButton;
    [SerializeField] private GameObject settingScreen;
    [SerializeField] private GameObject nickNameText;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        if(PlayerPrefs.GetString("Nickname", "") != "")
        {
            SetAvatarImageOnGamePanel();
        }
    }

    public async void SetAvatarImageOnGamePanel()
    {
        nickNameText.SetActive(true);
        settingButton.image.sprite = await gameAPI.GetAvatarImage();  
    }

    public void SettingButtonClick()
    {
        settingScreen.SetActive(true);
    }
}
