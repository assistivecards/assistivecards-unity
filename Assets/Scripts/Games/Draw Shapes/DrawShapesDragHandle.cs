using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PathCreation;
using UnityEngine.UI;

public class DrawShapesDragHandle : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public PathCreator path;
    private DrawShapesBoardGenerator board;
    private DrawShapeTutorial tutorial;
    public float distanceThreshold;
    public bool canDrag;
    public List<GameObject> waypoints;
    public GameObject correctPath;
    private GameAPI gameAPI;
    public Color waypointGrey;
    public Color waypointGreen;
    public Color waypointGreyFade;
    private GameObject lastWaypoint;
    public int pathIndex;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable()
    {
        board = GameObject.Find("GamePanel").GetComponent<DrawShapesBoardGenerator>();
        MatchHandlesWithPaths();
    }

    public void MatchHandlesWithPaths()
    {
        if (gameObject.name == "Handle1")
        {
            pathIndex = 0;
            // path = board.randomPaths[0].GetComponent<PathCreator>();
        }
        else if (gameObject.name == "Handle2")
        {
            pathIndex = 1;
            // path = board.randomPaths[1].GetComponent<PathCreator>();
        }
        else if (gameObject.name == "Handle3")
        {
            pathIndex = 2;
            // path = board.randomPaths[2].GetComponent<PathCreator>();
        }

        path = board.randomPaths[pathIndex].GetComponent<PathCreator>();

        correctPath = board.randomPaths[board.correctCardIndex];

        waypoints.Clear();

        for (int i = 0; i < path.transform.GetChild(0).childCount; i++)
        {
            waypoints.Add(path.transform.GetChild(0).GetChild(i).gameObject);
        }

        lastWaypoint = waypoints[waypoints.Count - 1];
        lastWaypoint.AddComponent<CircleCollider2D>();
        lastWaypoint.GetComponent<CircleCollider2D>().radius = 10;
        lastWaypoint.GetComponent<CircleCollider2D>().isTrigger = true;
        lastWaypoint.tag = "LastWaypoint";
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
                if (Physics2D.OverlapPoint(waypoints[i].transform.position) == GetComponent<Collider2D>() && canDrag)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        waypoints[j].GetComponent<Image>().color = waypointGreen;
                    }
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
        // transform.position = eventData.position;
        // Vector3 nearestWorldPositionOnPath = path.path.GetPointAtDistance(path.path.GetClosestDistanceAlongPath(transform.position));
        // transform.position = nearestWorldPositionOnPath;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (path.gameObject != correctPath)
        {
            canDrag = false;
            LeanTween.move(gameObject, path.path.GetPoint(0), .25f);

            for (int i = 0; i < waypoints.Count; i++)
            {
                LeanTween.color(waypoints[i].GetComponent<RectTransform>(), waypointGrey, .25f);
            }
        }
    }
}
