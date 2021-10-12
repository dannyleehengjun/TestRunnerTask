using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Texture2D_Test_GET_PIXELS : MonoBehaviour
{
    public TMP_InputField x;
    public TMP_InputField y;
    public TextMeshProUGUI text;
    private Texture2D texture;

    // Start is called before the first frame update
    void Start()
    {
        texture = GetComponent<SpriteRenderer>().sprite.texture;
        x.text = "0";
        y.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        texture = GetComponent<SpriteRenderer>().sprite.texture;
        var colorPixels = texture.GetPixels();
        int numX;
        int numY;
        if (!int.TryParse(x.text, out numX))
        {
            x.text = "0";
        }
        else
        {
            if (numX > texture.width)
                x.text = (texture.width - 1).ToString();
            if (numX < 0)
                x.text = "0";
        }
        if(!int.TryParse(y.text, out numY))
        {
            y.text = "0";
        }
        else
        {
            if (numY > texture.width)
                y.text = (texture.height - 1).ToString();
            if (numY < 0)
                y.text = "0";
        }

        int index = int.Parse(x.text) + int.Parse(y.text)*32;
        if (index >= 0 && index < colorPixels.Length)
            text.text = "GetPixels(" + x.text + "," + y.text + ") is " + colorPixels[index].ToString();
    }
}
