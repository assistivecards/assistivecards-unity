using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetOrderTutorial : MonoBehaviour
{
    [SerializeField] AlphabetOrderBoardGenerator board;
    public int count = 0;
    public Transform point1;
    public Transform point2;

    private void OnEnable()
    {
        if (count < 3 && !board.cardParents[count].GetComponent<AlphabetOrderMatchDetection>().isMatched)
        {
            point1 = board.cardParents[count].transform;
            for (int i = 0; i < board.slots.Length; i++)
            {
                if (board.slots[i].name == board.cardParents[count].transform.GetChild(0).GetComponent<Image>().sprite.texture.name)
                {
                    point2 = board.slots[i].transform;
                }
            }

        }
        else if (count < 3)
        {
            count++;
        }
        else if (count >= 3)
        {
            count = 0;
        }
    }

    void Update()
    {
        if (point1 != null && point2 != null)
        {
            this.transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time, 1));
        }
    }

    private void OnDisable()
    {
        if (count >= 3)
        {
            count = 0;
        }
        else
        {
            count++;
        }
    }
}
