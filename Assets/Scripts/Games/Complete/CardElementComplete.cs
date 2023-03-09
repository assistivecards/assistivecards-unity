using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardElementComplete : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public string cardType;
    public bool moveable;
    public bool matched;
    private GameObject board;
    private DetectMatchComplete detectMatchComplete;
    private BoardCreatorComplete boardCreatorComplete;

    private void Start() 
    {
        detectMatchComplete = GetComponentInParent<DetectMatchComplete>();
        board = GameObject.Find("Grid");
        boardCreatorComplete = board.GetComponent<BoardCreatorComplete>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(moveable)
            this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(moveable)
            this.transform.position = eventData.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(moveable)
        {
            if(other.gameObject.GetComponent<CardElementComplete>().cardType == cardType)
            {
                LeanTween.move(this.gameObject, other.transform.position, 0.25f);
                matched = true;
                moveable = false;
                this.transform.SetParent(other.transform);
                boardCreatorComplete.matchCount += 1;
                boardCreatorComplete.Invoke("EndLevel", 0.4f);
            }
        }
    }

}
