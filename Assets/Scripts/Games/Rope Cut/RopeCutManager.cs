using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCutManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Rope")
                {
                    LeanTween.alpha(hit.collider.gameObject, 0, .15f);
                    Destroy(hit.collider.gameObject, .15f);
                }
            }
        }
    }
}
