using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragInsideMatchDetection : MonoBehaviour
{
    [SerializeField] List<GameObject> cardsInside = new List<GameObject>();
    [SerializeField] List<GameObject> wrongCardsInside = new List<GameObject>();
    [SerializeField] List<GameObject> correctCardsInside = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        cardsInside.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        cardsInside.Remove(other.gameObject);
    }

    public void CheckCardsInside()
    {
        wrongCardsInside = cardsInside.Where(card => card.tag == "WrongCard").ToList();
        correctCardsInside = cardsInside.Where(card => card.tag == "CorrectCard").ToList();

        if (correctCardsInside.Count == 2 && wrongCardsInside.Count == 0)
        {
            Debug.Log("LEVEL COMPLETED");
        }

        else
        {
            Debug.Log("LEVEL NOT COMPLETED");
        }

    }
}
