using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDetectionFollowPath : MonoBehaviour
{
    public bool onPath = true;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "Path" || other.tag == "CorrectPath")
        {
            onPath = true;
        }
    }

    private void FixedUpdate() 
    {
        if(onPath)
        {
            onPath = false;
            Invoke("CheckIsOnPath", 0.2f);
        }
    }

    private void CheckIsOnPath()
    {
        if(onPath == false)
        {
            GetComponentInParent<CardControllerFollowPath>().MoveToBeginning();
        }
    }
}
