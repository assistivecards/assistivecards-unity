using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRumbleCardMovement : MonoBehaviour
{
    private CardRumbleBoardGenerator board;

    void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<CardRumbleBoardGenerator>();
    }

    public void InitiateCardMovement()
    {
        LeanTween.rotateZ(gameObject, 20, .5f).setLoopPingPong();
        ChooseRandomSpawnPoint();
    }

    // public void ChooseRandomSpawnPoint()
    // {
    //     LeanTween.move(gameObject, board.spawnPoints[Random.Range(0, board.spawnPoints.Length)].transform, Random.Range(1.5f, 2f)).setOnComplete(ChooseRandomSpawnPoint);
    // }

    public void ChooseRandomSpawnPoint()
    {
        var randomSpawnPoint = board.spawnPoints[Random.Range(0, board.spawnPoints.Length)].transform;
        var distance = Vector3.Distance(randomSpawnPoint.position, transform.position);
        var time = distance / board.cardSpeed;
        LeanTween.move(gameObject, randomSpawnPoint, time).setOnComplete(ChooseRandomSpawnPoint);
    }

}
