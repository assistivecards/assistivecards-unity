using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDrawLines : MonoBehaviour
{
    public Transform targetPosition;


    void Update()
    {
        transform.position = Vector3.Lerp(this.GetComponent<Tutorial>().tutorialPosition.position, targetPosition.position, Mathf.PingPong(Time.time / 2, 1));
    }
}
