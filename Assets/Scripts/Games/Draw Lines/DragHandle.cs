using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PathCreation;


public class DragHandle : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] PathCreator path;
    private DrawLinesBoardGenerator board;

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<DrawLinesBoardGenerator>();
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
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = eventData.position;
        Vector3 nearestWorldPositionOnPath = path.path.GetPointAtDistance(path.path.GetClosestDistanceAlongPath(transform.position));
        transform.position = nearestWorldPositionOnPath;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        transform.position = eventData.position;
        Vector3 nearestWorldPositionOnPath = path.path.GetPointAtDistance(path.path.GetClosestDistanceAlongPath(transform.position));
        transform.position = nearestWorldPositionOnPath;
    }
}
