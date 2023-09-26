using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchManager : MonoBehaviour
{
    public bool isFullyScratched = false;
    public float scratchThreshold;

    public void GetStatsInfo()
    {
        var data = gameObject.GetComponent<ScratchImage>().GetStatData();
        if (data.fillPercent >= scratchThreshold)
        {
            isFullyScratched = true;
            gameObject.GetComponent<ScratchImage>().enabled = false;
            LeanTween.alpha(transform.GetChild(0).GetComponent<RectTransform>(), 0, .25f);
            LeanTween.alpha(transform.GetChild(1).GetComponent<RectTransform>(), 0, .25f);
            Debug.Log("Fully Scratched!");
        }
    }
}
