using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PathCreation;


public class DragHandle : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] PathCreator path;
    private DrawLinesBoardGenerator board;
    public float distanceThreshold;
    public bool canDrag;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable()
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
        if (canDrag)
        {
            transform.position = eventData.position;
            Vector3 nearestWorldPositionOnPath = path.path.GetPointAtDistance(path.path.GetClosestDistanceAlongPath(transform.position));
            // transform.position = nearestWorldPositionOnPath;
            if (Vector3.Distance(eventData.position, nearestWorldPositionOnPath) > distanceThreshold)
            {
                canDrag = false;
                LeanTween.move(gameObject, path.path.GetPoint(0), .25f);
                // transform.position = path.path.GetPoint(0);
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameAPI.VibrateWeak();
        gameAPI.PlaySFX("Pickup");
        canDrag = true;
        transform.position = eventData.position;
        Vector3 nearestWorldPositionOnPath = path.path.GetPointAtDistance(path.path.GetClosestDistanceAlongPath(transform.position));
        // transform.position = nearestWorldPositionOnPath;
    }
}
