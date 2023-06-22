using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardShootingBallController : MonoBehaviour
{
    GameAPI gameAPI;
    public Vector3 throwVector;
    private Vector3 throwPoint;
    private Vector3 startPosition;
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private LineRenderer ballLineRenderer;
    private CardShootingBoardGenerator boardGenerator; 
    private GameObject currentCard;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable() 
    {
        startPosition = this.transform.position;
        boardGenerator = FindObjectOfType<CardShootingBoardGenerator>();
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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "card")
        {
            gameAPI.Speak(other.GetComponent<CardShootingCardName>().cardName);
            Debug.Log("TTS: " + other.GetComponent<CardShootingCardName>().cardName);

            LeanTween.scale(other.gameObject, Vector3.one * 0.5f, 0.25f).setOnComplete(ScaleDown);
            currentCard = other.gameObject;

            if(other.gameObject.name == boardGenerator.selectedCard)
            {
                gameAPI.PlaySFX("Success");
                Debug.Log("SUCCESS");
            }
        }
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

    private void ScaleDown()
    {
        LeanTween.scale(currentCard.gameObject, Vector3.zero, 0.5f);
    }
}
