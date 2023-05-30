using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerCardChain : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private Tutorial tutorial;
    [SerializeField] private AccessibilityScreen accessibilityScreen;
    [SerializeField] private BoardGenerateCardChain boardGenerateCardChain;

    public GameObject cardPosition;
    public GameObject cardPosition1;
    [SerializeField] private GameObject levelChangeScreen;
    [SerializeField] private GameObject packSelectionScreen;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject selectNewPackButton;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject tutorialGameObject;
    public int loopCount = 0;

    public bool firstTime = true;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void TutorialActive()
    {
        if(firstTime || gameAPI.GetTutorialPreference() == 1)
        {
            tutorial.tutorialPosition = cardPosition.transform;
            tutorialGameObject.SetActive(true);
        }
        firstTime = false;
    }

    public void TutorialLoopPosition()
    {
        loopCount = 0;
        if(cardPosition != null && cardPosition1 != null)
        {
            tutorial.GetComponent<TutorialCardChain>().point1 = cardPosition.transform;
            tutorial.GetComponent<TutorialCardChain>().point2 = cardPosition1.transform;
        }
        else
        {
            foreach(var card in boardGenerateCardChain.cards)
            {
                if(card != null)
                {
                    if(loopCount == 0)
                    {
                        if(tutorial.GetComponent<TutorialCardChain>().point1 == null)
                        {
                            tutorial.GetComponent<TutorialCardChain>().point1 = card.transform;
                        }
                    }
                    if(loopCount >= 1)
                    {
                        tutorial.GetComponent<TutorialCardChain>().point2 = card.transform;
                        break;
                    }
                    loopCount ++;
                }
            }
            Debug.Log("HERE");
        }
    }


    public void InGameBar()
    {
        backButton.SetActive(true);
        helloText.SetActive(false);
        settingButton.SetActive(true);
        levelChangeScreen.SetActive(false);
    }

    public void PackSelectionActive()
    {
        ResetScroll();
        helloText.SetActive(true);
        settingButton.SetActive(true);
        backButton.SetActive(false);
        packSelectionScreen.SetActive(true);
        levelChangeScreen.SetActive(false);
    }

    public void LevelChangeActive()
    {
        settingButton.SetActive(false);
        backButton.SetActive(false);
        helloText.SetActive(false);
        levelChangeScreen.SetActive(true);
        LeanTween.scale(levelChangeScreen, Vector3.one * 0.6f, 0.5f);
    }

    public void CloseLevelChange()
    {
        LeanTween.scale(levelChangeScreen, Vector3.zero, 0.25f);
        Invoke("ResetLevelChangeScreen", 0.15f);
    }

    private void ResetLevelChangeScreen()
    {
        LeanTween.scale(selectNewPackButton, Vector3.one, 0.15f);
        LeanTween.scale(continueButton, Vector3.one, 0.15f);
    }

    public void ResetScroll()
    {
        packSelectionScreen.transform.GetChild(0).GetChild(0).GetChild(0).transform.localPosition = Vector3.zero;
    }
}
