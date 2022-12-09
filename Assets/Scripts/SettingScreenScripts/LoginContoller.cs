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
    [SerializeField] private GameObject loginUI;
    public TMP_InputField nicknameInputField;
    [SerializeField] private Button nextButton;
    [SerializeField] private Image backgroundFadePanel;

    [Header ("Screens")]
    [SerializeField] private GameObject avatarSelectionScreen;
    [SerializeField] private GameObject practiceReminderScreen;
    [SerializeField] private GameObject congratulationsScreen;

    [Header ("Screen Prefabs")]
    [SerializeField] private GameObject loginPrefab;
    [SerializeField] private GameObject gamePrefab;



    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();

        nicknameInputField.onValueChanged.AddListener(delegate {ValueChangeCheck(); });

    }
    public void ValueChangeCheck()
    {
        gameAPI.SetNickname(nicknameInputField.text);
        nextButton.interactable = true;
    }

    private void Update()
    {
        if(TouchScreenKeyboard.visible)
        {
            LeanTween.moveLocal(loginUI, new Vector3(0, 300, 0), 0.5f);
        }
        else
        {
            LeanTween.moveLocal(loginUI, new Vector3(0, 0, 0), 0.5f);
        }
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
    public void StartButton()
    {
        //Fade Out
        backgroundFadePanel.CrossFadeAlpha(0, 0.25f, false);
        Invoke("SetGamePanelActive", 0.15f);
    }
    private void SetGamePanelActive()
    {
        avatarSelectionScreen.SetActive(false);
        practiceReminderScreen.SetActive(false);
        congratulationsScreen.SetActive(false);

        this.gameObject.SetActive(true);
        gamePrefab.SetActive(true);
        loginPrefab.SetActive(false);
    }
}
