using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardNinjaCutController : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerUpHandler
{
    [SerializeField] private CardNinjaUIController uıController;
    [SerializeField] private GameObject cutEffect;
    private Vector2 dragStartPosition;
    private Vector2 touchPosition;
    private Vector2 dragDirection;
    public bool isDragging;
    public bool horizontalDrag;
    public bool verticalDrag;
    public int cutCount;
    public int throwedCount;

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPosition = eventData.position;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        cutEffect.SetActive(true);
        cutEffect.GetComponent<TrailRenderer>().enabled = true;
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
        else if(Mathf.Abs(dragDirection.x) >= 1000)
        {
            cutEffect.GetComponent<TrailRenderer>().Clear();
            dragDirection = Vector2.zero;
        }
        else if(Mathf.Abs(dragDirection.y) >= 1000)
        {
            cutEffect.GetComponent<TrailRenderer>().Clear();
            dragDirection = Vector2.zero;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        cutEffect.SetActive(false);
        cutEffect.GetComponent<TrailRenderer>().Clear();
        dragDirection = Vector2.zero;
        horizontalDrag = false;
        verticalDrag = false;
        isDragging = false;
    }

    private void Update() 
    {
        Vector2 trailPos = Camera.main.ScreenToWorldPoint(touchPosition);
        cutEffect.transform.position = trailPos;

        if(cutCount >= 10 || throwedCount >= 17)
        {
            uıController.LevelEnd();
        }
    }
}
