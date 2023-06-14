using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardNinjaCardMovement : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Rigidbody2D cardRB;

    [SerializeField] private Transform horizontalPiecesParent;
    [SerializeField] private Transform verticalPiecesParent;

    [SerializeField] private float maxForce;
    [SerializeField] private float minForce;

    [SerializeField] private float lifeTime;
    [SerializeField] private float cardGravityScale;

    private void OnEnable() 
    {
        Invoke("Burst", Random.Range(0f, 65f));
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
        
    }
}
