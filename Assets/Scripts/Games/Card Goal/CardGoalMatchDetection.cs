using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGoalMatchDetection : MonoBehaviour
{
    Color green;
    private CardGoalBoardGenerator board;
    private CardGoalUIController UIController;
    private GameAPI gameAPI;
    [SerializeField] GameObject settingsButton;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#1B9738", out green);
        board = GameObject.Find("GamePanel").GetComponent<CardGoalBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<CardGoalUIController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.texture.name == board.correctCardSlug)
        {
            Debug.Log("Correct Match!");
            gameAPI.AddSessionExp();
            UIController.correctMatches++;
            UIController.backButton.GetComponent<Button>().interactable = false;
            settingsButton.GetComponent<Button>().interactable = false;
            gameAPI.PlaySFX("Success");
            board.Invoke("ReadCard", 0.25f);

            // other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.GetComponent<Rigidbody2D>().isKinematic = true;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.GetComponent<Rigidbody2D>().freezeRotation = true;
            other.transform.SetParent(transform);

            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.3f);

            if (UIController.correctMatches == UIController.checkpointFrequency)
            {
                board.Invoke("ScaleGoalPostDown", 1f);
                gameAPI.AddExp(gameAPI.sessionExp);
                UIController.Invoke("OpenCheckPointPanel", 1.3f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1.3f);

        }

        else
        {
            Debug.Log("Wrong Match!");
            gameAPI.RemoveSessionExp();
        }
    }

}
