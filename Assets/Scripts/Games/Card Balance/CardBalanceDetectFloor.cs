using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBalanceDetectFloor : MonoBehaviour
{
    private CardBalanceBoardGenerator boardGenerator;
    public string requiredFloor;


    private void OnEnable() 
    {
        boardGenerator = FindObjectOfType<CardBalanceBoardGenerator>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == requiredFloor)
        {
            boardGenerator.matchedCardCount++;
            boardGenerator.DetectMatches();
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == requiredFloor)
        {
            boardGenerator.matchedCardCount--;
        }
    }
}
