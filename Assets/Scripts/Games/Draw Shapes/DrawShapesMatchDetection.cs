using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DrawShapesMatchDetection : MonoBehaviour
{
    private DrawShapesDragHandle dragHandle;

    private void Start()
    {
        dragHandle = gameObject.GetComponent<DrawShapesDragHandle>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LastWaypoint" && dragHandle.path.gameObject == dragHandle.correctPath)
        {
            Debug.Log("Correct Match!");
        }

        else
        {
            Debug.Log("Wrong Match!");
        }
    }

}
