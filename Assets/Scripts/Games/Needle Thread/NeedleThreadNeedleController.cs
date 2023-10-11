using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class NeedleThreadNeedleController : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    GameAPI gameAPI;
    [SerializeField] private NeedleThreadBoardGenerator boardGenerator;
    [SerializeField] private GameObject needle;
    private Vector2 dragStartPosition;
    private Vector2 touchPosition;
    private Vector2 dragDirection;
    public bool isDragging;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(boardGenerator.gameStarted)
        {
            dragStartPosition = eventData.position;
            isDragging = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(boardGenerator.gameStarted)
        {
            needle.SetActive(true);
            needle.GetComponent<TrailRenderer>().enabled = true;
            Vector2 dragEndPosition = eventData.position;
            dragDirection = dragEndPosition - dragStartPosition;

            touchPosition = new Vector3(eventData.position.x, eventData.position.y, 0);
        }
    }

    private void Update() 
    {
        if(isDragging)
        {
            Vector2 trailPos = Camera.main.ScreenToWorldPoint(touchPosition);
            needle.transform.position = trailPos;
        }
    }
}
