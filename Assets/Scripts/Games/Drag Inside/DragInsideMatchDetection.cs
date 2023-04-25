using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DragInsideMatchDetection : MonoBehaviour
{
    [SerializeField] List<GameObject> cardsInside = new List<GameObject>();
    [SerializeField] List<GameObject> wrongCardsInside = new List<GameObject>();
    [SerializeField] List<GameObject> correctCardsInside = new List<GameObject>();
    Color green;
    Color red;
    Color original;

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#1B9738", out green);
        ColorUtility.TryParseHtmlString("#972F1B", out red);
        ColorUtility.TryParseHtmlString("#3E455B", out original);
    }

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
            LeanTween.color(GetComponent<Image>().rectTransform, green, .2f);
        }

        else if (cardsInside.Count >= 2 && wrongCardsInside.Count != 0)
        {
            Debug.Log("LEVEL NOT COMPLETED");
            LeanTween.color(GetComponent<Image>().rectTransform, red, .2f);
        }

        else
        {
            LeanTween.color(GetComponent<Image>().rectTransform, original, .2f);
        }

    }
}
