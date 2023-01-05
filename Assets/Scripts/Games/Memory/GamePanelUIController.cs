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
    [SerializeField] private GameObject speakerIcon;
    [SerializeField] private GameObject packSelectionScreen;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable() 
    {
        gameAPI.PlayMusic();
    }

    public void GamePanelUIControl()
    {
        if(boardGenerator.isInGame)
        {
            backButton.SetActive(true);
            helloText.SetActive(false);
            speakerIcon.SetActive(false);
        }
        else if(levelChangeScreenController.isOnLevelChange)
        {
            backButton.SetActive(false);
            helloText.SetActive(false);
            speakerIcon.SetActive(false);
        }
        else if(difficultSelectionPanelTween.isOnDifficultyScene)
        {
            backButton.SetActive(true);
            helloText.SetActive(false);
            speakerIcon.SetActive(false);
        }
        else if(packSelectionScreen.activeInHierarchy)
        {
            backButton.SetActive(false);
            helloText.SetActive(true);
            speakerIcon.SetActive(true);
        }
        else
        {
            backButton.SetActive(false);
            helloText.SetActive(false);
            speakerIcon.SetActive(false);
        }
    }
}
