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
            boardGenerator.cardSizes = 2;

            boardGrid.spacing = Vector3.one * 150;
            boardGrid.padding.left = 150;
            boardGrid.padding.top = 0;

            boardGrid.constraintCount = 2;
        }
        else if(boardGenerator.cardNumber < 11)
        {
            boardGenerator.cardSizes = 1.75f;

            boardGrid.spacing = Vector3.one * 100;
            boardGrid.padding.left = 0;
            boardGrid.padding.top = 35;

            boardGrid.constraintCount = 2;
        }
        else if(boardGenerator.cardNumber < 21)
        {
            boardGenerator.cardSizes = 1.35f;

            boardGrid.spacing = new Vector3(60,50,1);
            boardGrid.padding.left = 0;
            boardGrid.padding.top = 0;

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
