using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDashboard : MonoBehaviour
{
    private void OnEnable()
    {
        if (Application.productName == "Games")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         LoadDashboardScene();
    //     }

    // }

    public void LoadDashboardScene()
    {
        SceneManager.LoadScene("Games");
    }
}
