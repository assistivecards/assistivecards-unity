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

        transform.position = new Vector3(eventData.position.x, currentPos.y, currentPos.z);
    }
}
