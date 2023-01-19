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
    public string type;
 
    public GameObject rightNeighbour;
    public GameObject leftNeighbour;
    public GameObject topNeighbour;
    public GameObject bottomNeighbour;

    public string rightNeighbourType;
    public string leftNeighbourType;
    public string topNeighbourType;
    public string bottomNeighbourType;

    private void Awake() 
    {
        boardController = GameObject.Find("Board").GetComponent<BoardController>();
        swipeController = GameObject.Find("Board").GetComponent<SwipeController>();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        swipeController.SelectElement(this.gameObject);
        ResetNeighbours();
        DetectNeightbours();
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        swipeController.SwipeElements();
        ResetNeighbours();
        DetectNeightbours();
    }

    public void DetectNeightbours()
    {
        foreach (var card in boardController.cards)
        {
            if(card.GetComponent<CardTileInformation>().xValue == xValue + 1 && card.GetComponent<CardTileInformation>().yValue == yValue)
            {
                bottomNeighbour = card;
                if(!neighbours.Contains(bottomNeighbour))
                neighbours.Add(bottomNeighbour);
                bottomNeighbourType = bottomNeighbour.transform.GetChild(0).name;
            }
            else if(card.GetComponent<CardTileInformation>().xValue == xValue - 1 && card.GetComponent<CardTileInformation>().yValue == yValue)
            {
                topNeighbour = card;
                if(!neighbours.Contains(topNeighbour))
                neighbours.Add(topNeighbour);
                topNeighbourType = topNeighbour.transform.GetChild(0).name;
            }
            else if(card.GetComponent<CardTileInformation>().xValue == xValue && card.GetComponent<CardTileInformation>().yValue == yValue + 1)
            {
                rightNeighbour = card;
                if(!neighbours.Contains(rightNeighbour))
                neighbours.Add(rightNeighbour);
                rightNeighbourType = rightNeighbour.transform.GetChild(0).name;
            }
            else if(card.GetComponent<CardTileInformation>().xValue == xValue && card.GetComponent<CardTileInformation>().yValue == yValue - 1)
            {
                leftNeighbour = card;
                if(!neighbours.Contains(leftNeighbour))
                neighbours.Add(leftNeighbour);
                leftNeighbourType = leftNeighbour.transform.GetChild(0).name;
            }
        }
    }

    public void ResetNeighbours()
    {
        neighbours.Clear();
    }
}
