using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CardControllerSpellCards : MonoBehaviour
{
    private BoardGeneratorSpellCards boardGenerator;
    public string cardLetter;

    private void OnEnable() 
    {
        boardGenerator = GameObject.Find("GamePanel").GetComponent<BoardGeneratorSpellCards>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Dashedsquare" && other.GetComponent<CorrectLetterHolderSpellCards>().correctLetterForSlot == cardLetter &&
        other.GetComponent<CorrectLetterHolderSpellCards>().isEmpty == true)
        {
            other.GetComponent<CorrectLetterHolderSpellCards>().isEmpty = false;
            LeanTween.rotate(this.gameObject, Vector3.zero, 0.25f);
            LeanTween.move(this.gameObject, other.transform.position, 0.25f);
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<DraggableSpellCards>().draggable = false;
            boardGenerator.CheckLevelEnd();
        }
    }
}
