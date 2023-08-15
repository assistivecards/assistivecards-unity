using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBlastUIController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private CardBlastLevelControl1 levelChangeScreenController;
    [SerializeField] private DifficultSelectionPanelTween difficultSelectionPanelTween;
    [SerializeField] private PackSelectionScreenUIController packSelectionScreenUIController;
    [SerializeField] private CardBlastFillGrid fillGrid;
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

    private void Update() 
    {
        GamePanelUIControl();
    }

    public void TutorialSetActive()
    {
        if(firstTime || gameAPI.GetTutorialPreference() == 1)
        {
            tutorial.SetActive(true);
        }
        firstTime = false;
    }

    public void GamePanelUIControl()
    {
        if(fillGrid.isOnGame && fillGrid.isBoardCreated)
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
        fillGrid.cardLocalNames.Clear();
        fillGrid.isOnGame = false;
        LeanTween.scale(difficultSelectionPanelTween.gameObject, Vector3.one * 0.1f, 0.15f);
        gameAPI.ResetSessionExp();

        packSelectionScreen.SetActive(true);
        packSelectionScreenUIController.ResetScrollPosition();
        difficultSelectionPanelTween.gameObject.SetActive(false);

        difficultSelectionPanelTween.isOnDifficultyScene = false;

        transitionScreen.SetActive(false);

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

