using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CardTileInformation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int xValue;
    public int yValue;
    public int listNum;

    private BoardController boardController;
    private SwipeController swipeController;
    private GridGenerator gridGenerator;
    private EmptyTileHolder emptyTileHolder;

    public List<GameObject> neighbours = new List<GameObject>();

    public List<GameObject> horizontalNeighbours = new List<GameObject>();
    public List<GameObject> verticalNeighbours = new List<GameObject>();
    public string type;
 
    public GameObject rightNeighbour;
    public GameObject leftNeighbour;
    public GameObject topNeighbour;
    public GameObject bottomNeighbour;

    public string rightNeighbourType;
    public string leftNeighbourType;
    public string topNeighbourType;
    public string bottomNeighbourType;

    public bool isMatched;

    public int horizontalMatchedDrop = 0;
    public int verticalMatchedDrop = 0;

    int matchCount = 0;

    private void Awake() 
    {
        boardController = GameObject.Find("Board").GetComponent<BoardController>();
        swipeController = GameObject.Find("Board").GetComponent<SwipeController>();
        gridGenerator = GameObject.Find("Board").GetComponent<GridGenerator>();
        emptyTileHolder = GameObject.Find("Board").GetComponent<EmptyTileHolder>();
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
                    horizontalNeighbours.Add(rightNeighbour);
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
                    horizontalNeighbours.Add(leftNeighbour);
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
                    verticalNeighbours.Add(topNeighbour);
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
                    verticalNeighbours.Add(bottomNeighbour);
                    bottomNeighbourType = bottomNeighbour.transform.GetChild(0).name;
                }
            }
            else
            {
                bottomNeighbour = null;
            }
        }
    }

    private void FixedUpdate() 
    {
        CheckMatch();
    }

    private void DestroyMatch()
    {
        swipeController.ClearSelectedElements();
        Destroy(this.gameObject);
    }

    public void CheckMatch()
    {
        if(leftNeighbour != null && rightNeighbour != null)
        {
            if(leftNeighbourType == type && rightNeighbourType == type)
            {
                leftNeighbour.GetComponent<CardTileInformation>().isMatched = true;
                rightNeighbour.GetComponent<CardTileInformation>().isMatched = true;
                isMatched = true;
            }
        }

        if(topNeighbour != null && bottomNeighbour != null)
        {
            if(topNeighbourType == type && bottomNeighbourType == type)
            {
                topNeighbour.GetComponent<CardTileInformation>().isMatched = true;
                bottomNeighbour.GetComponent<CardTileInformation>().isMatched = true;
                isMatched = true;
            }
        }
        if(isMatched)
        {
            LeanTween.scale(this.gameObject, new Vector3(0.001f, 0.001f, 0.001f), 0.1f);
            // add empty tile here ONCE
        }
    }


    public void ResetNeighbours()
    {
        verticalNeighbours.Clear();
        horizontalNeighbours.Clear();
        neighbours.Clear();
    }
}
