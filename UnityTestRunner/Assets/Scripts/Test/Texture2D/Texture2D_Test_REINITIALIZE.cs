using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texture2D_Test_REINITIALIZE : MonoBehaviour
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
        
        dummyTexture.Reinitialize(64, 64);
        dummyTexture.Apply();
        
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(dummyTexture, new Rect(0, 0, 64, 64), new Vector2(0.5f, 0.5f));
    }
}
