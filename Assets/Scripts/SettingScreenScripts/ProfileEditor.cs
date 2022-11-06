using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ProfileEditor : MonoBehaviour
{
    GameAPI.AssistiveCardsSDK assistiveCardsSDK = new GameAPI.AssistiveCardsSDK();
    SettingsAPI settingsAPI;
    [SerializeField] GameObject api;
    public TMP_InputField nicknameInputField;
    private string nickname;
    public Button selectAvatarButton;


    [SerializeField] private TMP_InputField nicknameField;
    [SerializeField] private Button saveButton;


    private void Awake() 
    {
        settingsAPI = api.GetComponent<SettingsAPI>();
        nickname = settingsAPI.GetNickname();
    }

    public async void Start()
    {
        nicknameField.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
        selectAvatarButton.image.sprite = await settingsAPI.GetAvatarImage();  
    }

    private void Update() 
    {
        nickname = settingsAPI.GetNickname();
    }

    public void SaveSettings()
    {
        settingsAPI.SetNickname(nicknameInputField.text);
    }
    public void ValueChangeCheck()
    {
        //nickname change 
        
        saveButton.GetComponent<Button>().interactable = true;
    }

}
