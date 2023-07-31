using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchMatchUIController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private BoardCreatorHatchMatch boardCreatorHatchMatch;
    [SerializeField] private GameObject levelChange;
    private LevelChangeScreenHatchMatch levelChangeScreenHatchMatch;

    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject levelProgressContainer;
    [SerializeField] private GameObject packSelectionPanel;

    private bool firstTime = true;
    [SerializeField] GameObject tutorial;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        levelChangeScreenHatchMatch = levelChange.GetComponent<LevelChangeScreenHatchMatch>();
    }

    public void TutorialSetActive()
    {
        if(firstTime || gameAPI.GetTutorialPreference() == 1)
        {
            tutorial.SetActive(true);
        }
        firstTime = false;
    }

    private void FixedUpdate() 
    {
        if(levelChangeScreenHatchMatch.isOnpackSelect)
        {
            backButton.SetActive(false);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
        if(boardCreatorHatchMatch.boardCreated)
        {
            backButton.SetActive(true);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false)
;        }
        if(packSelectionPanel.activeInHierarchy)
        {
            helloText.SetActive(true);
            levelProgressContainer.SetActive(true);
            backButton.SetActive(false);
        }
    }

}
