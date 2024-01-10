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
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            isPointerUp = false;
        }
        else
        {
            if (Input.touchCount > 0)
            {
                isPointerUp = false;
		    }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            if(isDraggable)
            {
                this.transform.position = eventData.position;
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                if(isDraggable)
                {
                    this.transform.position = eventData.position;
                }
		    }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerUp = true;
    }
}
