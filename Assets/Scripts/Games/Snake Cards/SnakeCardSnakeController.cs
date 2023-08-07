using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SnakeCardSnakeController : MonoBehaviour
{
 public Rigidbody2D hook;
    public GameObject snakeBodyPrefab;
    public int snakeLenght;

    public void GenerateSnake()
    {
        Rigidbody2D previousRB = hook;
        for (int i = 0; i < snakeLenght; i++)
        {

            GameObject rope = Instantiate(snakeBodyPrefab, transform);
            HingeJoint2D joint = rope.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;

            if (i < snakeLenght - 1)
            {
                previousRB = rope.GetComponent<Rigidbody2D>();
            }

        }
    }
}
