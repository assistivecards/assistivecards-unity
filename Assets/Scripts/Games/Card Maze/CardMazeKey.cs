using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMazeKey : MonoBehaviour
{
    private CardMazeBoardGenerator board;
    public Vector3 originalPosition;
    private GameAPI gameAPI;
    public bool isCollected;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<CardMazeBoardGenerator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isCollected)
        {
            LeanTween.scale(gameObject, Vector3.zero, 0.2f);
            gameAPI.PlaySFX("Collect");
            isCollected = true;
            UnlockDoor();
        }
    }

    private void UnlockDoor()
    {
        var door = GameObject.Find("Door");
        originalPosition = door.transform.localPosition;

        Debug.Log(originalPosition);


        if (board.selectedMaze.name == "Maze")
        {
            LeanTween.moveLocalY(door, door.transform.localPosition.y + 150, .3f);
        }

        else if (board.selectedMaze.name == "Maze2")
        {
            LeanTween.moveLocalX(door, door.transform.localPosition.x + 150, .3f);
        }

        else if (board.selectedMaze.name == "Maze3")
        {
            LeanTween.moveLocalX(door, door.transform.localPosition.x - 150, .3f);
        }

        else
        {
            LeanTween.moveLocalY(door, door.transform.localPosition.y - 150, .3f);
        }
    }
}
