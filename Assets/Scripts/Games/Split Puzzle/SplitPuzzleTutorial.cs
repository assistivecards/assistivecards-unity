using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SplitPuzzleTutorial : MonoBehaviour
{
    [SerializeField] SplitPuzzleBoardGenerator board;
    List<GameObject> activePieces = new List<GameObject>();
    public Transform point1;
    public Transform point2;

    private void OnEnable()
    {
        activePieces = board.puzzlePieceParents.Where(card => card.GetComponent<SplitPuzzleMatchDetection>().isMatched == false).ToList();
        point1 = activePieces[0].transform;

        for (int i = 0; i < board.hintImagePieces.Count; i++)
        {
            if (activePieces[0].transform.GetChild(1).GetComponent<Image>().sprite == board.hintImagePieces[i].sprite)
            {
                point2 = board.hintImagePieces[i].transform;
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
