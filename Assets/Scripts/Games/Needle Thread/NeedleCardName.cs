using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleCardName : MonoBehaviour
{
    public string cardName;

    public void ScaleDownCrad()
    {
        LeanTween.scale(this.gameObject, Vector3.zero, 0.4f);
    }

    // private void DestroyCard()
    // {
    //     Destroy(this.gameObject);
    // }
}
