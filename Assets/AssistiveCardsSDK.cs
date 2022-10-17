using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System;

public class AssistiveCardsSDK : MonoBehaviour
{
    public TMP_InputField outputArea;
    private string language;
    private string activitySlug;
    public RawImage image;

    [Serializable]
    public class Pack
    {
        public int id;
        public string slug;
        public string color;
        public int premium;
        public string locale;
        public int count;
    }

    [Serializable]
    public class Packs
    {
        public Pack[] packs;
    }

    [Serializable]
    public class Activity
    {
        public string slug;
        public string title;
        public string search;
    }

    [Serializable]
    public class Activities
    {
        public Activity[] activities;
    }

    [Serializable]
    public class Language
    {
        public string code;
        public List<string> locale;
        public List<string> support;
        public string title;
        public string native;
        public bool rightToLeft;
        public bool readproof;
    }

    [Serializable]
    public class Languages
    {
        public Language[] languages;
    }

    public Packs packs = new Packs();
    public Activities activities = new Activities();
    public Languages languages = new Languages();

    public void GetPacks(string language)
    {
        StartCoroutine(GetPacksCoroutine(language));
    }

    public IEnumerator GetPacksCoroutine(string langCode)
    {

        string uri = "https://api.assistivecards.com/packs/" + langCode + "/metadata.json";

        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                outputArea.text = request.error;
            else
            {
                outputArea.text = request.downloadHandler.text;
                packs = JsonUtility.FromJson<Packs>("{\"packs\":" + request.downloadHandler.text + "}");
            }
        }
    }

    public void GetActivities(string language)
    {
        StartCoroutine(GetActivitiesCoroutine(language));
    }

    public IEnumerator GetActivitiesCoroutine(string langCode)
    {

        string uri = "https://api.assistivecards.com/activities/" + langCode + "/metadata.json";

        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                outputArea.text = request.error;
            else
            {
                outputArea.text = request.downloadHandler.text;
                activities = JsonUtility.FromJson<Activities>("{\"activities\":" + request.downloadHandler.text + "}");
            }
        }
    }

    public void GetLanguages()
    {
        StartCoroutine(GetLanguagesCoroutine());
    }

    public IEnumerator GetLanguagesCoroutine()
    {

        string uri = "https://api.assistivecards.com/languages.json";

        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                outputArea.text = request.error;
            else
            {
                outputArea.text = request.downloadHandler.text;
                languages = JsonUtility.FromJson<Languages>(request.downloadHandler.text);
            }
        }
    }

    public void GetActivityImages(string activitySlug)
    {
        StartCoroutine(GetActivityImagesCoroutine(activitySlug));
    }

    public IEnumerator GetActivityImagesCoroutine(string slug)
    {
        string uri = "https://api.assistivecards.com/activities/assets/" + slug + ".png";

        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                outputArea.text = request.error;
            else
            {
                image.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            }
        }
    }

}
