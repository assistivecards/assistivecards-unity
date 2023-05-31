using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePuzzleTutorial : MonoBehaviour
{
    [SerializeField] public Transform point1;
    [SerializeField] public Transform point2;

    public List<Transform> slots = new List<Transform>();

    [SerializeField] public Transform slot1;
    [SerializeField] public Transform slot2;
    [SerializeField] public Transform slot3;
    [SerializeField] public Transform slot4;

    private void OnEnable() 
    {
        CreateList();
        DetectTargetPiece();
    }

    private void CreateList()
    {
        slots.Add(slot1);
        slots.Add(slot2);
        slots.Add(slot3);
        slots.Add(slot4);
    }

    private void DetectTargetPiece()
    {
        if(point2 == null || point2 == slots[3])
        {
            point2 = slots[0];
        }
        else
        {
            for(int i = 0; i < 3; i++)
            {
                if(point2 == slots[i])
                {
                    point2 = slots[i + 1];  

                    break;
                }
            }
        }

    }

    void Update()
    {
        if(point1 != null && point2 != null)
            transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time / 1.5f, 1));
    }

    private void OnDisable() 
    {
        slots.Clear();
    }
}
