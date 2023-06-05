using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackCardsTutorial : MonoBehaviour
{
    [SerializeField] private StackCardsBoardGenerator stackCardsBoardGenerator;
    public Transform point1;
    public Transform point2;

    public List<Transform> targetPositions = new List<Transform>();
    public List<GameObject> slotList = new List<GameObject>();

    public List<Transform> positions1 = new List<Transform>();
    public List<Transform> positions2 = new List<Transform>();
    public List<Transform> positions3 = new List<Transform>();


    public Transform targetPositions1;
    public Transform targetPositions2;
    public Transform targetPositions3;

    public bool firstTime = true;
    public int turn;


    private void OnEnable() 
    {
        if(firstTime)
        {
            FindPositionLists();
            firstTime = false;
        }
        if(turn < positions1.Count)
        {
            point1 = targetPositions[0]; 
            point2 = positions1[turn];
        }
        else if(turn >= positions1.Count && turn < (positions1.Count + positions2.Count))
        {
            point1 = targetPositions[1];
            point2 = positions2[turn - positions1.Count];
        }
        else if(turn >= (positions1.Count + positions2.Count))
        {
            point1 = targetPositions[2];
            point2 = positions3[turn - (positions1.Count + positions2.Count)];
        }
    }

    public void FindPositionLists()
    {
        targetPositions.Add(targetPositions1);
        targetPositions.Add(targetPositions2);
        targetPositions.Add(targetPositions3);

        foreach (var card in slotList)
        {
            if(card.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite == targetPositions[0].GetChild(0).GetComponent<Image>().sprite)
            {
                positions1.Add(card.transform);
            }
            if(card.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite == targetPositions[1].GetChild(0).GetComponent<Image>().sprite)
            {
                positions2.Add(card.transform);
            }
            if(card.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite == targetPositions[2].GetChild(0).GetComponent<Image>().sprite)
            {
                positions3.Add(card.transform);
            }
        }
        point1 = targetPositions[0];
    }

    void Update()
    {
        if(point1 != null && point2 != null)
        {
            transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time * 0.5f, 1));
        }
    }

    private void OnDisable() 
    {
        turn ++;
    }

    public void ClearTutorial()
    {
        positions1.Clear();
        positions2.Clear();
        positions3.Clear();
        targetPositions.Clear();
        firstTime = true;
        turn = 0;
    }

}
