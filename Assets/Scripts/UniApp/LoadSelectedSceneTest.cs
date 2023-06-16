using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSelectedSceneTest : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadSelectedScene);
    }
    public void LoadSelectedScene()
    {
        SceneManager.LoadScene(transform.GetChild(0).GetComponent<TMP_Text>().text);
    }
}
