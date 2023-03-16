using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabControllerCardChain : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.transform.parent.name == this.transform.parent.name)
        {
            var otherParent = other.transform.parent;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            other.transform.SetParent(this.transform);
        }
    }
}
