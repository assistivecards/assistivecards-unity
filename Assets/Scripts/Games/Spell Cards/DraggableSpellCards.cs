using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DraggableSpellCards : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public bool isDraggable;
    public bool isPointerUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerUp = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isDraggable)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerUp = true;
    }
}
