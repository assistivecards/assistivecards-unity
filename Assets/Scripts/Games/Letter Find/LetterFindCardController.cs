using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LetterFindCardController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    GameAPI gameAPI;
    private LetterFindUIController uıController;
    public string cardLetter;
    public string targetWord;
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
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        transform.position = eventData.position;
        isPointerUp = false;
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
        isPointerUp = true;
        Invoke("MoveToStartPosition", 1f);
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(isPointerUp && !match)
        {
            if(other.tag == "EmptyLetter" && other.gameObject.GetComponent<LetterFindLetterController>().letter == cardLetter) 
            {
                match = true;
                gameAPI.PlaySFX("Success");
                Invoke("ReadCard", 0.2f);
                gameAPI.AddSessionExp();
                uıController = GetComponentInParent<LetterFindUIController>();
                uıController.Invoke("LevelEndCheck", 0.5f);
                LeanTween.move(this.gameObject, other.transform.position, 0.5f);
            }
            else if(oneTime)
            {
                oneTime = false;
                gameAPI.RemoveSessionExp();
                MoveToStartPosition();
            }
        }
    }

    private void MoveToStartPosition()
    {
        if(!match)
        {
            LeanTween.move(this.gameObject, startPosition, 1f).setOnComplete(SetDragTrue);
        }
    }

    private void SetDragTrue()
    {
        oneTime = true;
    }

    private void ReadCard()
    {
        gameAPI.Speak(targetWord);
        Debug.Log(targetWord);
    }
}
