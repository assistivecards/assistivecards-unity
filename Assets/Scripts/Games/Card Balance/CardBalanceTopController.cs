using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBalanceTopController : MonoBehaviour
{
    public GameObject topObject;
    public GameObject requiredTopObject;
    public bool matched;
    private CardBalanceBoardGenerator boardGenerator;
    [SerializeField] private CardBalanceDraggable cardBalanceDraggable;

    private void OnEnable() 
    {
        boardGenerator = FindObjectOfType<CardBalanceBoardGenerator>();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Card")
        {
            if(cardBalanceDraggable.isPointerUp)
            {
                topObject = other.gameObject;
                if(topObject == requiredTopObject && requiredTopObject != null)
                {
                    matched = true;
                    boardGenerator.DetectMatches();
                }
                else if(topObject != requiredTopObject && requiredTopObject != null)
                {
                    matched = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Card")
        {
            matched = false;
        }
    }
}
