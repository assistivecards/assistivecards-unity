using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleCardWordHunt : MonoBehaviour
{
    public string cardName;

    public void ScaleUp()
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.8f, 0.5f).setOnComplete(ScaleDown);
    }

    public void ScaleDown()
    {
        LeanTween.scale(this.gameObject, Vector3.zero, 0.25f);
    }
}
