using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ProfileEditor : MonoBehaviour
{
    [Header ("API Connection")]
    SettingsAPI settingsAPI;
    [SerializeField] GameObject api;
    
    [Header ("Profile UI Assests")]
    [SerializeField] private Image profileImage;
    public TMP_InputField nicknameInputField;
    public Button selectAvatarButton;
    public string nickname;


    private void Awake() 
    {
        settingsAPI = api.GetComponent<SettingsAPI>();
        nickname = settingsAPI.GetNickname();
    }

    public async void Start()
    {
        nicknameInputField.text = nickname;
        selectAvatarButton.image.sprite = await settingsAPI.GetAvatarImage();  
        profileImage.GetComponent<Image>().sprite = await settingsAPI.GetAvatarImage();
    }

    private void Update() 
    {
        nickname = settingsAPI.GetNickname();
    }
}
