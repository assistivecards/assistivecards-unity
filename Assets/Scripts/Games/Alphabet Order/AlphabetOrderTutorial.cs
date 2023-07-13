using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AlphabetOrderTutorial : MonoBehaviour
{
    [SerializeField] AlphabetOrderBoardGenerator board;
    public Transform point1;
    public Transform point2;

    private void OnEnable()
    {
        var unmatchedCards = board.cardParents.Where(card => !card.GetComponent<AlphabetOrderMatchDetection>().isMatched).ToList();
        point1 = unmatchedCards[0].transform;
        for (int i = 0; i < board.slots.Length; i++)
        {
            if (board.slots[i].name == unmatchedCards[0].transform.GetChild(0).GetComponent<Image>().sprite.texture.name)
            {
                point2 = board.slots[i].transform;
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
