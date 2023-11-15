using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathPartControllerFollowPath : MonoBehaviour
{
    [SerializeField] private BoardGeneratorFollowPath boardGenerator;
    [SerializeField] private Color correctColor;
    public bool isCorrectPathElement = false;
    public bool selected = false;
    public int correctPathListIndex;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Touch" && isCorrectPathElement == true)
        {
            if(boardGenerator.correctPathElements[0] == this.gameObject)
            {
                selected = true;
                this.GetComponent<Text>().color = correctColor;
                boardGenerator.selectedPathElements.Add(this.gameObject);
            }
            else if(boardGenerator.correctPathElements[correctPathListIndex - 1] != null)
            {
                if(boardGenerator.selectedPathElements.Contains(boardGenerator.correctPathElements[correctPathListIndex - 1]))
                {
                    selected = true;
                    this.GetComponent<Text>().color = correctColor;
                    boardGenerator.selectedPathElements.Add(this.gameObject);
                }
            }
        }
    }
}
