using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardElementWordHunt : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private BoardGeneratorWordHunt boardGenerator;
    public string cardLetter;
    private bool oneTime;
    public int row;
    public int column;
    public int index;
    public bool filled;

    public void OnDrag(PointerEventData eventData)
    {
        if(oneTime)
        {
            boardGenerator.currentWordLetters.Add(cardLetter);
            oneTime = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(oneTime)
        {
            boardGenerator.currentWordLetters.Add(cardLetter);
            oneTime = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        oneTime = true;
    }
}
