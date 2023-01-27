using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCrushCell : MonoBehaviour
{
    public float x;
    public float y;
    public bool isEmpty;
    public GameObject card;
    private CardCrushFillGrid cardCrushFillGrid;
    private CardCrushGrid cardCrushGrid;
    public List<CardCrushCell> neighbours = new List<CardCrushCell>();

    private void Awake() 
    {
        cardCrushFillGrid = FindObjectOfType<CardCrushFillGrid>();
        cardCrushGrid = FindObjectOfType<CardCrushGrid>();

        DetectNeighbourCells(); // use neighbour list for check unwanted destroys & refills 
    }

    private void Update() {
        if(cardCrushFillGrid.isBoardCreated)
        {
            if(isEmpty)
                cardCrushFillGrid.RefillCell(this);
        }
    }

    private void DetectNeighbourCells()
    {
        foreach(var cell in cardCrushGrid.allCells)
        {
            if(cell.x == x + 1 && cell.y == y)
            {
                neighbours.Add(cell);
            }
            else if(cell.x == x - 1 && cell.y == y)
            {
                neighbours.Add(cell);
            }
            else if(cell.x == x && cell.y == y - 1)
            {
                neighbours.Add(cell);
            }
            else if(cell.x == x - 1 && cell.y == y + 1)
            {
                neighbours.Add(cell);
            }
        }
    }
}
