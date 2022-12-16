using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameAPI gameAPI;
    private BoardGenerator boardGenerator;
    private bool levelFinished = false;

    private void Awake() 
    {
        boardGenerator = this.GetComponent<BoardGenerator>();    
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }
    public async void levelFinisher()
    {
        if(GameObject.FindGameObjectsWithTag("notMatchedCard").Length == 0)
        {
            gameAPI.PlaySFX("Finished");
            boardGenerator.ClearBoard();
            await boardGenerator.GenerateRandomBoardAsync("animals");
        }
    }
}
