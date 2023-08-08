using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SnakeCardTrailMove : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerUpHandler, IEndDragHandler
{
    [SerializeField] private GameObject snake;
    private Vector2 dragStartPosition;
    private Vector2 touchPosition;
    private Vector2 dragDirection;

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragEndPosition = eventData.position;
        dragDirection = dragEndPosition - dragStartPosition;
        touchPosition = new Vector3(eventData.position.x, eventData.position.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragDirection = Vector2.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragDirection = Vector2.zero;
    }

    private void Update() 
    {
        Vector2 trailPos = Camera.main.ScreenToWorldPoint(touchPosition);
        snake.transform.position += transform.right * Time.deltaTime * 0.5f;
    }
}
