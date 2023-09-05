using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class AvatarListCreator : MonoBehaviour
{
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private GameObject practiceReminder;
    private Image avatarButtonImage;
    private Texture2D avatarTexture;
    private Sprite sprite;
    [SerializeField] Canvas canvas;
    GameAPI gameAPI;

    [SerializeField] private GameObject tempAvatarElement;
    private GameObject avatarElement;
    private GameObject dummyElement;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start() 
    {
        AvatarListCreate("boy", 33);
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
                    avatarTexture.wrapMode = TextureWrapMode.Clamp;
                    avatarTexture.filterMode = FilterMode.Bilinear;
                    avatarElement.name = _avatarID + "0" + i;
                    sprite = Sprite.Create(avatarTexture, new Rect(0.0f, 0.0f, avatarTexture.width, avatarTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
                    avatarButtonImage = avatarElement.GetComponent<Image>();
                    avatarButtonImage.sprite = sprite;
                    avatarElement.GetComponent<Button>().AddEventListener(_avatarID + "0" + i, SelectAvatar); 
                    avatarElement.GetComponent<AvatarSelect>().practiceReminder = practiceReminder;   
                }
                if(i >= 10)
                {
                    avatarElement = Instantiate(tempAvatarElement, transform);
                    avatarTexture = await gameAPI.GetAvatarImage(_avatarID + i);
                    avatarTexture.wrapMode = TextureWrapMode.Clamp;
                    avatarTexture.filterMode = FilterMode.Bilinear;
                    avatarElement.name = _avatarID + i;
                    sprite = Sprite.Create(avatarTexture, new Rect(0.0f, 0.0f, avatarTexture.width, avatarTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
                    avatarButtonImage = avatarElement.GetComponent<Image>();
                    avatarButtonImage.sprite = sprite;
                    avatarElement.GetComponent<Button>().AddEventListener(_avatarID + i, SelectAvatar);    
                    avatarElement.GetComponent<AvatarSelect>().practiceReminder = practiceReminder;
                }
            }
            for(int j = 0; j < 31; j++)
            {
                dummyElement = Instantiate(tempAvatarElement, transform);
                dummyElement.GetComponent<Button>().enabled = false;
                dummyElement.GetComponent<Image>().enabled = false;
            }
            ResetScroll();
        }
    }

    private void ResetScroll()
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(this.GetComponent<RectTransform>().anchoredPosition.x, 0, 0);
    }

    private async void SelectAvatar(string avatarID)
    {
        gameAPI.SetAvatarImage(avatarID);
        canvasController.profileImage.GetComponent<Image>().sprite = await gameAPI.GetAvatarImage();
    }
}
