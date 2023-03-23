using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TrailRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            || Input.GetMouseButton(0)))
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
