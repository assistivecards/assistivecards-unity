using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DivideTest : MonoBehaviour
{
    [SerializeField] List<Texture2D> textures = new List<Texture2D>();
    [SerializeField] List<Sprite> pieces = new List<Sprite>();
    [SerializeField] List<Image> images = new List<Image>();

    void Start()
    {
        for (int i = 0; i < textures.Count; i++)
        {
            Divide(textures[i], textures[i].name);
        }
        PlaceIntoSlots();
    }

    public void Divide(Texture2D texture, string name)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                Sprite newSprite = Sprite.Create(texture, new Rect(i * 128, j * 128, 128, 256), new Vector2(0.5f, 0.5f));
                newSprite.name = name + i;
                pieces.Add(newSprite);
            }
        }
    }
    public void PlaceIntoSlots()
    {
        for (int i = 0; i < images.Count; i++)
        {
            if (images[i].sprite == null)
            {
                var randomIndex = Random.Range(0, pieces.Count);
                var sprite = pieces[randomIndex];
                pieces.RemoveAt(randomIndex);
                images[i].sprite = sprite;
                images[i].name = sprite.name;
            }
        }
    }
}
