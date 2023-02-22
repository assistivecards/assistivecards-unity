using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawLinesMatchDetection : MonoBehaviour
{
    public bool isMatched = false;
    [SerializeField] Image cardToBeMatched;
    private GameObject matchedOption;

    private void OnTriggerEnter2D(Collider2D other)
    {
        matchedOption = other.gameObject;
        if (other.tag == "Option" && other.GetComponent<Image>().sprite == cardToBeMatched.sprite)
        {
            isMatched = true;
            Debug.Log("Correct Match!");
            gameObject.GetComponent<DragHandle>().enabled = false;
            LeanTween.scale(gameObject, Vector3.zero, .25f);
            Invoke("DisableCurrentHandle", 0.25f);
            LeanTween.scale(matchedOption, Vector3.one * 1.25f, .25f);
        }
        else
        {
            isMatched = false;
            Debug.Log("Wrong Match!");
            gameObject.GetComponent<DragHandle>().enabled = false;
            LeanTween.scale(gameObject, Vector3.zero, .25f);
            Invoke("DisableCurrentHandle", 0.25f);
            LeanTween.alpha(matchedOption.GetComponent<RectTransform>(), .5f, .25f);
        }

    }

    public void DisableCurrentHandle()
    {
        gameObject.SetActive(false);
    }

}
