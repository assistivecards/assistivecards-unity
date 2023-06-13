using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindCardMatchDetection : MonoBehaviour
{
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void CheckCard(Transform flippedCard)
    {
        if (flippedCard.tag == "CorrectCard")
        {
            Debug.Log("CORRECT CARD");
        }

        else if (flippedCard.tag == "WrongCard")
        {
            Debug.Log("WRONG CARD");
            LeanTween.rotateY(flippedCard.gameObject, 0, .75f);
            gameAPI.PlaySFX("FlipCardBack");
        }

    }
}
