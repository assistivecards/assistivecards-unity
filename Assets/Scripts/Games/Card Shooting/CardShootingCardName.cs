using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShootingCardName : MonoBehaviour
{
    public string cardName;


    public void DestroyCard()
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.5f, 0.25f).setOnComplete(ScaleDown);
    }

    private void ScaleDown()
    {
        LeanTween.scale(this.gameObject, Vector3.zero, 0.5f);
    }
}
