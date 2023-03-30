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
    }
    

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(GetComponentInParent<BoardGenerateCardChain>().isBoardCreated && drag)
        {
            if(other.gameObject.GetComponent<CardControllerCardChain>().rightCard.name == leftCard.name)
            {
                preLeftCard = leftCard;
                leftCardLocalName = other.gameObject.GetComponent<CardControllerCardChain>().rightCardLocalName;
                rt.sizeDelta = new Vector2(rt.sizeDelta.x + 283, rt.sizeDelta.y);
                foreach(Transform child in transform)
                {
                    child.localPosition = new Vector3(child.localPosition.x + 141, child.localPosition.y, child.localPosition.z);
                }
                leftCard = other.gameObject.GetComponent<CardControllerCardChain>().leftCard;
                other.gameObject.GetComponent<CardControllerCardChain>().leftCard.transform.SetParent(this.transform);
                LeanTween.moveLocal(leftCard, new Vector3(preLeftCard.transform.localPosition.x - 283, 0, 0), 0.05f);
                Destroy(other.gameObject);
                gameAPI.PlaySFX("Success");
                Invoke("ReadLeftCard", 0.25f);

                boardGenerateCardChain.matchCount ++;
                if(boardGenerateCardChain.matchCount >= 4)
                {
                    Invoke("CallResetBoard", 0.3f);
                }
            }
            else if(other.gameObject.GetComponent<CardControllerCardChain>().leftCard.name == rightCard.name)
            {
                preRightCard = rightCard;
                rightCardLocalName = other.gameObject.GetComponent<CardControllerCardChain>().leftCardLocalName;
                rt.sizeDelta = new Vector2(rt.sizeDelta.x + 283, rt.sizeDelta.y);
                foreach(Transform child in transform)
                {
                    child.localPosition = new Vector3(child.localPosition.x - 141, child.localPosition.y, child.localPosition.z);
                }
                rightCard = other.gameObject.GetComponent<CardControllerCardChain>().rightCard;
                other.gameObject.GetComponent<CardControllerCardChain>().rightCard.transform.SetParent(this.transform);
                LeanTween.moveLocal(rightCard, new Vector3(preRightCard.transform.localPosition.x + 283, 0, 0), 0.05f);
                Destroy(other.gameObject);
                gameAPI.PlaySFX("Success");
                Invoke("ReadRightCard", 0.25f);

                boardGenerateCardChain.matchCount ++;
                if(boardGenerateCardChain.matchCount >= 4)
                {
                    Invoke("CallResetBoard", 0.3f);
                }
            }
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
