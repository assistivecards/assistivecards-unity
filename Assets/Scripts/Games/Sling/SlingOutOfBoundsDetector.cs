using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlingOutOfBoundsDetector : MonoBehaviour
{
    [SerializeField]
    Transform cardSlot;
    Collider2D collidedCard;
    SlingUIController UIController;
    [SerializeField]
    Transform box;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        RectTransform rect = GetComponent<RectTransform>();
        collider.size = new Vector2(rect.rect.width, rect.rect.height);
        UIController = GameObject.Find("GamePanel").GetComponent<SlingUIController>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Out Of Bounds!!!");
        gameAPI.RemoveSessionExp();
        collidedCard = other;
        UIController.backButton.GetComponent<Button>().interactable = false;
        LeanTween.alpha(collidedCard.gameObject, 0, .2f);
        Invoke("ResetCardPosition", .25f);

    }

    void ResetCardPosition()
    {
        if (box.localScale == Vector3.one)
        {
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
            UIController.backButton.GetComponent<Button>().interactable = true;
        }

    }

}
