using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Texture2D_Test_APPLY : MonoBehaviour
{
    public Button btn_reset;
    public Button btn_withApply;
    public Button btn_withoutApply;

    private Sprite originalSprite;

    // Start is called before the first frame update
    void Start()
    {
        btn_reset.onClick.AddListener(ResetChanges);
        btn_withApply.onClick.AddListener(WithApply);
        btn_withoutApply.onClick.AddListener(WithoutApply);

        originalSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResetChanges()
    {
        GetComponent<SpriteRenderer>().sprite = originalSprite;
    }

    private void WithApply()
    {
        var texture = GetComponent<SpriteRenderer>().sprite.texture;
        var dummyTexture = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        Graphics.CopyTexture(texture, dummyTexture);
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(dummyTexture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        texture = GetComponent<SpriteRenderer>().sprite.texture;

        var dummyPixels = new Color[texture.GetPixels().Length];

        for (int i = 0; i < dummyPixels.Length; i++)
        {
            dummyPixels[i] = Color.green;
        }

        texture.SetPixels(dummyPixels);
        texture.Apply();
    }

    private void WithoutApply()
    {
        var texture = GetComponent<SpriteRenderer>().sprite.texture;
        var dummyTexture = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        Graphics.CopyTexture(texture, dummyTexture);
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(dummyTexture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        texture = GetComponent<SpriteRenderer>().sprite.texture;

        var dummyPixels = new Color[texture.GetPixels().Length];

        for (int i = 0; i < dummyPixels.Length; i++)
        {
            dummyPixels[i] = Color.green;
        }

        texture.SetPixels(dummyPixels);
    }
}
