using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardElementComplete : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public string cardType;
    public bool moveable;

    public void OnDrag(PointerEventData eventData)
    {
        if(moveable)
            this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(moveable)
            this.transform.position = eventData.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {   if(moveable)
        {
            if(other.gameObject.name == this.gameObject.name)
            {
                LeanTween.move(this.gameObject, other.transform.position, 0.75f);
            }
        }
    }

}
