using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInsideTutorial : MonoBehaviour
{
    public GameObject[] cards;
    [SerializeField] private Transform point1;
    [SerializeField] public Transform point2;

    private void OnEnable() 
    {
        DetectDestination();
    }


    public void DetectDestination()
    {
        cards = GameObject.FindGameObjectsWithTag("CorrectCard");

        if(point2.gameObject == cards[1])
        {
            point2 = cards[2].transform;
        }
        else if(point2.gameObject == cards[2])
        {
            point2 = cards[1].transform;
        }
        else
        {
            point2 = cards[2].transform;
        }
    }

    void Update()
    {
        transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
    }
}
