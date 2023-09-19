using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EggController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private BoardCreatorHatchMatch boardCreatorHatchMatch;

    private AnimationPhase1Events animationPhase1Events;
    private Sprite eggPhaseImage;
    private GameObject card;

    private Animator animator;

    public int clickCount;
    public Color[] colors;
    public bool isCracked;

    private void OnEnable() 
    {
        this.GetComponent<Image>().color = colors[Random.Range(0, colors.Length)];
        animator = GetComponent<Animator>();
        animationPhase1Events = animator.GetBehaviour<AnimationPhase1Events >();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if(boardCreatorHatchMatch.boardCreated)
        {
            IncreaseClickCount();
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if(boardCreatorHatchMatch.boardCreated)
        {
            card = FindObjectOfType<CardElementHatchMatch>().gameObject;
            ChangeAnim();
        }
    }

    private void IncreaseClickCount()
    {
        clickCount ++;
    }

    private void ChangeAnim()
    {
        if(clickCount == 0)
        {
            gameObject.GetComponent<Animator>().Play("Idle", -1, 0f);
        }
        else if(clickCount > 0 && clickCount <= 1)
        {
            gameObject.GetComponent<Animator>().Play("Phase1", -1, 0f);
        }
        else if(clickCount > 1 && clickCount <= 2)
        {
            gameObject.GetComponent<Animator>().Play("Phase2", -1, 0f);
        }
        else if(clickCount > 2 && clickCount <= 3)
        {
            gameObject.GetComponent<Animator>().Play("Phase3", -1, 0f);
        }
        else if(clickCount > 3 && clickCount <= 4)
        {
            gameObject.GetComponent<Animator>().Play("Phase4", -1, 0f);
        }
        else if(clickCount >= 4 && clickCount <= 5)
        {
            gameObject.GetComponent<Animator>().Play("Phase5", -1, 0f);
            Invoke("ActivateCard", 0.25f);
            isCracked = true;
        }
    }

    private void ActivateCard()
    {
        LeanTween.scale(this.gameObject, Vector3.zero, 0.5f).setOnComplete(ResetEgg);
        LeanTween.scale(card, Vector3.one * 0.7f, 0.6f).setOnComplete(ScaleDown);
    }
    private void ScaleDown()
    {
        LeanTween.scale(card, Vector3.one * 0.5f, 0.25f);
    }

    public void ResetEgg()
    {
        gameObject.GetComponent<Animator>().Play("Idle", -1, 0f);
        this.GetComponent<Image>().color = colors[Random.Range(0, colors.Length)];
        clickCount = 0;
        isCracked = false;
    }
}
