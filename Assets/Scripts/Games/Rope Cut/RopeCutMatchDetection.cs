using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCutMatchDetection : MonoBehaviour
{
    private RopeCutBoardGenerator board;
    private RopeCutUIController UIController;

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<RopeCutBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<RopeCutUIController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CorrectCard")
        {
            Debug.Log("Correct Match!");
            UIController.correctMatches++;
            other.GetComponent<BoxCollider2D>().enabled = false;
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.30f);
            if (UIController.correctMatches == UIController.checkpointFrequency)
            {
                UIController.Invoke("OpenCheckPointPanel", 1.30f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1.30f);
        }

        else if (other.tag == "WrongCard")
        {
            Debug.Log("Wrong Match!");
        }
    }
}
