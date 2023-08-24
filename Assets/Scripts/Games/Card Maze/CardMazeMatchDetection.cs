using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMazeMatchDetection : MonoBehaviour
{
    private CardMazeBoardGenerator board;
    private GameObject card;
    private CardMazeUIController UIController;

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<CardMazeBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<CardMazeUIController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("LEVEL COMPLETED");
            UIController.correctMatches++;
            card = other.gameObject;
            card.GetComponent<CardMazeDraggableCard>().enabled = false;
            card.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("PlayCorrectMatchAnimation", 0.25f);
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.3f);

            if (UIController.correctMatches == UIController.checkpointFrequency)
            {
                UIController.Invoke("OpenCheckPointPanel", 1.3f);
            }

            else
                board.Invoke("GenerateRandomBoardAsync", 1.3f);
        }
    }

    private void PlayCorrectMatchAnimation()
    {
        LeanTween.scale(card, Vector3.one * 12f, .25f);
    }
}
