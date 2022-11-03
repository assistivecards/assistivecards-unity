using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SubscriptionsPanel : MonoBehaviour
{
    [SerializeField] private string moneyType;
    private string selectedPackage;
    [SerializeField] private float monthlyPremiumPrice;
    [SerializeField] private float yearlyPremiumPrice;
    [SerializeField] private float lifetimePremiumPrice;
    [SerializeField] private TMP_Text monthlyPremiumPriceText;
    [SerializeField] private TMP_Text yearlyPremiumPriceText;
    [SerializeField] private TMP_Text lifetimePremiumPriceText;
    private GameObject button;


    private void Start() 
    {
        monthlyPremiumPriceText.text = moneyType + monthlyPremiumPrice.ToString();
        yearlyPremiumPriceText.text = moneyType + yearlyPremiumPrice.ToString();
        lifetimePremiumPriceText.text = moneyType + lifetimePremiumPrice.ToString();
    }

    public void MonthlyPremiumSelected()
    {
        selectedPackage = "monthly";
        //monthly selected
        Debug.Log(selectedPackage);
    }

    public void YearlyPremiumSelected()
    {
        selectedPackage = "yearly";
        //yearly selected
        Debug.Log(selectedPackage);
    }

    public void LifetimePremiumSelected()
    {
        selectedPackage = "lifetime";
        //lifetime selected
        Debug.Log(selectedPackage);
    }
}
