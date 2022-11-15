using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopAppBarController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private SettingsAPI settingsAPI;
    private GameObject backButton;
    private GameObject saveButton;
    private ProfileEditor profileEditor;

    [Header ( "UI Elements")]
    
    public Toggle hapticsToggle;
    public Toggle activateOnPressToggle;
    public Toggle voiceGreetingToggle;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void BackButtonClicked()
    {
        LeanTween.scale(this.transform.parent.gameObject, Vector3.one*0.9f ,0.15f);
        Invoke("SceneSetActiveFalse", 0.15f);
    }

    private void SceneSetActiveFalse()
    {
        this.transform.parent.gameObject.SetActive(false);
    }

    public void SaveButtonClicked()
    {
        if(GetComponentInParent<ProfileEditor>() != null)
        {
            profileEditor = GetComponentInParent<ProfileEditor>();
            settingsAPI.SetNickname(profileEditor.nicknameInputField.text);
            canvasController.ProfilePanelUpdate();
        }
        if(GetComponentInParent<AccessibilityScreen>() != null)
        {
            gameAPI.SetHapticsPreference(hapticsToggle.isOn ? 1 : 0);
            gameAPI.SetActivateOnPressInPreference(activateOnPressToggle.isOn ? 1 : 0);
            gameAPI.SetVoiceGreetingPreference(voiceGreetingToggle.isOn ? 1 : 0);
        }

        LeanTween.scale(this.transform.parent.gameObject, Vector3.one*0.9f ,0.15f);
        Invoke("SceneSetActiveFalse", 0.15f);
    }
}
