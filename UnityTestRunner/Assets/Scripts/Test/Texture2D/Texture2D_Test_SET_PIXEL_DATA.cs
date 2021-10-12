using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture2D_Test_SET_PIXEL_DATA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var texture = GetComponent<SpriteRenderer>().sprite.texture;
        var dummyTexture = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        Graphics.CopyTexture(texture, dummyTexture);
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(dummyTexture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        texture = GetComponent<SpriteRenderer>().sprite.texture;
        var dummyPixelData = new Color32[texture.GetPixelData<Color32>(0).Length];

        for (int i = 0; i < dummyPixelData.Length; i++)
        {
            dummyPixelData[i] = Color.green;
        }

        texture.SetPixelData<Color32>(dummyPixelData, 0, 0);
        texture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
