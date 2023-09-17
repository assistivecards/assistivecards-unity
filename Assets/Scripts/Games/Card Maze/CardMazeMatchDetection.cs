using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMazeMatchDetection : MonoBehaviour
{
    private CardMazeBoardGenerator board;
    private GameObject card;
    private CardMazeUIController UIController;
    private GameAPI gameAPI;
    [SerializeField] GameObject settingsButton;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

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
            gameAPI.AddSessionExp();
            UIController.backButton.GetComponent<Button>().interactable = false;
            settingsButton.GetComponent<Button>().interactable = false;
            card = other.gameObject;
            card.GetComponent<CardMazeDraggableCard>().isValid = false;
            card.GetComponent<CardMazeDraggableCard>().enabled = false;
            card.GetComponent<CircleCollider2D>().enabled = false;
            gameAPI.PlaySFX("Success");
            board.Invoke("ReadCard", 0.25f);
            Invoke("PlayCorrectMatchAnimation", 0.25f);
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.5f);

            if (UIController.correctMatches == UIController.checkpointFrequency)
            {
                gameAPI.AddExp(gameAPI.sessionExp);
                UIController.Invoke("OpenCheckPointPanel", 1.5f);
            }

            else
                board.Invoke("GenerateRandomBoardAsync", 1.5f);
        }
    }

    private void PlayCorrectMatchAnimation()
    {
        LeanTween.scale(card, Vector3.one * 12f, .25f);
    }
}
