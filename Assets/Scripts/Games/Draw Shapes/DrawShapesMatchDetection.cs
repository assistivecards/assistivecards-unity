using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DrawShapesMatchDetection : MonoBehaviour
{
    private DrawShapesDragHandle dragHandle;
    private DrawShapesBoardGenerator board;

    private void Start()
    {
        dragHandle = gameObject.GetComponent<DrawShapesDragHandle>();
        board = GameObject.Find("GamePanel").GetComponent<DrawShapesBoardGenerator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LastWaypoint" && dragHandle.path.gameObject == dragHandle.correctPath && dragHandle.canDrag)
        {
            Debug.Log("Correct Match!");
            gameObject.GetComponent<DrawShapesDragHandle>().enabled = false;
            LeanTween.scale(gameObject, Vector3.zero, .25f);
            for (int i = 0; i < dragHandle.waypoints.Count; i++)
            {
                LeanTween.color(dragHandle.waypoints[i].GetComponent<RectTransform>(), dragHandle.waypointGreen, .25f);
            }

            Invoke("DisableCurrentHandle", 0.25f);
            board.Invoke("ScaleImagesDown", .75f);
            board.Invoke("ClearBoard", 1.05f);
            board.Invoke("GenerateRandomBoardAsync", 1.05f);
        }

        else if (other.tag == "LastWaypoint" && dragHandle.path.gameObject != dragHandle.correctPath && dragHandle.canDrag)
        {
            Debug.Log("Wrong Match!");
        }
    }

    public void DisableCurrentHandle()
    {
        gameObject.SetActive(false);
    }

}
