using UnityEngine;

public class RopeGenerator : MonoBehaviour
{

    public Rigidbody2D hook;
    public GameObject ropePrefab;
    public int ropes;
    public CardAttacher cardAttacher;

    void OnEnable()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        Rigidbody2D previousRB = hook;
        for (int i = 0; i < ropes; i++)
        {

            GameObject rope = Instantiate(ropePrefab, transform);
            HingeJoint2D joint = rope.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;

            if (i < ropes - 1)
            {
                previousRB = rope.GetComponent<Rigidbody2D>();
            }
            else
            {
                cardAttacher.ConnectRopeEnd(rope.GetComponent<Rigidbody2D>());
            }

        }
    }

}
