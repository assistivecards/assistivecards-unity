using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardTileInformation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int xValue;
    public int yValue;

    private BoardController boardController;
 
    public GameObject rightNeighbour;
    public GameObject leftNeighbour;
    public GameObject topNeighbour;
    public GameObject bottomNeighbour;

    private void Awake() 
    {
        boardController = GameObject.Find("Board").GetComponent<BoardController>();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
        DetectNeightbours();
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {

    }

    private void DetectNeightbours()
    {
        foreach (var card in boardController.cards)
        {
            if(card.GetComponent<CardTileInformation>().xValue == xValue + 1 && card.GetComponent<CardTileInformation>().yValue == yValue)
            {
                bottomNeighbour = card;
            }
            else if(card.GetComponent<CardTileInformation>().xValue == xValue - 1 && card.GetComponent<CardTileInformation>().yValue == yValue)
            {
                topNeighbour = card;
            }
            else if(card.GetComponent<CardTileInformation>().xValue == xValue && card.GetComponent<CardTileInformation>().yValue == yValue + 1)
            {
                rightNeighbour = card;
            }
            else if(card.GetComponent<CardTileInformation>().xValue == xValue && card.GetComponent<CardTileInformation>().yValue == yValue - 1)
            {
                leftNeighbour = card;
            }
        }
    }

    //null check
}
