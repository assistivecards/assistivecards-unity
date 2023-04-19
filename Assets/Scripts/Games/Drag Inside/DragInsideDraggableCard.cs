using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragInsideDraggableCard : MonoBehaviour, IDragHandler
{

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
        transform.SetParent(GameObject.Find("GamePanel").transform);
        transform.SetAsLastSibling();
    }

}
