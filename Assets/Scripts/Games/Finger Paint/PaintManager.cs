using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour
{
    public bool isFullyColorized = false;
    public float paintThreshold;

    public void GetStatsInfo()
    {
        var data = gameObject.GetComponent<PaintImage>().GetStatData();
        // Debug.Log(gameObject.name + " " + data.fillPercent);
        if (data.fillPercent >= paintThreshold)
        {
            isFullyColorized = true;
            gameObject.GetComponent<PaintImage>().enabled = false;
            LeanTween.alpha(transform.GetChild(0).GetComponent<RectTransform>(), 0, .25f);
            Debug.Log("Fully Colorized!");
        }
    }
}
