using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelUIController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private LevelChangeScreenController levelChangeScreenController;
    [SerializeField] private DifficultSelectionPanelTween difficultSelectionPanelTween;
    [SerializeField] private BoardGenerator boardGenerator;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject levelProgressContainer;
    [SerializeField] private GameObject packSelectionScreen;
    [SerializeField] private GameObject transitionScreen;
    [SerializeField] private GameObject tutorial;
    public bool firstTime = true;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable() 
    {
        gameAPI.PlayMusic();
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
        if(boardGenerator.isInGame)
        {
            backButton.SetActive(true);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
        else if(levelChangeScreenController.isOnLevelChange)
        {
            backButton.SetActive(false);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
        else if(difficultSelectionPanelTween.isOnDifficultyScene)
        {
            backButton.SetActive(true);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
        else if(packSelectionScreen.activeInHierarchy)
        {
            backButton.SetActive(false);
            helloText.SetActive(true);
            levelProgressContainer.SetActive(true);
        }
        else if(transitionScreen.activeInHierarchy)
        {
            backButton.SetActive(false);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
        else
        {
            backButton.SetActive(false);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
    }
}
