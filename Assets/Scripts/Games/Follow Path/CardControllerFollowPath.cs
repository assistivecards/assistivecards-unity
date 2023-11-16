using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControllerFollowPath : MonoBehaviour
{
    private BoardGeneratorFollowPath boardGenerator;
    public bool isCorrect;
    public bool isAllCorrectSelected;

    private void OnEnable() 
    {
        boardGenerator = GameObject.Find("GamePanel").GetComponent<BoardGeneratorFollowPath>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Touch")
        {
            boardGenerator.CheckPath();
            if(isAllCorrectSelected && isCorrect)
            {
                Debug.Log("Level End");
            }
            else
            {
                Debug.Log(this.name);
            }
        }
    }
}
