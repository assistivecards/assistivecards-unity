using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardBalanceDraggable : MonoBehaviour,  IDragHandler, IPointerDownHandler
{
    GameAPI gameAPI;
    public Rigidbody2D cardRB;
    public bool draggable;
    
    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void ActiavateGravityEffect() 
    {
        if(draggable)
        {
            cardRB.gravityScale = 100;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!draggable)
            this.transform.position = eventData.position;
    }
}
