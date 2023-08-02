using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PatternTrainCardController : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public bool draggable = false;

    public void OnDrag(PointerEventData eventData)
    {
        if(draggable) 
        {
            transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        if(draggable) 
        {
            transform.position = eventData.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag == "Card") 
        {
            Debug.Log("Here");
        }
    }
}
