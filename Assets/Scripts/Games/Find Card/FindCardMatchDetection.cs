using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindCardMatchDetection : MonoBehaviour
{
    private FindCardBoardGenerator board;

    private void Start()
    {
        board = gameObject.GetComponent<FindCardBoardGenerator>();
    }

    public void CheckCard(Transform flippedCard)
    {
        if (flippedCard.GetChild(1).GetChild(0).GetComponent<Image>().sprite == board.randomSprites[0])
        {
            Debug.Log("CORRECT CARD");
        }

        else if (flippedCard.GetChild(1).GetChild(0).GetComponent<Image>().sprite != board.randomSprites[0])
        {
            Debug.Log("WRONG CARD");
            LeanTween.rotateY(flippedCard.gameObject, 0, .75f);
        }

    }
}
