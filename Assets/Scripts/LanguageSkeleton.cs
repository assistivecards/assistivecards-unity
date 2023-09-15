using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSkeleton : MonoBehaviour
{
    [SerializeField] private SupportedLanguagesPanel supportedLanguagePanel;
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

    void Update()
    {
        transform.SetAsLastSibling();

        if (supportedLanguagePanel.loadingCompleted)
        {
            gameObject.SetActive(false);
            Debug.Log("Skeleton disabled");
        }
    }
}
