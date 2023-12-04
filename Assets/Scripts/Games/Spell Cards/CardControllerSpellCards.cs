using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CardControllerSpellCards : MonoBehaviour, IPointerUpHandler
{
    GameAPI gameAPI;
    public string cardLetter;
    public Color correctMatchColor;
    private DraggableSpellCards draggable;
    private BoardGeneratorSpellCards boardGenerator;
    public Vector3 startPosition;
    public bool matched;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable() 
    {
        boardGenerator = GameObject.Find("GamePanel").GetComponent<BoardGeneratorSpellCards>();
        Invoke("GetStartPosition", 0.5f);
        draggable = GetComponent<DraggableSpellCards>();
    }

    private void GetStartPosition()
    {
        startPosition = transform.localPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Invoke("MoveToBeginning", 1f);
    }

    private void MoveToBeginning()
    {
        if(!matched)
        {
            LeanTween.moveLocal(this.gameObject, startPosition, 0.5f);
            draggable.isDraggable = true;
            gameAPI.RemoveSessionExp();
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "Dashedsquare" && draggable.isPointerUp)
        {
            if(other.GetComponent<CorrectLetterHolderSpellCards>().correctLetterForSlot == cardLetter &&
            other.GetComponent<CorrectLetterHolderSpellCards>().isEmpty == true)
            {
                matched = true;
                other.GetComponent<CorrectLetterHolderSpellCards>().isEmpty = false;
                LeanTween.rotate(this.gameObject, Vector3.zero, 0.25f);
                LeanTween.move(this.gameObject, other.transform.position, 0.25f);
                this.GetComponent<Collider2D>().enabled = false;
                draggable.isDraggable = false;
                gameAPI.PlaySFX("Success");
                boardGenerator.Invoke("CheckLevelEnd", 0.5f);
            }
            else if(other.GetComponent<CorrectLetterHolderSpellCards>().correctLetterForSlot != cardLetter && !matched)
            {
                Invoke("MoveToBeginning", 0.5f);
            }
        }
    }
}
