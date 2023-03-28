using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCutManager : MonoBehaviour
{
    private int ropeIndex;
    private Transform hitRope;

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
                    hitRope = hit.collider.transform.parent;
                    LeanTween.alpha(hit.collider.gameObject, 0, .15f);
                    Destroy(hit.collider.gameObject, .15f);

                    ropeIndex = hit.transform.GetSiblingIndex();

                    for (int i = ropeIndex; i < hitRope.childCount; i++)
                    {
                        LeanTween.alpha(hitRope.GetChild(i).gameObject, 0, .25f).setDelay(.25f);
                        Destroy(hitRope.GetChild(i).gameObject, .5f);
                    }

                }
            }
        }
    }
}
