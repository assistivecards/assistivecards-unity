using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMemory : MonoBehaviour
{
    private Tutorial tutorial;

    private void Awake() 
    {
        tutorial = GetComponent<Tutorial>();
    }

    private void OnEnable() 
    {
        Invoke("Relocate", 1f);
    }

    private void Relocate()
    {
        LeanTween.moveLocal(this.gameObject, new Vector3(-395, -190, 0), 0);
    }
}
