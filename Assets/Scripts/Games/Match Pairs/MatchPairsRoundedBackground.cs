using System.Collections;
using System.Collections.Generic;
using Nobi.UiRoundedCorners;
using UnityEngine;

public class MatchPairsRoundedBackground : MonoBehaviour
{

    public void DetermineCornerRoundness()
    {
        var roundedCornerScript = transform.GetChild(0).GetComponent<ImageWithIndependentRoundedCorners>();
        var rectTransform = transform.GetChild(1).GetComponent<RectTransform>();

        if (transform.GetChild(1).name.Contains("0"))
        {
            roundedCornerScript.r = new Vector4(20, 0, 0, 20);
            roundedCornerScript.Validate();
            roundedCornerScript.Refresh();

            rectTransform.offsetMin = new Vector2(10, 10);
            rectTransform.offsetMax = new Vector2(0, -10);
        }

        else if (transform.GetChild(1).name.Contains("1"))
        {
            roundedCornerScript.r = new Vector4(0, 20, 20, 0);
            roundedCornerScript.Validate();
            roundedCornerScript.Refresh();

            rectTransform.offsetMin = new Vector2(0, 10);
            rectTransform.offsetMax = new Vector2(-10, -10);
        }
    }


}
