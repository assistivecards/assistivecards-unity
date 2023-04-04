using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour
{

    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    Rigidbody2D rb;
    bool canThrow = true;
    [SerializeField] Transform cardSlot;

    [Range(0.05f, 1f)]
    public float throwForce = 0.3f;
    bool isValid;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            var touchPosition = new Vector2(wp.x, wp.y);

            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition))
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

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && canThrow && isValid)
        {

            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;

            endPos = Input.GetTouch(0).position;
            direction = startPos - endPos;

            rb.isKinematic = false;
            rb.AddForce(-direction / timeInterval * throwForce);

            canThrow = false;

        }
    }
}
