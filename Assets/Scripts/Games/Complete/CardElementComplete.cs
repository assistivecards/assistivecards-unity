using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardElementComplete : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    GameAPI gameAPI;
    public string cardType;
    public bool moveable;
    public bool matched;
    private GameObject board;
    private DetectMatchComplete detectMatchComplete;
    private BoardCreatorComplete boardCreatorComplete;
    public string localName;
    public Vector3 startPosition;
    public bool matchComplete;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

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

    public void OnPointerUp(PointerEventData eventData)
    {
        if(moveable)
        {
            ChangePosition();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(moveable)
        {
            if(other.gameObject.GetComponent<CardElementComplete>().cardType == cardType)
            {
                moveable = false;
                LeanTween.move(this.gameObject, other.transform.position, 0.25f).setOnComplete(MatchComplete);
                gameAPI.PlaySFX("Success");
                Invoke("ReadCard", 0.2f);
                matched = true;
                this.transform.SetParent(other.transform);
                boardCreatorComplete.matchCount += 1;
                boardCreatorComplete.Invoke("EndLevel", 0.4f);
            }
        }
    }

    private void ReadCard()
    {
        gameAPI.Speak(localName);
    }

    private void ChangePosition()
    {
        if(!matched)
        {
            LeanTween.move(this.gameObject, startPosition, 1f);
        }
    }

    private void Update() 
    {
        CheckIsPositionTrue();
    }

    private void CheckIsPositionTrue()
    {
        if(matchComplete && transform.localPosition != Vector3.zero)
            this.transform.localPosition = Vector3.zero;
    }

    private void MatchComplete()
    {
        matchComplete = true;
    }
}
