using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchManager : MonoBehaviour
{
    public bool isFullyScratched = false;

    public void GetStatsInfo()
    {
        var data = gameObject.GetComponent<ScratchImage>().GetStatData();
        Debug.Log(gameObject.name + " " + data.fillPercent);
        if (data.fillPercent == 1f)
        {
            isFullyScratched = true;
            Debug.Log("Fully Scratched!");
        }
    }
}
