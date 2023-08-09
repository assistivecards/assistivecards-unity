using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCardsCardController : MonoBehaviour
{
    public string cardName;
    public string cardLocalName;

    public void Eaten()
    {
        LeanTween.scale(this.gameObject, Vector3.zero, 0.5f).setOnComplete(DestroyCard);
    }

    private void DestroyCard()
    {
        Destroy(this.gameObject);
    }
}
