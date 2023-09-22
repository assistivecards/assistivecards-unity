using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardBlastElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    GameAPI gameAPI;
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
    public List<GameObject> canMatch = new List<GameObject>();
    public bool isMatched;
    public bool isMoved;
    public bool matcheable;

    private bool oneTime = true;
    public bool isOnTop;

    public string localName;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }


    private void OnEnable() 
    {
        cardPosition = this.transform.position;
        cardCrushGrid = FindObjectOfType<CardCrushGrid>();
        cardBlastFillGrid = FindObjectOfType<CardBlastFillGrid>();
        soundController = FindObjectOfType<SoundController>();
        DetectNeighbours();
        DetectPossibleMatch();
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
        DetectMatch();
        LockMatch();

        Invoke("RemovePoints", 1f);
    }

    private void Update() 
    {
        if(cardBlastFillGrid.isBoardCreated)
        {
            CheckDrop();
        }
        if(isMatched)
        {
            DetectMatch();
            LockMatch();
            Invoke("RestoreCard", 0.8f);
        }

        if(canMatch.Count >= 2)
        {
            matcheable = true;

            if(!cardBlastFillGrid.matcheableCards.Contains(this.gameObject)){

                cardBlastFillGrid.matcheableCards.Add(this.gameObject);
                Debug.Log(cardBlastFillGrid.matcheableCards + " Yeni eklenen: " + this.gameObject);
            }
        }
        else if(canMatch.Count < 2)
        {
            matcheable = false;
            if(cardBlastFillGrid.matcheableCards.Contains(this.gameObject))
                cardBlastFillGrid.matcheableCards.Remove(this.gameObject);
        }
    }

    private void RemovePoints()
    {
        if(!isMatched)
        {
            gameAPI.RemoveSessionExp();           
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
        canMatch.RemoveAll(item => item == null);
    }

    private void CheckDrop()
    {
        DetectNeighbours();
        DetectPossibleMatch();
        if(transform.parent != null)
        {
            var bottom = transform.parent.GetComponent<CardCrushCell>().bottomNeighbour;
            
            if(bottom)
            {
                if(bottom.transform.GetComponent<CardCrushCell>().isEmpty)
                {
                    MoveToTarget(transform.parent.GetComponent<CardCrushCell>().bottomNeighbour);
                    cardBlastFillGrid.Invoke("RefillBoard", 0.5f);
                }
            }
            else
            {
                cardBlastFillGrid.Invoke("RefillBoardsTop", 1f);
            }
        }
        canMatch.RemoveAll(item => item == null);
    }

    private void MoveToTarget(GameObject _cell)
    {
        DetectNeighbours();
        DetectPossibleMatch();
        LeanTween.move(this.gameObject, _cell.transform.position, 0.2f);

        this.transform.parent.GetComponent<CardCrushCell>().isEmpty = true;
        this.transform.parent = _cell.transform;

        _cell.GetComponent<CardCrushCell>().card = this.gameObject;

        x = _cell.GetComponent<CardCrushCell>().x;
        y = _cell.GetComponent<CardCrushCell>().y;
        this.transform.parent.GetComponent<CardCrushCell>().isEmpty = false;
    }

    public void DetectMatch()
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
                        {
                            matched.Add(neighbour.card);
                            neighbour.card.GetComponent<CardBlastElement>().isMatched = true;
                        }
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
                        {
                            matched.Add(neighbour.card);
                            neighbour.card.GetComponent<CardBlastElement>().isMatched = true;
                        }
                    }
                    else 
                    {
                        break;
                    }
                }
            }
        }

        foreach(var neighbour in GetComponentInParent<CardCrushCell>().verticalNeightboursBottom)
        {
            if(neighbour.card != null)
            {
                if(neighbour.card.GetComponent<CardBlastElement>().type == type)
                {
                    if(!matched.Contains(neighbour.card))
                    {
                        matched.Add(neighbour.card);
                        neighbour.card.GetComponent<CardBlastElement>().isMatched = true;
                    }
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
                    {
                        matched.Add(neighbour.card);
                        neighbour.card.GetComponent<CardBlastElement>().isMatched = true;
                    }
                }
                else 
                {
                    break;
                }
            }
        }
    }

    private void DetectPossibleMatch()
    {
        if(transform.parent != null)
        {
            if(transform.GetComponentInParent<CardCrushCell>() != null)
            {
                foreach(var neighbour in GetComponentInParent<CardCrushCell>().horizontalNeighboursRight)
                {
                    if(neighbour.card != null)
                    {
                        if(neighbour.card.GetComponent<CardBlastElement>().type == type)
                        {
                            if(!canMatch.Contains(neighbour.card))
                            {
                                canMatch.Add(neighbour.card);
                            }
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
                            if(!canMatch.Contains(neighbour.card))
                            {
                                canMatch.Add(neighbour.card);
                            }
                        }
                        else 
                        {
                            break;
                        }
                    }
                }
            }

            foreach(var neighbour in GetComponentInParent<CardCrushCell>().verticalNeightboursBottom)
            {
                if(neighbour.card != null)
                {
                    if(neighbour.card.GetComponent<CardBlastElement>().type == type)
                    {
                        if(!canMatch.Contains(neighbour.card))
                        {
                            canMatch.Add(neighbour.card);
                        }
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
                        if(!canMatch.Contains(neighbour.card))
                        {
                            canMatch.Add(neighbour.card);
                        }
                    }
                    else 
                    {
                        break;
                    }
                }
            }
        }
    }

    private void LockMatch()
    {
        if(matched.Count >= 2)
        {
            if(!matched.Contains(this.gameObject))
            {
                matched.Add(this.gameObject);
                isMatched = true;
                
                ScaleUpMatch();
            }
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
            if(transform.parent != null)
            {
                if(card.transform.GetComponentInParent<CardCrushCell>() != null)
                {
                    card.transform.GetComponentInParent<CardCrushCell>().isEmpty = true;
                }
            }
            Destroy(card);
        }
    }

    private void RestoreCard()
    {
        LeanTween.scale(this.gameObject, Vector3.one, 0);
        isMatched = false;
    }

    private void ScaleUpMatch()
    {
        cardBlastFillGrid.scoreInt += 1;
        gameAPI.AddSessionExp();
        cardBlastFillGrid.isOnRefill = true;
        foreach(var card in matched)
        {
            soundController.matchedList.Add(localName);
            soundController.match = true;
            soundController.Invoke("ReadMatch", 0.6f);
            soundController.Invoke("TriggerSuccessSFX", 0.25f);
            LeanTween.scale(card, new Vector3(0.5f, 0.5f, 0.5f), 0.1f);   
            gameAPI.PlayConfettiParticle(card.transform.position);
        }
        Invoke("DestroyMatched", 0.1f);
    }

    public void DestroyCard()
    {
        cardBlastFillGrid.isOnRefill = true;
        LeanTween.scale(this.gameObject, new Vector3(0.5f, 0.5f, 0.5f), 0.1f);  
        Invoke("DestroySelf", 0.1f);
    }

    private void DestroySelf()
    {
        this.transform.GetComponentInParent<CardCrushCell>().isEmpty = true;
        Destroy(this.gameObject);
    }

    private void CheckIsOnTop()
    {
        if(GetComponentInParent<CardCrushCell>().isOnTop == true)
        {
            isOnTop = true;
        }
        else if(GetComponentInParent<CardCrushCell>().isOnTop == false)
        {
            isOnTop = false;
        }
    }
}
