using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EggController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private BoardCreatorHatchMatch boardCreatorHatchMatch;

    [SerializeField] private Sprite eggPhase1;
    [SerializeField] private Sprite eggPhase2;
    [SerializeField] private Sprite eggPhase3;
    [SerializeField] private Sprite eggPhase4;
    private GameObject card;

    private Sprite eggPhaseImage;

    public int clickCount;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if(boardCreatorHatchMatch.boardCreated)
        {
            clickCount ++;
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if(boardCreatorHatchMatch.boardCreated)
        {
            card = FindObjectOfType<CardElementHatchMatch>().gameObject;

            if(clickCount >= 1 && clickCount < 2)
            {
                GetComponent<Image>().sprite = eggPhase1;
            }
            else if(clickCount >= 2 && clickCount < 3)
            {
                GetComponent<Image>().sprite = eggPhase2;
            }
            else if(clickCount >= 3 && clickCount < 4)
            {
                GetComponent<Image>().sprite = eggPhase3;
            }
            else if(clickCount >= 4 && clickCount < 5)
            {
                GetComponent<Image>().sprite = eggPhase4;
            }
            else if(clickCount >= 5)
            {
                LeanTween.scale(this.gameObject, Vector3.zero, 0.1f);
                LeanTween.scale(card, Vector3.one * 0.5f, 0.1f);
            }
        }
    }
}
