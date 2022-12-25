using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackButton : MonoBehaviour
{
    [SerializeField] private GameObject cardGrid;
    [SerializeField] private BoardGenerator boardGenerator;
    [SerializeField] private GameObject packSelectionPanel;
    [SerializeField] private GameObject levelDifficultySelectionPanel;
    [SerializeField] private GamePanelUIController gamePanelUIController;

    public void GameBackButtonClick()
    {
        LeanTween.scale(cardGrid, Vector3.one * 0.0001f, 0.01f);
        packSelectionPanel.SetActive(true);
        boardGenerator.ResetBoard();
        boardGenerator.isInGame = false;
        gamePanelUIController.GamePanelUIControl();
    }
}
