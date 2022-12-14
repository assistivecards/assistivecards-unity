using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RightToLeftTextChanger : MonoBehaviour
{
    [Header ("Rotate")]
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject gamePanel;

    [Header ("Not Rotate")]
    [SerializeField] private GameObject nameText;
    [SerializeField] private GameObject deviceLanguageList;
    [SerializeField] private GameObject supportedLanguageList;
    [SerializeField] private GameObject TTS;
    [SerializeField] private GameObject nicknameInput;
    [SerializeField] private GameObject loginNicknameInput;
    private TMP_Text[] tMP_Texts;

    private void Start()
    {
        if(PlayerPrefs.GetString("Language", "") == "Arabic" || PlayerPrefs.GetString("Language", "") == "Urdu")
        {
            RightToLeftLangugeChanged();
            Debug.Log("!");
        }
    }
    public void RightToLeftLangugeChanged()
    {
        panel.GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);
        gamePanel.GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);

        nameText.GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);
        deviceLanguageList.GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);
        supportedLanguageList.GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);
        TTS.GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);
        nicknameInput.GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);
        loginNicknameInput.GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);
        // tMP_Texts = this.GetComponentsInChildren<TMP_Text> ();

        // foreach(TMP_Text tMP_Text in tMP_Texts)
        // {
        //     tMP_Text.isRightToLeftText = true;
        // }
    }

    public void LeftToRightLanguageChanged()
    {
        panel.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        gamePanel.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);

        nameText.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        deviceLanguageList.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        supportedLanguageList.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        TTS.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        nicknameInput.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        loginNicknameInput.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        // tMP_Texts = this.GetComponentsInChildren<TMP_Text> ();

        // foreach(TMP_Text tMP_Text in tMP_Texts)
        // {
        //     tMP_Text.isRightToLeftText = false;
        // }
    }
}
