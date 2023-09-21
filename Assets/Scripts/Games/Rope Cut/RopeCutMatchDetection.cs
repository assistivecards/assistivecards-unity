using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeCutMatchDetection : MonoBehaviour
{
    private RopeCutBoardGenerator board;
    private RopeCutUIController UIController;
    private GameAPI gameAPI;
    [SerializeField] Button settingsButton;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

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
            gameAPI.AddSessionExp();
            UIController.correctMatches++;
            UIController.backButton.GetComponent<Button>().interactable = false;
            gameAPI.PlaySFX("Success");
            other.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(other.GetComponent<HingeJoint2D>());
            board.Invoke("ReadCard", 0.25f);
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.30f);
            if (UIController.correctMatches == UIController.checkpointFrequency)
            {
                gameAPI.AddExp(gameAPI.sessionExp);
                UIController.Invoke("OpenCheckPointPanel", 1.30f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1.30f);
        }

        else if (other.tag == "WrongCard")
        {
            Debug.Log("Wrong Match!");
            gameAPI.RemoveSessionExp();
            Destroy(other.GetComponent<HingeJoint2D>());
        }

        settingsButton.interactable = true;
        // Destroy(other.GetComponent<HingeJoint2D>());

    }
}
