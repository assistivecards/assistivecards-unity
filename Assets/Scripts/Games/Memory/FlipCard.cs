using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class FlipCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    GameAPI gameAPI;
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
        gameAPI = Camera.main.GetComponent<GameAPI>();
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
        CalculateFlipTween();
    }

    public void StartBackFlip()
    {
        gameAPI.PlaySFX("CardBackFlip");
        CalculateBackFlipTween();
    }


    private void Flip()
    {
        if(checkMatches.flippedCards.Count < 2)
        {
            gameAPI.PlaySFX("CardFlip");
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
            gameAPI.PlaySFX("CardFlip");
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

    private void CalculateFlipTween()
    {
        LeanTween.rotateY(this.gameObject, -180, 0.6f);
        Invoke("Flip", 0.35f);
    }

    private void CalculateBackFlipTween()
    {
        LeanTween.rotateY(this.gameObject, 0, 0.6f);
        LeanTween.rotateZ(this.gameObject, 180, 0.01f);
        Invoke("BackFlip", 0.35f);
    }
}
