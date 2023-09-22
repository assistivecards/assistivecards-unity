using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardControllerBucket : MonoBehaviour
{    
    GameAPI gameAPI;
    public string cardLocalName;
    private bool dropped = false;
    [SerializeField] private int speed;


    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Update() 
    {
        if(GetComponentInParent<DropControllerBucket>() != null)
        {
            if(GetComponentInParent<DropControllerBucket>().moveCard != null)
            {
                if(this.gameObject == GetComponentInParent<DropControllerBucket>().moveCard)
                {
                    Move();
                }
            }
        }
    }

    public void Move() 
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
        transform.GetChild(0).position += Vector3.down * Time.deltaTime * 5;
    }

    private void CallMoveCard()
    {
        GetComponentInParent<DropControllerBucket>().SelectMoveCard();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!dropped)
        {
            if(other.gameObject.GetComponent<BucketMovement>() != null)
            {
                gameAPI.Speak(cardLocalName);
                Debug.Log(cardLocalName);
                if(this.gameObject.name == GetComponentInParent<DropControllerBucket>().collectableCard)
                {
                    gameAPI.PlaySFX("Success");
                    gameAPI.PlayConfettiParticle(this.transform.position);
                    gameAPI.AddSessionExp();
                    GetComponentInParent<DropControllerBucket>().matchCount ++;
                    GetComponentInParent<DropControllerBucket>().SetCount();
                    
                    if(GetComponentInParent<DropControllerBucket>().matchCount >= 5)
                    {
                        GetComponentInParent<DropControllerBucket>().CloseCollectText();
                        GetComponentInParent<DropControllerBucket>().isLevelEnd = true;
                        GetComponentInParent<DropControllerBucket>().ResetLevel();
                    }
                }
                else if(this.gameObject.name != GetComponentInParent<DropControllerBucket>().collectableCard)
                {
                    gameAPI.RemoveSessionExp();
                    gameAPI.PlaySFX("NotMatched");
                    Invoke("FadeOutCard", 2f);
                }
                GetComponentInParent<DropControllerBucket>().cards.Remove(this.gameObject);
                GetComponentInParent<DropControllerBucket>().SelectMoveCard();
                this.transform.SetParent(other.transform);
            }
            else if(other.gameObject.tag == "Finish" && GetComponentInParent<DropControllerBucket>().isBoardCreated)
            {
                gameAPI.PlaySFX("NotMatched");
                if(GetComponentInParent<DropControllerBucket>() != null)
                {
                    GetComponentInParent<DropControllerBucket>().cards.Remove(this.gameObject);
                    GetComponentInParent<DropControllerBucket>().SelectMoveCard();
                }
                this.transform.SetParent(other.transform);
                dropped = true;
                this.GetComponent<Collider2D>().isTrigger = false;
                Invoke("FadeOutCard", 2f);
            }
        }
    }

    private void FadeOutCard()
    {
        this.GetComponent<Image>().CrossFadeAlpha(0, 2.0f, false);
        this.GetComponentInChildren<RawImage>().CrossFadeAlpha(0, 2.0f, false);
        Invoke("DestroyThis", 2.5f);
    }
    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
