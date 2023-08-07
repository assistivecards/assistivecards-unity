using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowCardsMatchDetection : MonoBehaviour
{
    private Rigidbody2D rb;
    private ThrowCardsBoardGenerator board;
    private ThrowCardsUIController UIController;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        board = GameObject.Find("GamePanel").GetComponent<ThrowCardsBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<ThrowCardsUIController>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.GetChild(0).GetComponent<Image>().sprite == transform.GetChild(0).GetComponent<SpriteRenderer>().sprite)
        {
            Debug.Log("CORRECT MATCH");
            gameAPI.AddSessionExp();
            UIController.correctMatches++;
            UIController.backButton.GetComponent<Button>().interactable = false;
            gameAPI.PlaySFX("Success");
            board.Invoke("ReadCard", 0.25f);
            rb.sharedMaterial.bounciness = 0;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            LeanTween.move(gameObject, other.transform.position, .25f);
            Invoke("PlayCorrectMatchAnimation", 0.25f);
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.3f);

            if (UIController.correctMatches == UIController.checkpointFrequency)
            {

                gameAPI.AddExp(gameAPI.sessionExp);
                UIController.Invoke("OpenCheckPointPanel", 1.3f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1.3f);

        }

        else
        {
            Debug.Log("WRONG MATCH");
            gameAPI.RemoveSessionExp();
            rb.sharedMaterial.bounciness = 0.6f;
        }
    }

    private void PlayCorrectMatchAnimation()
    {
        LeanTween.scale(gameObject, transform.localScale * 1.25f, .25f);
    }

}
