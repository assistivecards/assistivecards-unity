using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SnakeCardTrailMove : MonoBehaviour
{
    public GameObject snake;
    [SerializeField] private float speed;
    public Vector2 firstTouchPosition;
    public Vector2 secondTouchPosition;
    public Vector2 currentSwipe;
    public Vector2 direction;
    public bool move;
    private int degree;

    private void Update() 
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

    private void CheckSnakeIfInScreen()
    {
        if(snake.transform.localPosition.x > -500 && snake.transform.localPosition.x < 500 
        && snake.transform.localPosition.y < 300 && snake.transform.localPosition.y > -250)
        {
            move = true;
        }
        else if(snake.transform.position.x < -500)
        {
            move = false;
            if(snake.transform.position.y > 0) { RotateSnake(0);}
            if(snake.transform.position.y <= 0) { RotateSnake(180);}
            snake.transform.position = new Vector3(-499, snake.transform.position.y, 0);
            move = true;
        }
        else if(snake.transform.position.x > 500)
        {
            move = false;
            if(snake.transform.position.y > 0) { RotateSnake(0);}
            if(snake.transform.position.y <= 0) { RotateSnake(180);}
            snake.transform.position = new Vector3(499, snake.transform.position.y, 0);
            move = true;
        }
        else if(snake.transform.position.y > 300)
        {
            move = false;
            if(snake.transform.position.x > 0) { RotateSnake(-90);}
            if(snake.transform.position.x <= 0) { RotateSnake(90);}
            snake.transform.position = new Vector3(299, snake.transform.position.y, 0);
            move = true;
        }
        else if(snake.transform.position.y < -250)
        {
            move = false;
            if(snake.transform.position.x > 0) { RotateSnake(-90);}
            if(snake.transform.position.x <= 0) { RotateSnake(90);}
            snake.transform.position = new Vector3(-249, snake.transform.position.y, 0);
            move = true;
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
