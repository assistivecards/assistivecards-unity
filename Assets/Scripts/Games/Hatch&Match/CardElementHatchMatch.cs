using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardElementHatchMatch : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private EggController eggController;
    private BoardCreatorHatchMatch boardCreatorHatchMatch;
    public bool match;

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
        if(!match)
            this.transform.position = eventData.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        
        if(other.gameObject.name == this.gameObject.name)
        {
            match = true;
            LeanTween.move(this.gameObject, other.transform.position, 0.75f).setOnComplete(LevelEnd);
        }
    }

    private void LevelEnd()
    {
        boardCreatorHatchMatch.levelEnd = true;
    }
}
