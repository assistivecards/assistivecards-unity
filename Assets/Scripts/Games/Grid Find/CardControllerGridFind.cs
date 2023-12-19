using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardControllerGridFind : MonoBehaviour, IPointerDownHandler
{
    public string cardName;
    public bool isCorrect;
    public bool isExampleCard;
    private Color shadowColor;
    private BoardGeneratorGridFind boardGenerator;

    private void OnEnable() 
    {
        boardGenerator = GameObject.Find("GamePanel").GetComponent<BoardGeneratorGridFind>();
        shadowColor = transform.GetChild(0).GetComponent<RawImage>().color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isExampleCard)
        {
            CardClickAnimation();
        }
    }

    private void CardClickAnimation()
    {
        GetComponentInChildren<RawImage>().color = Color.white;
        LeanTween.scale(this.gameObject, Vector3.one * 0.6f, 0.25f).setOnComplete(ScaleDownCard);
        Invoke("SpeakCardName", 0.2f);
        if(isCorrect)
        {
            boardGenerator.score++;
            boardGenerator.UpdateScore();
            boardGenerator.gameAPI.PlaySFX("Success");
            boardGenerator.gameAPI.PlayConfettiParticle(this.transform.position);
        }
        else
        {
            boardGenerator.gameAPI.RemoveSessionExp();
            Invoke("ReturnShadowColor", 0.6f);
        }
    }

    private void ReturnShadowColor()
    {
        transform.GetChild(0).GetComponent<RawImage>().color = shadowColor;
    }

    private void SpeakCardName()
    {
        boardGenerator.gameAPI.Speak(cardName);
        Debug.Log(cardName);
    }

    private void ScaleDownCard()
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.45f, 0.5f);
    }
}