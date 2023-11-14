using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathPartControllerFollowPath : MonoBehaviour
{
    [SerializeField] private BoardGeneratorFollowPath boardGenerator;
    [SerializeField] private Color correctColor;
    public bool selected = false;
    public int correctPathListIndex;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Touch")
        {
            if(boardGenerator.correctPathElements[0] == this.gameObject)
            {
                selected = true;
                this.GetComponent<Text>().color = correctColor;
                boardGenerator.selectedPathElements.Add(this.gameObject);
            }
            else if(boardGenerator.selectedPathElements.Contains(boardGenerator.correctPathElements[correctPathListIndex - 1]))
            {
                selected = true;
                this.GetComponent<Text>().color = correctColor;
                boardGenerator.selectedPathElements.Add(this.gameObject);
            }
        }
    }
}
