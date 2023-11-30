using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardControllerGridFind : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        CardClickAnimation();
    }

    private void CardClickAnimation()
    {
        GetComponentInChildren<RawImage>().color = Color.white;
        LeanTween.scale(this.gameObject, Vector3.one * 0.6f, 0.25f).setOnComplete(ScaleDownCard);
    }

    private void ScaleDownCard()
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.45f, 0.5f);
    }
}
