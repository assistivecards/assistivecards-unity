using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasInputDetect : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;   
    [SerializeField] private GameObject packSelectionPanel;
    [SerializeField] private GameObject levelChangeScreen;
    private int time = 0; 

    void FixedUpdate () 
    {
        if(Input.touchCount <= 0 && !packSelectionPanel.activeInHierarchy && !levelChangeScreen.activeInHierarchy)
        {
            time = time + 1;
        }
        else 
        {
            time = 0;
        }
        if(time == 800) 
        {
            if(tutorial != null)
            {
                tutorial.SetActive(true);
            }

            time = 0;
        }
    }
}
