using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarListCreator : MonoBehaviour
{
    [SerializeField] private CanvasController canvasController;
    private Image avatarButtonImage;
    private Texture2D avatarTexture;
    private Sprite sprite;
    SettingsUIManager settingsUIManager;
    [SerializeField] Canvas canvas;
    GameAPI gameAPI;

    [SerializeField] private GameObject tempAvatarElement;
    private GameObject avatarElement;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        settingsUIManager = canvas.GetComponent<SettingsUIManager>();
    }

    private async void Start() 
    {
        for(int i = 1; i< 29; i++)
        {
            if(i <= 9)
            {
                avatarElement = Instantiate(tempAvatarElement, transform);
                avatarTexture = await gameAPI.GetAvatarImage("boy0" + i);
                avatarElement.name = "boy0" + i;


                sprite = Sprite.Create(avatarTexture, new Rect(0.0f, 0.0f, avatarTexture.width, avatarTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
                avatarButtonImage = avatarElement.GetComponent<Image>();
                avatarButtonImage.sprite = sprite;

                avatarElement.GetComponent<Button>().AddEventListener("boy0" + i, SelectAvatar);    

            }
            if(i >= 10)
            {
                avatarElement = Instantiate(tempAvatarElement, transform);
                avatarTexture = await gameAPI.GetAvatarImage("boy" + i);
                avatarElement.name = "boy" + i;


                sprite = Sprite.Create(avatarTexture, new Rect(0.0f, 0.0f, avatarTexture.width, avatarTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
                avatarButtonImage = avatarElement.GetComponent<Image>();
                avatarButtonImage.sprite = sprite;

                avatarElement.GetComponent<Button>().AddEventListener("boy" + i, SelectAvatar);    
            }
        }
        Destroy(tempAvatarElement);
    }

    private async void SelectAvatar(string avatarID)
    {
        gameAPI.SetAvatarImage(avatarID);
        canvasController.profileImage.GetComponent<Image>().sprite = await gameAPI.GetAvatarImage();
    }
}
