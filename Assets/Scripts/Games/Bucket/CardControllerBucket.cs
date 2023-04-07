using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControllerBucket : MonoBehaviour
{
    public string cardLocalName;
    public bool move = false;
    private bool oneTime = true;

    private void Update() 
    {
        if(move)
        {
            Move();
        }
    }

    public void Move() 
    {
        transform.position += Vector3.down * Time.deltaTime * 900;
        transform.GetChild(0).position += Vector3.down * Time.deltaTime * 5;

        if(oneTime)
        {
            Invoke("CallMoveCard", 2.25f);
            oneTime = false;
        }
    }

    private void CallMoveCard()
    {
        GetComponentInParent<DropControllerBucket>().MoveCard();
    }
}
