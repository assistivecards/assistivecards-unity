using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CardBalanceDetectFloor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    GameAPI gameAPI;
    public string cardLocalName;
    public bool matched;
    public bool notMatched;
    private CardBalanceBoardGenerator boardGenerator;
    public string requiredFloor;
    public bool touch;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable() 
    {
        boardGenerator = FindObjectOfType<CardBalanceBoardGenerator>();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == requiredFloor && boardGenerator.isPointerUp)
        {
            boardGenerator.DetectMatches();
            if(!matched && touch)
            {
                gameAPI.PlaySFX("Success");
                Invoke("SpeakCard", 0.2f);
            }
            matched = true;
        }
    }

    private void SpeakCard()
    {
        gameAPI.Speak(cardLocalName);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == requiredFloor)
        {
            matched = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        boardGenerator.isPointerUp = false;
        touch = true;
    }
        
    public void OnPointerUp(PointerEventData eventData)
    {
        boardGenerator.isPointerUp = true;
        Invoke("SetTouchFalse", 0.5f);
    }

    private void SetTouchFalse()
    {
        touch = false;
    }
}
