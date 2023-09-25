using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwapCardsCardController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private GameAPI gameAPI;
    private bool isPointerUp;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }
    
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.transform.tag == "Border" && this.transform.parent.gameObject != other.gameObject)
        {
            if(isPointerUp)
            {
                GameObject otherCard = other.transform.GetChild(0).gameObject;
                Transform thisCardParent = this.transform.parent.transform;

                LeanTween.move(this.gameObject, other.transform.position, 0.25f);
                LeanTween.move(otherCard, thisCardParent.position, 0.25f);

                otherCard.transform.parent = thisCardParent;
                this.transform.parent = other.transform;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(Input.touchCount == 1)
        {
            transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(Input.touchCount == 1)
        {
            transform.GetComponent<Rigidbody2D>().isKinematic = true;
            isPointerUp = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(Input.touchCount == 1)
        {
            transform.GetComponent<Rigidbody2D>().isKinematic = false;
            isPointerUp = true;
        }
    }
}
