using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatches : MonoBehaviour
{
    private BoardGenerator boardGenerator;
    public List<GameObject> flippedCards = new List<GameObject>();

    private void Awake() 
    {
        boardGenerator = this.GetComponent<BoardGenerator>();
    }

    public void CheckAllBoardFlip()
    {
        foreach(GameObject card in flippedCards)
        {
            card.GetComponent<FlipCard>().StartBackFlip();
        }
        flippedCards.Clear();
    }
}
