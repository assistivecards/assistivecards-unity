using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGoalPostMovement : MonoBehaviour
{
    [SerializeField] GameObject gamePanel;
    [SerializeField] float movementSpeed;

    private void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, gamePanel.GetComponent<RectTransform>().rect.yMin + 140);
        var destination = new Vector3(transform.localPosition.x, gamePanel.GetComponent<RectTransform>().rect.yMax - 140);

        var distance = Vector3.Distance(transform.localPosition, destination);
        var time = distance / movementSpeed;
        LeanTween.moveLocal(gameObject, destination, time).setLoopPingPong();

    }
}
