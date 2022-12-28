using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelUIController : MonoBehaviour
{
    [SerializeField] private LevelChangeScreenController levelChangeScreenController;
    [SerializeField] private BoardGenerator boardGenerator;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject helloText;

    public void GamePanelUIControl()
    {
        if(boardGenerator.isInGame)
        {
            backButton.SetActive(true);
            helloText.SetActive(false);
        }
        else if(levelChangeScreenController.isOnLevelChange)
        {
            backButton.SetActive(false);
            helloText.SetActive(false);
        }
        else
        {
            backButton.SetActive(false);
            helloText.SetActive(true);
        }
    }

}
