using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private GameObject levelChangeScreen;
    [SerializeField] private PackageSelectManager packageSelectManager;
    private BoardGenerator boardGenerator;
    private bool levelFinished = false;
    [SerializeField] private GamePanelUIController gamePanelUIController;

    private void Awake() 
    {
        boardGenerator = this.GetComponent<BoardGenerator>();    
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void CustomBoard()
    {
        if(boardGenerator.cardNumber < 7)
        {
        
        }
        else if(boardGenerator.cardNumber < 11)
        {

        }
        else if(boardGenerator.cardNumber < 21)
        {

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
