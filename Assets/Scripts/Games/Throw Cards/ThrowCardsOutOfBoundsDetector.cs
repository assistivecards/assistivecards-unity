using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowCardsOutOfBoundsDetector : MonoBehaviour
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
        LeanTween.alpha(collidedCard.gameObject, 0, .2f);
        Invoke("ResetCardPosition", .25f);

    }

    void ResetCardPosition()
    {
        Rigidbody2D rb = collidedCard.GetComponent<Rigidbody2D>();
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        collidedCard.transform.localScale = Vector3.zero;
        LeanTween.alpha(collidedCard.gameObject, 1, .001f);
        collidedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
        collidedCard.transform.position = cardSlot.position;
        LeanTween.scale(collidedCard.gameObject, Vector3.one * 12, .2f);

    }

}
