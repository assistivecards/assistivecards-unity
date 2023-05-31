using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMatchPairs : MonoBehaviour
{
    [SerializeField] public MatchPairsBoardGenerator matchPairsBoardGenerator;
    [SerializeField] public Transform point1;
    [SerializeField] public Transform point2;

    private void OnEnable() 
    {
        matchPairsBoardGenerator.FindMatchForTutorial();
    }

    void Update()
    {
        if(point1 != null && point2 != null)
            transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
    }
}
