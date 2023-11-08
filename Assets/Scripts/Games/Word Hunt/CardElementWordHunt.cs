using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardElementWordHunt : MonoBehaviour
{
    [SerializeField] private BoardGeneratorWordHunt boardGenerator;
    [SerializeField] private DetectTouchWordHunt detectTouch;
    public string cardLetter;
    public bool oneTime = true;
    public int row;
    public int column;
    public int index;
    public bool filled;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Touch" && oneTime)
        {
            GetComponent<Image>().color = detectTouch.currentColor;
            boardGenerator.currentWordLetters.Add(cardLetter.ToLower());
            boardGenerator.currentWordLetterObjects.Add(this.gameObject);
            oneTime = false;
        }
    }
}
