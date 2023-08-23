using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternTrainTutorial : MonoBehaviour
{
    [SerializeField] public Transform point1;
    [SerializeField] public Transform trueCard;

    void Update()
    {
        if(point1 != null && trueCard != null)
            transform.position = Vector3.Lerp(point1.position, trueCard.position, Mathf.PingPong(Time.time, 1));
    }
}
