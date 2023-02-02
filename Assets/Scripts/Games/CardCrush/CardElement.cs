using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float x;
    public float y;
    public Vector3 cardPosition;
    public string type;

    private CardCrushGrid cardCrushGrid;
    private CardCrushFillGrid cardCrushFillGrid;

    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;

    private float swipeAngle;

    public GameObject rightNeighbour;
    public GameObject leftNeighbour;

    public GameObject topNeighbour;
    public GameObject bottomNeighbour;

    public List<GameObject> matched = new List<GameObject>();

    private bool notHorizontal = false;

    private void OnEnable() 
    {
        LeanTween.scale(this.gameObject, Vector3.one, 0.3f);
        cardPosition = this.transform.position;
        cardCrushGrid = FindObjectOfType<CardCrushGrid>();
        cardCrushFillGrid = FindObjectOfType<CardCrushFillGrid>();
        if(this.transform.localScale.x > 1)
        {
            this.transform.localScale = Vector3.one;
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        cardPosition = this.transform.position;
        if(cardCrushFillGrid.isBoardCreated && !cardCrushFillGrid.isOnRefill)
        {
            firstTouchPosition = pointerEventData.position;
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if(cardCrushFillGrid.isBoardCreated && !cardCrushFillGrid.isOnRefill)
        {
            finalTouchPosition = pointerEventData.position;
            MoveDrops();
        }
    }
    private void Update() 
    {
        if(this.transform.localScale.x > 1)
        {
            this.transform.localScale = Vector3.one;
        }
        if(cardCrushFillGrid.isBoardCreated)
            DetectNeighbours();
            
        if(!cardCrushFillGrid.isOnRefill)
            DetectLongMatch();
    }

    private void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2((finalTouchPosition.y - firstTouchPosition.y), (finalTouchPosition.x - firstTouchPosition.x)) * Mathf.Rad2Deg;
    }

    private void MoveToTarget(CardCrushCell _cell, GameObject _card, Vector3 _transform, float _targetX, float _targetY)
    {
        _card.GetComponent<CardElement>().cardPosition = this.transform.position;
        LeanTween.move(_card, cardPosition, 0.2f);
        LeanTween.move(this.gameObject, _transform, 0.2f);
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

        if(swipeAngle != 0)
        {
            if(swipeAngle > -45 && swipeAngle <= 45 && x < cardCrushGrid.width -1) //right swipe
            {
                foreach (var cell in cardCrushGrid.allCells)
                {
                    if(cell.x == x + 1 && cell.y == y)
                    {
                        if(cell != null)
                        {
                            MoveToTarget(cell, cell.card, cell.transform.position, cell.card.GetComponent<CardElement>().x,cell.card.GetComponent<CardElement>().y);
                            break;
                        }
                    }
                }
            }
            else if(swipeAngle > 45 && swipeAngle <= 135 && y < cardCrushGrid.height -1) //up swipe
            {
                foreach (var cell in cardCrushGrid.allCells)
                {
                    if(cell.x == x && cell.y == y + 1)
                    {
                        if(cell != null)
                        {
                            MoveToTarget(cell, cell.card, cell.transform.position, cell.card.GetComponent<CardElement>().x, cell.card.GetComponent<CardElement>().y);
                            break;
                        }
                    }
                }
            } 
            else if(swipeAngle > 135 || swipeAngle <= -135 && x > 0) //left swipe
            {
                foreach (var cell in cardCrushGrid.allCells)
                {
                    if(cell.x == x - 1 && cell.y == y)
                    {
                        if(cell != null)
                        {
                            MoveToTarget(cell, cell.card, cell.transform.position, cell.card.GetComponent<CardElement>().x, cell.card.GetComponent<CardElement>().y);
                            break;
                        }
                    }
                }
            }
            else if(swipeAngle < -45 && swipeAngle >= -135) //down swipe
            {

                foreach (var cell in cardCrushGrid.allCells)
                {
                    if(cell.x == x && cell.y == y - 1) 
                    {
                        if(cell != null)
                        {
                            MoveToTarget(cell, cell.card, cell.transform.position, cell.card.GetComponent<CardElement>().x, cell.card.GetComponent<CardElement>().y);
                            break;
                        }
                    }
                }
            }
        }
    }


    public void DetectNeighbours()
    {
        if(transform.parent != null)
        {
            if(transform.parent.GetComponent<CardCrushCell>().rightNeighbour != null)
            {
                if(transform.parent.GetComponent<CardCrushCell>().rightNeighbour.transform.childCount > 0)
                {
                    rightNeighbour = transform.parent.GetComponent<CardCrushCell>()
                        .rightNeighbour.transform.GetChild(0).gameObject;
                }
            }

            if(transform.parent.GetComponent<CardCrushCell>().leftNeighbour != null)
            {
                if(transform.parent.GetComponent<CardCrushCell>().leftNeighbour.transform.childCount > 0)
                {
                    leftNeighbour = transform.parent.GetComponent<CardCrushCell>()
                        .leftNeighbour.transform.GetChild(0).gameObject;
                }
            }

            if(transform.parent.GetComponent<CardCrushCell>().topNeighbour != null)
            {
                if(transform.parent.GetComponent<CardCrushCell>().topNeighbour.transform.childCount > 0)
                {
                    topNeighbour = transform.parent.GetComponent<CardCrushCell>()
                        .topNeighbour.transform.GetChild(0).gameObject;
                }
            }

            if(transform.parent.GetComponent<CardCrushCell>().bottomNeighbour != null)
            {
                if(transform.parent.GetComponent<CardCrushCell>().bottomNeighbour.transform.childCount > 0)
                {
                    bottomNeighbour = transform.parent.GetComponent<CardCrushCell>()
                        .bottomNeighbour.transform.GetChild(0).gameObject;
                }
            }
        }
    }

    private void DetectLongMatch()
    {
        if(transform.GetComponentInParent<CardCrushCell>() != null)
        {
            foreach(var neighbour in GetComponentInParent<CardCrushCell>().horizontalNeighboursRight)
            {
                if(neighbour.card != null)
                {
                    if(neighbour.card.GetComponent<CardElement>().type == type)
                    {
                        if(!matched.Contains(neighbour.card))
                            matched.Add(neighbour.card);
                    }
                    else 
                    {
                        break;
                    }
                }
            }

            foreach(var neighbour in GetComponentInParent<CardCrushCell>().horizontalNeighboursLeft)
            {
                if(neighbour.card != null)
                {
                    if(neighbour.card.GetComponent<CardElement>().type == type)
                    {
                        if(!matched.Contains(neighbour.card))
                            matched.Add(neighbour.card);
                    }
                    else 
                    {
                        break;
                    }
                }
            }

            if(matched.Count >= 2)
            {
                if(!matched.Contains(this.gameObject))
                    matched.Add(this.gameObject);

                ScaleUpMatch();
            }
            if(matched.Count < 2)
            {
                notHorizontal = true;
                matched.Clear();
            }
            if(notHorizontal)
            {
                foreach(var neighbour in GetComponentInParent<CardCrushCell>().verticalNeightboursBottom)
                {
                    if(neighbour.card != null)
                    {
                        if(neighbour.card.GetComponent<CardElement>().type == type)
                        {
                            if(!matched.Contains(neighbour.card))
                                matched.Add(neighbour.card);
                        }
                        else 
                        {
                            break;
                        }
                    }
                }

                foreach(var neighbour in GetComponentInParent<CardCrushCell>().verticalNeightboursTop)
                {
                    if(neighbour.card != null)
                    {
                        if(neighbour.card.GetComponent<CardElement>().type == type)
                        {
                            if(!matched.Contains(neighbour.card))
                                matched.Add(neighbour.card);
                        }
                        else 
                        {
                            break;
                        }
                    }
                }


                if(matched.Count >= 2)
                {
                    if(!matched.Contains(this.gameObject))
                        matched.Add(this.gameObject);
                    ScaleUpMatch();
                }
                if(matched.Count < 2)
                {
                    matched.Clear();
                }

            }
        }
    }

    private void DestroyMatched()
    {
        foreach(var card in matched)
        {
            card.transform.GetComponentInParent<CardCrushCell>().isEmpty = true;
            Destroy(card);
        }
    }
    private void ScaleUpMatch()
    {
        cardCrushFillGrid.isOnRefill = true;
        foreach(var card in matched)
        {
            cardCrushFillGrid.score += 1;
            LeanTween.scale(card, new Vector3(0.5f, 0.5f, 0.5f), 0.1f);
        }
        Invoke("DestroyMatched", 0.1f);
    }
}
