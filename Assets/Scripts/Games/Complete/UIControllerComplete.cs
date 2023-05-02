using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerComplete : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private BoardCreatorComplete boardCreatorComplete;

    [Header("Screens")]
    [SerializeField] private GameObject levelScreen;
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject gridBackground;
    [SerializeField] private GameObject packSelectionPanel;

    [Header("UI Elements")]
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject helloText;
    public bool firstTime = true;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void TutorialSetActive(GameObject _tutorial)
    {
        if(firstTime || gameAPI.GetTutorialPreference() == 1)
        {
            _tutorial.SetActive(true);
        }
        firstTime = false;
    }

    private void Update() 
    {
        if(boardCreatorComplete.levelEnded)
        {
            boardCreatorComplete.ResetLevel();
            levelScreen.SetActive(true);
            helloText.SetActive(false);
            gridBackground.SetActive(false);
            backButton.SetActive(false);
        }
        else if(packSelectionPanel.activeInHierarchy)
        {
            helloText.SetActive(true);
            backButton.SetActive(false);
            gridBackground.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);
            helloText.SetActive(false);
        }
    }

}
