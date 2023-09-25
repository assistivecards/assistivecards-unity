using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using System;
using TMPro;
using UnityEngine.Purchasing.Extension;
using System.Linq;
using System.Globalization;

public class IAPManager : MonoBehaviour, IDetailedStoreListener
{
    private string premium;
    private string monthly;
    private string yearly;

    GameAPI gameAPI;
    [SerializeField] TMP_Text subscriptionsScreenPrice;
    [SerializeField] TMP_Text subscriptionsScreenMonthlyPrice;
    [SerializeField] TMP_Text subscriptionsScreenYearlyPrice;
    [SerializeField] TMP_Text promoScreenPrice;
    [SerializeField] TMP_Text promoScreenMonthlyPrice;
    [SerializeField] TMP_Text promoScreenYearlyPrice;
    [SerializeField] TMP_Text promoScreenPuchasePrice;

    [SerializeField] IAPUIManager IAPUIManager;

    public string environment = "development";

    public IStoreController m_StoreController;          // The Unity Purchasing system.
    private IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.
    [SerializeField] GameObject purchaseRestoredPanel;

    private bool restored = false;
    private static bool isSubscriptionChecked = false;

    private void Awake()
    {
        premium = Application.productName.Replace(" ", "_").ToLower(new CultureInfo("en-US", false)) + "_iap";
        monthly = "zumo_monthly";
        yearly = "zumo_yearly";
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private async void Start()
    {
        try
        {
            var options = new InitializationOptions()
                .SetEnvironmentName(environment);

            await UnityServices.InitializeAsync(options);
        }
        catch (Exception exception)
        {
            Debug.Log("An error occurred during initialization: " + exception);
        }
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }

        foreach (UnityEngine.Purchasing.Product item in m_StoreController.products.all)
        {
            Debug.Log(item.definition.id);
        }

        if (Application.productName == "Zumo")
        {
            subscriptionsScreenPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "subscriptionsScreenPrice").FirstOrDefault();
            promoScreenPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "promoScreenPrice").FirstOrDefault();
            promoScreenPuchasePrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "promoScreenPuchasePrice").FirstOrDefault();

            subscriptionsScreenMonthlyPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "subscriptionsScreenMonthlyPrice").FirstOrDefault();
            subscriptionsScreenYearlyPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "subscriptionsScreenYearlyPrice").FirstOrDefault();
            promoScreenMonthlyPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "promoScreenMonthlyPrice").FirstOrDefault();
            promoScreenYearlyPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "promoScreenYearlyPrice").FirstOrDefault();
        }

        else
        {
            subscriptionsScreenPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "standaloneSubscriptionsScreenPrice").FirstOrDefault();
            promoScreenPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "standalonePromoScreenPrice").FirstOrDefault();
            promoScreenPuchasePrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "standalonePromoScreenPuchasePrice").FirstOrDefault();
        }

        if (Application.productName == "Zumo")
        {
            subscriptionsScreenPrice.text = m_StoreController.products.WithID(premium).metadata.localizedPriceString;
            promoScreenPrice.text = m_StoreController.products.WithID(premium).metadata.localizedPriceString;
            promoScreenPuchasePrice.text = m_StoreController.products.WithID(premium).metadata.localizedPriceString;

            subscriptionsScreenMonthlyPrice.text = m_StoreController.products.WithID(monthly).metadata.localizedPriceString;
            subscriptionsScreenYearlyPrice.text = m_StoreController.products.WithID(yearly).metadata.localizedPriceString;
            promoScreenMonthlyPrice.text = m_StoreController.products.WithID(monthly).metadata.localizedPriceString;
            promoScreenYearlyPrice.text = m_StoreController.products.WithID(yearly).metadata.localizedPriceString;
        }

        else
        {
            subscriptionsScreenPrice.text = m_StoreController.products.WithID(premium).metadata.localizedPriceString;
            promoScreenPrice.text = m_StoreController.products.WithID(premium).metadata.localizedPriceString;
            promoScreenPuchasePrice.text = m_StoreController.products.WithID(premium).metadata.localizedPriceString;
        }

    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(premium, ProductType.NonConsumable);

        if (Application.productName == "Zumo")
        {
            builder.AddProduct(monthly, ProductType.Subscription);
            builder.AddProduct(yearly, ProductType.Subscription);
        }

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void BuyNonConsumable()
    {
        BuyProductID(premium);
    }

    public void BuyMonthlySubscription()
    {
        BuyProductID(monthly);
    }

    public void BuyYearlySubscription()
    {
        BuyProductID(yearly);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result, error) =>
            {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");

                if (result)
                {
                    if (restored == false)
                    {
                        purchaseRestoredPanel.SetActive(true);
                        restored = true;
                    }
                }

                else
                {
                    Debug.Log(error);
                }

            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");

        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;


        if (Application.productName == "Zumo")
        {
            if (!isSubscriptionChecked)
            {
                if (gameAPI.GetPremium() == "0")
                {
                    if (CheckSubscription(monthly) || CheckSubscription(yearly))
                    {
                        gameAPI.SetSubscription("A5515T1V3C4RD5");
                    }
                    else
                    {
                        gameAPI.SetSubscription("0");
                    }
                    isSubscriptionChecked = true;
                }
            }

        }

        IAPUIManager.CheckIfPremiumButtonInteractable();

        if (Application.productName == "Zumo")
        {
            subscriptionsScreenPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "subscriptionsScreenPrice").FirstOrDefault();
            promoScreenPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "promoScreenPrice").FirstOrDefault();
            promoScreenPuchasePrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "promoScreenPuchasePrice").FirstOrDefault();

            subscriptionsScreenMonthlyPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "subscriptionsScreenMonthlyPrice").FirstOrDefault();
            subscriptionsScreenYearlyPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "subscriptionsScreenYearlyPrice").FirstOrDefault();
            promoScreenMonthlyPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "promoScreenMonthlyPrice").FirstOrDefault();
            promoScreenYearlyPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "promoScreenYearlyPrice").FirstOrDefault();
        }

        else
        {
            subscriptionsScreenPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "standaloneSubscriptionsScreenPrice").FirstOrDefault();
            promoScreenPrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "standalonePromoScreenPrice").FirstOrDefault();
            promoScreenPuchasePrice = GameObject.FindObjectsOfType<TMP_Text>(true).Where(txt => txt.gameObject.name == "standalonePromoScreenPuchasePrice").FirstOrDefault();
        }

        if (Application.productName == "Zumo")
        {
            subscriptionsScreenPrice.text = m_StoreController.products.WithID(premium).metadata.localizedPriceString;
            promoScreenPrice.text = m_StoreController.products.WithID(premium).metadata.localizedPriceString;
            promoScreenPuchasePrice.text = m_StoreController.products.WithID(premium).metadata.localizedPriceString;

            subscriptionsScreenMonthlyPrice.text = m_StoreController.products.WithID(monthly).metadata.localizedPriceString;
            subscriptionsScreenYearlyPrice.text = m_StoreController.products.WithID(yearly).metadata.localizedPriceString;
            promoScreenMonthlyPrice.text = m_StoreController.products.WithID(monthly).metadata.localizedPriceString;
            promoScreenYearlyPrice.text = m_StoreController.products.WithID(yearly).metadata.localizedPriceString;
        }

        else
        {
            subscriptionsScreenPrice.text = m_StoreController.products.WithID(premium).metadata.localizedPriceString;
            promoScreenPrice.text = m_StoreController.products.WithID(premium).metadata.localizedPriceString;
            promoScreenPuchasePrice.text = m_StoreController.products.WithID(premium).metadata.localizedPriceString;
        }

    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {

        if (String.Equals(args.purchasedProduct.definition.id, premium, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            gameAPI.SetPremium("A5515T1V3C4RD5");
            IAPUIManager.CheckIfPremiumButtonInteractable();
            IAPUIManager.StartCoroutine("PlayParticles");
            IAPUIManager.ResetAvailablePacks();
        }

        else if (String.Equals(args.purchasedProduct.definition.id, monthly, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            gameAPI.SetSubscription("A5515T1V3C4RD5");
            IAPUIManager.CheckIfPremiumButtonInteractable();
            IAPUIManager.StartCoroutine("PlayParticles");
        }

        else if (String.Equals(args.purchasedProduct.definition.id, yearly, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            gameAPI.SetSubscription("A5515T1V3C4RD5");
            IAPUIManager.CheckIfPremiumButtonInteractable();
            IAPUIManager.StartCoroutine("PlayParticles");
        }

        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }

    bool CheckSubscription(string id)
    {

        var subscriptionProduct = m_StoreController.products.WithID(id);

        if (subscriptionProduct != null)
        {

            try
            {
                if (subscriptionProduct.hasReceipt)
                {
                    var subscriptionManager = new SubscriptionManager(subscriptionProduct, null);
                    var info = subscriptionManager.getSubscriptionInfo();

                    if (info.isSubscribed() == Result.True)
                    {

                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }

                else
                {
                    Debug.Log("Receipt not found.");
                    return false;
                }
            }
            catch (System.Exception)
            {

                Debug.Log("Platform not supported. Unity Fake Store");
                return false;
            }

        }

        else
        {
            Debug.Log("Product not found.");
            return false;
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureDescription));
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }
}
