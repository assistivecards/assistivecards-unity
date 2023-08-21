using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterFindTutorial : MonoBehaviour
{
    public GameObject trueLetterCard;
    public GameObject emptyLetter;

    void Update()
    {
        if(trueLetterCard != null && emptyLetter != null)
            transform.position = Vector3.Lerp(trueLetterCard.transform.position, emptyLetter.transform.position, Mathf.PingPong(Time.time, 1));
    }

}
