using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCardsBorderDetector : MonoBehaviour
{
    [SerializeField] private SnakeCardTrailMove trailMove;
    public Vector3 snakePosition;

    private void Update()
    {
        snakePosition = this.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Border")
        {
            if(snakePosition.x < -6)
            {
                if(snakePosition.y > 0) { trailMove.RotateSnake(0);}
                else if(snakePosition.y <= 0) { trailMove.RotateSnake(180);}
                trailMove.BounceSnake(-500, trailMove.snake.transform.position.y);
            }
            if(snakePosition.x > 6)
            {
                if(snakePosition.y > 0) { trailMove.RotateSnake(0);}
                else if(snakePosition.y <= 0) { trailMove.RotateSnake(180);}
                trailMove.BounceSnake(500, trailMove.snake.transform.position.y);
            }
            if(snakePosition.y < -3)
            {
                if(snakePosition.x > 0) { trailMove.RotateSnake(-90);}
                else if(snakePosition.x <= 0) { trailMove.RotateSnake(90);}
                trailMove.BounceSnake(trailMove.snake.transform.position.x, -300);
            }
            if(snakePosition.y > 3)
            {
                if(snakePosition.x > 0) { trailMove.RotateSnake(-90);}
                else if(snakePosition.x <= 0) { trailMove.RotateSnake(90);}
                trailMove.BounceSnake(trailMove.snake.transform.position.x, 300);
            }
        }
    }
}
