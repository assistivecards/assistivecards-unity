using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardNinjaCardMovement : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Rigidbody2D cardRB;

    [SerializeField] private float maxForce;
    [SerializeField] private float minForce;

    [SerializeField] private float lifeTime;
    [SerializeField] private float cardGravityScale;

    private List<Transform> childs = new List<Transform>();


    private void OnEnable() 
    {
        Invoke("Burst", Random.Range(0f, 65f));

        foreach (Transform child in transform)
        {
            childs.Add(child);
        }
    }

    private void Burst() 
    {
        float force = Random.Range(minForce, maxForce);
        cardRB.AddForce(this.transform.up * force, ForceMode2D.Impulse);
        cardRB.gravityScale = cardGravityScale;
        Destroy(this.gameObject, lifeTime);
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        cardRB.simulated = false;
        for(int i=0; i <= childs.Count; i++)
        {
            float childforce = Random.Range(minForce, maxForce);

            // if object cut verticaly

            // if(i == 1 || i==3)
            // {
            //     childs[i].GetComponent<Rigidbody2D>().simulated = true;
            //     childs[i].gameObject.GetComponent<Rigidbody2D>().AddForce(childforce * -transform.right, ForceMode2D.Impulse);
            //     childs[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = cardGravityScale * 15;

            // }
            // else if(i == 2 || i==4)
            // {
            //     childs[i].GetComponent<Rigidbody2D>().simulated = true;
            //     childs[i].gameObject.GetComponent<Rigidbody2D>().AddForce(childforce * transform.right, ForceMode2D.Impulse);
            //     childs[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = cardGravityScale * 15;

            // }

            // if object cut horizontaly

            if(i == 1 || i == 2)
            {
                childs[i].GetComponent<Rigidbody2D>().simulated = true;
                childs[i].gameObject.GetComponent<Rigidbody2D>().AddForce(childforce * -transform.right, ForceMode2D.Impulse);
                childs[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = cardGravityScale * 15;

            }
            else if(i == 3 || i==4)
            {
                childs[i].GetComponent<Rigidbody2D>().simulated = true;
                childs[i].gameObject.GetComponent<Rigidbody2D>().AddForce(childforce * transform.right, ForceMode2D.Impulse);
                childs[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = cardGravityScale * 15;

            }
            
        }
    }
}
