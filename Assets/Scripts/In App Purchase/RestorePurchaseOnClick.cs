using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestorePurchaseOnClick : MonoBehaviour
{
    [SerializeField] IAPManager IAPManager;
    void Start()
    {
        IAPManager = GameObject.Find("IAP").GetComponent<IAPManager>();
        gameObject.GetComponent<Button>().onClick.AddListener(() => IAPManager.RestorePurchases());
    }

}
