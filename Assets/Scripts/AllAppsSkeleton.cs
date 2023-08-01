using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllAppsSkeleton : MonoBehaviour
{
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            for (int j = 0; j < transform.GetChild(i).childCount - 1; j++)
            {
                LeanTween.alpha(transform.GetChild(i).GetChild(j).GetComponent<RectTransform>(), .5f, .5f).setLoopPingPong();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.SetAsLastSibling();

        if (transform.parent.GetComponent<AllAppsPage>().appElementGameObject.Count == gameAPI.cachedApps.apps.Count)
        {
            gameObject.SetActive(false);
            Debug.Log("Skeleton disabled");
        }
    }

}
