using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackSelectionScreenUIController : MonoBehaviour
{
    GameAPI gameAPI;
    public bool canGenerate;
    [SerializeField] PackSelectionPanel packSelectionPanelScript;
    [SerializeField] GameObject fadeInPanel;
    [SerializeField] GameObject settingButton;
    [SerializeField] CanvasController canvasController;
    [SerializeField] GameObject packSelectionPanel;






    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();

    }
    private void OnEnable()
    {
        OpenPackPanelTween();
    }

    public void OpenPackPanelTween()
    {
        LeanTween.scale(this.gameObject, Vector3.one, 0.1f);
    }

    public void ClosePackPanelTween()
    {
        if (canGenerate)
        {
            LeanTween.scale(this.gameObject, Vector3.zero, 0.25f);
            Invoke("ClosePackPanel", 0.5f);
        }
    }

    private void ClosePackPanel()
    {
        this.gameObject.SetActive(false);
    }

    public async void OnPackSelect()
    {
        if (gameAPI.GetPremium() == "A5515T1V3C4RD5" || gameAPI.GetSubscription() == "A5515T1V3C4RD5")
        {
            canGenerate = true;
        }
        else
        {
            for (int i = 0; i < gameAPI.cachedPacks.packs.Length; i++)
            {
                if (gameAPI.cachedPacks.packs[i].slug == packSelectionPanelScript.selectedPackElement.name)
                {
                    if (gameAPI.cachedPacks.packs[i].premium == 1)
                    {
                        Debug.Log("Seçilen paket premium");
                        canGenerate = false;
                        // canvasController.GetComponent<CanvasController>().StartFadeAnim();
                        fadeInPanel.SetActive(true);
                        settingButton.GetComponent<SettingScreenButton>().SettingButtonClickFunc();
                        canvasController.GetComponent<CanvasController>().PremiumPromoButtonClick();
                        Invoke("ResetScrollPosition", 0.3f);

                    }
                    else
                    {
                        canGenerate = true;
                        // GenerateCorrespondingRandomBoard();
                    }

                }
            }
        }
    }

    public void ResetScrollPosition()
    {
        var rt = packSelectionPanel.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(rt.offsetMax.x, 0);
    }
}
