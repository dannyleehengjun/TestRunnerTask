using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class testGET_PIXELS32
{
    [Test]
    public void testGET_PIXELS32SimplePasses()
    {
        //Red
        var texture = Resources.Load<Texture2D>("Textures/TrueRed");

        var pixelColor = texture.GetPixels32();

        Assert.That(pixelColor, Is.All.EqualTo((Color32)Color.red));

        //Green
        texture = Resources.Load<Texture2D>("Textures/TrueGreen");

        pixelColor = texture.GetPixels32();

        Assert.That(pixelColor, Is.All.EqualTo((Color32)Color.green));

        //Blue
        texture = Resources.Load<Texture2D>("Textures/TrueBlue");

        pixelColor = texture.GetPixels32();

        Assert.That(pixelColor, Is.All.EqualTo((Color32)Color.blue));

        //White
        texture = Resources.Load<Texture2D>("Textures/TrueWhite");

        pixelColor = texture.GetPixels32();

        Assert.That(pixelColor, Is.All.EqualTo((Color32)Color.white));

        //Black
        texture = Resources.Load<Texture2D>("Textures/TrueBlack");

        pixelColor = texture.GetPixels32();

        Assert.That(pixelColor, Is.All.EqualTo((Color32)Color.black));
    }
}
