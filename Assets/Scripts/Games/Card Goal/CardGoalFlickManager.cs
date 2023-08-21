using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardGoalFlickManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    Rigidbody2D rb;
    public bool canThrow = true;

    [Range(0.05f, 1f)]
    public float throwForce = 0.3f;
    public bool isValid;
    [SerializeField] CardGoalFlickManager[] allFlickManagers;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        allFlickManagers = GameObject.FindObjectsOfType<CardGoalFlickManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GoalPost")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        isValid = true;
        touchTimeStart = Time.time;
        startPos = Input.GetTouch(0).position;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (canThrow && isValid)
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            endPos = Input.GetTouch(0).position;

            direction = startPos - endPos;

            rb.isKinematic = false;
            rb.AddForce(-direction / timeInterval * throwForce);

            foreach (var item in allFlickManagers)
            {
                item.canThrow = false;
            }
            gameAPI.PlaySFX("Pickup");

            GetComponent<SpriteRenderer>().sortingOrder = 4;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
    }
}
