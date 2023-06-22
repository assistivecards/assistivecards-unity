using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardShootingBallController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Vector3 throwVector;
    private Vector3 throwPoint;
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private LineRenderer ballLineRenderer;


    public void OnPointerDown(PointerEventData eventData)
    {
        CalculateTheowVector();
        SetArrow();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        CalculateTheowVector();
        SetArrow();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        RemoveArrow();
        Throw();
    }

    private void CalculateTheowVector()
    {
        throwPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 distance =  throwPoint - this.transform.position;
        throwVector = -distance.normalized * 100;
    }

    private void SetArrow()
    {
        ballLineRenderer.positionCount = 2;
        ballLineRenderer.SetPosition(0, new Vector3(0, -3, 2));
        ballLineRenderer.SetPosition(1, throwVector.normalized * 150);
        ballLineRenderer.enabled = true;
    }

    private void RemoveArrow()
    {
        ballLineRenderer.enabled = false;
    }

    private void Throw()
    {
        ballRigidbody.AddForce(throwVector * 150);
    }
}
