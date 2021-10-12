using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Texture2D_Test_GET_PIXEL : MonoBehaviour
{
    public TextMeshProUGUI text;
    private Texture2D texture;

    // Start is called before the first frame update
    void Start()
    {
        texture = GetComponent<SpriteRenderer>().sprite.texture;
    }

    // Update is called once per frame
    void Update()
    {
        texture = GetComponent<SpriteRenderer>().sprite.texture;
        text.text = "GetPixel(0,0) is " + texture.GetPixel(0, 0).ToString();
    }
}
