using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathPartControllerFollowPath : MonoBehaviour
{
    [SerializeField] private BoardGeneratorFollowPath boardGenerator;
    [SerializeField] private Color correctColor;
    public bool isCorrectPathElement = false;
    public bool isGeneralPathElement = false;
    public bool selected = false;
    public int generalPathListIndex;
    public int correctPathListIndex;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Touch" && isGeneralPathElement)
        {
            if(boardGenerator.generalPathElements[0] == this.gameObject)
            {
                selected = true;
                this.GetComponent<Text>().color = correctColor;
                boardGenerator.selectedPathElements.Add(this.gameObject);
            }
            else if(boardGenerator.generalPathElements[generalPathListIndex - 1] != null)
            {
                if(boardGenerator.selectedPathElements.Contains(boardGenerator.generalPathElements[generalPathListIndex - 1]))
                {
                    selected = true;
                    this.GetComponent<Text>().color = correctColor;
                    boardGenerator.selectedPathElements.Add(this.gameObject);
                }
            }
        }
        else if(other.tag == "Touch" && isCorrectPathElement 
        && boardGenerator.selectedPathElements.Contains(boardGenerator.generalPathElements[boardGenerator.generalPathElements.Count - 1]))
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
        else if(other.tag == "Touch" && !isCorrectPathElement 
        && boardGenerator.selectedPathElements.Contains(boardGenerator.generalPathElements[boardGenerator.generalPathElements.Count - 1]))
        {
            selected = true;
            this.GetComponent<Text>().color = correctColor;
            boardGenerator.selectedPathElements.Add(this.gameObject);
        }
    }
}
