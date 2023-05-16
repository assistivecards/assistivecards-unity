using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCardOrderDetection : MonoBehaviour
{
    [SerializeField] private GameObject slotParent;
    public List<GameObject> slots = new List<GameObject>();
    public List<string> cards = new List<string>();



    private void OnEnable() 
    {
        foreach (Transform child in slotParent.transform)
        {
            slots.Add(child.gameObject);
        }
    }

    public void ListCards()
    {
        for(int i = 0; i < slots.Count; i++)
        {
            cards.Add(null);
            if(slots[i].transform.childCount > 0)
            {
                cards.Insert(i, slots[i].transform.GetChild(0).GetComponent<SortCardDraggable>().cardType);
            }
        }
    }
}
