using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SortCardDraggable : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    GameAPI gameAPI;
    public GameObject tutorial;
    private SortCardsLevelEnding levelEnding;
    private SortCardOrderDetection orderDetection;
    public Vector3 startingPos;
    public GameObject startingParent;
    public string cardType;
    public bool draggable = false;
    public bool isPointerUp = false;
    public bool landed = false;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();

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
        tutorial = GameObject.FindWithTag("Tutorial");
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
            orderDetection = GameObject.Find("Slots").GetComponent<SortCardOrderDetection>();
            orderDetection.DetectMatch(other.gameObject, cardType);

            if(tutorial != null)
            {
                tutorial.GetComponent<TutorialSortCard>().i++;
            }

            if(levelEnding.count == 3)
            {
                levelEnding.CreateString();

                if(tutorial != null)
                {
                    tutorial.GetComponent<TutorialSortCard>().ClearLists();
                }
            }

            landed = true;
        }
    }

    public void SetLandedFalse()
    {
        // this.transform.position = startingParent.transform.position;
        landed = false;
    }

}
