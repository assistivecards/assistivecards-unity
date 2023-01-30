using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCrushCell : MonoBehaviour
{
    public float x;
    public float y;
    public bool isEmpty = false;
    public GameObject card;
    private CardCrushFillGrid cardCrushFillGrid;
    private CardCrushGrid cardCrushGrid;

    public GameObject rightNeighbour;
    public GameObject leftNeighbour;
    public GameObject topNeighbour;
    public GameObject bottomNeighbour;

    public List<CardCrushCell> neighbours = new List<CardCrushCell>();

    private void Awake() 
    {
        cardCrushFillGrid = FindObjectOfType<CardCrushFillGrid>();
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
    }
}
