using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCardsLevelEnding : MonoBehaviour
{
    [SerializeField] private SortCardBoardGenerator boardGenerator;
    [SerializeField] private SortCardOrderDetection orderDetection;
    public string orderedCards;
    public int count;

    public void CreateString()
    {
        for(int i = 0; i < 3; i++)
        {
            orderedCards = orderedCards + orderDetection.cards[i];
        }


        if(orderedCards == boardGenerator.sortedCardsString)
        {
            Debug.Log("LEVEL END!");
        }
    }
}
