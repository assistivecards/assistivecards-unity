using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginContoller : MonoBehaviour
{
    [Header ("API Connection")]
    SettingsAPI settingsAPI;
    [SerializeField] GameObject api;
    [SerializeField] private CanvasController canvasController;
    
    [Header ("LoginPage UI Assests")]
    //[SerializeField] private Image profileImage;
    public TMP_InputField nicknameInputField;
    //public Button selectAvatarButton;
    public string nickname;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject avatarSelectionScreen;


    private void Awake() 
    {
        settingsAPI = api.GetComponent<SettingsAPI>();

        nicknameInputField.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {
        nextButton.interactable = true;
    }
    public void NextButtonClicked()
    {
        settingsAPI.SetNickname(nicknameInputField.text);
        canvasController.ProfilePanelUpdate();
        this.gameObject.SetActive(false);

        avatarSelectionScreen.SetActive(true);
        LeanTween.scale(avatarSelectionScreen,  Vector3.one, 0.2f);
    }

}
