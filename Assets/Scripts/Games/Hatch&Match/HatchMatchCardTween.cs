using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchMatchCardTween : MonoBehaviour
{
    private void OnEnable() 
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.5f, 0.5f);
    }
}
