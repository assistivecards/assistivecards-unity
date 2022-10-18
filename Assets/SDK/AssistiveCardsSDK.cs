using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System;
using System.Threading.Tasks;

public class AssistiveCardsSDK : MonoBehaviour
{
    public TMP_InputField outputArea;
    public RawImage image;
    private const string api = "https://api.assistivecards.com/";
    private const string metadata = "https://api.assistivecards.com/apps/metadata.json";

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

    [Serializable]
    public class App
    {
        public string slug;
        public string name;
        public string color;
        public Tagline tagline;
        public Description description;
        public StoreId storeId;
        public bool advertise;
    }

    [Serializable]
    public class Description
    {
        public string en;
        public string es;
        public string fr;
        public string de;
        public string it;
        public string ja;
        public string ko;
        public string zh;
        public string ar;
        public string cs;
        public string da;
        public string nl;
        public string fi;
        public string el;
        public string he;
        public string hi;
        public string hu;
        public string id;
        public string nb;
        public string pl;
        public string pt;
        public string ro;
        public string ru;
        public string sk;
        public string sv;
        public string th;
        public string tr;
        public string ur;
        public string bn;
        public string et;
        public string fil;
        public string jv;
        public string km;
        public string ne;
        public string si;
        public string uk;
        public string vi;
    }

    [Serializable]
    public class Apps
    {
        public List<App> apps;
    }

    [Serializable]
    public class StoreId
    {
        public int appStore;
        public object googlePlay;
    }

    [Serializable]
    public class Tagline
    {
        public string en;
        public string es;
        public string fr;
        public string de;
        public string it;
        public string ja;
        public string ko;
        public string zh;
        public string ar;
        public string cs;
        public string da;
        public string nl;
        public string fi;
        public string el;
        public string he;
        public string hi;
        public string hu;
        public string id;
        public string nb;
        public string pl;
        public string pt;
        public string ro;
        public string ru;
        public string sk;
        public string sv;
        public string th;
        public string tr;
        public string ur;
        public string bn;
        public string et;
        public string fil;
        public string jv;
        public string km;
        public string ne;
        public string si;
        public string uk;
        public string vi;
    }

    public Packs packs = new Packs();
    public Activities activities = new Activities();
    public Languages languages = new Languages();
    public Apps apps = new Apps();

    public async void DisplayPacks(string language)
    {
        var result = await asyncGetPacks(language);
        outputArea.text = JsonUtility.ToJson(result);
    }
    public async Task<Packs> GetPacks(string language)
    {
        var result = await asyncGetPacks(language);
        return result;
    }

    private async Task<Packs> asyncGetPacks(string language)
    {

        string uri = "https://api.assistivecards.com/packs/" + language + "/metadata.json";

        UnityWebRequest request = UnityWebRequest.Get(uri);
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            return null;
        else
        {
            return packs = JsonUtility.FromJson<Packs>("{\"packs\":" + request.downloadHandler.text + "}");
        }
    }

    public async void DisplayActivities(string language)
    {
        var result = await asyncGetActivities(language);
        outputArea.text = JsonUtility.ToJson(result);
    }

    public async Task<Activities> GetActivities(string language)
    {
        var result = await asyncGetActivities(language);
        return result;
    }

    private async Task<Activities> asyncGetActivities(string language)
    {

        string uri = api + "activities/" + language + "/metadata.json";

        UnityWebRequest request = UnityWebRequest.Get(uri);
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            return null;
        else
        {
            return activities = JsonUtility.FromJson<Activities>("{\"activities\":" + request.downloadHandler.text + "}");
        }
    }


    public async void DisplayLanguages()
    {
        var result = await asyncGetLanguages();
        outputArea.text = JsonUtility.ToJson(result);
    }

    public async Task<Languages> GetLanguages()
    {
        var result = await asyncGetLanguages();
        return result;
    }

    private async Task<Languages> asyncGetLanguages()
    {

        string uri = api + "languages.json";

        UnityWebRequest request = UnityWebRequest.Get(uri);
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            return null;
        else
        {
            return languages = JsonUtility.FromJson<Languages>(request.downloadHandler.text);
        }
    }

    public async void DisplayActivityImage(string activitySlug)
    {
        var texture = await asyncGetActivityImage(activitySlug);
        image.texture = texture;
    }

    public async Task<Texture> GetActivityImage(string activitySlug)
    {
        var result = await asyncGetActivityImage(activitySlug);
        return result;
    }

    private async Task<Texture> asyncGetActivityImage(string activitySlug)
    {

        string uri = api + "activities/assets/" + activitySlug + ".png";

        UnityWebRequest request = UnityWebRequest.Get(uri);
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            return null;
        else
        {
            var texture = ((DownloadHandlerTexture)request.downloadHandler).texture as Texture;
            return texture;
        }
    }

    public void GetAvatarImages256(string avatarId)
    {
        StartCoroutine(GetAvatarImages256Coroutine(avatarId, 256));
    }

    public void GetAvatarImages512(string avatarId)
    {
        StartCoroutine(GetAvatarImages512Coroutine(avatarId, 512));
    }

    public IEnumerator GetAvatarImages256Coroutine(string avatarId, int res)
    {
        string uri = api + "cards/avatar/" + avatarId + ".png";





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

    public IEnumerator GetAvatarImages512Coroutine(string avatarId, int res)
    {
        string uri = api + "cards/avatarHD/" + avatarId + ".png";


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

    public void GetPackImages256(string packSlug)
    {
        StartCoroutine(GetPackImages256Coroutine(packSlug));
    }

    public IEnumerator GetPackImages256Coroutine(string packSlug)
    {
        string uri = api + "cards/icon/" + packSlug + ".png";

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

    public void GetPackImages512(string packSlug)
    {
        StartCoroutine(GetPackImages512Coroutine(packSlug));
    }

    public IEnumerator GetPackImages512Coroutine(string packSlug)
    {
        string uri = api + "cards/icon/" + packSlug + "@2x.png";

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

    public void GetAppIcons(string appSlug)
    {
        StartCoroutine(GetAppIconsCoroutine(appSlug));
    }

    public IEnumerator GetAppIconsCoroutine(string appSlug)
    {
        string uri = api + "apps/icon/" + appSlug + "@3x.png";

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

    public void GetCardImages256(string packSlug, string cardSlug)
    {
        StartCoroutine(GetCardImages256Coroutine(packSlug, cardSlug));
    }

    public IEnumerator GetCardImages256Coroutine(string packSlug, string cardSlug)
    {
        string uri = api + "cards/" + packSlug + "/" + cardSlug + ".png";

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

    public void GetCardImages512(string packSlug, string cardSlug)
    {
        StartCoroutine(GetCardImages512Coroutine(packSlug, cardSlug));
    }

    public IEnumerator GetCardImages512Coroutine(string packSlug, string cardSlug)
    {
        string uri = api + "cards/" + packSlug + "/" + cardSlug + "@2x.png";

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

    public async void DisplayApps()
    {
        var result = await asyncGetApps();
        outputArea.text = JsonUtility.ToJson(result);
    }

    public async Task<Apps> GetApps()
    {
        var result = await asyncGetApps();
        return result;
    }

    private async Task<Apps> asyncGetApps()
    {

        //string uri = metadata;

        UnityWebRequest request = UnityWebRequest.Get(metadata);
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            return null;
        else
        {
            outputArea.text = request.downloadHandler.text;
            return apps = JsonUtility.FromJson<Apps>(request.downloadHandler.text);
        }
    }

}
