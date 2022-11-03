using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class App
{
    public string appName;
    public string appSummary;
    public string appDescription;
    private Image appImage;

    //private link

    public App(string _appName, string _appSummary, string _appDescription)
    {
        appName = _appName;
        appSummary = _appSummary;
        appDescription = _appDescription;
    }
}

public class AllAppsPage : MonoBehaviour
{
    [SerializeField] private GameObject tempApp;
    public  List<App> apps = new List<App>();
    private GameObject appElement;
 
    private void Start() 
    {
        tempApp = this.transform.GetChild(0).gameObject;

        apps.Add(new App("LEELOO",
                        "leeloo summary",
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit."));
        apps.Add(new App("WINGO",
                        "wingo summary",
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit."));

        for(int i = 0; i < apps.Count; i++)
        {

            Debug.Log(apps[i].appName);
            appElement = Instantiate(tempApp, transform);

            appElement.transform.GetChild(0).GetComponent<TMP_Text>().text = apps[i].appName;
            appElement.transform.GetChild(1).GetComponent<TMP_Text>().text = apps[i].appSummary;
            appElement.transform.GetChild(2).GetComponent<TMP_Text>().text = apps[i].appDescription;
            //tempApp.transform.GetChild(3).GetComponent<Image>()                           PULL THE APP IMAGE FROM SOURCE;     
            //button = EventSystem.current.currentSelectedGameObject;
            //link                                                                          SEND TO LINKED PAGE
        }
        Destroy(tempApp);
    }
}
