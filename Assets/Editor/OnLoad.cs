using System;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
static class OnLoad
{
    static OnLoad()
    {
        CustomBuildProcessor.productName = PlayerSettings.productName;
        CustomBuildProcessor.productVersion = PlayerSettings.bundleVersion;
        Debug.Log("Current product name is: " + PlayerSettings.productName);
        Debug.Log("Current product version is: " + PlayerSettings.bundleVersion);


        // var scenesInbuild = EditorBuildSettings.scenes;

        // Array.Clear(scenesInbuild, 0, scenesInbuild.Length);
        // var sceneToAdd = new EditorBuildSettingsScene("Assets/Scenes/Deneme.unity", true);
        // scenesInbuild[0] = sceneToAdd;
    }
}
