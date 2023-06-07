using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardWhackScoreManager : MonoBehaviour
{
    public int score;
    [SerializeField] TMP_Text scoreText;
    public bool isLevelComplete;
    [SerializeField] CardWhackCardSpawner cardSpawner;


    void Update()
    {
        if (score >= 100)
        {
            score = 100;

            if (!isLevelComplete)
            {
                isLevelComplete = true;
                Debug.Log("LEVEL COMPLETED");
                cardSpawner.CancelInvoke("SpawnCard");
            }
        }

        else if (score <= 0)
        {
            score = 0;
        }

        scoreText.text = score.ToString();

    }

    public void InreaseScore()
    {
        score = score + 10;
        LeanTween.scale(scoreText.transform.parent.parent.gameObject, Vector3.one * 1.15f, .25f).setOnComplete(ScaleScoreTextDown);
    }

    public void DecreaseScore()
    {
        score = score - 5;
        LeanTween.scale(scoreText.transform.parent.parent.gameObject, Vector3.one * 1.15f, .25f).setOnComplete(ScaleScoreTextDown);
    }

    private void ScaleScoreTextDown()
    {
        LeanTween.scale(scoreText.transform.parent.parent.gameObject, Vector3.one, .25f);
    }
}
