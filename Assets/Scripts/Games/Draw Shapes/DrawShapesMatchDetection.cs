using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DrawShapesMatchDetection : MonoBehaviour
{
    private DrawShapesDragHandle dragHandle;
    private DrawShapesBoardGenerator board;
    private DrawShapesUIController UIController;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        dragHandle = gameObject.GetComponent<DrawShapesDragHandle>();
        board = GameObject.Find("GamePanel").GetComponent<DrawShapesBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<DrawShapesUIController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LastWaypoint" && dragHandle.path.gameObject == dragHandle.correctPath && dragHandle.canDrag)
        {
            Debug.Log("Correct Match!");
            UIController.correctMatches++;
            UIController.backButton.GetComponent<Button>().interactable = false;
            gameAPI.PlaySFX("Success");
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

            if (UIController.correctMatches == UIController.checkpointFrequency)
            {
                UIController.Invoke("OpenCheckPointPanel", 1.3f);
            }
            else
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
        LeanTween.scale(board.cardImagesInScene[dragHandle.pathIndex].gameObject, Vector3.one * 1.10f, .25f);
        LeanTween.scale(board.pathsParents[dragHandle.pathIndex].gameObject, board.pathsParents[dragHandle.pathIndex].transform.localScale * 1.10f, .25f);
    }

}
