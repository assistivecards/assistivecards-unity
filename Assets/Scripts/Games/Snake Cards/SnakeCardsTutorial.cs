using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCardsTutorial : MonoBehaviour
{
    [SerializeField] private SnakeCardsBoardGenerator boardGenerator;
    [SerializeField] public Transform point1;
    [SerializeField] public Transform point2;

    void Update()
    {
        if(point1 != null && point2.childCount != 0)
        {
            transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
        }
        else if(point2.childCount == 0)
        {
            transform.position = new Vector3(-1000, -1000, 0);
        }
    }
}
