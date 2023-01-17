using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private GameObject tempcardElement;
    private GameObject cardElement;
    public List<GameObject> cards = new List<GameObject>();

    public int cardCount;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        for(int i = 0; i < cardCount; i ++)
        {
            cards.Add(Instantiate(tempcardElement, Vector3.zero, Quaternion.identity));
            cards[i].transform.parent = this.transform;
        }
    }



}
