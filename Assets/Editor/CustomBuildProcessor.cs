using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

[InitializeOnLoad]
class CustomBuildProcessor : IPreprocessBuildWithReport
{
    public static string productName;
    public static string productVersion;
    public int callbackOrder { get { return 0; } }
    public void OnPreprocessBuild(BuildReport report)
    {
        if (productName != PlayerSettings.productName)
        {
            Debug.Log("isim değişti");

            // List<EditorBuildSettingsScene> editorBuildSettingsScenesList = new List<EditorBuildSettingsScene>();
            // var sceneToAdd = new EditorBuildSettingsScene("Assets/Scenes/" + ToTitleCase(PlayerSettings.productName) + ".unity", true);
            // editorBuildSettingsScenesList.Add(sceneToAdd);
            // EditorBuildSettings.scenes = editorBuildSettingsScenesList.ToArray();
            // AssetDatabase.SaveAssets();

            Texture2D icon = Resources.Load<Texture2D>(PlayerSettings.productName + "_icon");
            PlayerSettings.SetIcons(NamedBuildTarget.Unknown, new Texture2D[] { icon }, IconKind.Any);
        }
        else
        {
            Debug.Log("isim ayni");
        }

        if (productVersion != PlayerSettings.bundleVersion)
        {
            Debug.Log("bundle version değişti");
            var bundleVersionCode = PlayerSettings.bundleVersion.Replace(".", string.Empty);
            PlayerSettings.Android.bundleVersionCode = Int32.Parse(bundleVersionCode);
        }
        else
        {
            Debug.Log("bundle version ayni");
        }
    }

    string ToTitleCase(string stringToConvert)
    {
        string firstChar = stringToConvert[0].ToString();
        return (stringToConvert.Length > 0 ? firstChar.ToUpper() + stringToConvert.Substring(1) : stringToConvert);

    }
}