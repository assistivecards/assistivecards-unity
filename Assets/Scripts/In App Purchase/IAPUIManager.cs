using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class IAPUIManager : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] TMP_InputField availablePacksText;
    [SerializeField] GameObject subsRestoreButton;
    [SerializeField] GameObject promoUniAppRestoreButton;
    [SerializeField] Button subscriptionsScreenPremiumButton;
    [SerializeField] Button subscriptionsScreenMonthlyButton;
    [SerializeField] Button subscriptionsScreenYearlyButton;
    [SerializeField] Button promoScreenPremiumButton;
    [SerializeField] Button promoScreenMonthlyButton;
    [SerializeField] Button promoScreenYearlyButton;
    [SerializeField] Button promoScreenPuchasePremiumButton;


    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Pack> availablePacksArray;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();

        if (Application.productName == "Zumo")
        {
            subsRestoreButton = GameObject.FindObjectsOfType<GameObject>(true).Where(btn => btn.gameObject.name == "subsRestoreButton").FirstOrDefault();
            promoUniAppRestoreButton = GameObject.FindObjectsOfType<GameObject>(true).Where(btn => btn.gameObject.name == "promoUniAppRestoreButton").FirstOrDefault();
        }

        else
        {
            subsRestoreButton = GameObject.FindObjectsOfType<GameObject>(true).Where(btn => btn.gameObject.name == "standaloneSubsRestoreButton").FirstOrDefault();
            promoUniAppRestoreButton = GameObject.FindObjectsOfType<GameObject>(true).Where(btn => btn.gameObject.name == "standalonePromoRestoreButton").FirstOrDefault();
        }


        // if (Application.platform != RuntimePlatform.IPhonePlayer)
        // {
        //     restoreButton.SetActive(false);
        // }
#if UNITY_IOS
        subsRestoreButton.SetActive(true);
        promoUniAppRestoreButton.SetActive(true);
#endif
    }
    private async void Start()
    {

        if (Application.productName == "Zumo")
        {
            subscriptionsScreenPremiumButton = GameObject.FindObjectsOfType<Button>(true).Where(btn => btn.gameObject.name == "subscriptionsScreenPremiumButton").FirstOrDefault();
            promoScreenPremiumButton = GameObject.FindObjectsOfType<Button>(true).Where(btn => btn.gameObject.name == "promoScreenPremiumButton").FirstOrDefault();
            promoScreenPuchasePremiumButton = GameObject.FindObjectsOfType<Button>(true).Where(btn => btn.gameObject.name == "promoScreenPuchasePremiumButton").FirstOrDefault();

            subscriptionsScreenMonthlyButton = GameObject.FindObjectsOfType<Button>(true).Where(btn => btn.gameObject.name == "subscriptionsScreenMonthlyButton").FirstOrDefault();
            subscriptionsScreenYearlyButton = GameObject.FindObjectsOfType<Button>(true).Where(btn => btn.gameObject.name == "subscriptionsScreenYearlyButton").FirstOrDefault();
            promoScreenMonthlyButton = GameObject.FindObjectsOfType<Button>(true).Where(btn => btn.gameObject.name == "promoScreenMonthlyButton").FirstOrDefault();
            promoScreenYearlyButton = GameObject.FindObjectsOfType<Button>(true).Where(btn => btn.gameObject.name == "promoScreenYearlyButton").FirstOrDefault();
        }

        else
        {
            subscriptionsScreenPremiumButton = GameObject.FindObjectsOfType<Button>(true).Where(btn => btn.gameObject.name == "standaloneSubscriptionsScreenPremiumButton").FirstOrDefault();
            promoScreenPremiumButton = GameObject.FindObjectsOfType<Button>(true).Where(btn => btn.gameObject.name == "standalonePromoScreenPremiumButton").FirstOrDefault();
            promoScreenPuchasePremiumButton = GameObject.FindObjectsOfType<Button>(true).Where(btn => btn.gameObject.name == "standalonePromoScreenPuchasePremiumButton").FirstOrDefault();
        }

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
                promoScreenMonthlyButton.interactable = false;
                promoScreenYearlyButton.interactable = false;
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
                promoScreenMonthlyButton.interactable = true;
                promoScreenYearlyButton.interactable = true;
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
