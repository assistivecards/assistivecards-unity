using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PatternTrainCardController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public string cardName;
    public string trueCardName;
    public bool draggable = false;
    private Vector3 startPosition;
    private bool isPointerUp;

    private void OnEnable() 
    {
        startPosition = this.transform.position;
    }

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
        isPointerUp = false;
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
        isPointerUp = true;
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.collider.tag == "Card" && cardName == trueCardName && isPointerUp) 
        {
            LeanTween.move(this.gameObject, other.transform.position, 0.5f).setOnComplete(RotateCard);
        }
        else if(cardName != trueCardName && isPointerUp)
        {
            LeanTween.move(this.gameObject, startPosition, 1f);
        }
    }

    private void RotateCard()
    {
        LeanTween.rotate(this.gameObject, new Vector3(0, 0, 5f), 1f);
    }
}
