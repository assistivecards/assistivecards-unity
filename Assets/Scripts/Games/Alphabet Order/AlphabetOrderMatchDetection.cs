using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlphabetOrderMatchDetection : MonoBehaviour, IPointerUpHandler
{
    private Transform matchedSlotTransform;
    public bool isMatched = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == transform.GetChild(0).GetComponent<Image>().sprite.texture.name)
        {
            matchedSlotTransform = other.transform;
            isMatched = true;
            Debug.Log("Correct Match! ENTER");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == transform.GetChild(0).GetComponent<Image>().sprite.texture.name)
        {
            isMatched = false;
            Debug.Log("Correct Match! EXIT");
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMatched)
        {
            gameObject.GetComponent<AlphabetOrderDraggableCard>().enabled = false;
            transform.SetParent(matchedSlotTransform);
            LeanTween.move(gameObject, matchedSlotTransform, 0.25f);
            LeanTween.rotate(gameObject, Vector3.zero, .25f);
            Debug.Log("CORRECT MATCH");
        }

        else
        {
            transform.SetParent(GameObject.Find(gameObject.GetComponent<AlphabetOrderDraggableCard>().parentName).transform);
            LeanTween.move(gameObject, transform.parent.position, .5f);
            Debug.Log("WRONG MATCH");
        }
    }
}
