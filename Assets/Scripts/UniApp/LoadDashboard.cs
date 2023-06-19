using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDashboard : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadDashboardScene();
        }

    }

    public void LoadDashboardScene()
    {
        SceneManager.LoadScene("Games");
    }
}
