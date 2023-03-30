using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardControllerCardChain : MonoBehaviour,IPointerDownHandler, IPointerUpHandler , IDragHandler
{   
    public GameObject rightCard;
    public GameObject leftCard;

    public GameObject preRightCard;
    public GameObject preLeftCard;
    private GameObject board;
    public UIControllerCardChain uıController;
    public BoardGenerateCardChain boardGenerateCardChain;
    private RectTransform rt;
    private Vector3 leftSnapPosition;
    private Vector3 rightSnapPosition;
    public bool cantMove = false;
    public bool drag;
    float width;
    float height;
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
        rightCard = this.transform.GetChild(1).gameObject;
        leftCard = this.transform.GetChild(0).gameObject;
    }
    

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(GetComponentInParent<BoardGenerateCardChain>().isBoardCreated && drag)
        {
            if(other.gameObject.GetComponent<CardControllerCardChain>().rightCard.name == leftCard.name)
            {
                preLeftCard = leftCard;
                rt.sizeDelta = new Vector2(rt.sizeDelta.x + 283, rt.sizeDelta.y);
                foreach(Transform child in transform)
                {
                    child.localPosition = new Vector3(child.localPosition.x + 141, child.localPosition.y, child.localPosition.z);
                }
                leftCard = other.gameObject.GetComponent<CardControllerCardChain>().leftCard;
                other.gameObject.GetComponent<CardControllerCardChain>().leftCard.transform.SetParent(this.transform);
                LeanTween.moveLocal(leftCard, new Vector3(preLeftCard.transform.localPosition.x - 283, 0, 0), 0.05f);
                Destroy(other.gameObject);

                boardGenerateCardChain.matchCount ++;
                if(boardGenerateCardChain.matchCount >= 4)
                {
                    boardGenerateCardChain.ResetBoard();
                    GetComponentInParent<UIControllerCardChain>().Invoke("LevelChangeActive", 0.75f);
                }
            }
            else if(other.gameObject.GetComponent<CardControllerCardChain>().leftCard.name == rightCard.name)
            {
                preRightCard = rightCard;
                rt.sizeDelta = new Vector2(rt.sizeDelta.x + 283, rt.sizeDelta.y);
                foreach(Transform child in transform)
                {
                    child.localPosition = new Vector3(child.localPosition.x - 141, child.localPosition.y, child.localPosition.z);
                }
                rightCard = other.gameObject.GetComponent<CardControllerCardChain>().rightCard;
                other.gameObject.GetComponent<CardControllerCardChain>().rightCard.transform.SetParent(this.transform);
                LeanTween.moveLocal(rightCard, new Vector3(preRightCard.transform.localPosition.x + 283, 0, 0), 0.05f);
                Destroy(other.gameObject);

                boardGenerateCardChain.matchCount ++;
                if(boardGenerateCardChain.matchCount >= 4)
                {
                    boardGenerateCardChain.ResetBoard();
                    GetComponentInParent<UIControllerCardChain>().Invoke("LevelChangeActive", 0.5f);
                }
            }
        }
    }
}
