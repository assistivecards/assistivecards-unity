using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class DetectTouchFollowPath : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerUpHandler
{
    [SerializeField] private BoardGeneratorFollowPath boardGenerator;
    public GameObject referenceCard;
    public GameObject touchDetectionObject;
    public bool isDragging;
    private Vector2 dragStartPosition;
    private Vector2 touchPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPosition = eventData.position;
        isDragging = true;
        touchDetectionObject.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragEndPosition = eventData.position;
        touchPosition = new Vector3(eventData.position.x, eventData.position.y, 0);
        touchDetectionObject.transform.position = touchPosition;

        if(referenceCard != null)
        {
            if(referenceCard.GetComponent<CardControllerFollowPath>().isMatch == false)
            {
                referenceCard.transform.position = touchPosition;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        touchDetectionObject.SetActive(false);
        boardGenerator.Invoke("CheckPath", 0.25f);
        if(referenceCard != null)
        {
            referenceCard.GetComponent<CardControllerFollowPath>().Invoke("MoveToBeginning", 0.75f);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        touchDetectionObject.SetActive(false);
        boardGenerator.Invoke("CheckPath", 0.25f);
        if(referenceCard != null)
        {
            referenceCard.GetComponent<CardControllerFollowPath>().Invoke("MoveToBeginning", 0.75f);
        }
    }
}
