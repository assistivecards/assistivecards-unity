using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SnakeCardSnakeController : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject snakeBodyPrefab;
    public int snakeLenght;
    public List<GameObject> bodyParts = new List<GameObject>();

    private void Update()
    {
        if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)))
        {
            Vector2 realWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            this.transform.position = realWorldPos;

            for(int i = 0; i < bodyParts.Count; i++)
            {
                bodyParts[i].GetComponent<SnakeCardsPartMovement>().Invoke("MovePart", i/10f);
            }
        }
    }

    public void GenerateSnake()
    {
        Rigidbody2D previousRB = hook;
        for (int i = 0; i < snakeLenght; i++)
        {

            GameObject part = Instantiate(snakeBodyPrefab, transform);
            HingeJoint2D joint = part.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;
            part.GetComponent<SnakeCardsPartMovement>().previousPart = previousRB.gameObject;
            bodyParts.Add(part);

            if (i < snakeLenght - 1)
            {
                previousRB = part.GetComponent<Rigidbody2D>();
            }
        }
    }   
}
