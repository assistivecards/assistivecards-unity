using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PathCreation;
using UnityEngine.UI;

public class DragHandle : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] PathCreator path;
    private DrawLinesBoardGenerator board;
    public float distanceThreshold;
    public bool canDrag;
    private GameAPI gameAPI;
    public List<GameObject> waypoints;
    public Color waypointGrey;
    public Color waypointGreen;
    [SerializeField] GameObject correctPath;

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

        correctPath = board.randomPaths[board.correctMatchIndex];

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
                for (int i = 0; i < waypoints.Count; i++)
                {
                    LeanTween.color(waypoints[i].GetComponent<RectTransform>(), waypointGrey, .25f);
                }
            }

            for (int i = 0; i < waypoints.Count; i++)
            {
                if (transform.position.x > waypoints[i].transform.position.x)
                {
                    waypoints[i].GetComponent<Image>().color = waypointGreen;
                }
                else
                    waypoints[i].GetComponent<Image>().color = waypointGrey;
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

    public void OnPointerUp(PointerEventData eventData)
    {
        if (path.gameObject != correctPath)
        {
            LeanTween.move(gameObject, path.path.GetPoint(0), .25f);
            for (int i = 0; i < waypoints.Count; i++)
            {
                LeanTween.color(waypoints[i].GetComponent<RectTransform>(), waypointGrey, .25f);
            }
        }
    }
}
