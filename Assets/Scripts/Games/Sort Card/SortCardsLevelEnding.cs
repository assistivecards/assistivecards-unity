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
        if(Card2 == boardGenerator.Card2)
        {
            correct++;
        }
        if(Card2 == boardGenerator.Card2)
        {
            correct++;
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
