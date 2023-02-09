using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiecePhysics : MonoBehaviour
{
    public float pushForce;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Piece"))
        {
            var direction = (other.transform.position - transform.position).normalized;
            Debug.Log(direction);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * pushForce, ForceMode2D.Force);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
