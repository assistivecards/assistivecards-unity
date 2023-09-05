using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremiumPromoScreen : MonoBehaviour
{
    [SerializeField] private GameObject premiumPromoContent;

    private void OnEnable()
    {
        premiumPromoContent.GetComponent<RectTransform>().anchoredPosition = new Vector3(442f, 1719f, 0);
    }
}
