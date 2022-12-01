using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    static CustomBuildProcessor()
    {
        productName = PlayerSettings.productName;
        productVersion = PlayerSettings.bundleVersion;
        Debug.Log("Current product name is: " + PlayerSettings.productName);
        Debug.Log("Current product version is: " + PlayerSettings.bundleVersion);
        BuildPlayerWindow.RegisterBuildPlayerHandler(OnClickBuildPlayer);
    }

    public void OnPreprocessBuild(BuildReport report)
    {
        if (productName != PlayerSettings.productName)
        {
            Texture2D icon = Resources.Load<Texture2D>(PlayerSettings.productName + "_icon");
            PlayerSettings.SetIcons(NamedBuildTarget.Unknown, new Texture2D[] { icon }, IconKind.Any);
        }
        else
        {
            Debug.Log("isim ayni");
        }

        if (productVersion != PlayerSettings.bundleVersion)
        {
            var bundleVersionCode = PlayerSettings.bundleVersion.Replace(".", string.Empty);
            PlayerSettings.Android.bundleVersionCode = Int32.Parse(bundleVersionCode);
        }
        else
        {
            Debug.Log("bundle version ayni");
        }
    }

    static string ToTitleCase(string stringToConvert)
    {
        string firstChar = stringToConvert[0].ToString();
        return (stringToConvert.Length > 0 ? firstChar.ToUpper() + stringToConvert.Substring(1) : stringToConvert);

    }

    private static void OnClickBuildPlayer(BuildPlayerOptions options)
    {
        if (Application.unityVersion.StartsWith("2022"))
        {
            if (productName != PlayerSettings.productName)
            {
                List<EditorBuildSettingsScene> editorBuildSettingsScenesList = new List<EditorBuildSettingsScene>();
                var sceneToAdd = new EditorBuildSettingsScene("Assets/Scenes/" + ToTitleCase(PlayerSettings.productName) + ".unity", true);
                editorBuildSettingsScenesList.Add(sceneToAdd);
                EditorBuildSettings.scenes = editorBuildSettingsScenesList.ToArray();
                AssetDatabase.SaveAssets();

                Array.Clear(options.scenes, 0, options.scenes.Length);
                options.scenes = EditorBuildSettings.scenes.Select(ebss => ebss.path).ToArray();
                BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);
            }
            else
            {
                BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);
            }
        }
        else
        {
            Debug.Log("Update Unity Version to 2022");
            BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);
        }

    }

}