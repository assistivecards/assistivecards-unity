using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCardTrailCollider : MonoBehaviour
{
    TrailRenderer snakeTrail;
    EdgeCollider2D snakeCollider;

    private void Awake()
    {
        snakeTrail = this.GetComponent<TrailRenderer>();
        GameObject colliderGameObject = new GameObject("TrailCollider", typeof(EdgeCollider2D));
        colliderGameObject.tag = "Snake";
        colliderGameObject.GetComponent<EdgeCollider2D>().isTrigger = true;
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
