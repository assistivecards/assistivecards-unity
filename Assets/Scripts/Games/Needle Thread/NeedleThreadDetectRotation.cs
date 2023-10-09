using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleThreadDetectRotation : MonoBehaviour
{
    [SerializeField] private GameObject needle;
    public Vector2 firstTouchPosition;
    public Vector2 secondTouchPosition;
    public Vector2 currentSwipe;
    public Vector2 direction;
    public string directionStatus;

    private void Update() 
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    firstTouchPosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    secondTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    ResetMovement();
                    break;
            }
        }
        DetectDirection();
        if(direction.x > 100 || direction.x < 100  || direction.y > 100 || direction.y < 100)
        {
            ResetMovement();
        }
    }

    private void DetectDirection()
    {
        direction = secondTouchPosition - firstTouchPosition;
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && direction.x > 0) 
        {
            LeanTween.rotate(needle, new Vector3(0, 0, -90), 0.1f);
            //up
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && direction.y > 0) 
        {
            LeanTween.rotate(needle, new Vector3(0, 0, 0), 0.1f);
            //right
        }
        else if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && direction.x < 0) 
        {
            LeanTween.rotate(needle, new Vector3(0, 0, 90), 0.1f);
            // down
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && direction.y < 0) 
        {
            LeanTween.rotate(needle, new Vector3(0, 0, 180), 0.1f);
            //left
        }
    }

    private void ResetMovement()
    {
        direction = Vector3.zero;
    }
}
