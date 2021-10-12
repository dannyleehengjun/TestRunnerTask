using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class testGET_PIXEL
{
    [Test]
    public void testGET_PIXELSimplePasses()
    {
        //Red
        var texture = Resources.Load<Texture2D>("Textures/TrueRed");

        var pixelColor = texture.GetPixel(0,0);

        Assert.AreEqual(Color.red, pixelColor);

        //Green
        texture = Resources.Load<Texture2D>("Textures/TrueGreen");

        pixelColor = texture.GetPixel(0, 0);

        Assert.AreEqual(Color.green, pixelColor);

        //Blue
        texture = Resources.Load<Texture2D>("Textures/TrueBlue");

        pixelColor = texture.GetPixel(0, 0);

        Assert.AreEqual(Color.blue, pixelColor);

        //White
        texture = Resources.Load<Texture2D>("Textures/TrueWhite");

        pixelColor = texture.GetPixel(0, 0);

        Assert.AreEqual(Color.white, pixelColor);

        //Black
        texture = Resources.Load<Texture2D>("Textures/TrueBlack");

        pixelColor = texture.GetPixel(0, 0);

        Assert.AreEqual(Color.black, pixelColor);
    }
}
