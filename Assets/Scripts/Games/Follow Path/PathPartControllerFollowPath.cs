using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathPartControllerFollowPath : MonoBehaviour
{
    [SerializeField] private Color correctColor;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Touch")
        {
            this.GetComponent<Text>().color = correctColor;
        }
    }
}
