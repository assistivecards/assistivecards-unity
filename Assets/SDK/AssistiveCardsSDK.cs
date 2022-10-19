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
    public RawImage rawImage;
    public TMP_InputField avatarImageSizeInput;
    public TMP_InputField avatarIdInput;
    public TMP_InputField packImageSizeInput;
    public TMP_InputField packSlugInput;
    public TMP_InputField cardImagePackSlugInput;
    public TMP_InputField cardImageCardSlugInput;
    public TMP_InputField cardImageSizeInput;
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
        rawImage.texture = texture;
    }

    public async Task<Texture2D> GetActivityImage(string activitySlug)
    {
        var result = await asyncGetActivityImage(activitySlug);
        return result;
    }

    private async Task<Texture2D> asyncGetActivityImage(string activitySlug)
    {

        string uri = api + "activities/assets/" + activitySlug + ".png";

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            return null;
        else
        {
            var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            return texture;
        }
    }

    public void DisplayAvatarImageOnClick()
    {
        var id = avatarIdInput.text;
        int size = Int32.Parse(avatarImageSizeInput.text);
        if (id != null && (size == 256 || size == 512))
            DisplayAvatarImage(id, size);
    }

    public async void DisplayAvatarImage(string avatarId, int imgSize)
    {

        var texture = await asyncGetAvatarImage(avatarId, imgSize);
        rawImage.texture = texture;
    }

    public async Task<Texture2D> GetAvatarImage(string avatarId, int imgSize)
    {
        var result = await asyncGetAvatarImage(avatarId, imgSize);
        return result;
    }

    private async Task<Texture2D> asyncGetAvatarImage(string avatarId, int imgSize)
    {
        string uri = "";
        if (imgSize == 256)
        {
            uri = api + "cards/avatar/" + avatarId + ".png";
        }
        else if (imgSize == 512)
        {
            uri = api + "cards/avatarHD/" + avatarId + ".png";
        }
        else
        {
            Debug.Log("Please enter a valid image size.");
        }

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            return null;
        else
        {
            var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            return texture;
        }
    }

    public void DisplayPackImageOnClick()
    {
        var slug = packSlugInput.text;
        int size = Int32.Parse(packImageSizeInput.text);
        if (slug != null && (size == 256 || size == 512))
            DisplayPackImage(slug, size);
    }

    public async void DisplayPackImage(string packSlug, int imgSize)
    {

        var texture = await asyncGetPackImage(packSlug, imgSize);
        rawImage.texture = texture;
    }

    public async Task<Texture2D> GetPackImage(string packSlug, int imgSize)
    {
        var result = await asyncGetPackImage(packSlug, imgSize);
        return result;
    }

    private async Task<Texture2D> asyncGetPackImage(string packSlug, int imgSize)
    {
        string uri = "";
        if (imgSize == 256)
        {
            uri = api + "cards/icon/" + packSlug + ".png";
        }
        else if (imgSize == 512)
        {
            uri = api + "cards/icon/" + packSlug + "@2x.png";
        }
        else
        {
            Debug.Log("Please enter a valid image size.");
        }

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            return null;
        else
        {
            var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            return texture;
        }
    }

    public async void DisplayAppIcon(string appSlug)
    {
        var texture = await asyncGetAppIcon(appSlug);
        rawImage.texture = texture;
    }

    public async Task<Texture2D> GetAppIcon(string appSlug)
    {
        var result = await asyncGetAppIcon(appSlug);
        return result;
    }

    private async Task<Texture2D> asyncGetAppIcon(string appSlug)
    {

        string uri = api + "apps/icon/" + appSlug + "@3x.png";

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            return null;
        else
        {
            var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            return texture;
        }
    }

    public void DisplayCardImageOnClick()
    {
        var packSlug = cardImagePackSlugInput.text;
        var cardSlugSlug = cardImageCardSlugInput.text;
        int size = Int32.Parse(cardImageSizeInput.text);
        if (packSlug != null && cardSlugSlug != null && (size == 256 || size == 512))
            DisplayCardImage(packSlug, cardSlugSlug, size);
    }

    public async void DisplayCardImage(string packSlug, string cardSlug, int imgSize)
    {

        var texture = await asyncGetCardImage(packSlug, cardSlug, imgSize);
        rawImage.texture = texture;
    }

    public async Task<Texture2D> GetCardImage(string packSlug, string cardSlug, int imgSize)
    {
        var result = await asyncGetCardImage(packSlug, cardSlug, imgSize);
        return result;
    }

    private async Task<Texture2D> asyncGetCardImage(string packSlug, string cardSlug, int imgSize)
    {
        string uri = "";
        if (imgSize == 256)
        {
            uri = api + "cards/" + packSlug + "/" + cardSlug + ".png";
        }
        else if (imgSize == 512)
        {
            uri = api + "cards/" + packSlug + "/" + cardSlug + "@2x.png";
        }
        else
        {
            Debug.Log("Please enter a valid image size.");
        }

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            return null;
        else
        {
            var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            return texture;
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
