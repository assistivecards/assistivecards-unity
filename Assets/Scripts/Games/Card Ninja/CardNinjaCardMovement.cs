using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardNinjaCardMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D cardRB;

    [SerializeField] private float maxForce;
    [SerializeField] private float minForce;

    [SerializeField] private float lifeTime;
    [SerializeField] private float cardGravityScale;

    private CardNinjaCutController cutController;
    private CardNinjaBoardGenerator boardGenerator;
    private List<Transform> childs = new List<Transform>();
    public List<Vector3> vectors = new List<Vector3>();


    private void OnEnable() 
    {
        cutController = FindObjectOfType<CardNinjaCutController>();
        boardGenerator = FindObjectOfType<CardNinjaBoardGenerator>();

        foreach (Transform child in transform)
        {
            childs.Add(child);
        }

        vectors.Add(new Vector3(-0.1f, 1, 0));
        vectors.Add(new Vector3(0.1f, 1, 0));
    }

    public void Throw() 
    {
        float force = Random.Range(minForce, maxForce);
        cardRB.AddForce(vectors[Random.Range(0, 2)] * force, ForceMode2D.Impulse);
        cardRB.gravityScale = cardGravityScale;
        Destroy(this.gameObject, lifeTime);
        cutController.throwedCount++;

        if(cutController.throwedCount < 17)
            boardGenerator.Invoke("ThrowCards", 2f);

    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Blade" && cutController.isDragging)
        {
            Break(cutController.horizontalDrag, cutController.verticalDrag);
            Debug.Log("selected card:" + boardGenerator.cards[0].name);
            Debug.Log("cutted card:" + this.gameObject.name);

            if(boardGenerator.cards[1].name == this.gameObject.name)
            {
                cutController.cutCount++;
            }
        }
    }

    public void Break(bool horizontalDrag, bool verticalDrag) 
    {
        cardRB.simulated = false;
        for(int i=0; i <= childs.Count; i++)
        {
            float childforce = 2;

            if(verticalDrag && !horizontalDrag)
            {
                if(i == 1 || i==3)
                {
                    childs[i].GetComponent<Rigidbody2D>().simulated = true;
                    childs[i].gameObject.GetComponent<Rigidbody2D>().AddForce(childforce * -transform.right, ForceMode2D.Impulse);
                    childs[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = cardGravityScale * 2.5f;

                }
                else if(i == 2 || i==4)
                {
                    childs[i].GetComponent<Rigidbody2D>().simulated = true;
                    childs[i].gameObject.GetComponent<Rigidbody2D>().AddForce(childforce * transform.right, ForceMode2D.Impulse);
                    childs[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = cardGravityScale * 2.5f;
                }

            }
            else if(horizontalDrag && !verticalDrag)
            {
                if(i == 1 || i == 2)
                {
                    childs[i].GetComponent<Rigidbody2D>().simulated = true;
                    childs[i].gameObject.GetComponent<Rigidbody2D>().AddForce(childforce * -transform.right, ForceMode2D.Impulse);
                    childs[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = cardGravityScale * 2.5f;

                }
                else if(i == 3 || i==4)
                {
                    childs[i].GetComponent<Rigidbody2D>().simulated = true;
                    childs[i].gameObject.GetComponent<Rigidbody2D>().AddForce(childforce * transform.right, ForceMode2D.Impulse);
                    childs[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = cardGravityScale * 2.5f;

                }
            }
        }
    }
}
