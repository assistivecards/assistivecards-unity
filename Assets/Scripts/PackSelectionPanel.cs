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
    public Color tempColor1;
    public Color tempColor2;
    public Color tempColor3;
    public Color tempColor4;
    bool firstTime = true;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        ListPacks();
        firstTime = false;
    }

    private void OnEnable()
    {
        if (didLanguageChange && !firstTime)
        {
            ListPacks();
            didLanguageChange = false;
        }
    }

    public async void ListPacks()
    {
        await GameAPI.cachePacks;
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


            packElement.transform.GetChild(0).GetComponent<Text>().text = gameAPI.ToSentenceCase(jsonPackss["packs"][i]["locale"].ToString().Replace("\"", ""));
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

            if (Application.productName.Replace(" ", "_").ToLower() == "complete" && (packElement.name == "colors" || packElement.name == "feelings"))
            {
                packElement.SetActive(false);
            }

            if (Application.productName.Replace(" ", "_").ToLower() == "finger_paint" && (packElement.name == "colors"))
            {
                packElement.SetActive(false);
            }

            if (Application.productName.Replace(" ", "_").ToLower() == "first_letter" && (packElement.name == "letters")
            || Application.productName.Replace(" ", "_").ToLower() == "alphabet_choose" && (packElement.name == "letters")
            || Application.productName.Replace(" ", "_").ToLower() == "letter_find" && (packElement.name == "letters"))
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
            ColorUtility.TryParseHtmlString(jsonPackss["packs"][i + gameAPI.freePackImages.Count]["color"].ToString().Replace("\"", ""), out bgColor);
            packElement.GetComponent<Image>().color = bgColor;


            packElement.transform.GetChild(0).GetComponent<Text>().text = gameAPI.ToSentenceCase(jsonPackss["packs"][i + gameAPI.freePackImages.Count]["locale"].ToString().Replace("\"", ""));
            var packTexture = gameAPI.premiumPackImages[i];
            packTexture.wrapMode = TextureWrapMode.Clamp;
            packTexture.filterMode = FilterMode.Bilinear;

            packElement.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(packTexture, new Rect(0.0f, 0.0f, gameAPI.premiumPackImages[i].width, gameAPI.premiumPackImages[i].height), new Vector2(0.5f, 0.5f), 100.0f);

            packElement.name = packs.packs[i + gameAPI.freePackImages.Count].slug;

            packElement.transform.GetChild(3).gameObject.SetActive(true);

            packElementGameObject.Add(packElement);

        }
        tempPackElement.SetActive(false);

        for (int i = gameAPI.freePackImages.Count; i < packElementGameObject.Count; i++)
        {
            var backgroundImage = packElementGameObject[i].GetComponent<Image>();
            tempColor1 = backgroundImage.color;
            tempColor1.a = 0f;
            backgroundImage.color = tempColor1;

            var packNameText = packElementGameObject[i].transform.GetChild(0).GetComponent<Text>();
            tempColor2 = packNameText.color;
            tempColor2.a = 0f;
            packNameText.color = tempColor2;

            var packImage = packElementGameObject[i].transform.GetChild(1).GetComponent<Image>();
            tempColor3 = packImage.color;
            tempColor3.a = 0f;
            packImage.color = tempColor3;

            var premiumLabelBackGroundImage = packElementGameObject[i].transform.GetChild(3).GetComponent<Image>();
            tempColor4 = premiumLabelBackGroundImage.color;
            tempColor4.a = 0f;
            premiumLabelBackGroundImage.color = tempColor4;

            var premiumLabelDiamondImage = packElementGameObject[i].transform.GetChild(3).GetChild(0).GetComponent<Image>();
            premiumLabelDiamondImage.color = tempColor2;

            var premiumLabelText = packElementGameObject[i].transform.GetChild(3).GetChild(1).GetComponent<Text>();
            premiumLabelText.color = tempColor2;

            packElementGameObject[i].GetComponent<Button>().interactable = false;

        }

        for (int i = gameAPI.freePackImages.Count; i < packElementGameObject.Count; i++)
        {
            ColorUtility.TryParseHtmlString(jsonPackss["packs"][i]["color"].ToString().Replace("\"", ""), out bgColor);
            LeanTween.color(packElementGameObject[i].GetComponent<Image>().rectTransform, new Color(bgColor.r, bgColor.g, bgColor.b, 1), .5f);
            LeanTween.textAlpha(packElementGameObject[i].transform.GetChild(0).GetComponent<Text>().rectTransform, 1, .5f);
            LeanTween.color(packElementGameObject[i].transform.GetChild(1).GetComponent<Image>().rectTransform, new Color(tempColor3.r, tempColor3.g, tempColor3.b, 1), .5f);
            LeanTween.color(packElementGameObject[i].transform.GetChild(3).GetComponent<Image>().rectTransform, new Color(tempColor4.r, tempColor4.g, tempColor4.b, 1), .5f);
            LeanTween.color(packElementGameObject[i].transform.GetChild(3).GetChild(0).GetComponent<Image>().rectTransform, new Color(tempColor2.r, tempColor2.g, tempColor2.b, 1), .5f);
            LeanTween.textAlpha(packElementGameObject[i].transform.GetChild(3).GetChild(1).GetComponent<Text>().rectTransform, 1, .5f);

            packElementGameObject[i].GetComponent<Button>().interactable = true;

        }


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
