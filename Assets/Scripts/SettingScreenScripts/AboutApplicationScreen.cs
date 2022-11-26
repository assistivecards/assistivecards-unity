using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AboutApplicationScreen : MonoBehaviour
{
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
        #elif UNITY_IPHONE
        Application.OpenURL("itms-apps://" + appleStoreLink);
        #endif
    }
    public void OpenSourceLicencesClick()
    {
        openSourceLicencesScreen.SetActive(true);
        sampleWebView = openSourceLicencesScreen.GetComponentInChildren<SampleWebView>();
        sampleWebView.webViewObject.SetVisibility(true);
    }
    public void PrivacyPolicyClick()
    {
        privacyPolicyScreen.SetActive(true);
        sampleWebView = privacyPolicyScreen.GetComponentInChildren<SampleWebView>();
        sampleWebView.webViewObject.SetVisibility(true);
    }
    public void TermsOfServicesClick()
    {
        termsOfServiceScreen.SetActive(true);
        sampleWebView = termsOfServiceScreen.GetComponentInChildren<SampleWebView>();
        sampleWebView.webViewObject.SetVisibility(true);
    }
    public void BackButtonClicked()
    {
        sampleWebView.webViewObject.SetVisibility(false);

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
