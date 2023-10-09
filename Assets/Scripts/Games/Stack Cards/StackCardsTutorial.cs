using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StackCardsTutorial : MonoBehaviour
{
    [SerializeField] private StackCardsBoardGenerator board;
    public Transform point1;
    public Transform point2;
    List<Image> activeCards = new List<Image>();
    [SerializeField] List<Image> fixedCards = new List<Image>();

    private void OnEnable()
    {
        activeCards = board.cardImagesInScene.Where(card => card.transform.parent.tag != "FixedCard").ToList();
        point1 = activeCards[0].transform;
        for (int i = 0; i < fixedCards.Count; i++)
        {
            if (activeCards[0].sprite == fixedCards[i].transform.GetChild(0).GetComponent<Image>().sprite)
            {
                point2 = fixedCards[i].transform;
            }
        }
    }

    void Update()
    {
        if (point1 != null && point2 != null)
        {
            transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time * 0.5f, 1));
        }
    }

}
