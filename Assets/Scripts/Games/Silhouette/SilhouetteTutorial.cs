using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilhouetteTutorial : MonoBehaviour
{
    [SerializeField] public Transform point1;
    [SerializeField] public Transform point2;

    void Update()
    {
        transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
    }
}
