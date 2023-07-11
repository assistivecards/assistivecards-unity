using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTutorial : MonoBehaviour
{
    [SerializeField] private MatchBoardGenerator boardGenerator;
    public int tutorialEnabledCount = 0; 
    public Transform point1;
    public Transform point2;

    private void OnEnable() 
    {
        if(!boardGenerator.cards[tutorialEnabledCount].GetComponent<MatchCardElement>().match && tutorialEnabledCount < 3)
        {
            point1 = boardGenerator.cards[tutorialEnabledCount].transform;
            point2 = boardGenerator.cards[tutorialEnabledCount + 3].transform;
        }
        else if(tutorialEnabledCount < 3)
        {
            tutorialEnabledCount ++;
        }
        else if(tutorialEnabledCount >= 3)
        {
            tutorialEnabledCount = 0;
        }
    }

    void Update()
    {
        if(point1 != null && point2 != null)
        {
            this.transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
        }
    }

    private void OnDisable() 
    {
        if(tutorialEnabledCount > 3)
        {
            tutorialEnabledCount = 0;
        }
        else
        {
            tutorialEnabledCount ++;
        }
    }
}
