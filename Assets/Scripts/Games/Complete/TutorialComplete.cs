using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialComplete : MonoBehaviour
{
    [SerializeField] private BoardCreatorComplete boardCreatorComplete;
    [SerializeField] private Transform position1;
    [SerializeField] private Transform position2;

    public void DetectDestination()
    {
        foreach(GameObject card in boardCreatorComplete.cards)
        {
            if(card.GetComponent<CardElementComplete>().cardType == position1.gameObject.GetComponentInChildren<CardElementComplete>().cardType)
            {
                position2 = card.transform;
            }
        }
    }

    void Update()
    {
        transform.position = Vector3.Lerp(position1.position, position2.position, Mathf.PingPong(Time.time / 2, 1));
    }
}
