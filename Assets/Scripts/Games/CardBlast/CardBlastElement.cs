using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardBlastElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float x;
    public float y;
    public Vector3 cardPosition;
    public string type;

    private CardCrushGrid cardCrushGrid;
    private CardBlastFillGrid cardBlastFillGrid;
    private SoundController soundController;

    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;

    private float swipeAngle;

    public GameObject rightNeighbour;
    public GameObject leftNeighbour;

    public GameObject topNeighbour;
    public GameObject bottomNeighbour;

    public List<GameObject> matched = new List<GameObject>();
    public bool isMatched;
    public bool isMoved;

    private void OnEnable() 
    {
        LeanTween.scale(this.gameObject, Vector3.one, 0.3f);
        cardPosition = this.transform.position;
        cardCrushGrid = FindObjectOfType<CardCrushGrid>();
        cardBlastFillGrid = FindObjectOfType<CardBlastFillGrid>();
        soundController = FindObjectOfType<SoundController>();
        if(this.transform.localScale.x > 1)
        {
            this.transform.localScale = Vector3.one;
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        isMoved = true;
        cardPosition = this.transform.position;
        if(cardBlastFillGrid.isBoardCreated && !cardBlastFillGrid.isOnRefill)
        {
            firstTouchPosition = pointerEventData.position;
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if(cardBlastFillGrid.isBoardCreated && !cardBlastFillGrid.isOnRefill)
        {
            finalTouchPosition = pointerEventData.position;
        }

        DetectLongVerticalMatch();
        DetectLongHorizontalMatch();
    }
    private void Update() 
    {
        if(this.transform.localScale.x > 1)
        {
            this.transform.localScale = Vector3.one;
        }

        DetectNeighbours();

        if(cardBlastFillGrid.isBoardCreated)
        {
            CheckDrop();
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

    private void CheckDrop()
    {
        if(transform.parent.GetComponent<CardCrushCell>().bottomNeighbour != null)
        {
            if(transform.parent.GetComponent<CardCrushCell>().bottomNeighbour.transform.GetComponent<CardCrushCell>().isEmpty)
            {
                MoveToTarget(transform.parent.GetComponent<CardCrushCell>().bottomNeighbour);
            }
        }
    }

    private void MoveToTarget(GameObject _cell)
    {
        LeanTween.move(this.gameObject, _cell.transform.position, 0.2f);

        this.transform.parent.GetComponent<CardCrushCell>().isEmpty = true;
        this.transform.parent = _cell.transform;

        _cell.GetComponent<CardCrushCell>().card = this.gameObject;

        x = _cell.GetComponent<CardCrushCell>().x;
        y = _cell.GetComponent<CardCrushCell>().y;
        this.transform.parent.GetComponent<CardCrushCell>().isEmpty = false;
    }

    public void DetectLongVerticalMatch()
    {
        if(transform.GetComponentInParent<CardCrushCell>() != null)
        {
            foreach(var neighbour in GetComponentInParent<CardCrushCell>().horizontalNeighboursRight)
            {
                if(neighbour.card != null)
                {
                    if(neighbour.card.GetComponent<CardBlastElement>().type == type)
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
                    if(neighbour.card.GetComponent<CardBlastElement>().type == type)
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

            if(matched.Count >= 1)
            {
                if(!matched.Contains(this.gameObject))
                    matched.Add(this.gameObject);
                    isMatched = true;
                    ScaleUpMatch();
            }
            if(matched.Count < 1)
            {
                matched.Clear();
            }
        }
    }
    private void DetectLongHorizontalMatch()
    {
        foreach(var neighbour in GetComponentInParent<CardCrushCell>().verticalNeightboursBottom)
        {
            if(neighbour.card != null)
            {
                if(neighbour.card.GetComponent<CardBlastElement>().type == type)
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
                if(neighbour.card.GetComponent<CardBlastElement>().type == type)
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
                isMatched = true;
                
                ScaleUpMatch();
            
        }
        if(matched.Count < 2)
        {
            matched.Clear();
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
        cardBlastFillGrid.isOnRefill = true;
        foreach(var card in matched)
        {
            //soundController.matchedList.Add(this.gameObject.name);
            LeanTween.scale(card, new Vector3(0.5f, 0.5f, 0.5f), 0.1f);   
        }
        Invoke("DestroyMatched", 0.1f);
    }
}
