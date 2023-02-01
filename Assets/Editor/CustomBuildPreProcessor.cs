using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

[InitializeOnLoad]
class CustomBuildPreProcessor : IPreprocessBuildWithReport
{
    public static string productName;
    public static string productVersion;
    public int callbackOrder { get { return 0; } }

    static CustomBuildPreProcessor()
    {
        productName = PlayerSettings.productName.Replace("-", "_");
        productVersion = PlayerSettings.bundleVersion;
        Debug.Log("Current product name is: " + productName);
        Debug.Log("Current product version is: " + productVersion);
        BuildPlayerWindow.RegisterBuildPlayerHandler(OnClickBuildPlayer);
    }

    public void OnPreprocessBuild(BuildReport report)
    {
        Texture2D icon = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Sprites/AppIcons/" + PlayerSettings.productName.Replace("-", "_").Replace("_", " ").Replace(" ", "_").ToLower() + ".png", typeof(Texture2D));
        PlayerSettings.SetIcons(NamedBuildTarget.Unknown, new Texture2D[] { icon }, IconKind.Any);
        PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.Android, "com.assistivecards." + PlayerSettings.productName.Replace("-", "_").Replace("_", " ").Replace(" ", "_").ToLower());

        var bundleVersionCode = PlayerSettings.bundleVersion.Replace(".", string.Empty);
        PlayerSettings.Android.bundleVersionCode = Int32.Parse(bundleVersionCode);
        PlayerSettings.iOS.buildNumber = PlayerSettings.bundleVersion;
        PlayerSettings.iOS.applicationDisplayName = ToTitleCase(PlayerSettings.productName.Replace("-", "_").Replace("_", " "));
        PlayerSettings.applicationIdentifier = "com.assistivecards." + PlayerSettings.productName.Replace("-", "_").Replace("_", " ").Replace(" ", "_").ToLower();
        Debug.Log("preprocessing");

    }

    static string ToTitleCase(string stringToConvert)
    {
      var textinfo = new CultureInfo("en-US", false).TextInfo;
      return textinfo.ToTitleCase(stringToConvert);
    }

    private static void OnClickBuildPlayer(BuildPlayerOptions options)
    {
        if (Application.unityVersion.StartsWith("2022"))
        {

            List<EditorBuildSettingsScene> editorBuildSettingsScenesList = new List<EditorBuildSettingsScene>();
            var sceneToAdd = new EditorBuildSettingsScene("Assets/Scenes/" + ToTitleCase(PlayerSettings.productName.Replace("-", "_").Replace("_", " ")) + ".unity", true);
            editorBuildSettingsScenesList.Add(sceneToAdd);
            EditorBuildSettings.scenes = editorBuildSettingsScenesList.ToArray();
            AssetDatabase.SaveAssets();

            Array.Clear(options.scenes, 0, options.scenes.Length);
            options.scenes = EditorBuildSettings.scenes.Select(ebss => ebss.path).ToArray();
            BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);


        }
        else
        {
            Debug.Log("Update Unity Version to 2022");
            BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);
        }

    }

}
