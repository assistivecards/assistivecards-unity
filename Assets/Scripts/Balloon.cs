using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Balloon : MonoBehaviour, IPointerClickHandler
{
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<Animator>().enabled = true;
        gameAPI.PlaySFX("Pop");
        gameAPI.VibrateWeak();
        Destroy(gameObject, .5f);
    }
}
