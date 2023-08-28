using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnboardingBackgroundController : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite background1;
    [SerializeField] private Sprite background2;
    [SerializeField] private Sprite background3;

    public void BackgroundAvailable()
    {
        backgroundImage.enabled = true;
    }

    public void BackgroundDisable()
    {
        backgroundImage.enabled = false;
    }
    
    public void SetBackground1()
    {
        backgroundImage.sprite = background1;
    }

    public void SetBackground2()
    {
        backgroundImage.sprite = background2;
    }

    public void SetBackground3()
    {
        backgroundImage.sprite = background3;
    }
}
