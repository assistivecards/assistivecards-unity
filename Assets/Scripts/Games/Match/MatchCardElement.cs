using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatchCardElement : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    GameAPI gameAPI;
    private MatchBoardGenerator boardGenerator;
    public string cardName;
    public bool moveable;
    public bool match;
    private GameObject levelChange;
    private Vector3 startPosition;
    private bool isPointerUp;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        startPosition = transform.position;
    }

    private void OnEnable() 
    {
        boardGenerator = FindObjectOfType<MatchBoardGenerator>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!match && moveable)
            this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerUp = false;
        if(!match && moveable)
            this.transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerUp = true;
        Invoke("MoveToBeginning", 0.25f);
    }

    void OnTriggerStay2D(Collider2D other)
    {   
        if(isPointerUp)
        {
            if(!match 
            && other.gameObject.GetComponent<MatchCardElement>().cardName == cardName)
            {
                match = true;
                LeanTween.move(this.gameObject, other.transform.position, 0.25f);
                other.gameObject.GetComponent<MatchCardElement>().match = true;
                SpeakCardName();
                boardGenerator.CheckMatches();
                gameAPI.AddSessionExp();
                gameAPI.PlaySFX("Success");
            }
            else if(!match 
            && other.gameObject.GetComponent<MatchCardElement>().cardName != cardName)
            {
                Invoke("MoveToBeginning", 0.25f);
            }
        }

    }

    private void MoveToBeginning()
    {
        if(!match && moveable)
        {
            moveable = false;
            LeanTween.move(this.gameObject, startPosition, 1.25f).setOnComplete(SetMoveableTrue);
        }
    }

    private void SpeakCardName()
    {
        gameAPI.Speak(cardName);
        Debug.Log(cardName);
    }

    private void SetMoveableTrue()
    {
        moveable = true;
        gameAPI.RemoveSessionExp();
    }
}
