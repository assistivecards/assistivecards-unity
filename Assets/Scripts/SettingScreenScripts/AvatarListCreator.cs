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

    private void Start() 
    {
        AvatarListCreate("misc", 29);
    }

    public void GirlButtonClicked()
    {
        foreach (Transform child in transform) 
        {
            GameObject.Destroy(child.gameObject);
        }

        AvatarListCreate("girl", 27);
    }

    public void BoyButtonClicked()
    {
        foreach (Transform child in transform) 
        {
            GameObject.Destroy(child.gameObject);
        }
        
        AvatarListCreate("boy", 33);
    }
    public void MiscButtonClicked()
    {
        foreach (Transform child in transform) 
        {
            GameObject.Destroy(child.gameObject);
        }
        
        AvatarListCreate("misc", 29);
    }

    private async void AvatarListCreate(string _avatarID, int _avatarListLenght)
    {
        if(tempAvatarElement != null)
        {
            for(int i = 1; i<= _avatarListLenght; i++)
            {
                if(i <= 9)
                {
                    avatarElement = Instantiate(tempAvatarElement, transform);
                    avatarTexture = await gameAPI.GetAvatarImage(_avatarID + "0" + i);
                    avatarElement.name = _avatarID + "0" + i;


                    sprite = Sprite.Create(avatarTexture, new Rect(0.0f, 0.0f, avatarTexture.width, avatarTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
                    avatarButtonImage = avatarElement.GetComponent<Image>();
                    avatarButtonImage.sprite = sprite;

                    avatarElement.GetComponent<Button>().AddEventListener(_avatarID + "0" + i, SelectAvatar);    

                }
                if(i >= 10)
                {
                    avatarElement = Instantiate(tempAvatarElement, transform);
                    avatarTexture = await gameAPI.GetAvatarImage(_avatarID + i);
                    avatarElement.name = _avatarID + i;


                    sprite = Sprite.Create(avatarTexture, new Rect(0.0f, 0.0f, avatarTexture.width, avatarTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
                    avatarButtonImage = avatarElement.GetComponent<Image>();
                    avatarButtonImage.sprite = sprite;

                    avatarElement.GetComponent<Button>().AddEventListener(_avatarID + i, SelectAvatar);    
                }
            }
        }
    }

    private async void SelectAvatar(string avatarID)
    {
        gameAPI.SetAvatarImage(avatarID);
        canvasController.profileImage.GetComponent<Image>().sprite = await gameAPI.GetAvatarImage();
    }
}
