using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NeedleMovement : MonoBehaviour
{
    private bool dragging = false;
    private Vector2 screenPosition;
    private Vector3 worldPosition;
    private NeedleDraggable lastDragged;

    private void Awake()
    {
        NeedleMovement[] controller = FindObjectsOfType<NeedleMovement>();
        if(controller.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(dragging)
        {
            if((Input.GetMouseButtonUp(0)) || Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Drop();
                return;
            }
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if(Input.touchCount > 0)
        {
            screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if(dragging)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                NeedleDraggable draggable = hit.transform.gameObject.GetComponent<NeedleDraggable>();
                if(draggable != null)
                {
                    lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    private void InitDrag()
    {
        dragging = true;
    }

    private void Drag()
    {
        lastDragged.transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }

    private void Drop()
    {
        dragging =  false;
    }
}
