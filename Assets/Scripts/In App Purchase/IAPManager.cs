using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string premium = "com.assistivecards.unity-template.premium";

    GameAPI gameAPI;
    [SerializeField] IAPUIManager IAPUIManager;


    [SerializeField] private Text currencySymbol;
    private IStoreController m_StoreController;
    private IExtensionProvider m_StoreExtensionProvider;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;

        foreach (var product in controller.products.all)
        {
            Debug.Log(product.metadata.localizedPriceString);

            Debug.Log(string.Format("string: {0}", product.metadata.localizedPriceString));

            Debug.Log(string.Format("decimal: {0}", product.metadata.localizedPrice.ToString()));

            currencySymbol.text = string.Format("decimal: {0}", product.metadata.localizedPrice.ToString());
        }
    }


    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == premium)
        {
            gameAPI.SetPremium("A5515T1V3C4RD5");
            IAPUIManager.CheckIfPremiumButtonInteractable();
            IAPUIManager.ResetAvailablePacks();
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("purchase failed");
    }
}