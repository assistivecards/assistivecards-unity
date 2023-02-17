using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class AccessVertexTest : MonoBehaviour
{
    [SerializeField] List<Vector3> vertices = new List<Vector3>();
    // [SerializeField] GameObject objectHolder;
    // [SerializeField] List<Vector3> waypoints = new List<Vector3>();
    [SerializeField] PathCreator path = new PathCreator();

    [SerializeField] Transform handle;
    void Start()
    {
        for (int i = 0; i < path.path.localPoints.Length; i++)
        {
            vertices.Add(path.path.GetPoint(i));
        }

        // for (int i = 0; i < objectHolder.transform.childCount; i++)
        // {
        //     waypoints.Add(objectHolder.transform.GetChild(i).transform.position);
        // }

        handle.position = vertices[0];

    }
}
