using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCardOrderDetection : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private GameObject slotParent;
    [SerializeField] private SortCardBoardGenerator boardGenerator;
    public List<GameObject> slots = new List<GameObject>();
    public List<GameObject> slotCards = new List<GameObject>();
    public List<string> cards = new List<string>();

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

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
            slotCards.Add(null);
            if(slots[i].transform.childCount > 0)
            {
                cards.Insert(i, slots[i].transform.GetChild(0).GetComponent<SortCardDraggable>().cardType);
                slotCards.Insert(i, slots[i].transform.GetChild(0).gameObject);
            }
        }
    }

    public void DetectMatch(GameObject parent, string cardType)
    {
        for(int i=0; i < 3; i++)
        {
            if(parent == slots[i])
            {
                if(cardType == boardGenerator.listedCards[i].GetComponentInChildren<SortCardDraggable>().cardType)
                {
                    gameAPI.Speak(cardType);
                    gameAPI.PlaySFX("Success");
                    Debug.Log(cardType);
                }
            }
        }
    }

    public void RemoveFromList(GameObject _object)
    {
        slotCards.Remove(_object);
    }

    public void ClearLists()
    {
        foreach(var card in slotCards)
        {
            Destroy(card);
        }
        slotCards.Clear();
        cards.Clear();
    }
}
