using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SnakeCardTrailMove : MonoBehaviour
{
    [SerializeField] private GameObject snake;
    public Vector2 firstTouchPosition;
    public Vector2 secondTouchPosition;
    public Vector2 currentSwipe;
    public Vector2 direction;

    private void Update() 
    {
        snake.transform.position += transform.right * Time.deltaTime * 0.5f;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    firstTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    secondTouchPosition = touch.position;
                    DetectDirection();
                    break;
            }

        }
    }

    private void DetectDirection()
    {
        direction = secondTouchPosition - firstTouchPosition;
        Debug.Log(direction);
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && direction.x > 0)
        {
            Debug.Log("right");
            RotateSnake(0);
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && direction.y > 0)
        {
            Debug.Log("up");
            RotateSnake(0);
        }
        else if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && direction.x < 0)
        {
            Debug.Log("left");
            RotateSnake(0);
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && direction.y < 0)
        {
            Debug.Log("down");
            RotateSnake(0);
        }
    }

    private void RotateSnake(int degree)
    {
        direction = Vector2.zero;
    }
}
