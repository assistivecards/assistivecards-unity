using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Defective.JSON;
using System;

public class PackSelectionPanel : MonoBehaviour
{
    [SerializeField] private GameObject tempPackElement;
    public AssistiveCardsSDK.AssistiveCardsSDK.Packs packs = new AssistiveCardsSDK.AssistiveCardsSDK.Packs();
    private GameObject packElement;
    public GameObject selectedPackElement;
    public List<GameObject> packElementGameObject = new List<GameObject>();
    private GameAPI gameAPI;
    private Color bgColor;
    [SerializeField] string currentLanguageCode;
    public static bool didLanguageChange = false;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] GameObject packSelectionPanel;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        ListPacks();
    }

    private void OnEnable()
    {
        if (didLanguageChange)
        {
            ListPacks();
            didLanguageChange = false;
        }
    }

    public async void ListPacks()
    {
        await GameAPI.cacheData;
        await GameAPI.cacheFreePackImages;
        loadingPanel.SetActive(false);
        currentLanguageCode = await gameAPI.GetSystemLanguageCode();

        if (packElementGameObject.Count != 0)
        {
            foreach (var item in packElementGameObject)
            {
                Destroy(item);
            }
            packElementGameObject.Clear();
        }

        packs = await gameAPI.GetPacks(currentLanguageCode);
        var jsonPacks = JsonUtility.ToJson(packs);
        JSONObject jsonPackss = new JSONObject(jsonPacks);

        tempPackElement.SetActive(true);

        for (int i = 0; i < gameAPI.freePackImages.Count; i++)
        {
            packElement = Instantiate(tempPackElement, transform);
            ColorUtility.TryParseHtmlString(jsonPackss["packs"][i]["color"].ToString().Replace("\"", ""), out bgColor);
            packElement.GetComponent<Image>().color = bgColor;


            packElement.transform.GetChild(0).GetComponent<Text>().text = jsonPackss["packs"][i]["locale"].ToString().Replace("\"", "");
            var packTexture = gameAPI.freePackImages[i];
            packTexture.wrapMode = TextureWrapMode.Clamp;
            packTexture.filterMode = FilterMode.Bilinear;

            packElement.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(packTexture, new Rect(0.0f, 0.0f, gameAPI.freePackImages[i].width, gameAPI.freePackImages[i].height), new Vector2(0.5f, 0.5f), 100.0f);

            packElement.name = packs.packs[i].slug;

            packElement.transform.GetChild(3).gameObject.SetActive(false);


            // if (packs.packs[i].premium == 1)
            // {
            //     packElement.transform.GetChild(3).gameObject.SetActive(true);
            // }

            packElementGameObject.Add(packElement);

            if (Application.productName.Replace(" ", "_").ToLower() == "silhouette" && (packElement.name == "colors" || packElement.name == "feelings"))
            {
                packElement.SetActive(false);
            }

        }
        tempPackElement.SetActive(false);

        Invoke("ScalePackSelectionPanelUp", 0.25f);

        await GameAPI.cachePremiumPackImages;

        tempPackElement.SetActive(true);

        for (int i = 0; i < gameAPI.premiumPackImages.Count; i++)
        {
            packElement = Instantiate(tempPackElement, transform);
            ColorUtility.TryParseHtmlString(jsonPackss["packs"][i + 13]["color"].ToString().Replace("\"", ""), out bgColor);
            packElement.GetComponent<Image>().color = bgColor;


            packElement.transform.GetChild(0).GetComponent<Text>().text = jsonPackss["packs"][i + 13]["locale"].ToString().Replace("\"", "");
            var packTexture = gameAPI.premiumPackImages[i];
            packTexture.wrapMode = TextureWrapMode.Clamp;
            packTexture.filterMode = FilterMode.Bilinear;

            packElement.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(packTexture, new Rect(0.0f, 0.0f, gameAPI.premiumPackImages[i].width, gameAPI.premiumPackImages[i].height), new Vector2(0.5f, 0.5f), 100.0f);

            packElement.name = packs.packs[i + 13].slug;

            packElement.transform.GetChild(3).gameObject.SetActive(true);

            packElementGameObject.Add(packElement);

        }
        tempPackElement.SetActive(false);


    }

    public void PackSelected(GameObject _PackElement)
    {
        selectedPackElement = _PackElement;

        Debug.Log(_PackElement.ToString());
    }

    public void ScalePackSelectionPanelUp()
    {
        packSelectionPanel.transform.GetChild(0).GetComponent<ScrollRect>().enabled = false;
        var rt = packSelectionPanel.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(rt.offsetMax.x, 0);
        LeanTween.scale(packSelectionPanel, Vector3.one, 0.15f);
        Invoke("EnableScrollRect", 0.15f);
    }

    public void EnableScrollRect()
    {
        packSelectionPanel.transform.GetChild(0).GetComponent<ScrollRect>().enabled = true;
    }

}
