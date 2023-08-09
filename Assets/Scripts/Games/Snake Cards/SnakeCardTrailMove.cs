using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SnakeCardTrailMove : MonoBehaviour
{
    public GameObject snake;
    [SerializeField] private SnakeCardsBoardGenerator boardGenerator;
    [SerializeField] private float speed;
    public Vector2 firstTouchPosition;
    public Vector2 secondTouchPosition;
    public Vector2 currentSwipe;
    public Vector2 direction;
    public bool move;
    private int degree = 90;

    private void Update() 
    {
        if(boardGenerator.gameStarted)
        {
            if(degree == 90) { snake.transform.position += transform.right * Time.deltaTime * speed;}
            else if(degree == -90) { snake.transform.position += -transform.right * Time.deltaTime * speed;}
            else if(degree == 180) { snake.transform.position += transform.up * Time.deltaTime * speed;}
            else if(degree == 0) { snake.transform.position += -transform.up * Time.deltaTime * speed;}
            if(Input.touchCount > 0)
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
    }

    private void DetectDirection()
    {
        direction = secondTouchPosition - firstTouchPosition;
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && direction.x > 0)
        {
            Debug.Log("right");
            RotateSnake(90);
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && direction.y > 0)
        {
            Debug.Log("up");
            RotateSnake(180);
        }
        else if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && direction.x < 0)
        {
            Debug.Log("left");
            RotateSnake(-90);
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && direction.y < 0)
        {
            Debug.Log("down");
            RotateSnake(0);
        }
    }

    public void RotateSnake(int _degree)
    {
        LeanTween.rotate(snake, new Vector3(0,0, _degree), 0.1f);
        degree = _degree;
        direction = Vector2.zero;
    }

    public void BounceSnake(float _x, float _y)
    {
        LeanTween.move(snake, new Vector3(_x, _y, 0), 0f);
    }
}
