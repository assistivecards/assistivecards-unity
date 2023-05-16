using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCardsLevelEnding : MonoBehaviour
{
    [SerializeField] private SortCardBoardGenerator boardGenerator;
    [SerializeField] private SortCardOrderDetection orderDetection;
    [SerializeField] private SortCardUIController UIController;
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
            UIController.LevelEnd();
        }
    }
}
