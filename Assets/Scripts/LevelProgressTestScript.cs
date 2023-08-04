using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelProgressTestScript : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text levelUpText;
    [SerializeField] Slider progressBar;
    [SerializeField] int levelOnDisable;
    [SerializeField] int levelOnEnable;
    [SerializeField] ParticleSystem confetti;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        levelOnDisable = gameAPI.levelOnStart;
    }

    private void OnEnable()
    {
        levelOnEnable = gameAPI.CalculateLevel(gameAPI.GetExp());
        var minExp = gameAPI.CalculateExp(levelOnEnable);
        var maxExp = gameAPI.CalculateExp(levelOnEnable + 1);
        levelText.text = "Level " + levelOnEnable;

        progressBar.minValue = minExp;
        progressBar.maxValue = maxExp;

        if (transform.parent.name == "LevelChangeScreen")
        {
            LeanTween.value(gameObject, progressBar.value, gameAPI.GetExp(), .5f).setOnUpdate((float val) => { progressBar.value = val; });
        }
        else
        {
            progressBar.value = gameAPI.GetExp();
        }

        if (levelOnEnable > levelOnDisable && transform.parent.name == "LevelChangeScreen")
        {
            Debug.Log("LEVEL UP!");
            gameObject.GetComponent<Animation>().Play();
            confetti.Play();
        }


    }

    private void OnDisable()
    {
        levelOnDisable = gameAPI.CalculateLevel(gameAPI.GetExp());
        gameObject.GetComponent<Animation>().Stop();
        confetti.Stop();
        LeanTween.value(levelText.alpha, 1, .0001f).setOnUpdate((float val) => { levelText.alpha = val; });
        LeanTween.value(levelUpText.alpha, 0, .0001f).setOnUpdate((float val) => { levelUpText.alpha = val; });
    }

}
