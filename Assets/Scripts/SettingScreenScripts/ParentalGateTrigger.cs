using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentalGateTrigger : MonoBehaviour
{
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject parentLockScreen;
    [SerializeField] private GameObject popUp;

    private void OnEnable()
    {
        LeanTween.scale(popUp,  Vector3.one, 0.15f);
        parentLockScreen.SetActive(true);
        buttons.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 2023f, 0);
    }
}
