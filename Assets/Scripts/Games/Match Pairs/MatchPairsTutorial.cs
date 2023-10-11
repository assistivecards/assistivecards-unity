using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MatchPairsTutorial : MonoBehaviour
{
    [SerializeField] MatchPairsBoardGenerator board;
    List<GameObject> activeCards = new List<GameObject>();
    public Transform point1;
    public Transform point2;

    private void OnEnable()
    {
        activeCards = board.puzzlePieceParents.Where(card => card.GetComponent<MatchPairsMatchDetection>().isMatched == false).ToList();
        point1 = activeCards[0].transform;

        for (int i = 0; i < activeCards.Count; i++)
        {
            if (activeCards[i].transform.GetChild(1).name.Substring(0, activeCards[i].transform.GetChild(1).name.Length - 1) == activeCards[0].transform.GetChild(1).name.Substring(0, activeCards[0].transform.GetChild(1).name.Length - 1))
            {
                point2 = activeCards[i].transform;
            }
        }

    }

    void Update()
    {
        if (point1 != null && point2 != null)
        {
            this.transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
        }
    }

}
