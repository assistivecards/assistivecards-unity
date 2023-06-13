using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardNinjaCardMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D cardRB;

    [SerializeField] private float maxForce;
    [SerializeField] private float minForce;

    [SerializeField] private float lifeTime;
    [SerializeField] private float cardGravityScale;

    private void OnEnable() 
    {
        Invoke("Burst", Random.Range(0, 60f));
    }

    private void Burst() 
    {
        float force = Random.Range(minForce, maxForce);
        cardRB.AddForce(this.transform.up * force, ForceMode2D.Impulse);
        cardRB.gravityScale = cardGravityScale;
        Destroy(this.gameObject, lifeTime);
    }
}
