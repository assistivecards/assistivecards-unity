using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SortCardDraggable : MonoBehaviour, IDragHandler
{
    public bool draggable = false;

    public void OnDrag(PointerEventData eventData)
    {
        if(draggable)
        {
            this.transform.position = eventData.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Slot")
        {
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, 0);
            Debug.Log("!!!!!!!!!!!!!");
        }
    }

}
