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
    [SerializeField] private CardShootingUIController uıController;
    [SerializeField] private CardShootingBoardGenerator boardGenerator; 
    [SerializeField] private LineRenderer ballLineRenderer;
    private GameObject currentCard;
    private float dragDistance;
    public int hitCount;
    public int levelCount;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable() 
    {
        startPosition = this.transform.position;
    }

    public void OnMouseDown()
    {
        ballLineRenderer.enabled = true;
        CalculateThrowVector();
        SetArrow();
    }
    
    public void OnMouseDrag()
    {
        CalculateThrowVector();
        SetArrow();
    }

    public void OnMouseUp()
    {
        RemoveArrow();
        if(dragDistance >= 100.0155f)
        {
            Throw();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "card")
        {
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            currentCard = other.gameObject;
            gameAPI.Speak(other.GetComponent<CardShootingCardName>().cardName);
            Debug.Log("TTS: " + other.GetComponent<CardShootingCardName>().cardName);
            other.GetComponent<CardShootingCardName>().ScaleUp();

            if(other.gameObject.name == boardGenerator.selectedCard)
            {
                gameAPI.AddSessionExp();
                gameAPI.PlaySFX("Success");
                hitCount++;

                if(hitCount >= 2)
                {
                    levelCount++;
                    uıController.Invoke("LevelEnding", 0.5f);
                    gameAPI.PlaySFX("Finished");
                    boardGenerator.Invoke("LevelEndCardScale", 0.5f);

                    if(levelCount >= 3)
                    {
                        uıController.Invoke("LevelChangeScreenActivate", 2.5f);
                    }
                }
            }
            else if(other.gameObject.name != boardGenerator.selectedCard)
            {
                gameAPI.RemoveSessionExp();
            }
        }
    }


    private void CalculateThrowVector()
    {
        throwPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 distance =  throwPoint - this.transform.position;
        dragDistance = Vector3.Distance(throwPoint,this.transform.position);
        throwVector = -distance.normalized * 100;
    }

    private void SetArrow()
    {
        ballLineRenderer.positionCount = 2;
        ballLineRenderer.SetPosition(0, new Vector3(0, -1.9f, 2));
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
        Invoke("ResetPosition", 1.7f);
    }

    private void ResetPosition()
    {
        this.transform.position = startPosition;
        ballRigidbody.velocity = Vector3.zero;
    }
}
