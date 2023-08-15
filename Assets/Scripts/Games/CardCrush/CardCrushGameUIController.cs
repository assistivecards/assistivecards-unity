using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCrushGameUIController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private CardCrushLevelControl levelChangeScreenController;
    [SerializeField] private DifficultSelectionPanelTween difficultSelectionPanelTween;
    [SerializeField] private PackSelectionScreenUIController packSelectionScreenUIController;
    [SerializeField] private CardCrushFillGrid fillGrid;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject levelProgressContainer;
    [SerializeField] private GameObject packSelectionScreen;
    [SerializeField] private GameObject transitionScreen;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject levelChange;
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

    private void Update() 
    {
        GamePanelUIControl();
    }

    public void GamePanelUIControl()
    {
        if(fillGrid.isOnGame)
        {
            score.SetActive(true);
            backButton.SetActive(true);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
        else if(fillGrid.scoreInt >= 100)
        {
            levelChange.SetActive(true);
            gameAPI.PlaySFX("Finish");
        }
        else if(levelChangeScreenController.isOnLevelChange)
        {
            score.SetActive(false);
            backButton.SetActive(false);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
        else if(difficultSelectionPanelTween.isOnDifficultyScene)
        {
            score.SetActive(false);
            backButton.SetActive(true);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
        else if(packSelectionScreen.activeInHierarchy)
        {
            score.SetActive(false);
            backButton.SetActive(false);
            helloText.SetActive(true);
            levelProgressContainer.SetActive(true);
        }
        else if(transitionScreen.activeInHierarchy)
        {
            score.SetActive(false);
            backButton.SetActive(false);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
        else
        {
            score.SetActive(false);
            backButton.SetActive(false);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
    }

    public void GameBackButtonClick()
    {
        //LeanTween.scale(cardGrid, Vector3.one * 0.0001f, 0.01f);
        fillGrid.isOnGame = false;
        LeanTween.scale(difficultSelectionPanelTween.gameObject, Vector3.one * 0.1f, 0.15f);
        LeanTween.scale(levelChangeScreenController.gameObject, Vector3.one * 0.1f, 0.15f);
        gameAPI.ResetSessionExp();

        packSelectionScreen.SetActive(true);
        packSelectionScreenUIController.ResetScrollPosition();
        difficultSelectionPanelTween.gameObject.SetActive(false);

        difficultSelectionPanelTween.isOnDifficultyScene = false;
        levelChangeScreenController.gameObject.SetActive(false);

        levelChangeScreenController.isOnLevelChange = false;
        transitionScreen.SetActive(false);

        fillGrid.ResetGrid();
        //fillGrid.isBoardCreated = false;
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
