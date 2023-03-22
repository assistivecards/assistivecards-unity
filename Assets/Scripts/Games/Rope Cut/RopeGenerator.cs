using UnityEngine;

public class RopeGenerator : MonoBehaviour
{

    public Rigidbody2D hook;
    public GameObject ropePrefab;
    public int ropes;

    void Start()
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
            previousRB = rope.GetComponent<Rigidbody2D>();

        }
    }

}
