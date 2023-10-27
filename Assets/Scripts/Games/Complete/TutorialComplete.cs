using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialComplete : MonoBehaviour
{
    [SerializeField] private BoardGeneratorComplete boardGenerator;
    [SerializeField] private Transform position1;
    [SerializeField] private Transform position2;

    public void DetectDestination()
    {
        if(position1 != null)
        {
            foreach(GameObject card in boardGenerator.cards)
            {
                if(card.GetComponent<CardElementComplete>() != null)
                {
                    if(card.GetComponent<CardElementComplete>().cardType == position1.gameObject.GetComponentInChildren<CardElementComplete>().cardType)
                    {
                        position2 = card.transform;
                    }
                }
            }
        }
    }

    void Update()
    {
        if(position1 != null && position2 != null)
        {
            transform.position = Vector3.Lerp(position1.position, position2.position, Mathf.PingPong(Time.time / 2, 1));
        }
    }
}
