using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AccessibilityScreen : MonoBehaviour
{
    GameAPI gameAPI;
    public bool isHapticsActive;
    public bool isPressInActive;
    public bool isVoiceGreetingActive;
    public bool isTutorialActive;

    public Toggle hapticsToggle;
    public Toggle activateOnPressToggle;
    public Toggle voiceGreetingToggle;
    public Toggle tutorialToggle;

    [SerializeField] private GameObject tutorial;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();

        isHapticsActive = gameAPI.GetHapticsPreference() == 1 ? true : false;
        isPressInActive = gameAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        isVoiceGreetingActive = gameAPI.GetVoiceGreetingPreference() == 1 ? true : false;
        isTutorialActive = gameAPI.GetTutorialPreference() == 1 ? true : false;
    }

    private void Start() 
    {
        hapticsToggle.isOn = gameAPI.GetHapticsPreference() == 1 ? true : false;
        activateOnPressToggle.isOn = gameAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        voiceGreetingToggle.isOn = gameAPI.GetVoiceGreetingPreference() == 1 ? true : false;
        tutorialToggle.isOn = gameAPI.GetTutorialPreference() == 1 ? true : false;
    }

    private void Update() 
    {
        isHapticsActive = gameAPI.GetHapticsPreference() == 1 ? true : false;
        isPressInActive = gameAPI.GetActivateOnPressInPreference() == 1 ? true : false;
        isVoiceGreetingActive = gameAPI.GetVoiceGreetingPreference() == 1 ? true : false;
        isTutorialActive = gameAPI.GetTutorialPreference() == 1 ? true : false;
    }
}
