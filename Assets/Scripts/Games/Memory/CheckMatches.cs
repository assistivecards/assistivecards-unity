using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatches : MonoBehaviour
{
    GameAPI gameAPI;
    private LevelManager levelManager;
    private BoardGenerator boardGenerator;
    public List<GameObject> flippedCards = new List<GameObject>();
    public string firstCardName;
    //public int score;
    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        boardGenerator = this.GetComponent<BoardGenerator>();
        levelManager = this.GetComponent<LevelManager>();

        PlayerPrefs.HasKey("MemoryGameScore");
        //score = PlayerPrefs.GetInt("MemoryGameScore");
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
            card.tag = "MatchedCard";
            //score += 1;
            //PlayerPrefs.SetInt("MemoryGameScore", score);
        }
        levelManager.levelFinisher();
    }

    IEnumerator ScaleCardBigger(GameObject _card)
    {
        LeanTween.scale(_card, Vector3.one * 1.25f, 0.3f);
        gameAPI.VibrateStrong();
        gameAPI.PlaySFX("Success");
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
