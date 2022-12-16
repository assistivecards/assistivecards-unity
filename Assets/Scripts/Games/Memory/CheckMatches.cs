using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatches : MonoBehaviour
{
    private LevelManager levelManager;
    private BoardGenerator boardGenerator;
    public List<GameObject> flippedCards = new List<GameObject>();
    public string firstCardName;
    private void Awake() 
    {
        boardGenerator = this.GetComponent<BoardGenerator>();
        levelManager = this.GetComponent<LevelManager>();
    }

    public void CheckMatche() 
    {
        if(flippedCards.Count == 2)
        {
            if(flippedCards[0].transform.GetChild(1).name == flippedCards[1].transform.GetChild(1).name)
            {
                Match();
            }
        }
    }

    public void Match()
    {
        foreach(GameObject card in flippedCards)
        {
            StartCoroutine(ScaleCardBigger(card));
            card.tag = "matched";
        }
        levelManager.levelFinisher();
    }

    IEnumerator ScaleCardBigger(GameObject _card)
    {
        LeanTween.scale(_card, Vector3.one * 3.5f, 0.3f);
        yield return  new WaitForSeconds(0.7f);
        ScaleCardSmaller(_card);
    }
    private void ScaleCardSmaller(GameObject _card)
    {
        LeanTween.scale(_card, Vector3.one * 0.001f, 0.25f);
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
