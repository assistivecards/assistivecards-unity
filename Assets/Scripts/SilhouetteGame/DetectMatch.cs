using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class DetectMatch : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] Transform shownImageSlot;
    private bool isMatched = false;
    [SerializeField] Board board;
    private GameAPI gameAPI;
    private Transform matchedImageTransform;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.GetComponent<Image>().sprite == other.gameObject.GetComponent<Image>().sprite)
        {
            matchedImageTransform = other.transform;
            isMatched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.GetComponent<Image>().sprite == other.gameObject.GetComponent<Image>().sprite)
        {
            isMatched = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMatched)
        {
            //correct match
            transform.position = matchedImageTransform.position;
            gameAPI.VibrateStrong();
            gameAPI.PlaySFX("Success");
            LeanTween.color(matchedImageTransform.gameObject.GetComponent<Image>().rectTransform, Color.white, .5f);
            // board.ClearBoard();
            // await board.GenerateRandomBoardAsync();
            board.Invoke("ClearBoard", .75f);
            board.Invoke("GenerateRandomBoardAsync", .75f);
            isMatched = false;
        }

        else
        {
            //wrong match
            gameAPI.VibrateWeak();
            transform.position = shownImageSlot.position;
        }
    }

}
