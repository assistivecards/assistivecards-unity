using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PatternTrainCardController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    GameAPI gameAPI;
    [SerializeField] private PatternTrainBoardGenerator boardGenerator;
    public string cardName;
    public string cardLocalName;
    public string trueCardName;
    public bool draggable = false;
    private Vector3 startPosition;
    private bool oneTime = true;
    private bool isPointerUp;
    private bool match;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable() 
    {
        startPosition = this.transform.position;
        boardGenerator = FindObjectOfType<PatternTrainBoardGenerator>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(draggable) 
        {
            transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        if(draggable) 
        {
            transform.position = eventData.position;
        }
        isPointerUp = false;
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
        isPointerUp = true;
        Invoke("MoveToStartPosition", 1f);
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if(isPointerUp && !match)
        {
            if(other.collider.tag == "Card" && cardName == trueCardName) 
            {
                match = true;
                LeanTween.move(this.gameObject, other.transform.position, 0.5f).setOnComplete(RotateCard);
                gameAPI.AddSessionExp();
                gameAPI.PlaySFX("Success");
                Invoke("SuccessTTS", 0.25f);
                draggable = false;
            }
            else if(oneTime)
            {
                oneTime = false;
                MoveToStartPosition();
                gameAPI.RemoveSessionExp();
            }
        }
    }

    private void SuccessTTS()
    {
        gameAPI.Speak(cardLocalName);
        Debug.Log(cardLocalName);
    }

    private void RotateCard()
    {
        LeanTween.rotate(this.gameObject, new Vector3(0, 0, 5f), 1f);
        boardGenerator.Invoke("LevelEnd", 0.5f);
    }

    private void MoveToStartPosition()
    {
        if(!match)
        {
            draggable = false;
            LeanTween.move(this.gameObject, startPosition, 1f).setOnComplete(SetDragTrue);
        }
    }

    private void SetDragTrue()
    {
        draggable = true;
        oneTime = true;
    }
}
