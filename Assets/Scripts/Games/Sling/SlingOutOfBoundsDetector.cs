using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingOutOfBoundsDetector : MonoBehaviour
{

    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        RectTransform rect = GetComponent<RectTransform>();
        collider.size = new Vector2(rect.rect.width, rect.rect.height);
    }

}
