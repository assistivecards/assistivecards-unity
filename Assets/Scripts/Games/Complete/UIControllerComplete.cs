using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerComplete : MonoBehaviour
{
    [SerializeField] private BoardCreatorComplete boardCreatorComplete;

    [Header("Screens")]
    [SerializeField] private GameObject levelScreen;
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject packSelectionPanel;

    [Header("UI Elements")]
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject helloText;


    private void Update() 
    {
        if(boardCreatorComplete.levelEnded)
        {
            boardCreatorComplete.ResetLevel();
            levelScreen.SetActive(true);
            backButton.SetActive(true);
            helloText.SetActive(false);
        }
        else if(packSelectionPanel.activeInHierarchy)
        {
            helloText.SetActive(true);
            backButton.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);
            helloText.SetActive(false);
        }
    }
}