using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScript : MonoBehaviour
{
    
    void Start()
    {
        if (gameObject.GetComponent<Image>() != null)
        {
            for (int i = 0; i <= 1; i++)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            }
        }
    }
}
