using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NeedleMovement : MonoBehaviour
{
    public bool dragging = false;
    public TrailRenderer trailRenderer;
    [SerializeField] private GameObject ropeGameobject;
    private Vector2 screenPosition;
    private Vector3 worldPosition;
    private NeedleDraggable needleDraggable;

    private void Awake()
    {
        NeedleMovement[] controller = FindObjectsOfType<NeedleMovement>();
        trailRenderer = ropeGameobject.GetComponent<TrailRenderer>();
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
            GetComponentInChildren<TrailRenderer>().time = 100;
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                NeedleDraggable draggable = hit.transform.gameObject.GetComponent<NeedleDraggable>();
                if(draggable != null)
                {
                    needleDraggable = draggable;
                    InitDrag();
                }
            }
        }
    }

    public void InitDrag()
    {
        dragging = true;
    }

    public void Drag()
    {
        //trailRenderer.sortingOrder = 10;
        needleDraggable.transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }

    public void Drop()
    {
        dragging =  false;
    }
}
