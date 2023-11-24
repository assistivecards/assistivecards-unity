using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DraggableSpellCards : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool touching;

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        touching = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        touching = false;
    }
}
