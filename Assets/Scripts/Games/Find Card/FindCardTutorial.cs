using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FindCardTutorial : MonoBehaviour
{
    [SerializeField] FindCardBoardGenerator board;
    [SerializeField] List<GameObject> correctCards = new List<GameObject>();
    [SerializeField] List<GameObject> activeCards = new List<GameObject>();

    private void OnEnable()
    {
        correctCards = board.cardParents.Where(card => card.tag == "CorrectCard").ToList();
        activeCards = correctCards.Where(card => card.GetComponent<FindCardFlipCard>().isFlipped == false).ToList();
        // gameObject.GetComponent<Tutorial>().tutorialPosition = activeCards[0].transform;
    }

    // private void Update()
    // {
    //     if(activeCards[0] != null)
    //     {
    //         transform.position = activeCards[0].transform.position;
    //     }
    // }
}
