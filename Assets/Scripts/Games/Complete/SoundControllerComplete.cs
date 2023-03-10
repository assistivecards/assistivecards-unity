using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerComplete : MonoBehaviour
{
    GameAPI gameAPI;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start() 
    {
        gameAPI.PlayMusic();
    }
}
