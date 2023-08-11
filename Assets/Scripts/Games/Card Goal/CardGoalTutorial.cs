using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGoalTutorial : MonoBehaviour
{
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;

    private void OnEnable()
    {
        startPos = Vector3.zero;
        endPos = new Vector3(transform.position.x - 200, 0, 0);

    }

    void Update()
    {
        if (startPos != null && endPos != null)
        {
            transform.localPosition = Vector3.Lerp(startPos, endPos, Mathf.PingPong(Time.time, 1));
        }
    }

}
