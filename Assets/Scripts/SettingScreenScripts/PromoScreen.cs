using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Defective.JSON;
using System;

public class PromoScreen : MonoBehaviour
{
    [SerializeField] private GameObject tempPackElement;
    public AssistiveCardsSDK.AssistiveCardsSDK.Packs packs = new AssistiveCardsSDK.AssistiveCardsSDK.Packs();
    private GameObject packElement;
    // private GameObject selectedAppElement;
    public List<GameObject> packElementGameObject = new List<GameObject>();
    private GameAPI gameAPI;
    private Color bgColor;
    [SerializeField] List<string> cardCountsArray = new List<string>();
    [SerializeField] List<string> phraseCountsArray = new List<string>();
    public static bool didLanguageChange = true;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private async void OnEnable()
    {
        if (didLanguageChange)
        {
            if (cardCountsArray.Count != 0)
            {
                cardCountsArray.Clear();
            }


            var currentLanguageCode = await gameAPI.GetSystemLanguageCode();

            tempPackElement.SetActive(true);

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


            for (int i = 0; i < packs.packs.Length; i++)
            {
                if (packs.packs[i].premium == 1)
                {
                    packElement = Instantiate(tempPackElement, transform);
                    ColorUtility.TryParseHtmlString(jsonPackss["packs"][i]["color"].ToString().Replace("\"", ""), out bgColor);
                    packElement.GetComponent<Image>().color = bgColor;


                    packElement.transform.GetChild(0).GetComponent<TMP_Text>().text = jsonPackss["packs"][i]["locale"].ToString().Replace("\"", "");

                    var cardCount = jsonPackss["packs"][i]["count"].ToString().Replace("\"", "");
                    cardCountsArray.Add(cardCount);
                    phraseCountsArray.Add((Int32.Parse(cardCount) * 3).ToString());

                    if (packElement.transform.GetChild(2) != null)
                        packElement.transform.GetChild(2).GetComponent<Image>().sprite = Sprite.Create(gameAPI.cachedPackImages[i], new Rect(0.0f, 0.0f, gameAPI.cachedPackImages[i].width, gameAPI.cachedPackImages[i].height), new Vector2(0.5f, 0.5f), 100.0f);

                    packElement.name = packs.packs[i].slug;



                    packElementGameObject.Add(packElement);
                }

            }
            tempPackElement.SetActive(false);

            for (int i = 0; i < packElementGameObject.Count; i++)
            {
                var cardCountResult = gameAPI.Translate(packElement.transform.GetChild(1).name, cardCountsArray[i].ToString(), currentLanguageCode);
                packElementGameObject[i].transform.GetChild(1).GetComponent<TMP_Text>().text = cardCountResult;
                var phraseCountResult = gameAPI.Translate(packElement.transform.GetChild(3).name, phraseCountsArray[i].ToString(), currentLanguageCode);
                packElementGameObject[i].transform.GetChild(3).GetComponent<TMP_Text>().text = phraseCountResult;

            }
            didLanguageChange = false;

        }

    }
}
