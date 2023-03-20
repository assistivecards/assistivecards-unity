using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCrushCell : MonoBehaviour
{
    public float x;
    public float y;
    public bool isEmpty = false;
    public GameObject card;
    private CardCrushGrid cardCrushGrid;

    public GameObject rightNeighbour;
    public GameObject leftNeighbour;
    public GameObject topNeighbour;
    public GameObject bottomNeighbour;

    public List<CardCrushCell> neighbours = new List<CardCrushCell>();
    public List<CardCrushCell> horizontalNeighboursRight = new List<CardCrushCell>();
    public List<CardCrushCell> horizontalNeighboursLeft = new List<CardCrushCell>();

    public List<CardCrushCell> verticalNeightboursTop = new List<CardCrushCell>();
    public List<CardCrushCell> verticalNeightboursBottom = new List<CardCrushCell>();

    public bool isOnTop = false;
    public bool isOnBottom = true;

    private void OnEnable() 
    {
        cardCrushGrid = FindObjectOfType<CardCrushGrid>();
    }

    public void DetectNeighbourCells()
    {
        foreach(var cell in cardCrushGrid.allCells)
        {
            if(cell.x == x + 1 && cell.y == y)
            {
                rightNeighbour = cell.gameObject;
                if(!neighbours.Contains(cell))
                {
                    neighbours.Add(cell);
                }
            }
            if(cell.x == x - 1 && cell.y == y)
            {
                leftNeighbour = cell.gameObject;
                if(!neighbours.Contains(cell))
                {
                    neighbours.Add(cell);
                }
            }
            if(cell.x == x && cell.y == y - 1)
            {
                isOnBottom = false;
                bottomNeighbour = cell.gameObject;
                if(!neighbours.Contains(cell))
                {
                    neighbours.Add(cell);
                }
            }
            if(cell.x == x && cell.y == y + 1)
            {
                topNeighbour = cell.gameObject;
                if(!neighbours.Contains(cell))
                {
                    neighbours.Add(cell);
                }
            }
        }
        if(!neighbours.Contains(this))
            neighbours.Add(this);

        GetTopCells();
    }

    public void DetectNeighboursAround()
    {
        foreach(var cell in cardCrushGrid.allCells)
        {
            if(cell.y == y)
            {
                if(cell.x > x)
                {
                    if(!horizontalNeighboursRight.Contains(cell))
                        horizontalNeighboursRight.Add(cell);
                }
                else if(cell.x < x)
                {
                    if(!horizontalNeighboursLeft.Contains(cell))
                        horizontalNeighboursLeft.Add(cell);
                }
            }

            if(cell.x == x)
            {
                if(cell.y > y)
                {
                    if(!verticalNeightboursTop.Contains(cell))
                        verticalNeightboursTop.Add(cell);
                }
                else if(cell.y < y)
                {
                    if(!verticalNeightboursBottom.Contains(cell))
                        verticalNeightboursBottom.Add(cell);
                }
            }
        }
        horizontalNeighboursLeft.Reverse();
        verticalNeightboursBottom.Reverse();
    }

    private void GetTopCells()
    {
        if(y == 3)
        {
            isOnTop = true;
        }
    }
}
