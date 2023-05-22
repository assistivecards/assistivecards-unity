using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
            board.Invoke("ReadCard", 0.25f);
            Invoke("PlayCorrectMatchAnimation", 0.25f);
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.3f);
            board.Invoke("GenerateRandomBoardAsync", 1.3f);
        }

        else if (other.tag == "LastWaypoint" && dragHandle.path.gameObject != dragHandle.correctPath && dragHandle.canDrag)
        {
            Debug.Log("Wrong Match!");
            gameObject.GetComponent<DrawShapesDragHandle>().enabled = false;
            LeanTween.scale(gameObject, Vector3.zero, .25f);

            for (int i = 0; i < dragHandle.waypoints.Count; i++)
            {
                LeanTween.color(dragHandle.waypoints[i].GetComponent<RectTransform>(), dragHandle.waypointGrey, .25f);
            }

            Invoke("DisableCurrentHandle", 0.25f);
            LeanTween.alpha(board.cardImagesInScene[dragHandle.pathIndex].GetComponent<RectTransform>(), .5f, .25f);
        }
    }

    public void DisableCurrentHandle()
    {
        gameObject.SetActive(false);
    }

    public void PlayCorrectMatchAnimation()
    {
        LeanTween.scale(board.cardImagesInScene[dragHandle.pathIndex].gameObject, Vector3.one * 1.25f, .25f);
    }

}
