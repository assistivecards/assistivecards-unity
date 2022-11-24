using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginContoller : MonoBehaviour
{
    [Header ("API Connection")]
    GameAPI gameAPI;
    [SerializeField] private CanvasController canvasController;
    
    [Header ("LoginPage UI Assests")]
    public TMP_InputField nicknameInputField;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject avatarSelectionScreen;
    [SerializeField] private GameObject practiceReminderScreen;
    [SerializeField] private GameObject congratulationsScreen;



    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();

        nicknameInputField.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {
        nextButton.interactable = true;
    }
    public void NextButtonClicked()
    {
        gameAPI.SetNickname(nicknameInputField.text);
        canvasController.ProfilePanelUpdate();
        this.gameObject.SetActive(false);

        avatarSelectionScreen.SetActive(true);
        practiceReminderScreen.SetActive(true);
        congratulationsScreen.SetActive(true);
        
        LeanTween.scale(avatarSelectionScreen,  Vector3.one, 0.2f);
    }

}
