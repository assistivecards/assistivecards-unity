using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardElementHatchMatch : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private EggController eggController;
    private BoardCreatorHatchMatch boardCreatorHatchMatch;
    public bool levelEnd;

    private void Start() 
    {
        eggController = FindObjectOfType<EggController>();
        boardCreatorHatchMatch = GetComponentInParent<BoardCreatorHatchMatch>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        
        if(other.gameObject.name == this.gameObject.name)
        {
            boardCreatorHatchMatch.levelEnd = true;
        }
    }
}
