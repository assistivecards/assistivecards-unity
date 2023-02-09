using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBlastUIController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private DifficultSelectionPanelTween difficultSelectionPanelTween;
    [SerializeField] private PackSelectionScreenUIController packSelectionScreenUIController;
    [SerializeField] private CardBlastFillGrid fillGrid;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject packSelectionScreen;
    [SerializeField] private GameObject transitionScreen;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject levelChange;
    [SerializeField] private GameObject difficultSelectionPanel;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Update() 
    {
        GamePanelUIControl();
    }

    public void GamePanelUIControl()
    {
        if(fillGrid.isOnGame)
        {
            backButton.SetActive(true);
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
        fillGrid.isOnGame = false;
        LeanTween.scale(difficultSelectionPanelTween.gameObject, Vector3.one * 0.1f, 0.15f);


        packSelectionScreen.SetActive(true);
        packSelectionScreenUIController.ResetScrollPosition();
        difficultSelectionPanelTween.gameObject.SetActive(false);

        difficultSelectionPanelTween.isOnDifficultyScene = false;

        transitionScreen.SetActive(false);

        fillGrid.ResetGrid();
        GamePanelUIControl();
    }

    public void PackSelected()
    {
        if(packSelectionScreenUIController.canGenerate)
        {
            difficultSelectionPanel.SetActive(true);
        }
    }
}

