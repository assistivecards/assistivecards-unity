using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatchCardElement : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    GameAPI gameAPI;

    public bool moveable;
    public bool match;
    private GameObject levelChange;
    private LevelChangeScreenHatchMatch levelChangeScreenHatchMatch;
    public string cardName;
    private Vector3 startPosition;
    private bool isPointerUp;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        startPosition = transform.position;
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
    }

    void OnTriggerStay2D(Collider2D other)
    {   
        if(isPointerUp)
        {
            if(!match 
            && other.gameObject.GetComponent<MatchCardElement>().moveable == false  
            && other.gameObject.GetComponent<MatchCardElement>().cardName == cardName)
            {
                LeanTween.move(this.gameObject, other.transform.position, 0.25f);
                other.gameObject.GetComponent<MatchCardElement>().match = true;
                match = true;
                SpeakCardName();
            }
            else if(!match 
            && other.gameObject.GetComponent<MatchCardElement>().moveable == false 
            && other.gameObject.GetComponent<MatchCardElement>().cardName != cardName)
            {
                moveable = false;
                Invoke("MoveToBegging", 0.25f);
            }
        }

    }

    private void MoveToBegging()
    {
        LeanTween.move(this.gameObject, startPosition, 1.25f).setOnComplete(SetMoveableTrue);
        Debug.Log("MoveToBegging");
    }

    private void SpeakCardName()
    {
        gameAPI.Speak(cardName);
        Debug.Log(cardName);
    }

    private void SetMoveableTrue()
    {
        moveable = true;
    }
}
