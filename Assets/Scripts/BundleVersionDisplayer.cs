using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class BundleVersionDisplayer : MonoBehaviour
{
    [SerializeField] TMP_Text bundleText;
    private void OnValidate()
    {
#if UNITY_EDITOR
        bundleText.text = "Bundle Version: " + Application.version + "\nAndroid Bundle Version Code: " + PlayerSettings.Android.bundleVersionCode + "\niOS Build Number: " + PlayerSettings.iOS.buildNumber + "\nAndroid Bundle ID: " + PlayerSettings.GetApplicationIdentifier(UnityEditor.Build.NamedBuildTarget.Android);
#endif
    }
}
