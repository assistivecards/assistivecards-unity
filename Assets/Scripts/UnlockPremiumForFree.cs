using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnlockPremiumForFree : MonoBehaviour, IPointerClickHandler
{
    private GameAPI gameAPI;
    int counter = 0;
    private IAPUIManager IAPUIManager;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        IAPUIManager = GameObject.Find("IAP").GetComponent<IAPUIManager>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (counter < 9)
        {
            counter++;
        }

        else if (counter == 9)
        {
            if (gameAPI.GetPremium() != "A5515T1V3C4RD5")
            {
                gameAPI.SetPremium("A5515T1V3C4RD5");
                IAPUIManager.CheckIfPremiumButtonInteractable();
                IAPUIManager.ResetAvailablePacks();
            }
        }
    }

}
