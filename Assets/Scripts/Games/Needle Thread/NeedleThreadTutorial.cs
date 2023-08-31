using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleThreadTutorial : MonoBehaviour
{
    [SerializeField] private NeedleThreadBoardGenerator boardGenerator;
    [SerializeField] public Transform needle;
    [SerializeField] public Transform card;

    void Update()
    {
        if(needle != null && card != null)
        {
            transform.position = Vector3.Lerp(needle.position, card.position, Mathf.PingPong(Time.time, 1));
        }
    }
}
