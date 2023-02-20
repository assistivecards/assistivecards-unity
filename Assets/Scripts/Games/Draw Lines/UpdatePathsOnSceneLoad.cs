using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class UpdatePathsOnSceneLoad : MonoBehaviour
{
    private GameObject[] paths;
    void Start()
    {
        paths = GameObject.FindGameObjectsWithTag("Path");
        foreach (var path in paths)
        {
            path.GetComponent<PathCreator>().bezierPath.NotifyPathModified();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
