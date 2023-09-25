using System.Collections.Generic;
using UnityEngine;

public class PacksLanguageTest : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] List<AssistiveCardsSDK.AssistiveCardsSDK.Cards> cachedCards = new List<AssistiveCardsSDK.AssistiveCardsSDK.Cards>();

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    async void Start()
    {
        await gameAPI.CachePacks();
        for (int i = 0; i < gameAPI.cachedLanguages.languages.Length; i++)
        {
            Debug.Log("checking" + " " + gameAPI.cachedLanguages.languages[i].code);

            for (int j = 0; j < gameAPI.cachedPacks.packs.Length; j++)
            {
                var cards = await gameAPI.GetCards(gameAPI.cachedLanguages.languages[i].code, gameAPI.cachedPacks.packs[j].slug);

                if (cards.cards.Length == 0)
                {
                    cachedCards.Add(cards);
                    Debug.Log("missing pack: " + gameAPI.cachedLanguages.languages[i].code + " " + gameAPI.cachedPacks.packs[j].slug);
                }
            }
        }
    }
}
