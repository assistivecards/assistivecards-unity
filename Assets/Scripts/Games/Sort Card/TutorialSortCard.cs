using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSortCard : MonoBehaviour
{
    [SerializeField] public Transform point1;
    [SerializeField] public Transform point2;

    void Update()
    {
        if(point1 != null && point2 != null)
            transform.position = Vector3.Lerp(new Vector3(point1.position.x, 500f, 0), point2.position, Mathf.PingPong(Time.time / 1.5f, 1));
    }
}
