using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardControllerGridFind : MonoBehaviour, IPointerDownHandler
{
    public string cardName;
    public bool isCorrect;
    private BoardGeneratorGridFind boardGenerator;

    private void OnEnable() 
    {
        boardGenerator = GameObject.Find("GamePanel").GetComponent<BoardGeneratorGridFind>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CardClickAnimation();
    }

    private void CardClickAnimation()
    {
        GetComponentInChildren<RawImage>().color = Color.white;
        LeanTween.scale(this.gameObject, Vector3.one * 0.6f, 0.25f).setOnComplete(ScaleDownCard);
        if(isCorrect)
        {
            boardGenerator.score++;
            boardGenerator.UpdateScore();
        }
    }

    private void ScaleDownCard()
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.45f, 0.5f);
    }
}
