using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControllerBucket : MonoBehaviour
{    
    GameAPI gameAPI;

    public string cardLocalName;
    public bool move = false;
    private bool oneTime = true;


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
        transform.position += Vector3.down * Time.deltaTime * 950;
        transform.GetChild(0).position += Vector3.down * Time.deltaTime * 5;
    }

    private void CallMoveCard()
    {
        GetComponentInParent<DropControllerBucket>().SelectMoveCard();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.GetComponent<BucketMovement>() != null)
        {
            GetComponentInParent<DropControllerBucket>().cards.Remove(this.gameObject);
            GetComponentInParent<DropControllerBucket>().SelectMoveCard();
            gameAPI.Speak(cardLocalName);
            Debug.Log(cardLocalName);
            gameAPI.PlaySFX("Success");
            if(this.gameObject.name == GetComponentInParent<DropControllerBucket>().collectableCard)
            {
                GetComponentInParent<DropControllerBucket>().matchCount ++;
                // if(GetComponentInParent<DropControllerBucket>().matchCount >= 5)
                // {
                //     GetComponentInParent<DropControllerBucket>().isLevelEnd = true;
                //     GetComponentInParent<DropControllerBucket>().ResetLevel();
                // }
            }
            this.transform.SetParent(other.transform);
        }
        else if(other.gameObject.tag == "Finish" && GetComponentInParent<DropControllerBucket>().isBoardCreated)
        {
            GetComponentInParent<DropControllerBucket>().cards.Remove(this.gameObject);
            GetComponentInParent<DropControllerBucket>().SelectMoveCard();
            Destroy(this.gameObject);
        }
    }
}
