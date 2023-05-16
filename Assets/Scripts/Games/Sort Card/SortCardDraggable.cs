using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SortCardDraggable : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private SortCardsLevelEnding levelEnding;
    public Vector3 startingPos;
    public GameObject startingParent;
    public string cardType;
    public bool draggable = false;
    public bool isPointerUp = false;
    private bool landed = false;

    private void Awake() 
    {
        levelEnding = GameObject.Find("GamePanel").GetComponent<SortCardsLevelEnding>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(draggable)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerUp = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerUp = false;
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Slot" && isPointerUp && !landed)
        {
            LeanTween.rotateZ(this.gameObject, 0, 0.7f);
            LeanTween.move(this.gameObject, other.transform.position, 0.7f);
            this.transform.SetParent(other.transform);
            other.gameObject.GetComponentInParent<SortCardOrderDetection>().ListCards();
            levelEnding.count++;
            if(levelEnding.count == 3)
            {
                levelEnding.CreateString();
            }
            landed = true;
        }
    }

    public void MoveToStartPos()
    {
        LeanTween.move(this.gameObject, startingParent.transform.position, 0.75f);
        this.transform.SetParent(startingParent.transform);
        landed = false;
    }

}
