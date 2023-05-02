using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerCardChain : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private Tutorial tutorial;
    [SerializeField] private AccessibilityScreen accessibilityScreen;

    public GameObject cardPosition;
    public GameObject cardPosition1;
    [SerializeField] private GameObject levelChangeScreen;
    [SerializeField] private GameObject packSelectionScreen;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject selectNewPackButton;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject tutorialGameObject;

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
            TutorialLoopPosition1();
        }
        firstTime = false;
    }

    public void TutorialLoopPosition()
    {
        if(tutorialGameObject.activeInHierarchy)
            LeanTween.move(tutorialGameObject, cardPosition.transform.position, 0f).setOnComplete(TutorialLoopPosition1);
    }

    public void TutorialLoopPosition1()
    {
        if(tutorialGameObject.activeInHierarchy)
            LeanTween.move(tutorialGameObject, cardPosition1.transform.position, 1.25f).setOnComplete(TutorialLoopPosition);
    }


    public void InGameBar()
    {
        backButton.SetActive(true);
        helloText.SetActive(false);
        settingButton.SetActive(true);
        levelChangeScreen.SetActive(false);
    }

    public void PackSelectionActive()
    {
        ResetScroll();
        helloText.SetActive(true);
        settingButton.SetActive(true);
        backButton.SetActive(false);
        packSelectionScreen.SetActive(true);
        levelChangeScreen.SetActive(false);
    }

    public void LevelChangeActive()
    {
        settingButton.SetActive(false);
        backButton.SetActive(false);
        helloText.SetActive(false);
        levelChangeScreen.SetActive(true);
        LeanTween.scale(levelChangeScreen, Vector3.one * 0.6f, 0.5f);
    }

    public void CloseLevelChange()
    {
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
        packSelectionScreen.transform.GetChild(0).GetChild(0).GetChild(0).transform.localPosition = Vector3.zero;
    }
}
