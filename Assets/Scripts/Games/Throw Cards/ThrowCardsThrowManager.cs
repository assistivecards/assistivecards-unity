using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCardsThrowManager : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private Rigidbody2D rb;
    private Vector3 forceAtCard;
    public float forceFactor;
    public GameObject trajectoryDotPrefab;
    private GameObject[] trajectoryDots;
    public int numOfDots;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trajectoryDots = new GameObject[numOfDots];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = gameObject.transform.position;

            for (int i = 0; i < numOfDots; i++)
            {
                trajectoryDots[i] = Instantiate(trajectoryDotPrefab, gameObject.transform);
            }
        }

        if (Input.GetMouseButton(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            gameObject.transform.position = endPos;
            forceAtCard = endPos - startPos;

            for (int i = 0; i < numOfDots; i++)
            {
                trajectoryDots[i].transform.position = CalculatePosition(i * 0.1f);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.simulated = true;
            rb.gravityScale = 1;
            rb.velocity = new Vector2(-forceAtCard.x * forceFactor, -forceAtCard.y * forceFactor);

            for (int i = 0; i < numOfDots; i++)
            {
                Destroy(trajectoryDots[i]);
            }
        }
    }

    private Vector2 CalculatePosition(float elapsedTime)
    {
        return new Vector2(endPos.x, endPos.y) +
                new Vector2(-forceAtCard.x * forceFactor, -forceAtCard.y * forceFactor) * elapsedTime +
                0.5f * Physics2D.gravity * elapsedTime * elapsedTime;
    }
}
