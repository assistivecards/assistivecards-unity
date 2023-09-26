using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

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

        PlayerSettings.keystorePass = "assistivecards";
        PlayerSettings.keyaliasPass = "assistivecards";

        BuildPlayerWindow.RegisterBuildPlayerHandler(OnClickBuildPlayer);
    }

    public async void OnPreprocessBuild(BuildReport report)
    {

        Texture2D icon = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Sprites/AppIcons/" + PlayerSettings.productName.Replace("-", "_").Replace("_", " ").Replace(" ", "_").ToLower(new CultureInfo("en-US", false)) + ".png", typeof(Texture2D));
        PlayerSettings.SetIcons(NamedBuildTarget.Unknown, new Texture2D[] { icon }, IconKind.Any);
        PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.Android, "com.assistivecards." + PlayerSettings.productName.Replace("-", "_").Replace("_", " ").Replace(" ", "_").ToLower(new CultureInfo("en-US", false)));

        var bundleVersionCode = PlayerSettings.bundleVersion.Replace(".", string.Empty);
        PlayerSettings.Android.bundleVersionCode = Int32.Parse(bundleVersionCode);
        PlayerSettings.iOS.buildNumber = PlayerSettings.bundleVersion;
        PlayerSettings.iOS.applicationDisplayName = ToTitleCase(PlayerSettings.productName.Replace("-", "_").Replace("_", " "));
        PlayerSettings.applicationIdentifier = "com.assistivecards." + PlayerSettings.productName.Replace("-", "_").Replace("_", " ").Replace(" ", "_").ToLower(new CultureInfo("en-US", false));
        await CacheGames();
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
            if (Application.productName != "Zumo")
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

                List<EditorBuildSettingsScene> editorBuildSettingsScenesList = new List<EditorBuildSettingsScene>();
                var sceneToAdd = new EditorBuildSettingsScene("Assets/Scenes/" + ToTitleCase(PlayerSettings.productName.Replace("-", "_").Replace("_", " ")) + ".unity", true);
                editorBuildSettingsScenesList.Add(sceneToAdd);

                string folderName = "Assets/Scenes/";
                var dirInfo = new DirectoryInfo(folderName);
                var allFileInfos = dirInfo.GetFiles("*.unity", SearchOption.AllDirectories);

                foreach (var fileInfo in allFileInfos)
                {
                    if (fileInfo.Name != "Zumo.unity" && fileInfo.Name != "Template.unity")
                    {
                        var sceneFound = new EditorBuildSettingsScene("Assets/Scenes/" + fileInfo.Name, true);
                        editorBuildSettingsScenesList.Add(sceneFound);
                    }
                }

                EditorBuildSettings.scenes = editorBuildSettingsScenesList.ToArray();
                AssetDatabase.SaveAssets();

                Array.Clear(options.scenes, 0, options.scenes.Length);
                options.scenes = EditorBuildSettings.scenes.Select(ebss => ebss.path).ToArray();
                BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);
            }


        }
        else
        {
            Debug.Log("Update Unity Version to 2022");
            BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);
        }

    }

    public static async Task CacheGames()
    {

        UnityWebRequest request = UnityWebRequest.Get("https://api.assistivecards.com/games/metadata.json");
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
        {
            string path = Path.Combine(Application.dataPath, "Resources", "games.txt");

            if (!File.Exists(path))
            {
                File.WriteAllText(path, request.downloadHandler.text.Replace("apps", "games"));
            }
            else
            {
                File.Delete(path);
                File.WriteAllText(path, request.downloadHandler.text.Replace("apps", "games"));
            }

            AssetDatabase.Refresh();

        }
    }

}
