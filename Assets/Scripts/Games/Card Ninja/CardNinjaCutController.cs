using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardNinjaCutController : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerUpHandler
{
    public bool horizontalDrag;
    public bool verticalDrag;
    private Vector2 dragStartPosition;
    [SerializeField] private GameObject cutEffect;
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
        if(Mathf.Abs(dragDirection.x) >= Mathf.Abs(dragDirection.y))
        {
            horizontalDrag = true;
            verticalDrag = false;
        }
        else if(Mathf.Abs(dragDirection.x) < Mathf.Abs(dragDirection.y))
        {
            horizontalDrag = false;
            verticalDrag = true;
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        dragDirection = Vector2.zero;
        horizontalDrag = false;
        verticalDrag = false;
    }

    private void Update() 
    {
        Vector2 trailPos = Camera.main.ScreenToWorldPoint(touchPosition);
        cutEffect.transform.position = trailPos;
    }
}
