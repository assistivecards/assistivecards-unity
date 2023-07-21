using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowCardsThrowManager : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector3 startPos;
    private Vector3 endPos;
    private Rigidbody2D rb;
    private Vector3 forceAtCard;
    public float forceFactor;
    public GameObject trajectoryDotPrefab;
    private GameObject[] trajectoryDots;
    public int numOfDots;
    [SerializeField] GameObject clampBox;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trajectoryDots = new GameObject[numOfDots];
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = gameObject.transform.position;

        for (int i = 0; i < numOfDots; i++)
        {
            trajectoryDots[i] = Instantiate(trajectoryDotPrefab, gameObject.transform);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        var bounds = clampBox.GetComponent<BoxCollider2D>().bounds;

        endPos = new Vector3(Mathf.Clamp(Camera.main.ScreenToWorldPoint(eventData.position).x, bounds.min.x, bounds.max.x), Mathf.Clamp(Camera.main.ScreenToWorldPoint(eventData.position).y, bounds.min.y, bounds.max.y)) + new Vector3(0, 0, 10);

        transform.position = endPos;
        forceAtCard = endPos - startPos;

        for (int i = 0; i < numOfDots; i++)
        {
            trajectoryDots[i].transform.position = CalculatePosition(i * 0.1f);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rb.simulated = true;
        rb.gravityScale = 1;
        rb.velocity = new Vector2(-forceAtCard.x * forceFactor, -forceAtCard.y * forceFactor);

        for (int i = 0; i < numOfDots; i++)
        {
            Destroy(trajectoryDots[i]);
        }
    }
    private Vector2 CalculatePosition(float elapsedTime)
    {
        return new Vector2(endPos.x, endPos.y) +
                new Vector2(-forceAtCard.x * forceFactor, -forceAtCard.y * forceFactor) * elapsedTime +
                0.5f * Physics2D.gravity * elapsedTime * elapsedTime;
    }
}
