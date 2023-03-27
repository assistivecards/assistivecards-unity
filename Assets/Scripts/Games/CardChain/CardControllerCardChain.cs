using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardControllerCardChain : MonoBehaviour,IPointerDownHandler, IPointerUpHandler , IDragHandler
{   
    public GameObject rightCard;
    public GameObject leftCard;
    public bool cantMove = false;
    public bool drag;

    public void OnDrag(PointerEventData eventData)
    {
        if(!cantMove)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        drag = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        drag = false;
    }

    public void GetChildNames()
    {
        rightCard = this.transform.GetChild(0).gameObject;
        leftCard = this.transform.GetChild(1).gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(GetComponentInParent<BoardGenerateCardChain>().isBoardCreated && drag)
        {
            if(other.gameObject.GetComponent<CardControllerCardChain>().rightCard.name == leftCard.name)
            {
                rightCard = other.GetComponent<CardControllerCardChain>().leftCard;
                other.transform.SetParent(this.transform);
                other.GetComponent<CardControllerCardChain>().cantMove = true;
                LeanTween.moveLocal(other.gameObject, new Vector3(280, 0, 0), 0.1f);
            }
            else if(other.gameObject.GetComponent<CardControllerCardChain>().leftCard.name == rightCard.name)
            {
                leftCard = other.GetComponent<CardControllerCardChain>().rightCard;
                other.transform.SetParent(this.transform);
                other.GetComponent<CardControllerCardChain>().cantMove = true;
                LeanTween.moveLocal(other.gameObject, new Vector3(-280, 0, 0), 0.1f);
            }
        }
    }
}
