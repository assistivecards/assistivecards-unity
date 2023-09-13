using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCardsCollisionDetector : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private SnakeCardsBoardGenerator boardGenerator;
    [SerializeField] private SnakeCardTrailMove trailMove;
    public Vector3 snakePosition;
    public float snakeLenght;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Update()
    {
        snakePosition = this.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "TopBorder" || other.gameObject.tag == "BottomBorder")
        {
            if(snakePosition.x > 0) { trailMove.RotateSnake(0);}
            else if(snakePosition.x <= 0) { trailMove.RotateSnake(180);}
        }
        else if(other.gameObject.tag == "RightBorder" || other.gameObject.tag == "LeftBorder")
        {
            if(snakePosition.y > 0) { trailMove.RotateSnake(90);}
            else if(snakePosition.y <= 0) { trailMove.RotateSnake(-90);}
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Snake" && !trailMove.isRotating)
        {
            gameAPI.RemoveSessionExp();
            snakeLenght = GetComponentInChildren<TrailRenderer>().time;
            if(snakeLenght > 1.5f)
            {
                GetComponentInChildren<TrailRenderer>().time = snakeLenght - 2f;
            }
        }
        else if(other.gameObject.tag == "Card")
        {
            if(other.GetComponent<SnakeCardsCardController>().cardName == boardGenerator.targetCard)
            {
                gameAPI.AddSessionExp();
                snakeLenght = GetComponentInChildren<TrailRenderer>().time;
                GetComponentInChildren<TrailRenderer>().time = snakeLenght + 2f;
                LeanTween.scale(other.gameObject, Vector3.one * 1.2f, 0.2f).setOnComplete(other.gameObject.GetComponent<SnakeCardsCardController>().Eaten);
                boardGenerator.CardEaten();
                gameAPI.Speak(other.GetComponent<SnakeCardsCardController>().cardLocalName);
                Debug.Log(other.GetComponent<SnakeCardsCardController>().cardLocalName);
                Invoke("SuccessSound", 0.25f);
               
            }
            else
            {
                other.gameObject.GetComponent<SnakeCardsCardController>().Eaten();
            }
        }
    }

    private void SuccessSound()
    {
        gameAPI.PlaySFX("Success");
    }
}
