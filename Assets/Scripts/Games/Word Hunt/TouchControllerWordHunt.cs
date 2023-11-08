using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchControllerWordHunt : MonoBehaviour
{
    [SerializeField] private BoardGeneratorWordHunt boardGenerator;
    public Color[] colors;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Card")
        {
            other.GetComponent<Image>().color = colors[0];
            boardGenerator.currentWordLetters.Add(other.GetComponent<CardElementWordHunt>().cardLetter);
        }
    }
}
