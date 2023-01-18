using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private int collisionCount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionCount++;
        if (other.gameObject.tag == "CorrectCard" && collisionCount == 1)
        {
            Debug.Log("Correct Match !!!");
        }

    }
}
