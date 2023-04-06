using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingOutOfBoundsDetector : MonoBehaviour
{
    [SerializeField]
    Transform cardSlot;
    Collider2D collidedCard;

    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        RectTransform rect = GetComponent<RectTransform>();
        collider.size = new Vector2(rect.rect.width, rect.rect.height);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Out Of Bounds!!!");
        collidedCard = other;
        Invoke("ResetCardPosition", .25f);

    }

    void ResetCardPosition()
    {
        Rigidbody2D rb = collidedCard.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.freezeRotation = true;
        collidedCard.transform.localScale = Vector3.zero;
        collidedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
        collidedCard.transform.position = cardSlot.position;
        rb.freezeRotation = false;
        collidedCard.GetComponent<SwipeManager>().canThrow = true;
        collidedCard.GetComponent<SwipeManager>().isValid = false;
        LeanTween.scale(collidedCard.gameObject, Vector3.one * 10, .2f);
    }

}
