using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackButton : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private GameObject cardGrid;
    [SerializeField] private BoardGenerator boardGenerator;
    [SerializeField] private GameObject packSelectionPanel;
    [SerializeField] private GameObject levelChangeScreen;
    [SerializeField] private GameObject levelDifficultySelectionPanel;
    [SerializeField] private GameObject transitionScreen;
    [SerializeField] private GamePanelUIController gamePanelUIController;
    [SerializeField] private PackSelectionScreenUIController packSelectionScreenUIController;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void GameBackButtonClick()
    {
        LeanTween.scale(cardGrid, Vector3.one * 0.0001f, 0.01f);
        LeanTween.scale(levelDifficultySelectionPanel, Vector3.one * 0.1f, 0.15f);
        LeanTween.scale(levelChangeScreen, Vector3.one * 0.1f, 0.15f);
        gameAPI.ResetSessionExp();

        packSelectionPanel.SetActive(true);
        packSelectionScreenUIController.ResetScrollPosition();
        levelDifficultySelectionPanel.SetActive(false);

        levelDifficultySelectionPanel.GetComponent<DifficultSelectionPanelTween>().isOnDifficultyScene = false;
        levelChangeScreen.SetActive(false);

        levelChangeScreen.GetComponent<LevelChangeScreenController>().isOnLevelChange = false;
        transitionScreen.SetActive(false);

        boardGenerator.ResetBoard();
        boardGenerator.isInGame = false;
        gamePanelUIController.GamePanelUIControl();
    }
}
