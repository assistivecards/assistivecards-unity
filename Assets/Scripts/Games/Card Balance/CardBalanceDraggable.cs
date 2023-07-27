using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardBalanceDraggable : MonoBehaviour,  IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Rigidbody2D cardRB;
    public bool draggable;
    

    public void ActivateGravityEffect() 
    {
        if(draggable)
        {
            cardRB.gravityScale = 100;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(draggable)
        {
            transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
            cardRB.gravityScale = 0;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(draggable)
        {
            transform.position = eventData.position;
        }
    }
        
    public void OnPointerUp(PointerEventData eventData)
    {
        if(draggable)
        {
            ActivateGravityEffect();
        }
    }
}
