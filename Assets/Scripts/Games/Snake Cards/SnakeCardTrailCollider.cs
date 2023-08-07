using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCardTrailCollider : MonoBehaviour
{
    // [SerializeField] private LineRenderer line;
    // public void GenerateMeshCollider()
    // {
    //     MeshCollider collider = GetComponent<MeshCollider>();

    //     if(collider == null)
    //     {
    //         collider = gameObject.AddComponent<MeshCollider>();
    //     }

    //     Mesh mesh = new Mesh();
    //     line.BakeMesh(mesh, true);
    //     collider.sharedMesh = mesh;
    // }
    TrailRenderer snakeTrail;
    EdgeCollider2D snakeCollider;

    private void Awake()
    {
        snakeTrail = this.GetComponent<TrailRenderer>();
        GameObject colliderGameObject = new GameObject("TrailCollider", typeof(EdgeCollider2D));
        snakeCollider = colliderGameObject.GetComponent<EdgeCollider2D>();
    }

    private void Update()
    {
        SetColliderTrail(snakeTrail, snakeCollider);
    }
    
    private void SetColliderTrail(TrailRenderer trail, EdgeCollider2D collider)
    {
        List<Vector2> points = new List<Vector2>();
        for(int position = 0; position < trail.positionCount; position++)
        {
            points.Add(trail.GetPosition(position));
        }
        collider.SetPoints(points);
    }
}
