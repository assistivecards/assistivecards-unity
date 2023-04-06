using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardControllerCardChain : MonoBehaviour,IPointerDownHandler, IPointerUpHandler , IDragHandler
{   
    GameAPI gameAPI;
    public GameObject rightCard;
    public GameObject leftCard;
    public GameObject preRightCard;
    public GameObject preLeftCard;
    private GameObject board;
    public UIControllerCardChain uıController;
    public BoardGenerateCardChain boardGenerateCardChain;
    private RectTransform rt;
    public bool cantMove = false;
    public bool drag;
    public string leftCardLocalName;
    public string rightCardLocalName;
    public List<GameObject> childList = new List<GameObject>();
    private Collider2D otherCollider;
    private bool isPointerUp;
    public bool rightMatched;
    public bool leftMatched;
    private GameObject doubleCardParent;

    private void OnEnable()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start() 
    {
        rt = this.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!cantMove)
        {
            this.transform.position = eventData.position;
        }
    }

    private void DragFalse()
    {
        drag = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerUp = false;
        drag = true;
        GetComponentInChildren<CardControllerCardChain>().drag = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerUp = true;
        Invoke("DragFalse", 5f);
        GetComponentInChildren<CardControllerCardChain>().drag = false;
    }

    public void GetChildNames()
    {
        leftCard = this.transform.GetChild(0).gameObject;
        rightCard = this.transform.GetChild(1).gameObject;

        leftCard.GetComponent<ElementDetectorCardChain>().cardType = leftCard.name;
        rightCard.GetComponent<ElementDetectorCardChain>().cardType = rightCard.name;
    }

    private void GetChildList()
    {
        foreach(Transform child in transform)
        {
            childList.Add(child.gameObject);
        }
    }
    

    void OnTriggerStay2D(Collider2D other)
    { 
        if(GetComponentInParent<BoardGenerateCardChain>().isBoardCreated && drag)
        {
            if(other.gameObject.GetComponent<ElementDetectorCardChain>() != null)
            {
                if(other.gameObject.GetComponent<ElementDetectorCardChain>().cardType == leftCard.name)
                {
                    otherCollider = other;
                    GameObject doubleCardParent = other.transform.parent.gameObject;
                    leftMatched = true;
                }
                else if(other.gameObject.GetComponent<ElementDetectorCardChain>().cardType == rightCard.name)
                {
                    otherCollider = other;
                    GameObject doubleCardParent = other.transform.parent.gameObject;
                    rightMatched = true;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    { 
        if(GetComponentInParent<BoardGenerateCardChain>().isBoardCreated && drag)
        {
            if(other.gameObject.GetComponent<ElementDetectorCardChain>() != null)
            {
                if(other.gameObject.GetComponent<ElementDetectorCardChain>().cardType == leftCard.name)
                {
                    otherCollider = other;
                    GameObject doubleCardParent = other.transform.parent.gameObject;
                    leftMatched = false;
                }
                else if(other.gameObject.GetComponent<ElementDetectorCardChain>().cardType == rightCard.name)
                {
                    otherCollider = other;
                    GameObject doubleCardParent = other.transform.parent.gameObject;
                    rightMatched = false;
                }
            }
        }
    }

    private void Update() 
    {
        if(isPointerUp && leftMatched)
        {
            MatchLeft(otherCollider);
        }
        else if(isPointerUp && rightMatched)
        {
            MatchRight(otherCollider);
        }
    }

    public void MatchLeft(Collider2D _other)
    {
        doubleCardParent = _other.transform.parent.gameObject;
        if(doubleCardParent.GetComponent<CardControllerCardChain>().childList.Count <= 2)
        {
            preLeftCard = leftCard;
            LeanTween.move(doubleCardParent, leftCard.transform.position, 0.25f);

            if(doubleCardParent.GetComponent<CardControllerCardChain>().rightCardLocalName != null)
            {
                Invoke("MatchLeftCard", 0.5f);
            }
        }
        else if(doubleCardParent.GetComponent<CardControllerCardChain>().childList.Count > 2)
        {
           
            doubleCardParent.transform.GetComponent<CardControllerCardChain>().MatchRight(this.transform.GetChild(1).GetComponent<Collider2D>());
        }
    }

    private void MatchLeftCard()
    {
        leftCardLocalName = doubleCardParent.GetComponent<CardControllerCardChain>().rightCardLocalName;
        rt.sizeDelta = new Vector2(rt.sizeDelta.x + 283, rt.sizeDelta.y);
        foreach(Transform child in transform)
        {
            child.localPosition = new Vector3(child.localPosition.x + 141, child.localPosition.y, child.localPosition.z);
        }
        leftCard = doubleCardParent.GetComponent<CardControllerCardChain>().leftCard;
        doubleCardParent.GetComponent<CardControllerCardChain>().leftCard.transform.SetParent(this.transform);
        GetChildList();
        LeanTween.moveLocal(leftCard, new Vector3(preLeftCard.transform.localPosition.x - 283, 0, 0), 0.05f);
        gameAPI.PlaySFX("Success");
        Invoke("ReadLeftCard", 0.25f);
        Destroy(doubleCardParent.gameObject);

        boardGenerateCardChain.matchCount ++;
        if(boardGenerateCardChain.matchCount >= 4)
        {
            cantMove = true;
            LeanTween.scale(this.gameObject, Vector3.one * 0.55f, 0.8f);
            Invoke("CallResetBoard", 1.3f);
        }

        leftMatched = false;
        otherCollider = null;
        doubleCardParent = null;
    }

    public void MatchRight(Collider2D _other)
    {
        doubleCardParent = _other.transform.parent.gameObject;
        if(doubleCardParent.GetComponent<CardControllerCardChain>().childList.Count <= 2)
        {
            preRightCard = rightCard;
            LeanTween.move(doubleCardParent, rightCard.transform.position, 0.25f);

            if(doubleCardParent != null)
            {
                Invoke("MatchRightCard", 0.3f);
            }
        }
        else if(doubleCardParent.GetComponent<CardControllerCardChain>().childList.Count > 2)
        {
            doubleCardParent.transform.GetComponent<CardControllerCardChain>().MatchLeft(this.transform.GetChild(0).GetComponent<Collider2D>());
        }
    }

    private void MatchRightCard()
    {
        rightCardLocalName = doubleCardParent.GetComponent<CardControllerCardChain>().leftCardLocalName;
        rt.sizeDelta = new Vector2(rt.sizeDelta.x + 283, rt.sizeDelta.y);
        foreach(Transform child in transform)
        {
            child.localPosition = new Vector3(child.localPosition.x - 141, child.localPosition.y, child.localPosition.z);
        }
        rightCard = doubleCardParent.GetComponent<CardControllerCardChain>().rightCard;
        doubleCardParent.GetComponent<CardControllerCardChain>().rightCard.transform.SetParent(this.transform);
        GetChildList();
        LeanTween.moveLocal(rightCard, new Vector3(preRightCard.transform.localPosition.x + 283, 0, 0), 0.05f);
        gameAPI.PlaySFX("Success");
        Invoke("ReadRightCard", 0.25f);
        Destroy(doubleCardParent.gameObject);

        boardGenerateCardChain.matchCount ++;
        if(boardGenerateCardChain.matchCount >= 4)
        {
            cantMove = true;
            LeanTween.scale(this.gameObject, Vector3.one * 0.55f, 0.8f);
            Invoke("CallResetBoard", 1.3f);
        }

        rightMatched = false;
        otherCollider = null;
        doubleCardParent = null;
    }

    private void CallResetBoard()
    {
        boardGenerateCardChain.ResetBoard();
        GetComponentInParent<UIControllerCardChain>().Invoke("LevelChangeActive", 0.5f);
    }

    private void ReadRightCard()
    {
        gameAPI.Speak(rightCardLocalName);
        Debug.Log("right" + rightCardLocalName);
    }
    private void ReadLeftCard()
    {
        gameAPI.Speak(leftCardLocalName);
        Debug.Log("left" + leftCardLocalName);
    }
}
