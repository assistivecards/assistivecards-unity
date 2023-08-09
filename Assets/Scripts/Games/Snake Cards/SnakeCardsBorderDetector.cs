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
}
