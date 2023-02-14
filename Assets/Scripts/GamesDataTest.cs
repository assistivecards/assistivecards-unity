using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamesDataTest : MonoBehaviour
{
    private GameAPI gameAPI;
    [SerializeField] TMPro.TMP_InputField games;
    [SerializeField] TMPro.TMP_InputField gameSlugInputField;
    [SerializeField] RawImage gameIcon;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }
    async void Start()
    {
        await gameAPI.CacheData();
        for (int i = 0; i < gameAPI.cachedGames.games.Count; i++)
        {
            games.text += gameAPI.cachedGames.games[i].slug + "\n";
        }
    }

    public void OnFetchButtonClick()
    {
        DisplayGameIcon(gameSlugInputField.text);
    }

    public async void DisplayGameIcon(string gameSlug)
    {
        var texture = await gameAPI.GetGameIcon(gameSlug);
        gameIcon.texture = texture;
    }


}
