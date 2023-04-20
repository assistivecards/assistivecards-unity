using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData) 
    {
        Invoke("SetActiveFalse", 1f);
    }

    private void SetActiveFalse()
    {
        this.gameObject.SetActive(false);
    }
}
