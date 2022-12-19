using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelController : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    private Resolution[] resolutions;
    private float resolution;
    private void Start() 
    {
        resolutions = Screen.resolutions;

        // Print the resolutions
        foreach (var res in resolutions)
        {
            if(res.width > res.height)
            {
                resolution = Mathf.Abs(res.width / res.height);
                Debug.Log(resolution);
            }
            else if(res.height > res.width)
            {
                resolution = Mathf.Abs(res.height / res.width);
                Debug.Log(resolution);
            }
        }

        if(resolution < 1.25f)
        {
            //gamePanel.GetComponent<RectTransform>().LeanScale(Vector3.one * 0.80f, 0.01f);
        }
    }

}
