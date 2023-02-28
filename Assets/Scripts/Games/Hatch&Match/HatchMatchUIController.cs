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
    [SerializeField] private GameObject packSelectionPanel;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        levelChangeScreenHatchMatch = levelChange.GetComponent<LevelChangeScreenHatchMatch>();
    }

    private void FixedUpdate() 
    {
        if(levelChangeScreenHatchMatch.isOnpackSelect)
        {
            backButton.SetActive(false);
            helloText.SetActive(false);
        }
        if(boardCreatorHatchMatch.boardCreated)
        {
            backButton.SetActive(true);
            helloText.SetActive(false);
        }
        if(packSelectionPanel.activeInHierarchy)
        {
            helloText.SetActive(true);
            backButton.SetActive(false);
        }
    }

}
