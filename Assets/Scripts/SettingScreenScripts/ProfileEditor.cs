using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ProfileEditor : MonoBehaviour
{
    [SerializeField] private GameObject avatarSelectionSettingsScreen;
    [SerializeField] private CanvasController canvasController;

    [Header ("API Connection")]
    GameAPI gameAPI;
    
    [Header ("Profile UI Assests")]
    public TMP_InputField nicknameInputField;
    public Button selectAvatarButton;
    public string nickname;


    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        nickname = gameAPI.GetNickname();
    }

    public async void Start()
    {
        nicknameInputField.text = nickname;
        selectAvatarButton.image.sprite = await gameAPI.GetAvatarImage();  
        canvasController.profileImage.GetComponent<Image>().sprite = await gameAPI.GetAvatarImage();
    }

    private void Update() 
    {
        nickname = gameAPI.GetNickname();
        selectAvatarButton.GetComponent<Image>().sprite = canvasController.profileImage.GetComponent<Image>().sprite;
    }

    public void AvatarSelectButtonClicked()
    {
        canvasController.currentScreen = avatarSelectionSettingsScreen;
        avatarSelectionSettingsScreen.SetActive(true);
        LeanTween.scale(avatarSelectionSettingsScreen,  Vector3.one, 0.2f);
    }
}
