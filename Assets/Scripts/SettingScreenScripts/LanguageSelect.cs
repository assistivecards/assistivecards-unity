using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSelect : MonoBehaviour
{
    public void OnLanguageSelected()
    {
        this.transform.GetChild(2).GetComponent<Image>().color = Color.black;
    }

    // select just one button function will be write
    // language page save button interactible control function will be write
    // change all variables names from roundedCheckbox to radioButton :)
}
