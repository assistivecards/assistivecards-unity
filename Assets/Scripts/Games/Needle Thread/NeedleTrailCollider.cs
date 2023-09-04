using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleTrailCollider : MonoBehaviour
{
    TrailRenderer needleTrail;
    EdgeCollider2D needleCollider;

    private void Awake()
    {
        needleTrail = this.GetComponent<TrailRenderer>();
        GameObject colliderGameObject = new GameObject("TrailCollider", typeof(EdgeCollider2D));
        colliderGameObject.GetComponent<EdgeCollider2D>().isTrigger = true;
        needleCollider = colliderGameObject.GetComponent<EdgeCollider2D>();
    }

    private void Update()
    {
        SetColliderTrail(needleTrail, needleCollider);
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
