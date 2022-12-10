using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreenPositioning : MonoBehaviour
{
    [SerializeField] private GameObject premiumPromoButton;
    private Resolution[] resolutions;
    private float resolution;

     private void Start() 
    {
        resolutions = Screen.resolutions;

        foreach (var res in resolutions)
        {
            if(res.width > res.height)
            {
                resolution = Mathf.Abs(res.width / res.height);
            }
            else if(res.height > res.width)
            {
                resolution = Mathf.Abs(res.height / res.width);
            }
        }

        if(resolution < 1.25f)
        {

            premiumPromoButton.GetComponent<RectTransform>().LeanSetPosY(120);
        }
        else if(resolution > 1.25)
        {
            premiumPromoButton.GetComponent<RectTransform>().LeanSetPosY(-100);
        }
    }
}
