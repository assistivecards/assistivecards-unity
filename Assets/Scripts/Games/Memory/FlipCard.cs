using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class FlipCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float x,y,z;
    [SerializeField] private CheckMatches checkMatches;
    private Transform cardLogo;
    private Transform cardBack;
    public bool isCardBackActive = false;
    private int timer;
    public bool touched = false;
    private Transform cardName;

    private bool isInteractible = true;

    private void Awake() 
    {
        cardBack = this.transform.GetChild(1);
        cardLogo = this.transform.GetChild(0).transform.GetChild(0);
        cardName = this.transform.GetChild(2);
    }

    private void Start() {
        
        checkMatches = this.GetComponentInParent<CheckMatches>();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if(isInteractible)
        {
            StartFlip();
        }
    }

    private void StartFlip()
    {
        isInteractible = false;
        StartCoroutine(CalculateFlip());
    }

    public void StartBackFlip()
    {
        StartCoroutine(CalculateBackFlip());
    }


    private void Flip()
    {
        if(checkMatches.flippedCards.Count < 2)
        {
            cardBack.gameObject.SetActive(true);
            cardLogo.gameObject.SetActive(false);
            cardName.gameObject.SetActive(true);
            isCardBackActive = true;
            checkMatches.flippedCards.Add(this.gameObject);
            checkMatches.firstCardName = cardBack.name;
            checkMatches.CheckMatche();
        }
        else 
        {
            checkMatches.CheckAllBoardFlip();
            cardBack.gameObject.SetActive(true);
            cardLogo.gameObject.SetActive(false);
            cardName.gameObject.SetActive(true);
            isCardBackActive = true;
            checkMatches.flippedCards.Add(this.gameObject);
            checkMatches.firstCardName = cardBack.name;
            checkMatches.CheckMatche();
        }
    }

    private void BackFlip()
    {
        if(isCardBackActive == true)
        {
            cardName.gameObject.SetActive(false);
            cardLogo.gameObject.SetActive(true);
            cardBack.gameObject.SetActive(false);
            isCardBackActive = false;
            isInteractible = true;
        }
    }

    private IEnumerator CalculateFlip()
    {
        for(int i = 0; i <180; i++)
        {
            yield return new WaitForSeconds(0.001f);
            transform.Rotate(new Vector3(x,y,z));
            timer++;

            if(timer == 90 || timer == -90)
            {
                Flip();
            }
        }
        timer = 0;
    }

    IEnumerator CalculateBackFlip()
    {
        for(int i = 0; i <180; i++)
        {
            yield return new WaitForSeconds(0.001f);
            transform.Rotate(new Vector3(x,y,z));
            timer++;

            if(timer == 90 || timer == -90)
            {
                BackFlip();
            }
        }
        timer = 0;
    }
}
