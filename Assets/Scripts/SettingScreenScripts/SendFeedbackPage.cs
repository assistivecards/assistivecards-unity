using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SendFeedbackPage : MonoBehaviour
{
    [SerializeField] private SampleWebView sampleWebView;

    private void OnEnable()
    {
        sampleWebView.webViewObject.SetVisibility(true);
    }
}
