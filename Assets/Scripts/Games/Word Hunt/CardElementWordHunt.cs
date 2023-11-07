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
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if (hit.collider != null )
            {
                Debug.Log("touch" + this.name);
            }
        }
 
 
    }
}
