using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DragInsideTutorial : MonoBehaviour
{
    [SerializeField] DragInsideBoardGenerator board;
    [SerializeField] List<GameObject> correctCards = new List<GameObject>();
    List<GameObject> activeCards = new List<GameObject>();
    public Transform point1;
    public Transform point2;

    private void OnEnable()
    {
        correctCards = board.cardParents.Where(card => card.tag == "CorrectCard").ToList();
        activeCards = correctCards.Where(card => card.GetComponent<DragInsideDraggableCard>().isAdded == false).ToList();
        point1 = activeCards[0].transform;

    }

    void Update()
    {
        if (point1 != null && point2 != null)
        {
            this.transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
        }
    }

}
