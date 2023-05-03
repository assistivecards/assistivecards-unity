using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDrawLines : MonoBehaviour
{
    public Transform targetPosition;


    void Update()
    {
        if(targetPosition.position.y > 0)
        {
            transform.position = Vector3.Lerp(new Vector3(this.GetComponent<Tutorial>().tutorialPosition.position.x,
            (targetPosition.position.y + this.GetComponent<Tutorial>().tutorialPosition.position.y) / 2, 0),
            targetPosition.position, Mathf.PingPong(Time.time / 2, 1));
        }
        else 
        {
            transform.position = Vector3.Lerp(new Vector3(this.GetComponent<Tutorial>().tutorialPosition.position.x,
            targetPosition.position.y, 0),
            targetPosition.position, Mathf.PingPong(Time.time / 2, 1));
        }
    }
}
