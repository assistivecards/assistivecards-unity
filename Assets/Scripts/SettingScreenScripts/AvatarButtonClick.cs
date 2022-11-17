using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarButtonClick : MonoBehaviour
{
    private Image avatarButtonImage;
    private Texture2D avatarTexture;
    private Sprite sprite;
    [SerializeField] Canvas canvas;
    GameAPI gameAPI;


    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    async void Start()
    {
        avatarTexture = await gameAPI.GetAvatarImage(gameObject.name);
        sprite = Sprite.Create(avatarTexture, new Rect(0.0f, 0.0f, avatarTexture.width, avatarTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        avatarButtonImage = gameObject.GetComponent<Image>();
        avatarButtonImage.sprite = sprite;
        gameObject.GetComponent<Button>().onClick.AddListener(async () =>
        {
            gameAPI.SetAvatarImage(gameObject.name);
        }
        );
    }
}
