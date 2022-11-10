using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using TMPro;
using System.Collections.Generic;

public class IAPManager : MonoBehaviour
{
    private string premium = "com.assistivecards.unity-template.premium";
    [SerializeField] private GameObject restoreButton;
    GameAPI gameAPI;
    [SerializeField] TMP_InputField availablePacksText;
    [SerializeField] List<GameAPI.Pack> availablePacksArray;
    [SerializeField] Button premiumButton;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            restoreButton.SetActive(false);
        }
    }

    private async void Start()
    {
        CheckIfPremiumButtonInteractable();
        await GameAPI.cacheData;
        GetAvailablePacks();

    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == premium)
        {
            gameAPI.SetPremium("A5515T1V3C4RD5");
            CheckIfPremiumButtonInteractable();
            availablePacksArray.Clear();
            availablePacksText.text = "";
            GetAvailablePacks();
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("purchase failed");
    }

    public void GetAvailablePacks()
    {
        if (gameAPI.GetPremium() == "A5515T1V3C4RD5")
        {
            foreach (var pack in gameAPI.cachedPacks.packs)
            {
                availablePacksArray.Add(pack);
            }
        }
        else
        {
            foreach (var pack in gameAPI.cachedPacks.packs)
            {
                if (pack.premium == 0)
                {
                    availablePacksArray.Add(pack);
                }
            }
        }

        foreach (var pack in availablePacksArray)
        {
            availablePacksText.text += pack.slug + "\n";
        }
    }

    public void CheckIfPremiumButtonInteractable()
    {
        if (gameAPI.GetPremium() == "A5515T1V3C4RD5")
        {
            premiumButton.interactable = false;
        }
        else
        {
            premiumButton.interactable = true;
        }
    }
}