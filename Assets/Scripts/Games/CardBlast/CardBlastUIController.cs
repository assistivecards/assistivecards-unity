using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBlastUIController : MonoBehaviour
{
    GameAPI gameAPI;
    [Header("Classes")]
    [SerializeField] private CardBlastLevelControl levelChangeScreenController;
    [SerializeField] private DifficultSelectionPanelTween difficultSelectionPanelTween;
    [SerializeField] private PackSelectionScreenUIController packSelectionScreenUIController;
    [SerializeField] private CardBlastFillGrid fillGrid;
    [Header("Top App Bar Elements")]
    [SerializeField] private GameObject levelProgressContainer;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject score;
    [Header("Screens")]
    [SerializeField] private GameObject packSelectionScreen;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject levelChange;
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject difficultSelectionPanel;
    [SerializeField] GameObject tutorial;
    private bool firstTime = true;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void TutorialSetActive()
    {
        if(firstTime || gameAPI.GetTutorialPreference() == 1)
        {
            tutorial.SetActive(true);
        }
        firstTime = false;
    }

    public void TutorialSetDeactive()
    {
        tutorial.SetActive(false);
    }

    public void LoadingScreenActivation()
    {
        loadingScreen.SetActive(true);
        backButton.SetActive(false);
        settingsButton.SetActive(false);
        levelProgressContainer.SetActive(false);
        helloText.SetActive(false);
        TutorialSetDeactive();
    }

    public void LoadingScreenDeactivation()
    {
        loadingScreen.SetActive(false);
        backButton.SetActive(true);
        settingsButton.SetActive(true);
        levelProgressContainer.SetActive(false);
        helloText.SetActive(true);
    }

    public void DifficultSelectionPanelActivation()
    {
        score.SetActive(false);
        backButton.SetActive(true);
        helloText.SetActive(false);
        levelProgressContainer.SetActive(false);
    }

    public void GameUIActivate()
    {
        score.SetActive(true);
        backButton.SetActive(true);
        helloText.SetActive(false);
        levelProgressContainer.SetActive(false);
    }

    public void PackSelectionPanelActivation()
    {
        score.SetActive(false);
        backButton.SetActive(false);
        helloText.SetActive(true);
        levelProgressContainer.SetActive(true);
        TutorialSetDeactive();
    }

    public void GamePanelUIControl()
    {
        if(fillGrid.scoreInt >= 100)
        {
            levelChange.SetActive(true);
            gameAPI.PlaySFX("Finish");
        }
        else if(levelChangeScreenController.isOnLevelChange)
        {
            score.SetActive(false);
            backButton.SetActive(false);
            settingsButton.SetActive(false);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        GamePanelUIControl();
    } 

    public void GameBackButtonClick()
    {
        fillGrid.cardLocalNames.Clear();
        fillGrid.isOnGame = false;
        LeanTween.scale(difficultSelectionPanelTween.gameObject, Vector3.one * 0.1f, 0.15f);
        gameAPI.ResetSessionExp();
        packSelectionScreen.SetActive(true);
        packSelectionScreenUIController.ResetScrollPosition();
        difficultSelectionPanelTween.gameObject.SetActive(false);
        difficultSelectionPanelTween.isOnDifficultyScene = false;
        loadingScreen.SetActive(false);
        TutorialSetDeactive();
        fillGrid.ResetGrid();
        fillGrid.ResetPosition();
        GamePanelUIControl();
    }

    public void SetScoreZero()
    {
        fillGrid.scoreInt = 0;
    }

    public void PackSelected()
    {
        if(packSelectionScreenUIController.canGenerate)
        {
            difficultSelectionPanel.SetActive(true);
        }
    }
}

