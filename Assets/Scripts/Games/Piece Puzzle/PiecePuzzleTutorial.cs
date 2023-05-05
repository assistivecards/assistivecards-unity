using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePuzzleTutorial : MonoBehaviour
{
    [SerializeField] public Transform point1;
    [SerializeField] public Transform point2;

    void Update()
    {
        if(point1 != null && point2 != null)
            transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time / 1.5f, 1));
    }
}
