using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData) 
    {
        Invoke("SetActiveFalse", 0.15f);
    }

    private void SetActiveFalse()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Invoke("SetActiveFalse", 0.7f);
        }
    }
}
