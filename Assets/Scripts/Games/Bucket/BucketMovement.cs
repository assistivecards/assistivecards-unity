using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BucketMovement : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData) 
    {
        var currentPos = transform.position;
        
        if(transform.position.x > 300 && transform.position.x < 1780)
        {
            transform.position = new Vector3(eventData.position.x, currentPos.y, currentPos.z);
        }
        else if(transform.position.x <= 300)
        {
            if(eventData.delta.x > 0)
            {
                transform.position = new Vector3(eventData.position.x, currentPos.y, currentPos.z);
            }
        }
        else if(transform.position.x >= 1780)
        {
            if(eventData.delta.x < 0)
            {
                transform.position = new Vector3(eventData.position.x, currentPos.y, currentPos.z);
            }
        }
    }
}
