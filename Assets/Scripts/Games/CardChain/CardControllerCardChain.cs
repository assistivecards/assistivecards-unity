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

    public void OnPointerDown(PointerEventData eventData)
    {
        drag = true;
        GetComponentInChildren<CardControllerCardChain>().drag = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        drag = false;
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
    

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(GetComponentInParent<BoardGenerateCardChain>().isBoardCreated && drag)
        {
            if(other.gameObject.GetComponent<ElementDetectorCardChain>() != null)
            {
                if(other.gameObject.GetComponent<ElementDetectorCardChain>().cardType == leftCard.name)
                {
                    otherCollider = other;
                    GameObject doubleCardParent = other.transform.parent.gameObject;
                    LeanTween.move(doubleCardParent, new Vector3(leftCard.transform.position.x, leftCard.transform.position.y, 0), 0.5f);
                    Invoke("MatchLeftCollider", 0.5f);
                }
                else if(other.gameObject.GetComponent<ElementDetectorCardChain>().cardType == rightCard.name)
                {
                    otherCollider = other;
                    GameObject doubleCardParent = other.transform.parent.gameObject;
                    LeanTween.move(doubleCardParent, new Vector3(rightCard.transform.position.x, rightCard.transform.position.y, 0), 0.5f);
                    Invoke("MatchRightCollider", 0.5f);
                }
            }
        }
    }

    private void MatchLeftCollider()
    {
        MatchLeft(otherCollider);
    }

    private void MatchRightCollider()
    {
        MatchRight(otherCollider);
    }

    public void MatchLeft(Collider2D _other)
    {
        GameObject doubleCardParent = _other.transform.parent.gameObject;
        if(doubleCardParent.GetComponent<CardControllerCardChain>().childList.Count <= 2)
        {
            preLeftCard = leftCard;
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
            Destroy(doubleCardParent.gameObject);
            gameAPI.PlaySFX("Success");
            Invoke("ReadLeftCard", 0.25f);

            boardGenerateCardChain.matchCount ++;
            if(boardGenerateCardChain.matchCount >= 4)
            {
                cantMove = true;
                LeanTween.scale(this.gameObject, Vector3.one * 0.55f, 0.8f);
                Invoke("CallResetBoard", 1.3f);
            }
        }
        else if(doubleCardParent.GetComponent<CardControllerCardChain>().childList.Count > 2)
        {
            doubleCardParent.transform.GetComponent<CardControllerCardChain>().MatchRight(this.transform.GetChild(1).GetComponent<Collider2D>());
        }
    }

    public void MatchRight(Collider2D _other)
    {
        GameObject doubleCardParent = _other.transform.parent.gameObject;
        if(doubleCardParent.GetComponent<CardControllerCardChain>().childList.Count <= 2)
        {
            preRightCard = rightCard;
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
            Destroy(doubleCardParent.gameObject);
            gameAPI.PlaySFX("Success");
            Invoke("ReadRightCard", 0.25f);

            boardGenerateCardChain.matchCount ++;
            if(boardGenerateCardChain.matchCount >= 4)
            {
                cantMove = true;
                LeanTween.scale(this.gameObject, Vector3.one * 0.55f, 0.8f);
                Invoke("CallResetBoard", 1.3f);
            }
        }
        else if(doubleCardParent.GetComponent<CardControllerCardChain>().childList.Count > 2)
        {
            doubleCardParent.transform.GetComponent<CardControllerCardChain>().MatchLeft(this.transform.GetChild(0).GetComponent<Collider2D>());
        }

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
