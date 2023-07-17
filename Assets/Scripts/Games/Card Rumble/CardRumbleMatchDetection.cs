using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardRumbleMatchDetection : MonoBehaviour, IPointerClickHandler
{
    private CardRumbleBoardGenerator board;

    void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<CardRumbleBoardGenerator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.GetChild(0).GetComponent<Image>().sprite.texture.name == board.correctCardTitle)
        {
            Debug.Log("CORRECT MATCH!");
            LeanTween.pause(gameObject);
            LeanTween.rotateZ(gameObject, 0, .25f);
            LeanTween.scale(gameObject, Vector3.one * 1.25f, .25f).setOnComplete(ScaleCardDown);
        }
        else
        {
            Debug.Log("WRONG MATCH!");
            LeanTween.scale(gameObject, Vector3.one * .85f, .15f).setOnComplete(ScaleBackToNormal);

        }
    }

    private void ScaleBackToNormal()
    {
        LeanTween.scale(gameObject, Vector3.one, .15f);
    }

    private void ScaleCardDown()
    {
        LeanTween.scale(gameObject, Vector3.zero, .25f);

    }
}
