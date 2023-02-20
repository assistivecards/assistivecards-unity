using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EggController : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private Sprite eggPhase1;
    [SerializeField] private Sprite eggPhase2;
    [SerializeField] private Sprite eggPhase3;
    [SerializeField] private Sprite eggPhase4;

    public int clickCount;

    public void OnPointerUp(PointerEventData eventData)
    {
        clickCount++;
    }
}
