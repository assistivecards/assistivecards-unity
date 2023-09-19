using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardChainDraggable : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
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
