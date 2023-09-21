using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{

    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    Rigidbody2D rb;
    public bool canThrow = true;

    // [Range(0.05f, 1f)]
    // public float throwForce = 0.3f;
    public bool isValid;
    private PositionQueue pastPositions;
    Vector3 newPosition;
    public float speedMultiplier;
    public bool isBeingDragged;
    private GameAPI gameAPI;
    public bool isGrabbed;

    void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        pastPositions = new PositionQueue(5);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Debug.Log("Began");
                pastPositions.Clear();
                var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                var touchPosition = new Vector2(wp.x, wp.y);

                // if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition))
                if (GetComponent<Collider2D>().OverlapPoint(touchPosition))
                {
                    isValid = true;
                    touchTimeStart = Time.time;
                    startPos = Input.GetTouch(0).position;
                }

                else
                {
                    Debug.Log("MISS");
                }

            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved && canThrow && isValid)
            {
                // Debug.Log("Moved");

                if (!isGrabbed)
                {
                    gameAPI.PlaySFX("Pickup");
                    isGrabbed = true;
                }
                isBeingDragged = true;
                var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                newPosition = new Vector3(wp.x, wp.y, transform.position.z);

                pastPositions.Enqueue(newPosition);
                transform.position = newPosition;

                // Debug.Log(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended && canThrow && isValid)
            {
                // Debug.Log("Ended");
                isBeingDragged = false;

                // touchTimeFinish = Time.time;
                // timeInterval = touchTimeFinish - touchTimeStart;

                // endPos = Input.GetTouch(0).position;
                // direction = startPos - endPos;

                rb.isKinematic = false;
                // rb.AddForce(-direction / timeInterval * throwForce);
                if (pastPositions.Count != 0)
                {
                    var velocity = (newPosition - pastPositions.Peek()) / pastPositions.Count;
                    transform.GetComponent<Rigidbody2D>().velocity = velocity * speedMultiplier;

                }

                canThrow = false;
                isGrabbed = false;
            }

        }
    }
}

class PositionQueue
{
    private Queue<Vector3> _queue;
    private int _maxSize;
    public int Count
    {
        get
        {
            return _queue.Count;
        }
    }
    public PositionQueue(int maxSize)
    {
        _maxSize = maxSize;
        _queue = new Queue<Vector3>();
    }
    public void Enqueue(Vector3 v)
    {
        if (_queue.Count >= _maxSize)
        {
            _queue.Dequeue();
        }
        _queue.Enqueue(v);
    }
    public Vector3 Peek()
    {
        return _queue.Peek();
    }
    public void Clear()
    {
        _queue.Clear();
    }
}
