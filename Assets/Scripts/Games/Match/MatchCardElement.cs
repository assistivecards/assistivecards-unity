using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatchCardElement : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    GameAPI gameAPI;

    public bool moveable;
    public bool match;
    private GameObject levelChange;
    private LevelChangeScreenHatchMatch levelChangeScreenHatchMatch;

    public string cardName;
    private Vector3 startPosition;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(moveable)
            this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!match && moveable)
            this.transform.position = eventData.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {   

    }

    private void MoveToBegging()
    {
        LeanTween.move(this.gameObject, startPosition, 1.25f);
    }

    private void SpeakCardName()
    {
        gameAPI.Speak(cardName);
    }
}
