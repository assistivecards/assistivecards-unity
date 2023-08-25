using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMazeTutorial : MonoBehaviour
{
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;
    [SerializeField] CardMazeBoardGenerator board;

    private void OnEnable()
    {
        startPos = board.cardParent.transform.localPosition;
        endPos = GameObject.Find("TutorialFinishTarget").transform.localPosition;

    }

    void Update()
    {
        if (startPos != null && endPos != null)
        {
            transform.localPosition = Vector3.Lerp(startPos, endPos, Mathf.PingPong(Time.time, 1));
        }
    }
}
