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
                    direction = Vector3.zero;
                    break;
            }
        }
        DetectDirection();
    }

    private void DetectDirection()
    {
        direction = secondTouchPosition - firstTouchPosition;
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && direction.x > 0 && directionStatus != "down") 
        {
            LeanTween.rotate(needle, new Vector3(0, 0, -90), 0.1f);
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && direction.y > 0 && directionStatus != "left") 
        {
            LeanTween.rotate(needle, new Vector3(0, 0, 0), 0.1f);
        }
        else if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && direction.x < 0 && directionStatus != "up") 
        {
            LeanTween.rotate(needle, new Vector3(0, 0, 90), 0.1f);
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && direction.y < 0 && directionStatus != "right") 
        {
            LeanTween.rotate(needle, new Vector3(0, 0, 180), 0.1f);
        }
    }
}
