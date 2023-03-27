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
        if(GetComponentInParent<BoardGenerateCardChain>().isBoardCreated)
        {
            if(other.gameObject.GetComponent<CardControllerCardChain>().rightCard.name == leftCard.name)
            {
                other.transform.SetParent(this.transform);
                other.GetComponent<CardControllerCardChain>().cantMove = true;
                LeanTween.moveLocal(other.gameObject, new Vector3(280, 0, 0), 0.1f);
                rightCard = other.GetComponent<CardControllerCardChain>().rightCard;
            }
            // else if(other.gameObject.GetComponent<CardControllerCardChain>().leftCard.name == rightCard.name)
            // {
            //     other.transform.SetParent(this.transform);
            //     other.GetComponent<CardControllerCardChain>().cantMove = true;
            //     leftCard = other.GetComponent<CardControllerCardChain>().leftCard;
            //     LeanTween.moveLocal(other.gameObject, new Vector3(-280, 0, 0), 0.1f);
            // }
        }
    }
}
