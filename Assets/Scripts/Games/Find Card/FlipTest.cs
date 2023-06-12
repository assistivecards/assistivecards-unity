using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlipTest : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        LeanTween.rotateY(gameObject, -180, .75f);
    }

    public void FlipBack()
    {
        LeanTween.rotateY(gameObject, 0, .75f);
    }

}
