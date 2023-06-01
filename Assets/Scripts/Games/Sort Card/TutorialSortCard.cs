using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSortCard : MonoBehaviour
{
    [SerializeField] public Transform point1;
    [SerializeField] public Transform point2;

    public List<Transform> slots = new List<Transform>();
    public List<Transform> cards = new List<Transform>();
    public int i;

    private void OnEnable() 
    {
        DetectPoints();   
    }

    private void DetectPoints()
    {
        if(i == 3)
        {
            i = 0;
        }   
        point1 = cards[i].transform.parent.transform;
        point2 = slots[i];
    }

    void Update()
    {
        if(point1 != null && point2 != null)
            transform.position = Vector3.Lerp(new Vector3(point1.position.x, 650f, 0), point2.position, Mathf.PingPong(Time.time / 1.5f, 1));
    }

    public void ClearLists() 
    {
        slots.Clear();
        cards.Clear();
        i = 0;
    }
}
