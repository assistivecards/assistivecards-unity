using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardTileInformation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int xValue;
    public int yValue;

    private BoardController boardController;
    private SwipeController swipeController;

    public List<GameObject> neighbours = new List<GameObject>();
 
    public GameObject rightNeighbour;
    public GameObject leftNeighbour;
    public GameObject topNeighbour;
    public GameObject bottomNeighbour;

    private void Awake() 
    {
        boardController = GameObject.Find("Board").GetComponent<BoardController>();
        swipeController = GameObject.Find("Board").GetComponent<SwipeController>();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        DetectNeightbours();
        swipeController.SelectElement(this.gameObject);
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        swipeController.SwipeElements();
    }

    private void DetectNeightbours()
    {
        foreach (var card in boardController.cards)
        {
            if(card.GetComponent<CardTileInformation>().xValue == xValue + 1 && card.GetComponent<CardTileInformation>().yValue == yValue)
            {
                bottomNeighbour = card;
                if(!neighbours.Contains(bottomNeighbour))
                neighbours.Add(bottomNeighbour);
            }
            else if(card.GetComponent<CardTileInformation>().xValue == xValue - 1 && card.GetComponent<CardTileInformation>().yValue == yValue)
            {
                topNeighbour = card;
                if(!neighbours.Contains(topNeighbour))
                neighbours.Add(topNeighbour);
            }
            else if(card.GetComponent<CardTileInformation>().xValue == xValue && card.GetComponent<CardTileInformation>().yValue == yValue + 1)
            {
                rightNeighbour = card;
                if(!neighbours.Contains(rightNeighbour))
                neighbours.Add(rightNeighbour);
            }
            else if(card.GetComponent<CardTileInformation>().xValue == xValue && card.GetComponent<CardTileInformation>().yValue == yValue - 1)
            {
                leftNeighbour = card;
                if(!neighbours.Contains(leftNeighbour))
                neighbours.Add(leftNeighbour);
            }
        }
    }

    public void ResetNeighbours()
    {
        neighbours.Clear();
    }
}
