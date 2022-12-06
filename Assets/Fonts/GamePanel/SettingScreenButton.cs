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
    [SerializeField] private GameObject nickNameText;
    [SerializeField] private GameObject settingPrefab;
    [SerializeField] private GameObject gamePrefab;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }
    
    private async void OnEnable()
    {
        settingButton.image.sprite = await gameAPI.GetAvatarImage();  

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

        if(settingButton.IsActive())
        {
            settingButton.image.sprite = await gameAPI.GetAvatarImage();  
        }
    }

    public void SettingButtonClick()
    {
        settingPrefab.SetActive(true);
        gamePrefab.SetActive(false);

        canvasController.StartFade();
    }
}