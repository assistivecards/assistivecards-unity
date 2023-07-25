using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CardBalanceDetectFloor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool matched;
    private CardBalanceBoardGenerator boardGenerator;
    public string requiredFloor;


    private void OnEnable() 
    {
        boardGenerator = FindObjectOfType<CardBalanceBoardGenerator>();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == requiredFloor && boardGenerator.isPointerUp)
        {
            matched = true;
            boardGenerator.DetectMatches();
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == requiredFloor)
        {
            matched = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        boardGenerator.isPointerUp = false;
    }
        
    public void OnPointerUp(PointerEventData eventData)
    {
        boardGenerator.isPointerUp = true;
    }
}
