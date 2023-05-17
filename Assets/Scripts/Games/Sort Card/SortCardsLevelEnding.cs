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

        if(Card3 == boardGenerator.Card3)
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
            boardGenerator.ClearBoard();
        }
        else
        {
            Invoke("RestartBoard", 0.8f);
        }
    }

    private void RestartBoard()
    {
        orderDetection.slotCards[0].transform.SetParent(orderDetection.slotCards[0].GetComponent<SortCardDraggable>().startingParent.transform);
        orderDetection.slotCards[1].transform.SetParent(orderDetection.slotCards[1].GetComponent<SortCardDraggable>().startingParent.transform);
        orderDetection.slotCards[2].transform.SetParent(orderDetection.slotCards[2].GetComponent<SortCardDraggable>().startingParent.transform);

        LeanTween.move(orderDetection.slotCards[0],orderDetection.slotCards[0].GetComponent<SortCardDraggable>().startingParent.transform, 0.75f);
        LeanTween.move(orderDetection.slotCards[1],orderDetection.slotCards[1].GetComponent<SortCardDraggable>().startingParent.transform, 0.75f);
        LeanTween.move(orderDetection.slotCards[2],orderDetection.slotCards[2].GetComponent<SortCardDraggable>().startingParent.transform, 0.75f);

        orderDetection.slotCards[0].GetComponent<SortCardDraggable>().Invoke("SetLandedFalse", 0.8f);
        orderDetection.slotCards[1].GetComponent<SortCardDraggable>().Invoke("SetLandedFalse", 0.8f);
        orderDetection.slotCards[2].GetComponent<SortCardDraggable>().Invoke("SetLandedFalse", 0.8f);

        correct = 0;
        count = 0;
    }
}
