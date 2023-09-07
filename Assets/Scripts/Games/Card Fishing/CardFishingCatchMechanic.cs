using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFishingCatchMechanic : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private CardFishingUIController UIController;
    [SerializeField] private CardFishingRodController cardFishingRodController;
    [SerializeField] private CardFishingBoardGenerator boardGenerator;
    public bool catctedCard;
    public GameObject card;
    public GameObject formerCard;
    public int cachedCardCount;
    public int score;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!catctedCard)
        {
            if(other.gameObject.tag == "card")
            {
                card = other.gameObject;
                catctedCard = true;

                if(other.gameObject.name == boardGenerator.selectedCard)
                {
                    score ++;
                    gameAPI.AddSessionExp();
                }
                else
                {
                    gameAPI.RemoveSessionExp();
                }
            }
        }
    }

    void Update()
    {
        if(card != null)
            MoveCard(card);
    }

    private void MoveCard(GameObject _card)
    {
        _card.transform.position = this.transform.GetChild(0).transform.position;

        if(this.transform.localScale.y <= 0)
        {
            formerCard = card;
            card = null;
            ScaleCard();
        }
    }

    private void ScaleCard()
    {
        LeanTween.rotateZ(formerCard, 0, 0.2f);
        LeanTween.scale(formerCard, Vector3.one * 0.6f, 0.5f).setOnComplete(FadeOutCard);
        if(formerCard.name == boardGenerator.selectedCard)
        {
            gameAPI.PlaySFX("Success");
        }
        Invoke("ReadCard", 0.25f);
        catctedCard = false;
    }

    private void ReadCard()
    {
        gameAPI.Speak(formerCard.GetComponent<CardFishingCardName>().cardName);
        Debug.Log(formerCard.GetComponent<CardFishingCardName>().cardName);
    }

    private void FadeOutCard()
    {
        formerCard.GetComponent<Image>().CrossFadeAlpha(0, 0.5f, true);
        formerCard.transform.GetChild(0).GetComponent<RawImage>().CrossFadeAlpha(0, 0.5f, true);
        cachedCardCount++;
        Invoke("DestroyCard", 0.5f);
    }

    private void DestroyCard()
    {
        Destroy(card);
        Destroy(formerCard);
        formerCard = null;
        if(cachedCardCount >= 10 || score >= 2)
        {
            UIController.LevelChangeScreenActivate();
            gameAPI.PlaySFX("Finished");
        }
    }
}
