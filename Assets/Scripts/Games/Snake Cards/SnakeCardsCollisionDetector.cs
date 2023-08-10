using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCardsCollisionDetector : MonoBehaviour
{
    [SerializeField] private SnakeCardsBoardGenerator boardGenerator;
    [SerializeField] private SnakeCardTrailMove trailMove;
    public Vector3 snakePosition;
    public float snakeLenght;

    private void Update()
    {
        snakePosition = this.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "TopBorder" || other.gameObject.tag == "BottomBorder")
        {
            if(snakePosition.x > 0) { trailMove.RotateSnake(-90);}
            else if(snakePosition.x <= 0) { trailMove.RotateSnake(90);}
        }
        else if(other.gameObject.tag == "RightBorder" || other.gameObject.tag == "LeftBorder")
        {
            if(snakePosition.y > 0) { trailMove.RotateSnake(0);}
            else if(snakePosition.y <= 0) { trailMove.RotateSnake(180);}
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Snake" && !trailMove.isRotating)
        {
            snakeLenght = GetComponentInChildren<TrailRenderer>().time;
            GetComponentInChildren<TrailRenderer>().time = snakeLenght - 1f;
        }
        else if(other.gameObject.tag == "Card")
        {
            if(other.GetComponent<SnakeCardsCardController>().cardName == boardGenerator.targetCard)
            {
                snakeLenght = GetComponentInChildren<TrailRenderer>().time;
                GetComponentInChildren<TrailRenderer>().time = snakeLenght + 0.5f;
                LeanTween.scale(other.gameObject, Vector3.one * 1.2f, 0.2f).setOnComplete(other.gameObject.GetComponent<SnakeCardsCardController>().Eaten);
                Debug.Log("Here");
                // success sound
            }
            else
            {
                other.gameObject.GetComponent<SnakeCardsCardController>().Eaten();
            }
        }
    }
}
