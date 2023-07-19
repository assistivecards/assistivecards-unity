using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardRumbleTutorial : MonoBehaviour
{
    [SerializeField] CardRumbleBoardGenerator board;
    [SerializeField] List<GameObject> correctCards = new List<GameObject>();
    [SerializeField] List<GameObject> activeCards = new List<GameObject>();

    private void OnEnable()
    {
        correctCards = board.cardParents.Where(cardParent => cardParent.transform.GetChild(0).GetComponent<Image>().sprite.texture.name == board.correctCardTitle).ToList();
        activeCards = correctCards.Where(card => card.GetComponent<CardRumbleMatchDetection>().isClicked == false).ToList();
    }

    private void Update()
    {
        transform.position = activeCards[0].transform.position;
    }

}
