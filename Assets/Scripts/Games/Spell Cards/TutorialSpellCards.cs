using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpellCards : MonoBehaviour
{
    [SerializeField] public BoardGeneratorSpellCards boardGenerator;
    public Transform point1;
    public Transform point2;

    private void OnEnable()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        foreach(var dashedSquare in boardGenerator.dashedSquares)
        {
            if(dashedSquare.GetComponent<CorrectLetterHolderSpellCards>().isEmpty)
            {
                point1 = dashedSquare.transform;
                break;
            }
        }
        foreach(var letterCard in boardGenerator.letterCards)
        {
            if(!letterCard.GetComponent<CardControllerSpellCards>().matched)
            {
                point2 = letterCard.transform;
                break;
            }
        }
    }

    void Update()
    {
        if(point1 != null && point2 != null)
        {
           transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
        }
    }
}
