using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountButton : MonoBehaviour
{
    public int value;
    public CountGenerateBoard generateBoard;

    private void OnEnable() 
    {
        generateBoard = FindObjectOfType<CountGenerateBoard>();
    }


    public void CountButtonClick()
    {
        if(value == generateBoard.countNum + 1)
        {
            Debug.Log("TRUE MATCH");
        }
    }
}
