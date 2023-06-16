using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardNinjaUIController : MonoBehaviour
{
    GameAPI gameAPI;

    [Header ("Scripts")]
    [SerializeField] private PackSelectionPanel packSelectionPanelScript;
    [SerializeField] private CardNinjaBoardGenerator boardGenerator;

    [Header ("Panels")]
    [SerializeField] private GameObject levelChange;
    [SerializeField] private GameObject gameUI;

    [Header ("UI Objects")]
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject packSelectionScreen;

    [SerializeField] private GameObject tutorial;
    private bool firstTime = true;
    private bool canGenerate;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void TutorialSetActive()
    {
        if(canGenerate)
        {
            if(firstTime || gameAPI.GetTutorialPreference() == 1)
            {
                tutorial.SetActive(true);
            }
            firstTime = false;
        }
    }

    public void GameUIActivate()
    {
        if(canGenerate)
        {
            gameUI.SetActive(true);
            backButton.SetActive(true);
            settingButton.SetActive(true);
            helloText.SetActive(false);
            loadingScreen.SetActive(false);
        }
    }

    public void LevelEnd()
    {
        gameUI.SetActive(false);
        boardGenerator.ClearBoard();
        backButton.SetActive(false);
        settingButton.SetActive(false);
        helloText.SetActive(false);
        levelChange.SetActive(true);
        LeanTween.scale(levelChange, Vector3.one * 0.5f, 0.5f);
    }
}
