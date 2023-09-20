using UnityEngine;

public class RopeGenerator : MonoBehaviour
{

    public Rigidbody2D hook;
    public GameObject ropePrefab;
    public int ropes;
    public CardAttacher cardAttacher;

    public void GenerateRope()
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

        DestroyExcessRopes();
    }

    private void DestroyExcessRopes()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "Rope(Clone)" && i < transform.childCount - ropes)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

}
