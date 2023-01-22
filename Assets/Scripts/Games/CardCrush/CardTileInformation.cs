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
    private GridGenerator gridGenerator;

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

    int matchCount = 0;

    private void Awake() 
    {
        boardController = GameObject.Find("Board").GetComponent<BoardController>();
        swipeController = GameObject.Find("Board").GetComponent<SwipeController>();
        gridGenerator = GameObject.Find("Board").GetComponent<GridGenerator>();
    }

    private void OnEnable() 
    {
        //This function disable for  wrong neightbours bug
        //DetectNeightbours();
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
            if(xValue != gridGenerator.gridWidth -1)
            {
                if(card.GetComponent<CardTileInformation>().xValue == xValue + 1 &&
                card.GetComponent<CardTileInformation>().yValue == yValue)
                {
                    rightNeighbour = card;
                    neighbours.Add(rightNeighbour);
                    rightNeighbourType = rightNeighbour.transform.GetChild(0).name;
                }
            }
            else
            {
                rightNeighbour = null;
            }
        }
        foreach (var card in boardController.cards)
        {
            if(xValue != 0)
            {
                if(card.GetComponent<CardTileInformation>().xValue == xValue - 1 &&
                card.GetComponent<CardTileInformation>().yValue == yValue)
                {
                    leftNeighbour = card;
                    neighbours.Add(leftNeighbour);
                    leftNeighbourType = leftNeighbour.transform.GetChild(0).name;
                }
            }
            else
            {
                leftNeighbour = null;
            }
        }
        foreach (var card in boardController.cards)
        {
            if(yValue != gridGenerator.gridHeight -1)
            {
                if(card.GetComponent<CardTileInformation>().xValue == xValue &&
                card.GetComponent<CardTileInformation>().yValue == yValue + 1)
                {
                    topNeighbour = card;
                    neighbours.Add(topNeighbour);
                    topNeighbourType = topNeighbour.transform.GetChild(0).name;
                }
            }
            else 
            {
                topNeighbour = null;
            }
        }
        foreach (var card in boardController.cards)
        {
            if( yValue != 0)
            {
                if(card.GetComponent<CardTileInformation>().xValue == xValue &&
                card.GetComponent<CardTileInformation>().yValue == yValue - 1)
                {
                    bottomNeighbour = card;
                    neighbours.Add(bottomNeighbour);
                    bottomNeighbourType = bottomNeighbour.transform.GetChild(0).name;
                }
            }
            else
            {
                bottomNeighbour = null;
            }
        }
    }


    public void ResetNeighbours()
    {
        neighbours.Clear();
    }
}
