using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailManager : MonoBehaviour
{
    private int ropeIndex;
    private Transform hitRope;
    [SerializeField] RopeCutManager ropeCutManager;
    [SerializeField] Button settingsButton;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TrailRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)))
            {
                gameObject.GetComponent<TrailRenderer>().enabled = true;
                Plane objPlane = new Plane(Camera.main.transform.forward * -1, new Vector3(transform.position.x, transform.position.y, transform.position.z));

                Ray mRay = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.y));

                float rayDistance;
                if (objPlane.Raycast(mRay, out rayDistance))
                    transform.position = mRay.GetPoint(rayDistance);
            }
            else
            {
                gameObject.GetComponent<TrailRenderer>().enabled = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rope" && ropeCutManager.canCut)
        {
            ropeCutManager.canCut = false;
            // LeanTween.alpha(gameObject, 0, .25f);
            // gameObject.SetActive(false);
            hitRope = other.transform.parent;
            LeanTween.alpha(other.gameObject, 0, .15f);
            Destroy(other.gameObject, .15f);

            ropeIndex = other.transform.GetSiblingIndex();

            for (int i = ropeIndex; i < hitRope.childCount; i++)
            {
                LeanTween.alpha(hitRope.GetChild(i).gameObject, 0, .25f).setDelay(.25f);
                Destroy(hitRope.GetChild(i).gameObject, .5f);
            }

            settingsButton.interactable = false;
        }
    }
}
