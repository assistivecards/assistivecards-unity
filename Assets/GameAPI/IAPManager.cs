using UnityEngine;
using UnityEngine.Purchasing;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class IAPManager : MonoBehaviour
{
    private string premium = "com.assistivecards.unity-template.premium";
    [SerializeField] private GameObject restoreButton;
    [SerializeField] TMP_Text isPremiumText;
    int isPremium = 0;


    private void Awake()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            restoreButton.SetActive(false);
        }
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == premium && isPremium != 1)
        {
            isPremium = 1;
            isPremiumText.text = "isPremium: " + isPremium;
        }
        else
        {
            Debug.Log("already bought.");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("purchase failed. Reason: " + reason);
    }
}
