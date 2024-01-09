using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BucketMovement : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData) 
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            transform.position = new Vector3(eventData.position.x, this.transform.position.y, 1);
        }
        else
        {
            if (Input.touchCount > 0)
            {
                transform.position = new Vector3(eventData.position.x, this.transform.position.y, 1);
            }
		}
    }
}
