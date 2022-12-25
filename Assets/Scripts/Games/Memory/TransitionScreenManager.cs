using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScreenManager : MonoBehaviour
{
    [SerializeField] public Slider loadingBar;
    private float fillspeed = 0.2f;
    private float targetProgress = 0;

    private void OnEnable() 
    {
        loadingBar.value = 0;
    }

    private void Update()
    {
        if(loadingBar.value < targetProgress)
        loadingBar.value += fillspeed * Time.deltaTime;
    }

    public void IncrementProgress(float newProgess)
    {
        targetProgress = loadingBar.value + newProgess;
    }
}
