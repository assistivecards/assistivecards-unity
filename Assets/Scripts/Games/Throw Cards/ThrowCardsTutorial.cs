using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCardsTutorial : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;

    // Update is called once per frame
    void Update()
    {
        if (startPos != null && endPos != null)
        {
            transform.position = Vector3.Lerp(startPos.position, endPos.position, Mathf.PingPong(Time.time, 1));
        }
    }
}
