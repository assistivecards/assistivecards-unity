using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackButton : MonoBehaviour
{
    [SerializeField] private BoardGenerator boardGenerator;
    [SerializeField] private GameObject packSelectionPanel;
    [SerializeField] private GameObject levelDifficultySelectionPanel;

    public void GameBackButtonClick()
    {
        levelDifficultySelectionPanel.SetActive(true);
        packSelectionPanel.SetActive(true);
        boardGenerator.ResetBoard();
    }
}
