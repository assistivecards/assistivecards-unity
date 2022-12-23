using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private void OnEnable()
    {
        Camera.main.transform.GetChild(0).GetComponent<AudioSource>().Pause();
    }
    private void OnDisable()
    {
        Camera.main.transform.GetChild(0).GetComponent<AudioSource>().Play();
    }
}
