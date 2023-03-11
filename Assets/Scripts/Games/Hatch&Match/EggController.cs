using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EggController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private BoardCreatorHatchMatch boardCreatorHatchMatch;

    [SerializeField] private Sprite eggPhase0;
    [SerializeField] private Sprite eggPhase1;
    [SerializeField] private Sprite eggPhase2;
    [SerializeField] private Sprite eggPhase3;
    [SerializeField] private Sprite eggPhase4;
    private Sprite eggPhaseImage;
    private GameObject card;

    private Animator animator;

    public int clickCount;
    public Color[] colors;

    private void OnEnable() 
    {
        this.GetComponent<Image>().color = colors[Random.Range(0, colors.Length)];
        animator = GetComponent<Animator>();
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
            ChangeAnim();
        }
    }

    private void IncreaseClickCount()
    {
        clickCount ++;
    }

    private void ChangeAnim()
    {
        card = FindObjectOfType<CardElementHatchMatch>().gameObject;

        if(clickCount == 1)
        {
            animator.SetTrigger("Phase1");
            animator.ResetTrigger("Phase2");
            animator.ResetTrigger("Phase3");
            animator.ResetTrigger("Phase4");
            animator.ResetTrigger("Phase5");
            animator.ResetTrigger("Empty");
            GetComponent<Image>().sprite = eggPhase1;
        }
        else if(clickCount == 2)
        {
            animator.SetTrigger("Phase2");
            animator.ResetTrigger("Phase1");
            animator.ResetTrigger("Phase3");
            animator.ResetTrigger("Phase4");
            animator.ResetTrigger("Phase5");
            animator.ResetTrigger("Empty");
            GetComponent<Image>().sprite = eggPhase2;
        }
        else if(clickCount == 3)
        {
            animator.SetTrigger("Phase3");
            animator.ResetTrigger("Phase2");
            animator.ResetTrigger("Phase1");
            animator.ResetTrigger("Phase4");
            animator.ResetTrigger("Phase5");
            animator.ResetTrigger("Empty");
            GetComponent<Image>().sprite = eggPhase3;
        }
        else if(clickCount == 4)
        {
            animator.SetTrigger("Phase4");
            animator.ResetTrigger("Phase2");
            animator.ResetTrigger("Phase3");
            animator.ResetTrigger("Phase1");
            animator.ResetTrigger("Phase5");
            animator.ResetTrigger("Empty");
            GetComponent<Image>().sprite = eggPhase4;
        }
        else if(clickCount == 5)
        {
            animator.SetTrigger("Phase5");
            animator.ResetTrigger("Phase2");
            animator.ResetTrigger("Phase3");
            animator.ResetTrigger("Phase4");
            animator.ResetTrigger("Phase1");
            animator.ResetTrigger("Empty");
            GetComponent<Image>().sprite = eggPhase4;
        }
        else if(clickCount >= 5)
        {
            animator.SetTrigger("Empty");
            animator.ResetTrigger("Phase1");
            animator.ResetTrigger("Phase2");
            animator.ResetTrigger("Phase3");
            animator.ResetTrigger("Phase4");
            animator.ResetTrigger("Phase5");
            LeanTween.scale(this.gameObject, Vector3.zero, 0.5f).setOnComplete(ResetEgg);
            LeanTween.scale(card, Vector3.one * 0.5f, 0.5f);
        }
    }

    private void ResetEgg()
    {
        animator.ResetTrigger("Phase1");
        animator.ResetTrigger("Phase2");
        animator.ResetTrigger("Phase3");
        animator.ResetTrigger("Phase4");
        animator.ResetTrigger("Phase5");
        this.GetComponent<Image>().color = colors[Random.Range(0, colors.Length)];
        clickCount = 0;
        GetComponent<Image>().sprite = eggPhase0;
    }
}
