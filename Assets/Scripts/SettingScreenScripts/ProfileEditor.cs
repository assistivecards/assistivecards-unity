using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ProfileEditor : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameField;
    [SerializeField] private Button saveButton;

    public void Start()
    {
        nicknameField.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {
        //nickname change 
        
        saveButton.GetComponent<Button>().interactable = true;
    }

}
