using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardShootingBallController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Vector3 throwVector;
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private LineRenderer ballLineRenderer;
    private Vector3 throwPoint;


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
        ballLineRenderer.SetPosition(0, Vector3.zero);
        ballLineRenderer.SetPosition(1, throwVector.normalized/2);
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
