using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SendFeedbackPage : MonoBehaviour
{
    [SerializeField] private GameObject dropDownMenu;
    public void MenuButtonClick()
    {
        if(dropDownMenu.activeInHierarchy)
        {
            dropDownMenu.SetActive(false);
        }
        else
        {
            dropDownMenu.SetActive(true);
        }
    }
}
