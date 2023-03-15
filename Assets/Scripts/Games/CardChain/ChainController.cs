using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainController : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();

    public List<string> cardTypes = new List<string>();

    public void GetChildList()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            cards.Add(transform.GetChild(i).gameObject);
            cardTypes.Add(transform.GetChild(i).gameObject.name);
        }
    }
}
