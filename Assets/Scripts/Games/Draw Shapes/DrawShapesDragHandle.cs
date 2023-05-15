using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PathCreation;
using UnityEngine.UI;

public class DrawShapesDragHandle : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] PathCreator path;
    private DrawShapesBoardGenerator board;
    public float distanceThreshold;
    public bool canDrag;
    public List<GameObject> waypoints;
    [SerializeField] GameObject correctPath;

    private void OnEnable()
    {
        board = GameObject.Find("GamePanel").GetComponent<DrawShapesBoardGenerator>();
        MatchHandlesWithPaths();
    }

    public void MatchHandlesWithPaths()
    {
        if (gameObject.name == "Handle1")
        {
            path = board.randomPaths[0].GetComponent<PathCreator>();
        }
        else if (gameObject.name == "Handle2")
        {
            path = board.randomPaths[1].GetComponent<PathCreator>();
        }
        else if (gameObject.name == "Handle3")
        {
            path = board.randomPaths[2].GetComponent<PathCreator>();
        }

        correctPath = board.randomPaths[board.correctCardIndex];

        waypoints.Clear();

        for (int i = 0; i < path.transform.GetChild(0).childCount; i++)
        {
            waypoints.Add(path.transform.GetChild(0).GetChild(i).gameObject);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            transform.position = eventData.position;
            Vector3 nearestWorldPositionOnPath = path.path.GetPointAtDistance(path.path.GetClosestDistanceAlongPath(transform.position));
            // transform.position = nearestWorldPositionOnPath;
            if (Vector3.Distance(eventData.position, nearestWorldPositionOnPath) > distanceThreshold)
            {
                canDrag = false;
                LeanTween.move(gameObject, path.path.GetPoint(0), .25f);
            }

        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canDrag = true;
        transform.position = eventData.position;
        Vector3 nearestWorldPositionOnPath = path.path.GetPointAtDistance(path.path.GetClosestDistanceAlongPath(transform.position));
        // transform.position = nearestWorldPositionOnPath;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (path.gameObject != correctPath)
        {
            LeanTween.move(gameObject, path.path.GetPoint(0), .25f);
        }
    }
}
