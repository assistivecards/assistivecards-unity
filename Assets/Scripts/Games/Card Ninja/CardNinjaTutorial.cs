using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardNinjaTutorial : MonoBehaviour
{
    [SerializeField] private CardNinjaBoardGenerator boardGenerator;
    [SerializeField] private Transform hand;
    [SerializeField] public Transform cardPosition;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;

    private void OnEnable() 
    {
        if(boardGenerator.randomCard != null)
        {
            cardPosition = boardGenerator.randomCard.transform;
        }
    }

    void Update()
    {
        if(point1 != null && point2 != null && cardPosition != null)
        {
            hand.transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
            this.transform.position = cardPosition.position;
        }
    }
}
