using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private BoardGenerator boardGenerator;
    private bool levelFinished = false;

    private void Awake() 
    {
        boardGenerator = this.GetComponent<BoardGenerator>();    
    }
    public async void levelFinisher()
    {
        if(GameObject.FindGameObjectsWithTag("notMatchedCard").Length == 0)
        {
            foreach(GameObject matched in GameObject.FindGameObjectsWithTag("matched"))
            {
                Destroy(matched);
            }
            //await boardGenerator.GenerateRandomBoardAsync("animals");
        }
    }
}
