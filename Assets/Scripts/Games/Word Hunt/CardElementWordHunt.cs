using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardElementWordHunt : MonoBehaviour, IPointerEnterHandler
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(oneTime)
        {
            boardGenerator.currentWordLetters.Add(cardLetter);
            oneTime = false;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.name);
    }

    void Update()
    {
        // if (GetComponent<Button>().IsHighlighted() == true)
        // {
        //     Debug.Log( this.name + " is Highlighted");
        // }
    }

    // private void Update() 
    // {
    //     if (EventSystem.current.IsPointerOverGameObject())
    //         {
    //             Debug.Log("Clicked on the UI" + this.name);
    //         }
    // }
}
