using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private GameObject levelChangeScreen;
    [SerializeField] private GameObject packSelectionPanel;
    [SerializeField] private PackageSelectManager packageSelectManager;
    private BoardGenerator boardGenerator;
    private bool levelFinished = false;
    [SerializeField] private GamePanelUIController gamePanelUIController;
    private GridLayoutGroup boardGrid;
    private List<GameObject> notMatchedCards = new List<GameObject>(); 

    private void Awake() 
    {
        boardGenerator = this.GetComponent<BoardGenerator>();    
        gameAPI = Camera.main.GetComponent<GameAPI>();
        boardGrid = this.gameObject.GetComponent<GridLayoutGroup>();
    }

    public void SignOutFromGame()
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.0001f, 0.01f);

        boardGenerator.ClearBoard();
        boardGenerator.isInGame = false;
        gamePanelUIController.GamePanelUIControl();
        levelChangeScreen.SetActive(false);
        packSelectionPanel.SetActive(true);
    }

    public void CustomBoard()
    {
        if(boardGenerator.cardNumber < 7)
        {
            boardGenerator.cardSizes = 2.25f;

            boardGrid.spacing = new Vector3(250, 200, 0);
            boardGrid.padding.left = 50;
            boardGrid.padding.top = 0;

            boardGrid.constraintCount = 2;
        }
        else if(boardGenerator.cardNumber < 11)
        {
            boardGenerator.cardSizes = 2f;

            boardGrid.spacing = new Vector3(125, 150, 0);
            boardGrid.padding.left = -50;
            boardGrid.padding.top = 10;

            boardGrid.constraintCount = 2;
        }
        else if(boardGenerator.cardNumber < 21)
        {
            boardGenerator.cardSizes = 1.75f;

            boardGrid.spacing = new Vector3(85,90,1);
            boardGrid.padding.left = -60;
            boardGrid.padding.top = -45;

            boardGrid.constraintCount = 3;
        }
    }
    public void LevelFinisher()
    {
        if(GameObject.FindGameObjectsWithTag("notMatchedCard").Length == 0)
        {
            Invoke("EndLevel", 1.15f);
        }
    }

    private void EndLevel()
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.0001f, 0.01f);
        gameAPI.PlaySFX("Finished");
        boardGenerator.ClearBoard();
        levelChangeScreen.SetActive(true);
        gameAPI.AddExp(gameAPI.sessionExp);
        LeanTween.scale(this.gameObject, Vector3.one * 0.0001f, 0.1f);
        boardGenerator.isInGame = false;
        gamePanelUIController.GamePanelUIControl();
    }
}
