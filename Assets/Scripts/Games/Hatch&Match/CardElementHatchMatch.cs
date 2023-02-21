using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardElementHatchMatch : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private EggController eggController;

    private void Start() 
    {
        eggController = FindObjectOfType<EggController>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        
        if(other.gameObject.name == this.gameObject.name)
        {
            Debug.Log("!!!!!!!!!!!!!!!!!");
        }
    }
}
