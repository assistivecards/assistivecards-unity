using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForceActiveState : MonoBehaviour
{
    List<GameObject> rootObjects = new List<GameObject>();
    Transform[] childObjects;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = gameObject.GetComponent<GameAPI>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        scene.GetRootGameObjects(rootObjects);

        foreach (GameObject obj in rootObjects)
        {
            if (obj.name.Contains("Canvas"))
            {
                childObjects = obj.GetComponentsInChildren<Transform>(true);
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
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
