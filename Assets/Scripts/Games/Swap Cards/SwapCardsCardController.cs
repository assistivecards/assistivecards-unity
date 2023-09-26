using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwapCardsCardController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private GameAPI gameAPI;
    private SwapCardsBoardGenerator boardGenerator;
    private bool oneTime = true;
    private bool isPointerUp;
    public string parentName;
    public string cardType;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        boardGenerator = FindObjectOfType<SwapCardsBoardGenerator>();
    }
    
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.transform.tag == "CardPositions1" || other.transform.tag == "CardPositions2" || other.transform.tag == "CardPositions3" 
        && this.transform.parent.gameObject != other.gameObject)
        {
            if(isPointerUp && oneTime)
            {
                GameObject otherCard = other.transform.GetChild(0).gameObject;
                Transform thisCardParent = this.transform.parent.transform;

                LeanTween.move(this.gameObject, other.transform.position, 0.25f);
                LeanTween.move(otherCard, thisCardParent.position, 0.25f);
                otherCard.GetComponent<SwapCardsCardController>().parentName = parentName;
                parentName = other.transform.tag;
                otherCard.transform.parent = thisCardParent;
                this.transform.parent = other.transform;
                if(oneTime)
                {
                    boardGenerator.CheckCardChilds();
                    boardGenerator.CheckLevelEnding();
                    oneTime = false;
                }
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
