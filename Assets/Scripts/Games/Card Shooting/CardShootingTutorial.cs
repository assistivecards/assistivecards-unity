using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShootingTutorial : MonoBehaviour
{
    [SerializeField] private Transform hand;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;


    void Update()
    {
        if(point1 != null && point2 != null)
        {
            hand.transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
        }
    }
}
