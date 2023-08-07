using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardWhackDetectWhack : MonoBehaviour, IPointerClickHandler
{
    private CardWhackBoardGenerator board;
    private CardWhackScoreManager scoreManager;
    private bool isClicked = false;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<CardWhackBoardGenerator>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<CardWhackScoreManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.GetChild(0).GetComponent<Image>().sprite == board.randomSprites[0] && !isClicked)
        {
            Debug.Log("CORRECT CARD");
            gameAPI.AddSessionExp();
            isClicked = true;
            scoreManager.InreaseScore();
            ReadCard();
            gameAPI.PlaySFX("Success");
        }

        else if (transform.GetChild(0).GetComponent<Image>().sprite != board.randomSprites[0] && !isClicked)
        {
            Debug.Log("WRONG CARD");
            gameAPI.RemoveSessionExp();
            isClicked = true;
            scoreManager.DecreaseScore();
            gameAPI.PlaySFX("Pickup");
        }

        FadeCard();
    }

    private void FadeCard()
    {
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 0, .25f).setDestroyOnComplete(true);
    }

    public void ReadCard()
    {
        gameAPI.Speak(transform.GetChild(0).GetComponent<Image>().sprite.name);
    }

}
