using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardControllerCardChain : MonoBehaviour,IPointerDownHandler, IPointerUpHandler , IDragHandler
{   
    public BoardGenerateCardChain boardGenerateCardChain;
    public GameObject rightCard;
    public GameObject leftCard;
    private Vector3 leftSnapPosition;
    private Vector3 rightSnapPosition;
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
        GetComponentInChildren<CardControllerCardChain>().drag = true;
        //GetSnapPositions();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        drag = false;
        GetComponentInChildren<CardControllerCardChain>().drag = false;
    }

    public void GetChildNames()
    {
        rightCard = this.transform.GetChild(0).gameObject;
        leftCard = this.transform.GetChild(1).gameObject;
        //GetSnapPositions();
    }
    
    // public void GetSnapPositions()
    // {
    //     leftSnapPosition = new Vector3(leftCard.transform.localPosition.x - 400, leftCard.transform.localPosition.y + 70, 0);
    //     rightSnapPosition =  new Vector3(rightCard.transform.localPosition.x + 400, rightCard.transform.localPosition.y + 70, 0);
    // }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(GetComponentInParent<BoardGenerateCardChain>().isBoardCreated && drag)
        {
            if(other.gameObject.GetComponent<CardControllerCardChain>().rightCard.name == leftCard.name)
            {
                leftCard = other.GetComponent<CardControllerCardChain>().leftCard;
                other.transform.SetParent(this.transform);
                // other.GetComponent<CardControllerCardChain>().leftCard.transform.SetParent(this.transform);
                // other.GetComponent<CardControllerCardChain>().rightCard.transform.SetParent(this.transform);
                other.GetComponent<CardControllerCardChain>().cantMove = true;
                //LeanTween
                LeanTween.moveLocal(other.gameObject, new Vector3(-280, 0, 0), 0.1f);
                boardGenerateCardChain.matchCount ++;
                if(boardGenerateCardChain.matchCount >= 4)
                {
                    Debug.Log("LEVEL END");
                }
            }
            else if(other.gameObject.GetComponent<CardControllerCardChain>().leftCard.name == rightCard.name)
            {
                rightCard = other.GetComponent<CardControllerCardChain>().rightCard;
                other.transform.SetParent(this.transform);
                // other.GetComponent<CardControllerCardChain>().leftCard.transform.SetParent(this.transform);
                // other.GetComponent<CardControllerCardChain>().rightCard.transform.SetParent(this.transform);
                other.GetComponent<CardControllerCardChain>().cantMove = true;
                LeanTween.moveLocal(other.gameObject, new Vector3(280, 0, 0), 0.1f);
                //LeanTween.moveLocal(other.gameObject, rightSnapPosition, 0.1f);
                boardGenerateCardChain.matchCount ++;
                if(boardGenerateCardChain.matchCount >= 4)
                {
                    Debug.Log("LEVEL END");
                }
            }
            //GetSnapPositions();
        }
    }
}
