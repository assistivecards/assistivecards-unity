using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerCardChain : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private Tutorial tutorial;
    [SerializeField] private AccessibilityScreen accessibilityScreen;
    [SerializeField] private BoardGenerateCardChain boardGenerateCardChain;

    public GameObject cardPosition;
    public GameObject cardPosition1;
    public GameObject gameUI;
    public GameObject loadingScreen;
    [SerializeField] private GameObject levelChangeScreen;
    [SerializeField] private GameObject packSelectionScreen;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject levelProgressContainer;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject selectNewPackButton;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject tutorialGameObject;
    public int loopCount = 0;

    public bool firstTime = true;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void TutorialActive()
    {
        if(firstTime || gameAPI.GetTutorialPreference() == 1)
        {
            tutorial.tutorialPosition = cardPosition.transform;
            tutorialGameObject.SetActive(true);
        }
        firstTime = false;
    }

    public void InGameBar()
    {
        backButton.SetActive(true);
        helloText.SetActive(false);
        levelProgressContainer.SetActive(false);
        settingButton.SetActive(true);
        levelChangeScreen.SetActive(false);
    }

    public void PackSelectionActive()
    {
        ResetScroll();
        gameAPI.ResetSessionExp();
        helloText.SetActive(true);
        levelProgressContainer.SetActive(true);
        settingButton.SetActive(true);
        backButton.SetActive(false);
        packSelectionScreen.SetActive(true);
        levelChangeScreen.SetActive(false);
    }

    public void LevelChangeActive()
    {
        gameAPI.AddExp(gameAPI.sessionExp);
        settingButton.SetActive(false);
        backButton.SetActive(false);
        helloText.SetActive(false);
        levelProgressContainer.SetActive(false);
        levelChangeScreen.SetActive(true);
        LeanTween.scale(levelChangeScreen, Vector3.one * 0.6f, 0.5f);
    }

    public void CloseLevelChange()
    {
        gameAPI.ResetSessionExp();
        LeanTween.scale(levelChangeScreen, Vector3.zero, 0.25f);
        Invoke("ResetLevelChangeScreen", 0.15f);
    }

    private void ResetLevelChangeScreen()
    {
        LeanTween.scale(selectNewPackButton, Vector3.one, 0.15f);
        LeanTween.scale(continueButton, Vector3.one, 0.15f);
    }

    public void ResetScroll()
    {
        tutorialGameObject.SetActive(false);
        packSelectionScreen.transform.GetChild(0).GetChild(0).GetChild(0).transform.localPosition = Vector3.zero;
    }
}
