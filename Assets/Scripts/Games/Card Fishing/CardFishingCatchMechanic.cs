using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFishingCatchMechanic : MonoBehaviour
{
    [SerializeField] private CardFishingRodController cardFishingRodController;
    public bool catctedCard;
    public GameObject card;
    public GameObject formerCard;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(!catctedCard)
        {
            if(other.gameObject.tag == "card")
            {
                card = other.gameObject;
                catctedCard = true;
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
        LeanTween.scale(formerCard, Vector3.one * 0.6f, 0.5f);
        Invoke("FadeOutCard", 1f);
    }

    private void FadeOutCard()
    {
        formerCard.GetComponent<Image>().CrossFadeAlpha(0, 0.5f, true);
        formerCard.transform.GetChild(0).GetComponent<RawImage>().CrossFadeAlpha(0, 0.5f, true);
        DestroyCard();
    }

    private void DestroyCard()
    {
        Destroy(card);
        Destroy(formerCard);
        catctedCard = false;
        formerCard = null;
    }

}
