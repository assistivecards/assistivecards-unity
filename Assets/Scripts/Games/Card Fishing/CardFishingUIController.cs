using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFishingUIController : MonoBehaviour
{
    GameAPI gameAPI;
    
    [Header ("Scripts")]
    [SerializeField] private CardFishingRodController rodController;
    [SerializeField] private CardFishingBoardGenerator boardGenerator;

    [Header ("Panels")]
    [SerializeField] private GameObject levelChange;

    [Header ("UI Objects")]
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject packSelectionScreen;

    [SerializeField] private GameObject tutorial;
    private bool firstTime = true;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void GameUIActivate()
    {
        if(firstTime || gameAPI.GetTutorialPreference() == 1)
        {
            tutorial.SetActive(true);
        }
        gameUI.SetActive(true);
        backButton.SetActive(true);
        settingButton.SetActive(true);
        helloText.SetActive(false);
        loadingScreen.SetActive(false);
    }

    public void LevelChangeScreenActivate()
    {
        boardGenerator.ClearBoard();
        gameUI.SetActive(false);
        backButton.SetActive(false);
        settingButton.SetActive(false);
        levelChange.SetActive(true);
        LeanTween.scale(levelChange, Vector3.one * 0.5f, 0.1f);
    }

    public void CloseLevelChangePanel()
    {
        LeanTween.scale(levelChange, Vector3.zero, 0.5f);
        Invoke("LevelChangeDeactivate", 1f);
    }

    public void PackSelectionPanelActive()
    {
        gameUI.SetActive(false);
        backButton.SetActive(false);
        settingButton.SetActive(true);
        helloText.SetActive(true);
    }

    public void LevelChangeDeactivate()
    {
        levelChange.SetActive(false);
    }

    public void ResetScroll()
    {
        packSelectionScreen.transform.GetChild(0).GetChild(0).GetChild(0).transform.localPosition = Vector3.zero;
    }
    
}
