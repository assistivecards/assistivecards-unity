using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCardsLevelEnding : MonoBehaviour
{
    [SerializeField] private SortCardBoardGenerator boardGenerator;
    [SerializeField] private SortCardOrderDetection orderDetection;
    [SerializeField] private SortCardUIController UIController;

    public string Card1;
    public string Card2;
    public string Card3;

    public int count;
    public int correct;

    public void CreateString()
    {
        Card1 =  orderDetection.cards[0];
        Card2 =  orderDetection.cards[1];
        Card3 =  orderDetection.cards[2];

        if(Card1 == boardGenerator.Card1)
        {
            correct++;
        }
        else if(Card1 != boardGenerator.Card1)
        {
            orderDetection.slotCards[0].GetComponent<SortCardDraggable>().MoveToStartPos();
        }

        if(Card2 == boardGenerator.Card2)
        {
            correct++;
        }
        else if(Card2 != boardGenerator.Card2)
        {
            orderDetection.slotCards[1].GetComponent<SortCardDraggable>().MoveToStartPos();
        }


        if(Card3 == boardGenerator.Card3)
        {
            correct++;
        }
        else if(Card3 != boardGenerator.Card3)
        {
            orderDetection.slotCards[2].GetComponent<SortCardDraggable>().MoveToStartPos();
        }

        LevelEndDetect();
    }

    private void LevelEndDetect()
    {
        if(correct >= 3)
        {
            UIController.LevelEnd();
        }
    }
}
