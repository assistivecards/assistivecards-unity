using System.Collections;
using System.Collections.Generic;
using Coffee.UISoftMask;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    void Update()
    {
        var rt = transform.GetChild(0).GetComponent<RectTransform>();
        if (rt.offsetMax.y < 1f)
            gameObject.GetComponent<SoftMask>().enabled = false;
        else
            gameObject.GetComponent<SoftMask>().enabled = true;
    }
}
