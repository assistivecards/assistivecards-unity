using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSelectionPanel : MonoBehaviour
{
    GameAPI.AssistiveCardsSDK assistiveCardsSDK = new GameAPI.AssistiveCardsSDK();
    GameAPI.SettingsAPI settingsAPI = new GameAPI.SettingsAPI();
    private Image avatarButtonImage;
    private Texture2D avatarTexture;
    private Sprite sprite;
    SettingsUIManager settingsUIManager;
    [SerializeField] Canvas canvas;
    private ProfileEditor profileEditor;


    private void Awake()
    {
        settingsUIManager = canvas.GetComponent<SettingsUIManager>();
        profileEditor = this.GetComponentInParent<ProfileEditor>();
    }

    async void Start()
    {
        avatarTexture = await assistiveCardsSDK.GetAvatarImage(gameObject.name);
        sprite = Sprite.Create(avatarTexture, new Rect(0.0f, 0.0f, avatarTexture.width, avatarTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        avatarButtonImage = gameObject.GetComponent<Image>();
        avatarButtonImage.sprite = sprite;
        gameObject.GetComponent<Button>().onClick.AddListener(async () =>
        {
            settingsAPI.SetAvatarImage(gameObject.name);
            profileEditor.selectAvatarButton.image.sprite = await settingsAPI.GetAvatarImage();
        }
        );
    }
}
