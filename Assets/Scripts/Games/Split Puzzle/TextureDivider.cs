using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureDivider : MonoBehaviour
{
    [SerializeField] Texture2D textureToDivide;
    [SerializeField] List<Image> images = new List<Image>();
    [SerializeField] List<Image> hintImages = new List<Image>();
    private List<Sprite> pieces = new List<Sprite>();

    private void Start()
    {
        Divide(textureToDivide);
    }
    public List<Sprite> Divide(Texture2D texture)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Sprite newSprite = Sprite.Create(texture, new Rect(i * 128, j * 128, 128, 128), new Vector2(0.5f, 0.5f));
                pieces.Add(newSprite);
            }
        }

        for (int i = 0; i < hintImages.Count; i++)
        {
            hintImages[i].sprite = pieces[i];
        }

        for (int i = 0; i < images.Count; i++)
        {
            if (images[i].sprite == null)
            {
                var randomIndex = Random.Range(0, pieces.Count);
                var sprite = pieces[randomIndex];
                pieces.RemoveAt(randomIndex);
                images[i].sprite = sprite;
            }
        }

        return pieces;
    }
}
