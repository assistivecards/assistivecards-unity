using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IAPUIManager : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] TMP_InputField availablePacksText;
    [SerializeField] private GameObject restoreButton;
    [SerializeField] Button subscriptionsScreenPremiumButton;
    [SerializeField] Button subscriptionsScreenMonthlyButton;
    [SerializeField] Button subscriptionsScreenYearlyButton;
    [SerializeField] Button promoScreenPremiumButton;
    [SerializeField] Button promoScreenPuchasePremiumButton;


    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Pack> availablePacksArray;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();

        // if (Application.platform != RuntimePlatform.IPhonePlayer)
        // {
        //     restoreButton.SetActive(false);
        // }
#if UNITY_IOS
        restoreButton.SetActive(true);
#endif
    }
    private async void Start()
    {
        CheckIfPremiumButtonInteractable();
        await GameAPI.cachePacks;
        GetAvailablePacks();
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
        if (gameAPI.GetPremium() == "A5515T1V3C4RD5" || gameAPI.GetSubscription() == "A5515T1V3C4RD5")
        {
            subscriptionsScreenPremiumButton.interactable = false;
            if (subscriptionsScreenMonthlyButton != null)
            {
                subscriptionsScreenMonthlyButton.interactable = false;
                subscriptionsScreenYearlyButton.interactable = false;
            }

            promoScreenPremiumButton.interactable = false;
            promoScreenPuchasePremiumButton.interactable = false;
        }
        else
        {
            subscriptionsScreenPremiumButton.interactable = true;
            if (subscriptionsScreenMonthlyButton != null)
            {
                subscriptionsScreenMonthlyButton.interactable = true;
                subscriptionsScreenYearlyButton.interactable = true;
            }
            promoScreenPremiumButton.interactable = true;
            promoScreenPuchasePremiumButton.interactable = true;
        }
    }

    public void ResetAvailablePacks()
    {
        availablePacksArray.Clear();
        availablePacksText.text = "";
        GetAvailablePacks();
    }
}
