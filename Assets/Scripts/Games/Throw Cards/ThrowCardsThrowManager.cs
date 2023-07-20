using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCardsThrowManager : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private Rigidbody2D rb;
    private Vector3 forceAtPlayer;
    public float forceFactor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = gameObject.transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            gameObject.transform.position = endPos;
            forceAtPlayer = endPos - startPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.simulated = true;
            rb.gravityScale = 1;
            rb.velocity = new Vector2(-forceAtPlayer.x * forceFactor, -forceAtPlayer.y * forceFactor);
        }
    }

    private Vector2 calculatePosition(float elapsedTime)
    {
        return new Vector2(endPos.x, endPos.y) +
                new Vector2(-forceAtPlayer.x * forceFactor, -forceAtPlayer.y * forceFactor) * elapsedTime +
                0.5f * Physics2D.gravity * elapsedTime * elapsedTime;
    }
}
