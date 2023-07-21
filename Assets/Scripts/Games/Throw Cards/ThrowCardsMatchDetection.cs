using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowCardsMatchDetection : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.GetChild(0).GetComponent<Image>().sprite == transform.GetChild(0).GetComponent<SpriteRenderer>().sprite)
        {
            Debug.Log("CORRECT MATCH");
            rb.sharedMaterial.bounciness = 0;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;

        }

        else
        {
            Debug.Log("WRONG MATCH");
            rb.sharedMaterial.bounciness = 0.6f;
        }
    }
}
