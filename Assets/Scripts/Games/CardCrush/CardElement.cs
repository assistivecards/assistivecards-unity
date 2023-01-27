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

    private void Start() 
    {
        cardPosition = this.transform.position;
        cardCrushGrid = FindObjectOfType<CardCrushGrid>();
        cardCrushFillGrid = FindObjectOfType<CardCrushFillGrid>();
    }

    private void OnEnable() 
    {
        LeanTween.scale(this.gameObject, Vector3.one, 0.5f);

        if(this.transform.localScale.x > 1)
        {
            this.transform.localScale = Vector3.one;
        }
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

    private void Update() 
    {
        DetectNeighbours();
        if(cardCrushFillGrid.isBoardCreated == true)
        {
            DetectMatch();
            DestroyMatched();
        }
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
            DetectNeighbours();
        }
    }


    private void DetectNeighbours()
    {
        foreach (var cell in cardCrushGrid.allCells)
        {
            if(x < cardCrushGrid.width -1)
            {
                if(cell.x == x + 1 && cell.y == y)
                {
                    if(cell != null)
                    {
                        rightNeighbour = cell.card;
                    }
                    else
                    {
                        rightNeighbour = null;
                    }
                }
            }
            else
            {
                rightNeighbour = null;
            }
            if(y < cardCrushGrid.height -1)
            {
                if(cell.x == x && cell.y == y + 1)
                {
                    if(cell != null)
                    {
                        topNeighbour = cell.card;
                    }
                    else
                    {
                        topNeighbour = null;
                    }
                }
            }
            else
            {
                topNeighbour = null;
            }
            if(x > 0)
            {
                if(cell.x == x - 1 && cell.y == y)
                {
                    if(cell != null)
                    {
                        leftNeighbour = cell.card;
                    }
                    else 
                    {
                        leftNeighbour = null;
                    }
                }
            }
            else
            {
                leftNeighbour = null;
            }
            if(y > 0)
            {
                if(cell.x == x && cell.y == y - 1) 
                {
                    if(cell != null)
                    {
                        bottomNeighbour = cell.card;
                    }
                    else
                    {
                        bottomNeighbour = null;
                    }
                }
            }
            else
            {
                bottomNeighbour = null;
            }
        }
    }

    private void DetectMatch()
    {
        if(rightNeighbour != null && rightNeighbour.GetComponent<CardElement>().type == type)
        {
            if(rightNeighbour.GetComponent<CardElement>().rightNeighbour != null && 
            rightNeighbour.GetComponent<CardElement>().rightNeighbour.GetComponent<CardElement>().type == type)
            {
                if(!matched.Contains(rightNeighbour))
                    matched.Add(rightNeighbour);

                if(!matched.Contains(rightNeighbour.GetComponent<CardElement>().rightNeighbour))
                    matched.Add(rightNeighbour.GetComponent<CardElement>().rightNeighbour);

                if(!matched.Contains(this.gameObject))
                    matched.Add(this.gameObject);
            }
            else if(leftNeighbour != null && leftNeighbour.GetComponent<CardElement>().type == type)
            {
                if(!matched.Contains(rightNeighbour))
                    matched.Add(rightNeighbour);

                if(!matched.Contains(leftNeighbour))
                    matched.Add(leftNeighbour);

                if(!matched.Contains(this.gameObject))
                    matched.Add(this.gameObject);
            }
        }

        if(leftNeighbour != null && leftNeighbour.GetComponent<CardElement>().type == type)
        {
            if(leftNeighbour.GetComponent<CardElement>().leftNeighbour != null && 
            leftNeighbour.GetComponent<CardElement>().leftNeighbour.GetComponent<CardElement>().type == type)
            {
                if(!matched.Contains(leftNeighbour))
                    matched.Add(leftNeighbour);

                if(!matched.Contains(leftNeighbour.GetComponent<CardElement>().leftNeighbour))
                    matched.Add(leftNeighbour.GetComponent<CardElement>().leftNeighbour);

                if(!matched.Contains(this.gameObject))
                    matched.Add(this.gameObject);
            }
            else if(rightNeighbour != null && rightNeighbour.GetComponent<CardElement>().type == type)
            {
                if(!matched.Contains(rightNeighbour))
                    matched.Add(rightNeighbour);

                if(!matched.Contains(leftNeighbour))
                    matched.Add(leftNeighbour);

                if(!matched.Contains(this.gameObject))
                    matched.Add(this.gameObject);
            }
        }

        if(topNeighbour != null && topNeighbour.GetComponent<CardElement>().type == type)
        {
            if(topNeighbour.GetComponent<CardElement>().topNeighbour != null && 
            topNeighbour.GetComponent<CardElement>().topNeighbour.GetComponent<CardElement>().type == type)
            {
                if(!matched.Contains(topNeighbour))
                    matched.Add(topNeighbour);

                if(!matched.Contains(topNeighbour.GetComponent<CardElement>().topNeighbour))
                    matched.Add(topNeighbour.GetComponent<CardElement>().topNeighbour);

                if(!matched.Contains(this.gameObject))
                    matched.Add(this.gameObject);
            }
            else if(bottomNeighbour != null && bottomNeighbour.GetComponent<CardElement>().type == type)
            {
                if(!matched.Contains(bottomNeighbour))
                    matched.Add(bottomNeighbour);

                if(!matched.Contains(topNeighbour))
                    matched.Add(topNeighbour);

                if(!matched.Contains(this.gameObject))
                    matched.Add(this.gameObject);
            }
        }
    }

    private void DestroyMatched()
    {
        foreach(var card in matched)
        {
            card.transform.GetComponentInParent<CardCrushCell>().isEmpty = true;
            //if not neighbour dont destroy check ?
            // if(card.transform.GetComponentInParent<CardCrushCell>().neighbours.Contains(card.GetComponentInParent<CardCrushCell>()))
            // {
            //     Destroy(card);
            // }
            Destroy(card);
        }
    }
}
