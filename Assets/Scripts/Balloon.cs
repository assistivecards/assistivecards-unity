using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        gameObject.GetComponent<Image>().raycastTarget = false;
        gameAPI.PlaySFX("Pop");
        gameAPI.VibrateWeak();
        Destroy(gameObject, .5f);
    }
}
