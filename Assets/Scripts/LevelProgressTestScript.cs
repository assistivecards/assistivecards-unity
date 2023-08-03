using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelProgressTestScript : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] TMP_Text levelText;
    [SerializeField] Slider progressBar;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }
    private void OnEnable()
    {
        var level = gameAPI.CalculateLevel(gameAPI.GetExp());
        var minExp = gameAPI.CalculateExp(level);
        var maxExp = gameAPI.CalculateExp(level + 1);
        levelText.text = "Level " + level;

        progressBar.minValue = minExp;
        progressBar.maxValue = maxExp;
        progressBar.value = gameAPI.GetExp();

    }

}
