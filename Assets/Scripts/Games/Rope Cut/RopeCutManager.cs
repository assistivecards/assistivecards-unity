using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeCutManager : MonoBehaviour
{
    private int ropeIndex;
    private Transform hitRope;
    public bool canCut = true;
    [SerializeField] GameObject trailManager;
    [SerializeField] Button settingsButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Rope" && canCut)
                    {
                        canCut = false;
                        // LeanTween.alpha(trailManager, 0, .25f);
                        // trailManager.SetActive(false);
                        hitRope = hit.collider.transform.parent;
                        LeanTween.alpha(hit.collider.gameObject, 0, .15f);
                        Destroy(hit.collider.gameObject, .15f);

                        ropeIndex = hit.transform.GetSiblingIndex();

                        for (int i = ropeIndex; i < hitRope.childCount; i++)
                        {
                            LeanTween.alpha(hitRope.GetChild(i).gameObject, 0, .25f).setDelay(.25f);
                            Destroy(hitRope.GetChild(i).gameObject, .5f);
                        }

                        settingsButton.interactable = false;
                    }
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                // LeanTween.alpha(trailManager, 1, .00001f);
                // trailManager.SetActive(true);
                canCut = true;
            }
        }
    }
}
