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
    public bool isPointerUp;

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
        {
            this.transform.position = eventData.position;
            isPointerUp = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(moveable)
        {
            this.transform.position = eventData.position;
            isPointerUp = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(moveable)
        {
            isPointerUp = true;
            Invoke("ChangePosition", 0.5f);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    { 
        if(moveable && isPointerUp)
        {
            if(other.gameObject.GetComponent<CardElementComplete>().cardType == cardType)
            {
                moveable = false;
                LeanTween.move(this.gameObject, other.transform.position, 0.25f).setOnComplete(MatchComplete);
                gameAPI.AddSessionExp();
                gameAPI.PlaySFX("Success");
                gameAPI.PlayConfettiParticle(this.transform.position);
                Invoke("ReadCard", 0.2f);
                matched = true;
                this.transform.SetParent(other.transform);
                boardCreatorComplete.matchCount += 1;
                boardCreatorComplete.Invoke("EndLevel", 0.4f);
            }
        }
    }

    private void Update() 
    {
        if(boardCreatorComplete.isBoardCreated)
            boardCreatorComplete.CheckChilds();    
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
            gameAPI.RemoveSessionExp();
        }
    }

    private void MatchComplete()
    {
        matchComplete = true;
        GetComponent<Collider2D>().enabled = false;
    }
}
