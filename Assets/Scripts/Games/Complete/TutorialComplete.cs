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
        TutorialLoopPosition1();
    }

    public void TutorialLoopPosition()
    {
        LeanTween.move(this.gameObject, position1.position, 0f);
        TutorialLoopPosition1();
    }

    public void TutorialLoopPosition1()
    {
        LeanTween.move(this.gameObject, position2.position ,2f);
        Invoke("TutorialLoopPosition", 2f);
    }

}
