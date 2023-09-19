using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardChainCardController : MonoBehaviour
{
    GameAPI gameAPI;
    public BoardGenerateCardChain boardGenerateCardChain;
    public UIControllerCardChain uıController;
    public GameObject leftCard;
    public GameObject rightCard;
    public string leftCardLocalName;
    public string rightCardLocalName;
    public string preLeftCardLocalName;
    public string preRightCardLocalName;
    public Vector3 parentPos;
    public GameObject otherGameObject;

    private void OnEnable()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        boardGenerateCardChain = GetComponentInParent<BoardGenerateCardChain>();
        uıController = GetComponentInParent<UIControllerCardChain>();
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.GetComponent<CardChainCardController>() != null && GetComponent<CardChainDraggable>().touching)
        {
           if(other.GetComponent<CardChainCardController>().leftCardLocalName == rightCardLocalName)
           {
                if(other.transform.parent.tag == "Card")
                {
                    otherGameObject = other.transform.parent.gameObject;
                }
                else
                {
                    otherGameObject = other.gameObject;
                }
                preRightCardLocalName = rightCardLocalName;
                otherGameObject.transform.SetParent(this.transform);
                otherGameObject.transform.tag = "Untagged";
                otherGameObject.transform.position = rightCard.transform.position;
                rightCard = otherGameObject.GetComponent<CardChainCardController>().rightCard;
                LeanTween.scale(this.gameObject, Vector3.one * 0.55f, 0.5f).setOnComplete(ScaleDown);
                rightCardLocalName = otherGameObject.GetComponent<CardChainCardController>().rightCardLocalName;
                otherGameObject.GetComponent<CardChainDraggable>().enabled = false;
                Invoke(nameof(ReadRightCard), 0.1f);
                boardGenerateCardChain.matchCount++;
                Invoke(nameof(CallResetBoard), 0.2f);
           }
            else if(other.GetComponent<CardChainCardController>().rightCardLocalName == leftCardLocalName)
           {
                if(other.transform.parent.tag == "Card")
                {
                    otherGameObject = other.transform.parent.gameObject;
                }
                else
                {
                    otherGameObject = other.gameObject;
                }
                gameAPI.PlaySFX("Success");
                preLeftCardLocalName = leftCardLocalName;
                otherGameObject.transform.SetParent(this.transform);
                otherGameObject.transform.tag = "Untagged";
                otherGameObject.transform.position = leftCard.transform.position;
                leftCard = otherGameObject.GetComponent<CardChainCardController>().leftCard;
                LeanTween.scale(this.gameObject, Vector3.one * 0.55f, 0.5f).setOnComplete(ScaleDown);
                leftCardLocalName = otherGameObject.GetComponent<CardChainCardController>().leftCardLocalName;
                otherGameObject.GetComponent<CardChainDraggable>().enabled = false;
                Invoke(nameof(ReadLeftCard), 0.1f);
                boardGenerateCardChain.matchCount++;
                Invoke(nameof(CallResetBoard), 0.2f);
           }
        }
    }

    private void ReadLeftCard()
    {
        gameAPI.Speak(preLeftCardLocalName);
        Debug.Log(preLeftCardLocalName);
    }

    private void ReadRightCard()
    {
        gameAPI.Speak(preRightCardLocalName);
        Debug.Log(preRightCardLocalName);
    }

    private void ScaleDown()
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.5f, 0.2f);
    }

    private void CallResetBoard()
    {
        if(boardGenerateCardChain.matchCount >= 4)
        {
            boardGenerateCardChain.ResetBoard();
            GetComponentInParent<UIControllerCardChain>().Invoke("LevelChangeActive", 0.5f);
        }
    }
}
