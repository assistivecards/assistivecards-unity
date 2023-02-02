using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCrushGameUIController : MonoBehaviour
{
    [SerializeField] private LevelChangeScreenController levelChangeScreenController;
    [SerializeField] private DifficultSelectionPanelTween difficultSelectionPanelTween;
    [SerializeField] private PackSelectionScreenUIController packSelectionScreenUIController;
    [SerializeField] private CardCrushFillGrid fillGrid;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject packSelectionScreen;
    [SerializeField] private GameObject transitionScreen;

    private void Update() 
    {
        GamePanelUIControl();
    }

    public void GamePanelUIControl()
    {
        if(fillGrid.isBoardCreated)
        {
            backButton.SetActive(true);
            helloText.SetActive(false);
        }
        else if(levelChangeScreenController.isOnLevelChange)
        {
            backButton.SetActive(false);
            helloText.SetActive(false);
        }
        else if(difficultSelectionPanelTween.isOnDifficultyScene)
        {
            backButton.SetActive(true);
            helloText.SetActive(false);
        }
        else if(packSelectionScreen.activeInHierarchy)
        {
            backButton.SetActive(false);
            helloText.SetActive(true);
        }
        else if(transitionScreen.activeInHierarchy)
        {
            backButton.SetActive(false);
            helloText.SetActive(false);
        }
        else
        {
            backButton.SetActive(false);
            helloText.SetActive(false);
        }
    }

    public void GameBackButtonClick()
    {
        //LeanTween.scale(cardGrid, Vector3.one * 0.0001f, 0.01f);
        LeanTween.scale(difficultSelectionPanelTween.gameObject, Vector3.one * 0.1f, 0.15f);
        LeanTween.scale(levelChangeScreenController.gameObject, Vector3.one * 0.1f, 0.15f);


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
}
