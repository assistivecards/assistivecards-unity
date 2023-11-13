using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWordHunt : MonoBehaviour
{
    [SerializeField] public BoardGeneratorWordHunt boardGenerator;
    [SerializeField] public Transform point1;
    [SerializeField] public Transform point2;


    private void OnEnable() 
    {
        SetPosition();
    }

    private void SetPosition()
    {
        for(int i = 0; i < boardGenerator.tutorialPositions.Count; i++)
        {
            if(boardGenerator.tutorialPositions[i] != null)
            {
                point1 = boardGenerator.tutorialPositions[i].transform;
                point2 = boardGenerator.tutorialPositions[i + 1].transform;
                break;
            }
        }
    }

    void Update()
    {
        if(point1 != null && point2 != null)
        {
           transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
        }
    }
}
