using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float x;
    public float y;
    public Vector3 cardPosition;
    public string type;
    private bool isMatched = false;

    private CardCrushGrid cardCrushGrid;

    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;

    private float swipeAngle;

    private CardCrushCell targetCell;

    private void Start() 
    {
        cardPosition = this.transform.position;
        cardCrushGrid = FindObjectOfType<CardCrushGrid>();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        cardPosition = this.transform.position;
        firstTouchPosition = pointerEventData.position;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        finalTouchPosition = pointerEventData.position;
        MoveDrops();
    }

    private void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2((finalTouchPosition.y - firstTouchPosition.y), (finalTouchPosition.x - firstTouchPosition.x)) * Mathf.Rad2Deg;
    }

    private void MoveToTarget(CardCrushCell _cell, GameObject _card, Vector3 _transform, float _targetX, float _targetY)
    {
        _card.GetComponent<CardElement>().cardPosition = this.transform.position;
        LeanTween.move(_card, cardPosition, 0.1f);
        LeanTween.move(this.gameObject, _transform, 0.1f);
        cardPosition = this.transform.position;

        _card.transform.parent = this.transform.parent;
        this.transform.parent.GetComponent<CardCrushCell>().card = _card;
        this.transform.parent = _cell.transform;

        _cell.card = this.gameObject;

        _card.GetComponent<CardElement>().x = x;
        _card.GetComponent<CardElement>().y = y;
        x = _targetX;
        y = _targetY;
    }

    private void MoveDrops()
    {
        CalculateAngle();
        if(swipeAngle > -45 && swipeAngle <= 45 && x < cardCrushGrid.width -1) //right swipe
        {
            foreach (var cell in cardCrushGrid.allCells)
            {
                if(cell.x == x + 1 && cell.y == y)
                {
                    MoveToTarget(cell, cell.card, cell.transform.position, cell.card.GetComponent<CardElement>().x,cell.card.GetComponent<CardElement>().y);
                    break;
                }
            }
        }
        else if(swipeAngle > 45 && swipeAngle <= 135 && y < cardCrushGrid.height -1) //up swipe
        {
            foreach (var cell in cardCrushGrid.allCells)
            {
                if(cell.x == x && cell.y == y + 1)
                {
                    MoveToTarget(cell, cell.card, cell.transform.position, cell.card.GetComponent<CardElement>().x, cell.card.GetComponent<CardElement>().y);
                    break;
                }
            }
        } 
        else if(swipeAngle > 135 || swipeAngle <= -135 && x > 0) //left swipe
        {
            foreach (var cell in cardCrushGrid.allCells)
            {
                if(cell.x == x - 1 && cell.y == y)
                {
                    MoveToTarget(cell, cell.card, cell.transform.position, cell.card.GetComponent<CardElement>().x, cell.card.GetComponent<CardElement>().y);
                    break;
                }
            }
        }
        else if(swipeAngle < -45 && swipeAngle >= -135) //down swipe
        {

            foreach (var cell in cardCrushGrid.allCells)
            {
                if(cell.x == x && cell.y == y - 1) 
                {
                    MoveToTarget(cell, cell.card, cell.transform.position, cell.card.GetComponent<CardElement>().x, cell.card.GetComponent<CardElement>().y);
                    break;
                }
            }
        }
    }
}
