using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatches : MonoBehaviour
{
    private BoardGenerator boardGenerator;
    public List<GameObject> flippedCards = new List<GameObject>();
    public string firstCardName;
    private void Awake() 
    {
        boardGenerator = this.GetComponent<BoardGenerator>();
    }

    private void Update() 
    {
        if(flippedCards[0].transform.GetChild(1).name == flippedCards[1].transform.GetChild(1).name)
        {
            Matche();
        }
    }

    public void Matche()
    {
        foreach(GameObject card in flippedCards)
        {
            LeanTween.scale(card, Vector3.one * 0.001f, 0.25f);
            card.tag = "Untagged";
        }
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
