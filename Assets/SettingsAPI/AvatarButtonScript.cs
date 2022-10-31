using UnityEngine;
using UnityEngine.UI;

public class AvatarButtonScript : MonoBehaviour
{
    GameAPI.AssistiveCardsSDK assistiveCardsSDK = new GameAPI.AssistiveCardsSDK();
    GameAPI.SettingsAPI settingsAPI = new GameAPI.SettingsAPI();
    private Image avatarButtonImage;
    private Texture2D avatarTexture;
    private Sprite sprite;
    SettingsUIManager settingsUIManager;
    [SerializeField] Canvas canvas;


    private void Awake()
    {
        settingsUIManager = canvas.GetComponent<SettingsUIManager>();
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
            settingsUIManager.selectAvatarButton.image.sprite = await settingsAPI.GetAvatarImage();
        }
        );
    }



}
