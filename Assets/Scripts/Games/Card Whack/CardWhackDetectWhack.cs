using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardWhackDetectWhack : MonoBehaviour, IPointerClickHandler
{
    private CardWhackBoardGenerator board;
    private bool isClicked = false;

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<CardWhackBoardGenerator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.GetChild(0).GetComponent<Image>().sprite == board.randomSprites[0] && !isClicked)
        {
            Debug.Log("CORRECT CARD");
            isClicked = true;
        }

        else if (transform.GetChild(0).GetComponent<Image>().sprite != board.randomSprites[0] && !isClicked)
        {
            Debug.Log("WRONG CARD");
            isClicked = true;
        }
    }
}
