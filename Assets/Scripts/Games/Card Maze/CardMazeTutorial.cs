using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMazeTutorial : MonoBehaviour
{
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 target;
    [SerializeField] CardMazeBoardGenerator board;

    private void OnEnable()
    {
        startPos = board.cardParent.transform.localPosition;
        target = GameObject.Find("TutorialFinishTarget").transform.localPosition;

        if (board.isFlipped)
        {
            target = new Vector3(-target.x, target.y, target.z);
        }


    }

    void Update()
    {
        if (startPos != null && target != null)
        {
            transform.localPosition = Vector3.Lerp(startPos, target, Mathf.PingPong(Time.time, 1));
        }
    }
}
