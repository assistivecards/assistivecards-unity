using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardShootingBallController : MonoBehaviour
{
    public Vector3 throwVector;
    private Vector3 throwPoint;
    private Vector3 startPosition;
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private LineRenderer ballLineRenderer;

    private void OnEnable() 
    {
        startPosition = this.transform.position;
    }

    public void OnMouseDown()
    {
        CalculateTheowVector();
        SetArrow();
    }
    
    public void OnMouseDrag()
    {
        CalculateTheowVector();
        SetArrow();
    }

    public void OnMouseUp()
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
        ballLineRenderer.SetPosition(0, new Vector3(0, -2.65f, 2));
        ballLineRenderer.SetPosition(1, throwPoint);
        ballLineRenderer.enabled = true;
    }

    private void RemoveArrow()
    {
        ballLineRenderer.enabled = false;
    }

    private void Throw()
    {
        ballRigidbody.AddForce(throwVector * 140);
        Invoke("ResetPosition", 1.8f);
    }

    private void ResetPosition()
    {
        this.transform.position = startPosition;
        ballRigidbody.velocity = Vector3.zero;
    }
}
