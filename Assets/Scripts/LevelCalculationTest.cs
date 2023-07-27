using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LevelCalculationTest : MonoBehaviour
{
    [SerializeField] TMP_InputField levelInputField;
    [SerializeField] TMP_InputField expResultField;
    [SerializeField] TMP_InputField expInputField;
    [SerializeField] TMP_InputField levelResultField;
    [SerializeField] TMP_InputField fromInputField;
    [SerializeField] TMP_InputField toInputField;
    [SerializeField] TMP_InputField differenceResultField;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = gameObject.GetComponent<GameAPI>();
    }


    public void CalculateLevelFromExp()
    {
        levelResultField.text = gameAPI.CalculateLevel(Int32.Parse(expInputField.text)).ToString();
    }

    public void CalculateExpFromLevel()
    {
        expResultField.text = gameAPI.CalculateExp(Int32.Parse(levelInputField.text)).ToString();
    }

    public void CalculateExpBetweenLevels()
    {
        if (Int32.Parse(toInputField.text) > Int32.Parse(fromInputField.text))
        {
            differenceResultField.text = (gameAPI.CalculateExp(Int32.Parse(toInputField.text)) - gameAPI.CalculateExp(Int32.Parse(fromInputField.text))).ToString();
        }
    }

}
