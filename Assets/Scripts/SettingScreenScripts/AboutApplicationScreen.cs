using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AboutApplicationScreen : MonoBehaviour
{
    [SerializeField] private TopAppBarController topAppBarController;

    [Header ("SHARE APP VALUES")]
    [SerializeField] private string appName;
    [SerializeField] private string appDescription;
    [SerializeField] private string appURL;

    [Header ("STORE LINKS")]

    [SerializeField] private string googlePlayLink;
    [SerializeField] private string appleStoreLink;

    [Header ("Screens")]
    [SerializeField] private GameObject aboutCompanyScreen;
    [SerializeField] private GameObject openSourceLicencesScreen;
    [SerializeField] private GameObject privacyPolicyScreen;
    [SerializeField] private GameObject termsOfServiceScreen;
    private SampleWebView sampleWebView;
    
    public void AboutApplicationClick()
    {
        topAppBarController.ChangeTopAppBarType(3);
        aboutCompanyScreen.SetActive(true);
        sampleWebView = aboutCompanyScreen.GetComponentInChildren<SampleWebView>();
        sampleWebView.webViewObject.SetVisibility(true);
    }
    public void ShareThisAppClick()
    {
        StartCoroutine(Share());
    }
    public void RateThisAppClick()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://" + googlePlayLink);
#endif
#if UNITY_IOS
        Application.OpenURL("itms-apps://" + appleStoreLink);
#endif
    }
    public void OpenSourceLicencesClick()
    {
        topAppBarController.ChangeTopAppBarType(3);
        openSourceLicencesScreen.SetActive(true);
        sampleWebView = openSourceLicencesScreen.GetComponentInChildren<SampleWebView>();
        sampleWebView.webViewObject.SetVisibility(true);
    }
    public void PrivacyPolicyClick()
    {
        topAppBarController.ChangeTopAppBarType(3);
        privacyPolicyScreen.SetActive(true);
        sampleWebView = privacyPolicyScreen.GetComponentInChildren<SampleWebView>();
        sampleWebView.webViewObject.SetVisibility(true);
    }
    public void TermsOfServicesClick()
    {
        topAppBarController.ChangeTopAppBarType(3);
        termsOfServiceScreen.SetActive(true);
        sampleWebView = termsOfServiceScreen.GetComponentInChildren<SampleWebView>();
        sampleWebView.webViewObject.SetVisibility(true);
    }
    public void BackButtonClicked()
    {
        sampleWebView.webViewObject.SetVisibility(false);
        topAppBarController.ChangeTopAppBarType(2);

        aboutCompanyScreen.SetActive(false);
        openSourceLicencesScreen.SetActive(false);
        privacyPolicyScreen.SetActive(false);
        termsOfServiceScreen.SetActive(false);
    }

    private IEnumerator Share()
    {
        yield return null;
        new NativeShare().SetSubject( appName ).SetText( appDescription ).SetUrl( appURL ).Share();
    }
}
