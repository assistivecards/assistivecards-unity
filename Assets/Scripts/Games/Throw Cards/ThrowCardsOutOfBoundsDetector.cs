using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowCardsOutOfBoundsDetector : MonoBehaviour
{
    [SerializeField]
    Transform cardSlot;
    Collider2D collidedCard;
    private ThrowCardsUIController UIController;
    [SerializeField] GameObject fixedCard;

    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        RectTransform rect = GetComponent<RectTransform>();
        collider.size = new Vector2(rect.rect.width, rect.rect.height);
        UIController = GameObject.Find("GamePanel").GetComponent<ThrowCardsUIController>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Out Of Bounds!!!");
        collidedCard = other;
        UIController.backButton.GetComponent<Button>().interactable = false;
        LeanTween.alpha(collidedCard.gameObject, 0, .2f);
        Invoke("ResetCardPosition", .25f);

    }

    void ResetCardPosition()
    {
        if (fixedCard.transform.localScale == Vector3.one)
        {
            Rigidbody2D rb = collidedCard.GetComponent<Rigidbody2D>();
            rb.simulated = false;
            rb.velocity = Vector2.zero;
            collidedCard.transform.localScale = Vector3.zero;
            LeanTween.alpha(collidedCard.gameObject, 1, .001f);
            collidedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
            collidedCard.transform.position = cardSlot.position;
            LeanTween.scale(collidedCard.gameObject, Vector3.one * 12, .2f);
            collidedCard.GetComponent<ThrowCardsThrowManager>().canThrow = true;
            UIController.backButton.GetComponent<Button>().interactable = true;
        }

    }

}
