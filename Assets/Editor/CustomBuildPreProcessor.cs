using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
class CustomBuildPreProcessor : IPreprocessBuildWithReport
{
    public static string productName;
    public static string productVersion;
    List<GameObject> rootObjects = new List<GameObject>();
    Transform[] childObjects;

    public int callbackOrder { get { return 0; } }

    static CustomBuildPreProcessor()
    {
        productName = PlayerSettings.productName;
        productVersion = PlayerSettings.bundleVersion;
        Debug.Log("Current product name is: " + productName);
        Debug.Log("Current product version is: " + productVersion);
        BuildPlayerWindow.RegisterBuildPlayerHandler(OnClickBuildPlayer);
    }

    public void OnPreprocessBuild(BuildReport report)
    {
        Texture2D icon = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Sprites/AppIcons/" + PlayerSettings.productName.Replace(" ", "_").ToLower() + ".png", typeof(Texture2D));
        PlayerSettings.SetIcons(NamedBuildTarget.Unknown, new Texture2D[] { icon }, IconKind.Any);
        PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.Android, "com.assistivecards." + PlayerSettings.productName.Replace(" ", "_").ToLower());

        var bundleVersionCode = PlayerSettings.bundleVersion.Replace(".", string.Empty);
        PlayerSettings.Android.bundleVersionCode = Int32.Parse(bundleVersionCode);
        PlayerSettings.iOS.buildNumber = PlayerSettings.bundleVersion;
        PlayerSettings.iOS.applicationDisplayName = ToTitleCase(PlayerSettings.productName);
        PlayerSettings.applicationIdentifier = "com.assistivecards." + PlayerSettings.productName.Replace(" ", "_").ToLower();

        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        if (ToTitleCase(PlayerSettings.productName) == "Memory")
        {
            foreach (GameObject obj in rootObjects)
            {
                if (obj.name == "Canvas")
                {
                    childObjects = obj.GetComponentsInChildren<Transform>(true);
                }
            }
        }
        else
        {
            foreach (GameObject obj in rootObjects)
            {
                if (obj.name == "GameCanvas")
                {
                    childObjects = obj.GetComponentsInChildren<Transform>(true);
                }
            }
        }

        foreach (Transform item in childObjects)
        {
            if (item.gameObject.name == "LoadingPanel")
            {
                item.gameObject.SetActive(true);
            }
            else if (item.gameObject.name == "PackSelectionPrefab")
            {
                item.gameObject.SetActive(false);
            }
        }

        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(), "Assets/Scenes/" + ToTitleCase(PlayerSettings.productName) + ".unity");

        Debug.Log("preprocessing");

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
            Debug.Log("Update Unity Version to 2022");
            BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);
        }

    }

}
