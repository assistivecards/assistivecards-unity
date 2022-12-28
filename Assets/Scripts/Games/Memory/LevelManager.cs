using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    GameAPI gameAPI;
    
    [SerializeField] private GameObject levelChangeScreen;
    [SerializeField] private PackageSelectManager packageSelectManager;
    private BoardGenerator boardGenerator;
    private bool levelFinished = false;
    [SerializeField] private GamePanelUIController gamePanelUIController;
    private GridLayoutGroup boardGrid;

    private void Awake() 
    {
        boardGenerator = this.GetComponent<BoardGenerator>();    
        gameAPI = Camera.main.GetComponent<GameAPI>();
        boardGrid = this.gameObject.GetComponent<GridLayoutGroup>();
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
            boardGenerator.cardSizes = 1.5f;

            boardGrid.spacing = new Vector3(75,75,1);
            boardGrid.padding.left = -40;
            boardGrid.padding.top = -50;

            boardGrid.constraintCount = 3;
        }
    }
    public async void levelFinisher()
    {
        if(GameObject.FindGameObjectsWithTag("notMatchedCard").Length == 0)
        {
            LeanTween.scale(this.gameObject, Vector3.one * 0.0001f, 0.01f);
            gameAPI.PlaySFX("Finished");
            boardGenerator.ClearBoard();
            levelChangeScreen.SetActive(true);

            LeanTween.scale(this.gameObject, Vector3.one * 0.0001f, 0.1f);
            boardGenerator.isInGame = false;
            gamePanelUIController.GamePanelUIControl();

        }
    }
}
