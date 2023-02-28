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

    private Animator animator;
    private GameObject card;

    private Sprite eggPhaseImage;

    public int clickCount;

    public Color[] colors;

    private void OnEnable() 
    {
        this.GetComponent<Image>().color = colors[Random.Range(0, colors.Length)];
    }

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }

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

            if(clickCount == 1)
            {
                animator.SetTrigger("Phase1");
                GetComponent<Image>().sprite = eggPhase1;
            }
            else if(clickCount == 2)
            {
                animator.SetTrigger("Phase2");
                GetComponent<Image>().sprite = eggPhase2;
            }
            else if(clickCount == 3)
            {
                animator.SetTrigger("Phase3");
                GetComponent<Image>().sprite = eggPhase3;
            }
            else if(clickCount == 4)
            {
                animator.SetTrigger("Phase4");
                GetComponent<Image>().sprite = eggPhase4;
            }
            else if(clickCount >= 5)
            {
                LeanTween.scale(this.gameObject, Vector3.zero, 0.5f).setOnComplete(ResetEgg);
                LeanTween.scale(card, Vector3.one * 0.5f, 0.5f);
                animator.SetTrigger("Empty");
            }
        }
    }

    private void ResetEgg()
    {
        this.GetComponent<Image>().color = colors[Random.Range(0, colors.Length)];
        animator.SetFloat("Phase", 0);
        GetComponent<Image>().sprite = eggPhase0;
        animator.ResetTrigger("Phase1");
        animator.ResetTrigger("Phase2");
        animator.ResetTrigger("Phase3");
        animator.ResetTrigger("Phase4");
    }
}
