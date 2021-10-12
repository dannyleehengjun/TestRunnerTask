using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class testGET_PIXEL_DATA
{
    [Test]
    public void testGET_PIXEL_DATASimplePasses()
    {
        //Getting
        //Red
        var texture = Resources.Load<Texture2D>("Textures/TrueRed");

        var pixelColor = texture.GetPixelData<Color32>(0);

        Assert.That(pixelColor, Is.All.EqualTo((Color32)Color.red));

        //MultiColor
        texture = Resources.Load<Texture2D>("Textures/MultiColor");

        pixelColor = texture.GetPixelData<Color32>(0);

        for (int i = 0; i < pixelColor.Length; i++)
        {
            //red
            if (i % 32 >= 0 && i % 32 <= 7)
                Assert.AreEqual((Color32)Color.red, pixelColor[i]);
            //green
            if (i % 32 >= 8 && i % 32 <= 15)
                Assert.AreEqual((Color32)Color.green, pixelColor[i]);
            //blue
            if (i % 32 >= 16 && i % 32 <= 23)
                Assert.AreEqual((Color32)Color.blue, pixelColor[i]);
            //white
            if (i % 32 >= 24 && i % 32 <= 27)
                Assert.AreEqual((Color32)Color.white, pixelColor[i]);
            //black
            if (i % 32 >= 28 && i % 32 <= 31)
                Assert.AreEqual((Color32)Color.black, pixelColor[i]);
        }
    }

    [UnityTest]
    public IEnumerator testGET_PIXEL_DATAWithEnumeratorPasses()
    {
        //Setting
        var texture = new Texture2D(32, 32, TextureFormat.RGBA32, true);

        var pixelColor = texture.GetPixelData<Color32>(0);
        for (int i = 0; i < pixelColor.Length; i++)
        {
            pixelColor[i] = new Color32(255, 0, 0, 255);
        }
        texture.Apply(false);
        yield return null;

        Assert.That(pixelColor, Is.All.EqualTo((Color32)Color.red));
        
    }
}
