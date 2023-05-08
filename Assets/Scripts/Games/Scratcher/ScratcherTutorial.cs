using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratcherTutorial : MonoBehaviour
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;

    void Update()
    {
        transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
    }
}
