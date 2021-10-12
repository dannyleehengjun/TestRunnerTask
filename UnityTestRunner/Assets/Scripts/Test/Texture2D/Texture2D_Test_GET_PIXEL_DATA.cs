using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texture2D_Test_GET_PIXEL_DATA : MonoBehaviour
{
    public Button btn_ApplyChange;

    // Start is called before the first frame update
    void Start()
    {
        btn_ApplyChange.onClick.AddListener(ApplyChange);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void ApplyChange()
    {
        var texture = GetComponent<SpriteRenderer>().sprite.texture;
        var dummyTexture = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        Graphics.CopyTexture(texture, dummyTexture);
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(dummyTexture, new Rect(0,0,texture.width,texture.height),new Vector2(0.5f,0.5f));

        var pixelColor = dummyTexture.GetPixelData<Color32>(0);
        for (int i = 0; i < pixelColor.Length; i++)
        {
            pixelColor[i] = new Color32(0, 255, 0, 255);
        }
        dummyTexture.Apply(false);
    }
}
