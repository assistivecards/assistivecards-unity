using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    //Inherit this class for making draggable objects.


    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }
}
