using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EggController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite eggPhase1;
    [SerializeField] private Sprite eggPhase2;
    [SerializeField] private Sprite eggPhase3;
    [SerializeField] private Sprite eggPhase4;

    private Sprite eggPhaseImage;

    public int clickCount;
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        clickCount ++;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
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
        else if(clickCount >= 4)
        {
            GetComponent<Image>().sprite = eggPhase4;
        }
    }
}
