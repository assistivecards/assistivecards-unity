using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingSeparator : MonoBehaviour
{
    [SerializeField] GameObject panel;
    Collider2D collidedCard;
    [SerializeField] Transform box;
    [SerializeField] Transform cardSlot;

    void Start()
    {
        RectTransform rect = panel.GetComponent<RectTransform>();
        GetComponent<BoxCollider2D>().size = new Vector2(75, rect.rect.height);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SwipeManager>().isBeingDragged)
        {
            collidedCard = other;
            LeanTween.alpha(collidedCard.gameObject, 0, .2f);
            collidedCard.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("ResetCardPosition", .25f);
        }

    }

    void ResetCardPosition()
    {
        if (box.localScale == Vector3.one)
        {
            collidedCard.GetComponent<BoxCollider2D>().enabled = true;
            Rigidbody2D rb = collidedCard.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.freezeRotation = true;
            collidedCard.transform.localScale = Vector3.zero;
            LeanTween.alpha(collidedCard.gameObject, 1, .001f);
            collidedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
            collidedCard.transform.position = cardSlot.position;
            rb.freezeRotation = false;
            collidedCard.GetComponent<SwipeManager>().canThrow = true;
            collidedCard.GetComponent<SwipeManager>().isValid = false;
            collidedCard.GetComponent<SwipeManager>().isGrabbed = false;
            LeanTween.scale(collidedCard.gameObject, Vector3.one * 12, .2f);
        }

    }
}
