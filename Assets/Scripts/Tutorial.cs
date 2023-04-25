using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform tutorialPosition;

    private void OnEnable() 
    {
        if(tutorialPosition != null)
        {
            this.transform.position = tutorialPosition.position;
        }
        else if(tutorialPosition == null)
        {
            this.transform.position = Vector3.zero;
        }
    }

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
