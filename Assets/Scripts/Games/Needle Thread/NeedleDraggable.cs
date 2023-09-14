using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleDraggable : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] NeedleMovement needleMovement;
    [SerializeField] private NeedleThreadBoardGenerator boardGenerator;
    public bool onTts;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.GetComponent<NeedleCardName>().cardName == boardGenerator.targetCard && needleMovement.dragging)
        {
            gameAPI.AddSessionExp();
            LeanTween.scale(other.gameObject, Vector3.one, 0.4f);
            other.GetComponent<NeedleCardName>().matched = true;
            other.GetComponent<NeedleCardName>().Invoke("ScaleDownCrad", 0.4f);
            boardGenerator.matchCounter++;
            boardGenerator.CheckTargetCards();
            onTts = true;
            if(boardGenerator.ttsCount <= 0)
            {
                gameAPI.Speak(other.GetComponent<NeedleCardName>().cardLocalName);
                Debug.Log(other.GetComponent<NeedleCardName>().cardLocalName);
                Invoke("PlaySuccess", 0.25f);
            }
        }
        else if(other.GetComponent<NeedleCardName>().cardName != boardGenerator.targetCard && needleMovement.dragging)
        {
            gameAPI.RemoveSessionExp();
        }
    }

    private void Update()
    {
        if(onTts)
        {
            if(boardGenerator.ttsCount <= 150)
            {
                boardGenerator.ttsCount++;
            }
            else if(boardGenerator.ttsCount > 150)
            {
                boardGenerator.ttsCount = 0;
                onTts = false;
            }
        }
    }

    private void PlaySuccess()
    {
        gameAPI.PlaySFX("Success");
    }

    public void MoveToCenter()
    {
        LeanTween.move(this.gameObject, Vector3.zero, 0.1f);
    }
}
